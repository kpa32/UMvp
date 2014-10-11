using UnityEngine;
using System.Collections;

namespace Game
{
    public class UIMapItem : MonoBehaviour
    {
        public UIMapMove MapMove;



        private void OnDrag(Vector2 delta)
        {
            MapMove.SendMessage("OnDrag", delta);
        }

        private void OnClick()
        {
            Debug.Log("Click");
        }

    }
}
