using UnityEngine;
using System.Collections.Generic;
using System.Xml;

namespace Game
{
    public class DatareadUIPath:DatareadBase
    {

        protected override void FilterXml(System.Xml.XmlDocument doc, XmlNode root)
        {
            

            foreach (XmlNode item in root.ChildNodes)
            {
                UIPath vo = new UIPath();
				foreach (XmlAttribute attr in item.Attributes)
                {
                    string value = attr.Value;
                    switch (attr.Name)
                    {
                        case "Name":
                            vo.Name = value;
                            break;
                        case "Depth":
                            vo.Depth = int.Parse(value);
                            break;
                        case "Path":
                            vo.Path = value;
                            break;
                        case "Position":
                            string[] sps=value.Split(',');
                            vo.Position = new Vector3(
                                int.Parse(sps[0]),
                                int.Parse(sps[1]),
                                int.Parse(sps[2]));
                            break;
                        default:
                            break;
                    }
                }
                base.AddData(vo);
            }
            
        }


        public override string PathName()
        {
            return "UIPath"; 
        }
    }
}
