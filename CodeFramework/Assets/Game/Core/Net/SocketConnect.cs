using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;

namespace NetEngine
{
    public class SocketConnect
    {

        private Socket _socket;
        private readonly string _host;
        private readonly int _port;
        private Thread _thread = null;
        private NetThread _netview;
        public SocketConnect(string host, int port)
        {
            this._host = host;
            this._port = port;
        }



        /// <summary>
        /// 打开连接
        /// </summary>
        public void Open()
        {
            UnityEngine.NetworkReachability state = UnityEngine.Application.internetReachability;
            if (state != UnityEngine.NetworkReachability.NotReachable)
            {
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    _socket.Connect(_host, _port);
                }
                catch
                {
                    //socket.Dispose();
                    _socket = null;
                    throw;
                }
                _netview = CreateThread();

                _thread = new Thread(new ThreadStart(CheckReceive));
                _thread.Start();


            }

        }

        private NetThread CreateThread()
        {
            GameObject obj = GameObject.Find("_net");
            if (obj)
            {
                return obj.GetComponent<NetThread>();
            }
            else {
                GameObject go = new GameObject("_net");
                return go.AddComponent<NetThread>();
            }
        }

        /// <summary>
        /// 关闭连接
        /// </summary>
        public void Close()
        {
            if (_socket == null) return;
            try
            {
                lock (this)
                {
                    _socket.Shutdown(SocketShutdown.Both);
                    _socket.Close();
                    _socket = null;

                    _thread.Abort();
                    _thread = null;


                }
            }
            catch (Exception)
            {
                _socket = null;
            }
        }

        private void CheckReceive()
        {
            while (true)
            {
                if (_socket == null) return;
                try
                {
                    if (_socket.Poll(5, SelectMode.SelectRead))
                    {
                        if (_socket.Available == 0)
                        {
                            Debug.Log("Close Socket");
                            Close();
                            break;
                        }
                        byte[] prefix = new byte[DefaultReceiveFilter.HeadLength];
                        int recnum = _socket.Receive(prefix);

                        if (recnum == DefaultReceiveFilter.HeadLength)
                        {
                            int datalen = DefaultReceiveFilter.PasreBodyLength(prefix);
                            byte[] data = new byte[datalen];
                            int startIndex = 0;
                            recnum = 0;
                            do
                            {
                                int rev = _socket.Receive(data, startIndex, datalen - recnum, SocketFlags.None);
                                recnum += rev;
                                startIndex += rev;
                            } while (recnum != datalen);

                            _netview.Enqueue(DefaultReceiveFilter.PasreData(prefix,data));
                        }

                    }
                    else if (_socket.Poll(5, SelectMode.SelectError))
                    {
                        Close();
                        UnityEngine.Debug.Log("SelectError Close Socket");
                        break;

                    }
                }
                catch (Exception ex)
                {
                    UnityEngine.Debug.Log("catch" + ex.ToString());

                }

                Thread.Sleep(5);

            }

        }

        private void EnsureConnected()
        {
            if (_socket == null)
            {
                Open();
            }

        }

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="data"></param>
        public bool PostSend(byte[] data)
        {
            EnsureConnected();
            if (_socket != null)
            {

                IAsyncResult asyncSend = _socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(sendCallback), _socket);
                bool success = asyncSend.AsyncWaitHandle.WaitOne(5000, true);
                if (!success)
                {
                    Debug.LogError("asyncSend error close socket");
                    Close();
                    return false;
                }
                return true;
            }
            return false;

        }
        private void sendCallback(IAsyncResult asyncSend)
        {
        }

    }
}

