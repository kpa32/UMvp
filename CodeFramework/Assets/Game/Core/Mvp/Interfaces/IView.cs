using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace UMvp.Interfaces
{
    public interface IView
    {
        void UpdateView();

        IPresenter RegeisterPersenter();

        string RemovePersenter();
    }
}
