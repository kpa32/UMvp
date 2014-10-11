using UnityEngine;
using System.Collections;
using UMvp.Core;

namespace Game
{
    public class DemoView : View
    {

        /// <summary>
        /// return uiinput value
        /// </summary>
        /// <returns></returns>
        public string GetInputValue()
        {
            return F<UIInput>("Account").value;
        }

        /// <summary>
        /// onenbale regeister 
        /// </summary>
        /// <returns></returns>
        public override UMvp.Interfaces.IPresenter RegeisterPersenter()
        {
            return new DemoPresenter(this);
        }

        /// <summary>
        /// ondisable remove this
        /// </summary>
        /// <returns></returns>
        public override string RemovePersenter()
        {
            return typeof(DemoPresenter).Name;
        }
    }
}
