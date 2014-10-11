using UnityEngine;
using System.Collections;
using UMvp.Core;

namespace Game
{
    public class MessagePresenter:Presenter<MessageView>
    {
        public const string MSG = "MSG";
        public MessagePresenter(MessageView view):base(view)
        {

        }


        public override void RegeisterMethod()
        {
            this[MSG] = m => _view.PushMessage(m.ToString());
        }
    }
}
