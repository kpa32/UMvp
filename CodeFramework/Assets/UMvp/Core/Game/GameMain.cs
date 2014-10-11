using UnityEngine;
using System.Collections;
using Game;
using NetEngine.Command;
using System;
using Newtonsoft;
public class GameMain : MonoBehaviour {


    private void Awake()
    { 
        
    }
    private void Start()
    {
        SceneManager.Instance.Initial();
    }


    private void Update()
    {
        SceneManager.Instance.Update();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIManager.BackUI();
        }
    }

}
