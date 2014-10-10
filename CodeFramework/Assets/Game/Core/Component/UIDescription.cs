using UnityEngine;
using System.Collections;

public class UIDescription : MonoBehaviour {

    private UILabel _info;

    public string Info
    {
        get {

            if (_info == null)
                _info = transform.Find("Info").GetComponent<UILabel>();
            return _info.text; 
        }
        set {
            if (_info == null)
                _info = transform.Find("Info").GetComponent<UILabel>();
            _info.text = value; 
        }
    }
    private UILabel _value;

    public string Value
    {
        get
        {

            if (_value == null)
                _value = transform.Find("Value").GetComponent<UILabel>();
            return _value.text;
        }
        set
        {
            if (_value == null)
                _value = transform.Find("Value").GetComponent<UILabel>();
            _value.text = value;
        }
    }

    
}
