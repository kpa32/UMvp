using UnityEngine;
using System.Collections;

namespace Game
{
    public class UIMapMove : MonoBehaviour
    {
        public float TopOffset;

        public float DownOffset;

        public float LeftOffset;

        public float RightOffset;

        private void OnDrag(Vector2 delta)
        {
            Vector3 pos = transform.localPosition;

            float tempx = pos.x + delta.x;
            float tempy = pos.y + delta.y;

            //1.小于左边阀值,大于右边负值
            if (tempx<LeftOffset&&tempx>RightOffset)
            {
                pos.x += delta.x;
            }
            if (tempy<DownOffset&&tempy>TopOffset)
            {
                pos.y += delta.y;
            }
            transform.localPosition = pos;
        }

        private void OnPress(bool press)
        {
        }
    }
}
