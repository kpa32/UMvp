using UnityEngine;
using System.Collections;

public class MoveAction : MonoBehaviour {

    private Vector3 memberScale;

    private void Start()
    {
        memberScale = transform.localScale;
    }

    private void OnPress(bool press)
    {
        if (press)
        {
            transform.localScale = memberScale * 1.5f;
        }
        else {
            transform.localScale = memberScale;
        }
    }
}
