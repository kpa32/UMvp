using System;
using System.Collections.Generic;

namespace NetEngine
{
    public class ParamsValue
    {
        private Dictionary<string, object> _hash;
        public ParamsValue()
        {
            _hash = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        }


        public object this[string key]
        {
            get
            {
                if (_hash.ContainsKey(key))
                {
                    return _hash[key];
                }
                throw new NullReferenceException();
            }
            set {
                if (_hash.ContainsKey(key))
                {
                    _hash[key] = value;
                }
                else {
                    _hash.Add(key, value);
                }
            }
        }
    }

    
}
