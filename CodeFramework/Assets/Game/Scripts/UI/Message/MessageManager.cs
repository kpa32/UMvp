using UnityEngine;
using System.Collections;
using UMvp.Core;

namespace Game
{
    public class MessageManager
    {
        private static MessageManager _instance;

        private static MessageManager Instance
        {
            get {
                if (_instance == null) _instance = new MessageManager();
                return MessageManager._instance; 
            }
        }

        private MessageManager()
        { 
            
        }


        public static void AddMessage(string message)
        {
            if (!UIManager.ExistGlobalUI(UIName.Message))
            {
                UIManager.OpenGlobalUI(UIName.Message);
            }
            G.Send(MessagePresenter.MSG, message);
        }
    }

}