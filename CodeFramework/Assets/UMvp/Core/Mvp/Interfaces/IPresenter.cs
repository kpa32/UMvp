using System;
using System.Collections.Generic;


namespace UMvp.Interfaces
{
    public interface IPresenter
    {
        Dictionary<string, Action<object>> Methods { get; }
        void RegeisterMethod();
        void SetMethod(string name, Action<object> method);
    }
    public interface IPresenter<TView> : IPresenter where TView : class,IView
    {
        void View();
        void View(Action<TView> method);   
    }
}
