using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetEngine
{
    /// <summary>
    /// Params Values Manager
    /// </summary>
    public class Pvm
    {
        private static ParamsValue _current;

        public static ParamsValue Current
        {
            get { return Pvm._current; }
        }

        public static ParamsValue Bind(ParamsValue paramvalue)
        {
            _current = paramvalue;
            return Current;
        }

        /// <summary>
        /// <para>自动绑定K/v结构,个数必须为2的次幂</para>
        /// <para>并创建一个ParamsValue,绑定到当前Pvm</para>
        /// </summary>
        /// <param name="args">动态参数,K,V,K,V....</param>
        /// <returns>ParamsValue</returns>
        public static ParamsValue News(params object[] args)
        {
            int pl = args.Length % 2;
            if (pl != 0)
            {
                throw new Exception("PVM 参数匹配不正确");
            }
            ParamsValue pv = new ParamsValue();
            for (int i = 0; i < args.Length; i += 2)
            {
                pv[args[i].ToString()] = args[i + 1];
            }
            Bind(pv);
            return pv;
        }

    }
    public class Pvm<TValue> : Pvm
    {
        public static TValue Key(string key)
        {
            return (TValue)Current[key];
        }
    }
}
