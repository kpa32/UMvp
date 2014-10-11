using UnityEngine;
using System.Collections;
using Newtonsoft.Json;

namespace NetEngine.Command
{
    public abstract class ICommand
    {
        public JsonObject SendData { get; protected set; }

        

        public ICommand()
        {
            SendData = new JsonObject();

            
        }

        protected object this[string key]
        {
            set {
                SendData.Add(key, value.ToString());
            }
        }

        public abstract void SendParams(ParamsValue values);

        public abstract void ReceiveExcute(NetProtocol rev);

        
    }
}
