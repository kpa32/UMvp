using UnityEngine;
using System.Collections;

namespace Game
{
    public class SourceManager
    {
        public const string ItemPath = "Textures/Item/";

        public const string StateItemPath = "Textures/StateItem/";

        


        public static Texture2D LoadTexture(string icon, string path = ItemPath)
        {
			Texture2D txt = Resources.Load(path+icon, typeof(Texture2D)) as Texture2D;
            
            if (txt == null)
                Debug.LogError("Icon:" + icon + " Path:" + path);
            return txt;
        }

        public static Sprite LoadSprite(string icon, string path = ItemPath)
        {
            Sprite txt = Resources.Load(path + icon, typeof(Sprite)) as Sprite;

            if (txt == null)
                Debug.LogError("Icon:" + icon + " Path:" + path);
            return txt;
        }
    }
}
