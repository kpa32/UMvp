using UnityEngine;
using System.Collections;
using Newtonsoft.Json;


namespace NetEngine
{

    public class NetProtocol
    {
        public string Key { get; set; }

        public JsonObject Body { get; set; }

        public NetProtocol()
        {

        }

        public NetProtocol(string key, JsonObject body)
        {
            this.Key = key;
            this.Body = body;
        }
    }
}
