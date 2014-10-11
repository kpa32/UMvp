using System;
using System.Collections.Generic;
using UMvp.Interfaces;

namespace UMvp.Core
{
    public sealed class G:IGate
    {
        private static G _instance;

        public static G Instance
        {
            get {
                if (_instance == null) _instance = new G();
                return G._instance; 
            }
        }

        private Dictionary<string, IPresenter> _presenterMap;
        private List<IUpdate> _presenterUpdateMap;
        private Dictionary<string, IModelProxy> _modelProxyMap;
        private G()
        {
            _presenterMap = new Dictionary<string, IPresenter>();
            _modelProxyMap = new Dictionary<string, IModelProxy>();
            _presenterUpdateMap = new List<IUpdate>();
        }

        public void ExuteUpdate()
        {
            foreach (var item in _presenterUpdateMap)
            {
                item.Update();
            }
        }

        public static void Send(string messageId)
        {
            Send(messageId, null);
        }
        public static void Send(string messageId,object body)
        {
            Dictionary<string, IPresenter> _map = Instance._presenterMap;
            
            foreach (var key in new List<string>(_map.Keys))
            {
                if (_map[key].Methods.ContainsKey(messageId))
                {
                    _map[key].Methods[messageId](body);
                }
            }
        }

        public static void Action<TPresenter>(Action<TPresenter> method)where TPresenter:class,IPresenter
        {
            string typeName=typeof(TPresenter).Name;
            if (Instance._presenterMap.ContainsKey(typeName))
            {
                TPresenter t = Instance._presenterMap[typeName] as TPresenter;
                method(t);
            }
        }

        public static void RegeisterPresenter(IPresenter presenter)
        {
            if (!Instance._presenterMap.ContainsKey(presenter.GetType().Name))
            {
                presenter.RegeisterMethod();
                Instance._presenterMap.Add(presenter.GetType().Name, presenter);
                if (presenter is IUpdate)
                {
                    Instance._presenterUpdateMap.Add(presenter as IUpdate);
                }
                
            }
        }

        public static void RemovePresenter(string presenterName)
        {
            if (Instance._presenterMap.ContainsKey(presenterName))
            {
                IPresenter presenter=Instance._presenterMap[presenterName];

                if (presenter is IUpdate)
                {
                    Instance._presenterUpdateMap.Remove(presenter as IUpdate);
                }

                Instance._presenterMap.Remove(presenterName);

                
            }
        }

        public static void RegeisterProxy(IModelProxy proxy)
        {
            if (!Instance._modelProxyMap.ContainsKey(proxy.GetType().Name))
            {
                Instance._modelProxyMap.Add(proxy.GetType().Name, proxy);
            }
        }

        public static void RemoveProxy(Type proxyType)
        {
            if (Instance._modelProxyMap.ContainsKey(proxyType.Name))
            {
                Instance._modelProxyMap.Remove(proxyType.Name);
            }
        }

        public static TProxy RetrieveProxy<TProxy>() where TProxy :class,IModelProxy
        {
            string name=typeof(TProxy).Name;
            if (Instance._modelProxyMap.ContainsKey(name))
            {
                return Instance._modelProxyMap[name] as TProxy;
            }
            return default(TProxy);
        }
    }
}
