using System.Xml;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Game
{
    /// <summary>
    /// 游戏配置类
    /// </summary>
    public sealed class GameSetting
    {
        //不同平台下StreamingAssets的路径是不同的，这里需要注意一下。

        public static readonly string PathURL =

#if UNITY_ANDROID   //安卓

 "jar:file://" + Application.dataPath + "!/assets/";

#elif UNITY_IPHONE  //iPhone

Application.dataPath + "/Raw/";

#elif UNITY_STANDALONE_WIN || UNITY_EDITOR  //windows平台和web平台

"file://" + Application.dataPath + "/StreamingAssets/";

#else

string.Empty;

#endif

        private static GameSetting _instance;

        public static GameSetting Appsettings
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameSetting();
                }
                return GameSetting._instance;
            }
        }

        private GameSetting()
        {
            _configs = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            this.LoadConfig();
        }

        private Dictionary<string, string> _configs;

        public string this[string key]
        {
            get
            {
                if (_configs.ContainsKey(key))
                {
                    return _configs[key];
                }
                return string.Empty;
            }
            set
            {
                if (_configs.ContainsKey(key))
                {
                    _configs[key] = value;
                }
            }
        }

        private const string CONFIG_PATH = "Config";
        private void LoadConfig()
        {
            try
            {
                TextAsset text = Resources.Load(CONFIG_PATH, typeof(TextAsset)) as TextAsset;
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(text.text);

                var xmlList = doc.DocumentElement.SelectSingleNode("//appSettings");

                foreach (XmlNode node in xmlList.ChildNodes)
                {
                    if (!node.Name.Equals("#comment"))
                    {
                        string key = node.Attributes["key"].Value;
                        string value = node.Attributes["value"].Value;
                        _configs[key] = value;
                    }
                }

                Resources.UnloadAsset(text);
            }
            catch (Exception ex)
            {
                throw new Exception("Not Find Game Config!", ex);
            }

        }

        public void SaveChange()
        {
            TextAsset text = Resources.Load(CONFIG_PATH, typeof(TextAsset)) as TextAsset;
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(text.text);

            var xmlList = doc.DocumentElement.SelectSingleNode("//appSettings");

            foreach (XmlNode node in xmlList.ChildNodes)
            {
                if (!node.Name.Equals("#comment"))
                {
                    string key = node.Attributes["key"].Value;
                    node.Attributes["value"].Value = _configs[key];
                }
            }

            Resources.UnloadAsset(text);
        }
    }
}
