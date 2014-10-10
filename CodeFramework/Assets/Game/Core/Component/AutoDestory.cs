using UnityEngine;
using System.Collections;

public class AutoDestory : MonoBehaviour {
    public float _time;
    private void Awake()
    {
        Destroy(gameObject,_time);
    }
}
