using UnityEngine;
using System.Collections.Generic;

namespace Game
{
    public class SignalManager
    {

        private static Dictionary<uint, object> _signals;

        static SignalManager()
        {
            _signals = new Dictionary<uint, object>();
            
        }

        /// <summary>
        /// 添加信号，如果没有则反回默认值，
        /// 如果有则反值，并将信号至为deafult(T)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static T DeSignal<T>(uint msg) where T:new()
        {
            if (_signals.ContainsKey(msg))
            {
                T t = (T)_signals[msg];
                _signals[msg] = default(T);
                return t;
            }
            else {
                return default(T);
            }
        }

        public static void EnSignal<T>(uint msg,T sig) where T : new()
        {
            _signals[msg] = sig;
        }
        
    }
}
