using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UMvp.Interfaces
{
    public interface IModelProxy
    {
        void NotifyUpdate();
    }
    public interface IModelProxy<TModel> : IModelProxy
    {
        TModel Model { get; set; }
    }
}
