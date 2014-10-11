using UnityEngine;
using System.Collections;
using System;

namespace NetEngine
{
    public static class MethodExtend
    {

        public static int ToInt32(this object obj)
        {
            return Convert.ToInt32(obj);
        }

        public static bool ToBool(this object obj)
        {
            return Convert.ToBoolean(obj);
        }

        public static T Tot<T>(this object obj)
        {
            return (T)obj;
        }
    }
}
