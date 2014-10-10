using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace Game
{
    public class ConfigManager
    {
        private Dictionary<string, List<object>> _data;

        private ConfigManager()
        {
            _data = new Dictionary<string, List<object>>();
        }

        static private ConfigManager _instance;

        static public ConfigManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ConfigManager();
                return ConfigManager._instance;
            }
        }


        /// <summary>
        /// 读取本地配置表
        /// </summary>
        /// <typeparam name="TDatareadBase"></typeparam>
        static public void Initial<TDatareadBase>() where TDatareadBase : DatareadBase, new()
        {
            TDatareadBase data = new TDatareadBase();
            data.ReadXml();
        }

        /// <summary>
        /// 获取读取器的路径
        /// </summary>
        /// <typeparam name="TDatareadBase"></typeparam>
        /// <returns></returns>
        static public string PathName<TDatareadBase>() where TDatareadBase : DatareadBase, new()
        {
            return new TDatareadBase().PathName();
        }


        /// <summary>
        /// 添加读取的数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        public void AddData(string key, object data)
        {
            if (_data.ContainsKey(key))
            {
                _data[key].Add(data);
            }
            else
            {
                _data.Add(key, new List<object> { data });
            }
        }


        /// <summary>
        /// 查找数据
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="key">数据源路径</param>
        /// <returns></returns>
        static public List<T> FindList<T>(string key) where T : class
        {
            if (Instance._data.ContainsKey(key))
            {
                return Instance._data[key].ConvertAll<T>(o => o as T);
            }
            else
            {
#if UNITY_EDITOR
                throw new Exception(string.Format("没有找到配置数据:ConfigName:{0}", key));
#endif
            }
        }

        /// <summary>
        /// 查找数据
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="key">数据源路径</param>
        /// <param name="id">数据Key</param>
        /// <returns></returns>
        static public T FindVo<T>(string key, int id)
        {
            List<IConfigVo<int>> data = FindList<IConfigVo<int>>(key);
            foreach (var item in data)
            {
                if (item.Primarykey == id)
                {
                    if (item is T)
                        return (T)item;
                    else
                    {
#if UNITY_EDITOR
                        throw new Exception(string.Format("没有找到配置数据:ConfigName:{0},Key:{1}", key, id));
#endif
                        return default(T);
                    }
                }

            }
#if UNITY_EDITOR
            throw new Exception(string.Format("没有找到配置数据:ConfigName:{0},Key:{1}", key, id));
#endif
            return default(T);
        }

        static public T FindVo<T>(string key, string id)
        {
            List<IConfigVo<string>> data = FindList<IConfigVo<string>>(key);
            foreach (var item in data)
            {
                if (item.Primarykey.Equals(id))
                {
                    if (item is T)
                        return (T)item;
                    else
                    {
#if UNITY_EDITOR
                        throw new Exception(string.Format("没有找到配置数据:ConfigName:{0},Key:{1}", key, id));
#endif
                        return default(T);
                    }
                }

            }
#if UNITY_EDITOR
            throw new Exception(string.Format("没有找到配置数据:ConfigName:{0},Key:{1}", key, id));
#endif
            return default(T);
        }

        static public T FindVo<TDatareadBase, T>(int id) where TDatareadBase : DatareadBase, new()
        {
            return FindVo<T>(PathName<TDatareadBase>(), id);
        }

        static public T FindVo<TDatareadBase, T>(string id) where TDatareadBase : DatareadBase, new()
        {
            return FindVo<T>(PathName<TDatareadBase>(), id);
        }

    }
}
