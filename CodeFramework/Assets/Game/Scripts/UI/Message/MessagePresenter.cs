using UnityEngine;
using System.Collections;
using UMvp.Core;

namespace Game
{
    public class MessagePresenter:Presenter<MessageView>
    {
        public MessagePresenter(MessageView view):base(view)
        {

        }


        public override void RegeisterMethod()
        {
            
        }
    }
}
