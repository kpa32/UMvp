using UnityEngine;
using System.Collections;

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
            //Gate.instance.sendNotification(MsgConst.Message_Push, message);
        }
    }

}