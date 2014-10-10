using UnityEngine;
using System.Xml;
using System.Collections.Generic;

namespace Game
{
    public abstract class DatareadBase
    {
        public abstract string PathName();

        public DatareadBase()
        {

        }

        public void ReadXml()
        {
            TextAsset text = Resources.Load(GameSetting.Appsettings["ConfigPath"] + PathName(), typeof(TextAsset)) as TextAsset;
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(text.text);
            FilterXml(doc, doc.FirstChild);
            Resources.UnloadAsset(text);
            text = null;
            doc = null;


        }
        protected abstract void FilterXml(XmlDocument doc, XmlNode root);

        protected void AddData(IConfigVo<int> vo)
        {
            ConfigManager.Instance.AddData(PathName(), vo);
        }

        protected void AddData(IConfigVo<string> vo)
        {
            ConfigManager.Instance.AddData(PathName(), vo);
        }
    }
}