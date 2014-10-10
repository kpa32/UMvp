using System;
using System.Collections.Generic;
using UnityEngine;
using UMvp.Interfaces;

namespace UMvp.Core
{
    public abstract class View : MonoBehaviour, IView
    {
        public void OnEnable()
        {
            G.RegeisterPresenter(RegeisterPersenter());
        }

        public void OnDisable()
        {
            G.RemovePresenter(RemovePersenter());
        }

        public virtual void UpdateView()
        {

        }

        public abstract IPresenter RegeisterPersenter();

        public abstract string RemovePersenter();

        #region Help
        public T F<T>(string path = null) where T : Component
        {
            if (path == null)
            {
                return transform.GetComponent<T>();
            }
            else
            {
                return transform.Find(path).GetComponent<T>();
            }
        }
        public GameObject F(string path)
        {
            return transform.Find(path).gameObject;
        }

        public T F<T>(GameObject tag, string path = null) where T : Component
        {
            if (path == null)
            {
                return tag.transform.GetComponent<T>();
            }
            else
            {
                return tag.transform.Find(path).GetComponent<T>();
            }
        }
        public GameObject F(GameObject tag, string path)
        {
            return tag.transform.Find(path).gameObject;
        }
        #endregion

        
    }
}
