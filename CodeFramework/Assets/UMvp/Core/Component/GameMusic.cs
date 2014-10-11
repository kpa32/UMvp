using UnityEngine;
using System.Collections;

public class GameMusic : MonoBehaviour {

    public AudioClip[] audios;

    private AudioSource source;
    private void Awake()
    {
        source = GetComponent<AudioSource>();
        
    }


    public void PlayOne(string name)
    {
        AudioClip clip = FindClip(name);
        if (clip)
        {
            source.PlayOneShot(clip);
        }
    }


    private AudioClip FindClip(string name)
    {
        foreach (var item in audios)
        {
            if (item.name.Equals(name))
            {
                return item;
            }
        }
        return null;
    }

    private static GameMusic _music;

    public static GameMusic Instance
    {
        get { return GameMusic._music; }
    }

    private void OnEnable()
    {
        _music = this;
    }

    private void OnDisable()
    {
        _music = null;
    }
}
