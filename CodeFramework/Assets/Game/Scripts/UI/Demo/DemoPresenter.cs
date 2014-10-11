using UnityEngine;
using System.Collections;
using UMvp.Core;

namespace Game
{
    public class DemoPresenter : Presenter<DemoView>
    {
        public DemoPresenter(DemoView view):base(view)
        {

        }


        public override void RegeisterMethod()
        {
            this["Button_Login"] = OnButton_Login_Click;
        }

        public void OnButton_Login_Click(object e)
        { 
            MessageManager.AddMessage(
                string.Format("[000000]account[-] is [ff0000]{0}",
                _view.GetInputValue()));
        }
    }
}
