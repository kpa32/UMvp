using UnityEngine;
using System.Collections;

public class UIHitDisplay : MonoBehaviour {

    public GameObject prefab;

    public void DisplayHit(Transform _tag,string text)
    {
        prefab.SetActive(true);
        GameObject obj=GameObject.Instantiate(prefab) as GameObject;

        obj.transform.parent = _tag;
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localScale = Vector3.one;
        obj.transform.GetComponent<UILabel>().text = text;


        prefab.SetActive(false);
    }
}
