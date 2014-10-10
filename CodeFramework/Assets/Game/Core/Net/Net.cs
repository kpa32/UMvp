using UnityEngine;
using System.Collections;
using System;
using System.Text;
using NetEngine;
using NetEngine.Command;
namespace Game
{
    public sealed class Net
    {
        private SocketConnect _socket;

        private static Net _instance;

        private static Net Instance
        {
            get {
                if (_instance == null) _instance = new Net();
                return _instance;
            }
        }

        private Net()
        { 
            
        }

        private void StartSocket(string host, string port)
        {
            if (_socket==null)
            {
               _socket=new SocketConnect(host,int.Parse(port));
            }
        }

        public static void CloseSocket()
        {
            if (Instance._socket != null)
            {
                Instance._socket.Close();
                Instance._socket = null;
            }
            
        }

        public static void SetAddres(string host, string port)
        {
            Instance.StartSocket(host, port);
        }

        public static void Send(string msg)
        {
            Instance._socket.PostSend(Encoding.UTF8.GetBytes(msg));
        }

        public static void Send<Command>() where Command : ICommand,new()
        {
            Send<Command>(null);
        }
        public static void Send<Command>(ParamsValue values) where Command : ICommand, new()
        {
            Command cmd = new Command();
            cmd.SendParams(values);
            string key = cmd.GetType().Name;
            NetProtocol data = new NetProtocol();
            data.Key = key;
            data.Body = cmd.SendData;
            Instance._socket.PostSend(DefaultReceiveFilter.PasreData(data));
        }
        
    }
}
