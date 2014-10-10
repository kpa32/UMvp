using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UMvp.Core;
namespace Game
{
    public class MessageView : View
    {

        private Transform _msg;
        private UILabel _lbl;
        private const float _WAITTIME = 1.2f;
        private float _curTime = 0;
        private Queue<string> _messages;
        private bool _isShowing;

        private void Awake()
        {
            _isShowing = false;

            _messages = new Queue<string>();

            _msg = F("Msg").transform;

            _lbl = F<UILabel>("Msg/Label");
        }

        private void Start()
        {
            StopMsg();
        }


        private void SetActive(bool isactive)
        {
            _msg.gameObject.SetActive(isactive);
        }

        private void Update()
        {
            
            if (!_isShowing)
            {
                
                if (_messages.Count > 0)
                {
                    string msg = _messages.Dequeue();

                    ShowMsg(msg);
                }
            }
            else
            {
                if (_curTime > _WAITTIME)
                {
                    StopMsg();
                }
                _curTime += Time.deltaTime;
            }
        }

        private void ShowMsg(string msg)
        {
            SetActive(true);

            _lbl.text = msg;

            TweenPosition tp = _msg.GetComponent<TweenPosition>();
            tp.ResetToBeginning();
            tp.PlayForward();

            _curTime = 0;

            _isShowing = true;
        }

        private void StopMsg()
        {
            SetActive(false);
            _curTime = 0;
            _isShowing = false;
        }

        public void PushMessage(string msg)
        {
            _messages.Enqueue(msg);
        }

        public override UMvp.Interfaces.IPresenter RegeisterPersenter()
        {
            return new MessagePresenter(this);
        }

        public override string RemovePersenter()
        {
            return typeof(MessagePresenter).Name;
        }
    }
}

