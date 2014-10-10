using UnityEngine;
using System.Collections.Generic;

namespace Game
{
   

    public class UIManager 
    {
        private static readonly string LocalPath = GameSetting.Appsettings["UIPath"];
        private static readonly string LocalRoot = GameSetting.Appsettings["UIRoot"];
        private static UIManager _instance;

        private static UIManager Instance
        {
            get {
                if (_instance == null)
                    _instance = new UIManager();
                return UIManager._instance;
            }
        }

        private Dictionary<UIName, GameObject> _activeUI;   //激活的UI
        private Stack<UIName> _activeQueue;                 //UI队列
        private Dictionary<UIName, GameObject> _globalUI;   //全局激活UI
        private UIManager()
        {
            _activeUI = new Dictionary<UIName, GameObject>();
            _activeQueue = new Stack<UIName>();
            _globalUI = new Dictionary<UIName, GameObject>();
        }

        private UIPath FindPath(string ui)
        {
            List<UIPath> paths = ConfigManager.FindList<UIPath>(ConfigManager.PathName<DatareadUIPath>());
            foreach (UIPath path in paths)
            {
                if (path.Name.Equals(ui))
                {
                    return path;
                }
            }
            return null;
        }



        private GameObject CreateGameObject(UIPath path)
        {
            GameObject preObj = Resources.Load(LocalPath + path.Path
                        , typeof(GameObject)) as GameObject;

            GameObject obj = GameObject.Instantiate(preObj) as GameObject;

            GameObject root=GameObject.Find(LocalRoot);
            obj.transform.parent = root.transform;
            obj.transform.localPosition = path.Position;
            obj.transform.localRotation = Quaternion.identity;
            obj.transform.localScale = Vector3.one;
            obj.name = path.Name;
            obj.GetComponent<UIPanel>().depth = path.Depth;
            return obj;
        }

        public static void OpenUI(UIName ui)
        { 
            //1.检查是否重复打开
            if (!Instance._activeUI.ContainsKey(ui))
            {
				string name=ui.ToString();
                UIPath path=Instance.FindPath(name);
                if (path!= null)
                {
                    GameObject obj=Instance.CreateGameObject(path);
                    Instance._activeUI.Add(ui, obj);
                    Instance._activeQueue.Push(ui);
                }
            }
            else {
                Debug.LogError("重复调用打开UI" + ui.ToString());
            }
        }

        public static void OpenGlobalUI(UIName ui)
        {
            //1.检查是否重复打开
            if (!Instance._globalUI.ContainsKey(ui))
            {
                string name = ui.ToString();
                UIPath path = Instance.FindPath(name);
                if (path != null)
                {
                    GameObject obj = Instance.CreateGameObject(path);
                    Instance._globalUI.Add(ui, obj);
                }
            }
            else
            {
                Debug.LogError("重复调用打开UI" + ui.ToString());
            }
        }

        public static void CloseGlobalUI(UIName ui)
        {
            //1.检查是否以打开
            if (Instance._globalUI.ContainsKey(ui))
            {
                GameObject obj = Instance._globalUI[ui];
                GameObject.Destroy(obj);
                Instance._globalUI.Remove(ui);
            }
            else
            {
                Debug.LogWarning("UI不存在" + ui.ToString());
            }  
        }
        public static bool ExistGlobalUI(UIName ui)
        {
            return Instance._globalUI.ContainsKey(ui);
        }

        public static bool ExistUI(UIName ui)
        {
            return Instance._activeUI.ContainsKey(ui);
        }


        public static void CleraUI()
        {
            List<UIName> _list = new List<UIName>();
            foreach (UIName key in _instance._activeUI.Keys)
            {
                _list.Add(key);
            }
            foreach (var item in _list)
            {
                CloseUI(item);
            }
            _list = null;
            _instance._activeQueue.Clear();
        }

        public static void CloseUI(UIName ui)
        { 
            //1.检查是否以打开
            if (Instance._activeUI.ContainsKey(ui))
            {
                GameObject obj = Instance._activeUI[ui];
                GameObject.Destroy(obj);
                Instance._activeUI.Remove(ui);
                Instance._activeQueue.Pop();
            }
            else
            {
                Debug.LogWarning("UI不存在" + ui.ToString());
            }  
        }

        public static void BackUI()
        {
            if (Instance._activeQueue.Count>1)
            {
                CloseUI(Instance._activeQueue.Peek());
            }
        }

    }
}