using UnityEngine;
using System.Collections;
using System;

namespace Game
{
    public class SceneManager
    {
        private static SceneManager _instance;

        public static SceneManager Instance
        {
            get {
                if (_instance == null)
                    _instance = new SceneManager();
                return SceneManager._instance; 
            }
        }

        private IScene _scene;
        public SceneManager()
        {
            _scene = null;
        }

        public void Initial()
        {
            if (_scene == null)
                ChangeScene(new LoginScene());

        }

        public void Update()
        {
            if (_scene!=null)
            {
                _scene.Update();
                UMvp.Core.G.Instance.ExuteUpdate();
            }
        }

        public void ChangeScene(IScene scene)
        {
            
            if (_scene == null)
            {
                _scene = scene;
                _scene.Initial();
                _scene.Load();
            }
            else {
                _scene.UnLoad();
                _scene.Exit();
                _scene = scene;
                _scene.Initial();
                _scene.Load();
            }

        }

        public bool IsTypeScene(Type type)
        {
            if (_scene.GetType().Name.Equals(type.Name))
                return true;
            return false;
        }
    }
}
