using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using NetEngine.Command;
using Game;

namespace NetEngine
{
    public class NetThread : MonoBehaviour
    {
        private Queue<NetProtocol> _queue;

        private void Awake()
        {
            _queue = new Queue<NetProtocol>();
        }

        public void Enqueue(NetProtocol data)
        {
            lock (_queue)
            {
                _queue.Enqueue(data);
            }
        }

        private void Start()
        { 
            
        }

        private void Update()
        {
            lock (_queue)
            {
                if (_queue.Count>0)
                {
                    NetProtocol data=_queue.Dequeue();

                    Type type=CommandType.FindCmdType(data.Key);

                    ICommand cmd = Activator.CreateInstance(type) as ICommand;

                    cmd.ReceiveExcute(data);
                }
            }
        }

        private void OnApplicationQuit()
        {
            Debug.Log("game exit!");
            Net.CloseSocket();
        }

    }
}