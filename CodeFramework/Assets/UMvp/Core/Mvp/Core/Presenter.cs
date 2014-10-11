using System;
using System.Collections.Generic;
using UMvp.Interfaces;

namespace UMvp.Core
{
    public abstract class Presenter<TView>:IPresenter<TView> where TView:class,IView
    {
        protected TView _view;

        public Presenter(TView view)
        {
            _view = view;
            _methods = new Dictionary<string, Action<object>>();
        }

        protected Action<object> this[string methodName]
        {
            get { return null; }
             set {
                _methods[methodName] = value;
            }
        }

        

        public abstract void RegeisterMethod();

        private Dictionary<string, Action<object>> _methods;
        public Dictionary<string, Action<object>> Methods
        {
            get { return _methods; }
        }


        public void View()
        {
            _view.UpdateView();
        }

        public void View(Action<TView> method) 
        {
            method(_view as TView);
        }



        public void SetMethod(string name, Action<object> method)
        {
            _methods[name] = method;
        }
    }
}
