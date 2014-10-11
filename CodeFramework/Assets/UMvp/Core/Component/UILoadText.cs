using UnityEngine;
using System.Collections;

public class UILoadText : MonoBehaviour {

    private string LoadText="冒险中";

    private char LoadChart = '.';

    private UILabel _lbl;
    private float _curTime;
    private float _maxTime=1;

    private void Awake()
    {
        _lbl = GetComponent<UILabel>();
    }


    private void Update()
    {
        if (_curTime>_maxTime)
        {
            _curTime = 0;
            UpdateLabel();
        }
        _curTime += Time.deltaTime;
    }
    int index = 0;
    int maxIndex = 3;
    private void UpdateLabel()
    {
        if (index>maxIndex)
        {
            index = 0;
        }
        _lbl.text = string.Format("{0}{1}", LoadText, "".PadLeft(index, LoadChart));
        index++;
    }
}
