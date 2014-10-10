using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
namespace NetEngine
{
    public class DefaultReceiveFilter
    {
        public static int HeadLength
        {
            get {
                return 6;
            }
        }


        public static int PasreBodyLength(byte[] head)
        {
            return BitConverter.ToUInt16(head, 4);
        }

        public static NetProtocol PasreData(byte[] head, byte[] body)
        {
            string key = Encoding.UTF8.GetString(head, 0, 4);
            var data = JsonConvert.DeserializeObject<JsonObject>(Encoding.UTF8.GetString(body));
            
            return new NetProtocol(key,data);
        }

        public static byte[] PasreData(NetProtocol data)
        {
            List<byte> bs = new List<byte>();

            //1.add head
            bs.AddRange(Encoding.UTF8.GetBytes(data.Key));

            //2.add leangth
            string json = JsonConvert.SerializeObject(data.Body);

            byte[] jsData = Encoding.UTF8.GetBytes(json);

            ushort len=(ushort)jsData.Length;

            bs.AddRange(BitConverter.GetBytes(len));

            bs.AddRange(jsData);

            return bs.ToArray();
        }
        
    }
}
