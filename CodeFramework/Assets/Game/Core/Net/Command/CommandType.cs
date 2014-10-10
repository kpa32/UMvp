using UnityEngine;
using System.Collections.Generic;
using System;
using System.Reflection;

namespace NetEngine.Command
{
    public class CommandType
    {
        private static Dictionary<string, Type> _types;
        private const string _namespace = "NetEngine.Command.{0}";

        private static Assembly _ass;
        static CommandType()
        {
            _types = new Dictionary<string, Type>();
            _ass=Assembly.GetAssembly(typeof(ICommand));
        }


        public static Type FindCmdType(string key)
        {
            if (string.IsNullOrEmpty(key))
            { 
                throw new Exception();
            }
            if (_types.ContainsKey(key))
            {
                return _types[key];
            }
            else
            {

                Type t = Types.GetType(string.Format(_namespace, key), _ass.FullName);
                if (t != null)
                {
                    _types.Add(key, t);
                    return _types[key];
                }
                else {
                    throw new Exception("not find type");
                }
            }
        }
    }
}
