using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMvp.Interfaces;

namespace UMvp.Core
{
    public abstract class ModelProxy<TModel>:IModelProxy<TModel>
    {
        public ModelProxy():this(default(TModel))
        {

        }
        public ModelProxy(TModel model)
        {
            Model = model;
        }
        public TModel Model
        {
            get;
            set;
        }

        public virtual void NotifyUpdate()
        {
            
        }
    }
}
