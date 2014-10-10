using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Game;

public class UIAnimation : MonoBehaviour
{



    public SpriteData[] Data;

    private SpriteRenderer _read;

    private List<SpriteData> _data;

    private bool _isStart;

    private bool _isLoop;           //是否是循环

    public bool IsLoop
    {
        get { return _isLoop; }
    }

    private float _frameSpeed = 1;      //速度

    public float FrameSpeed
    {
        get { return _frameSpeed; }
        set { _frameSpeed = value; }
    }

    private float _curTime;         //当前计时

    private int _frameIndex;         //当前帧
    private void Awake()
    {
        _read = transform.GetComponent<SpriteRenderer>();
        _data = new List<SpriteData>();

        _isStart = false;
    }

    private void Start()
    {
        _data.AddRange(Data);
    }

    private void Update()
    {
        if (_isStart)
        {
            if (_curTime > _frameSpeed)
            {
                _curTime = 0;
                _frameIndex++;

                if (_frameIndex >= _data.Count)
                {
                    if (_isLoop)
                    {
                        _frameIndex = 0;
                    }
                    else
                    {
                        _isStart = false;
                        _frameIndex = 0;
                    }
                }
                else
                {
                    _read.sprite = _data[_frameIndex].sprite;
                    transform.localPosition = _data[_frameIndex].position;
                }
            }
            _curTime += Time.deltaTime;
        }
    }

    public void Play(bool IsLoop)
    {
        if (_data.Count > 0)
        {
            _isStart = true;
            _isLoop = IsLoop;
            _curTime = 0;
            _frameIndex = 0;

            _read.sprite = _data[_frameIndex].sprite;
            transform.localPosition = _data[_frameIndex].position;
        }
    }

    public void Stop()
    {
        _isStart = false;
        _isLoop = false;
        _curTime = 0;
        _frameIndex = 0;
        _frameSpeed = 1;
        _data.Clear();
    }

    public void StopToFirstFrame()
    {
        _read.sprite = _data[_frameIndex].sprite;
        transform.localPosition = _data[_frameIndex].position;
        Stop();
    }

    [System.Serializable]
    public class SpriteData
    {
        public Sprite sprite;
        public Vector3 position;

        public SpriteData()
        {
            position = Vector3.zero;
        }
    }

}

//public class UIAnimation : MonoBehaviour
//{

//    public class SpriteData
//    {
//        public Sprite sprite;
//        public Vector3 position;

//        public SpriteData()
//        {
//            position = Vector3.zero;
//        }
//    }

//    public Sprite[] Data;

//    private SpriteRenderer _read;

//    private List<SpriteData> _data;

//    private bool _isStart;

//    private bool _isLoop;           //是否是循环

//    public bool IsLoop
//    {
//        get { return _isLoop; }
//    }

//    private float _frameSpeed = 1;      //速度

//    public float FrameSpeed
//    {
//        get { return _frameSpeed; }
//        set { _frameSpeed = value; }
//    }

//    private float _curTime;         //当前计时

//    private int _frameIndex;         //当前帧
//    private void Awake()
//    {
//        _read = transform.GetComponent<SpriteRenderer>();
//        _data = new List<SpriteData>();

//        _isStart = false;
//    }


//    private void Update()
//    {
//        if (_isStart)
//        {
//            if (_curTime > _frameSpeed)
//            {
//                _curTime = 0;
//                _frameIndex++;

//                if (_frameIndex >= _data.Count)
//                {
//                    if (_isLoop)
//                    {
//                        _frameIndex = 0;
//                    }
//                    else
//                    {
//                        _isStart = false;
//                        _frameIndex = 0;
//                    }
//                }
//                else
//                {
//                    _read.sprite = _data[_frameIndex].sprite;
//                    transform.localPosition = _data[_frameIndex].position;
//                }
//            }
//            _curTime += Time.deltaTime;
//        }
//    }

//    public void Play(bool IsLoop)
//    {
//        if (_data.Count > 0)
//        {
//            _isStart = true;
//            _isLoop = IsLoop;
//            _curTime = 0;
//            _frameIndex = 0;

//            _read.sprite = _data[_frameIndex].sprite;
//            transform.localPosition = _data[_frameIndex].position;
//        }
//    }

//    public void Stop()
//    {
//        _isStart = false;
//        _isLoop = false;
//        _curTime = 0;
//        _frameIndex = 0;
//        _frameSpeed = 1;
//        _data.Clear();
//    }

//    public void StopToFirstFrame()
//    {
//        _read.sprite = _data[_frameIndex].sprite;
//        transform.localPosition = _data[_frameIndex].position;
//        Stop();
//    }

//    public void AddFrames(List<Frame> frames, string path)
//    {
//        _data.Clear();
//        foreach (Frame f in frames)
//        {
//            _data.Add(new SpriteData { sprite = SourceManager.LoadSprite(f.Icon, path), position = f.Position });
//        }
//    }

//    public void StartData()
//    {
//        if (Data.Length > 0)
//        {
//            for (int i = 0; i < Data.Length; i++)
//            {

//            }
//        }
//    }
//}


