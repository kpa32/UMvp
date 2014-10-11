using UnityEngine;
using System.Collections;
using UMvp.Core;

namespace UMvp
{
    public class MvpButtonClick : MonoBehaviour
    {
        private void OnClick()
        {
            G.Send(gameObject.name,this);
        }
    }
}
