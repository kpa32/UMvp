using UnityEngine;
using System.Collections;
namespace Game
{

    public class LoginScene : IScene
    {

        public override void Initial()
        {
            //初始化配置文件
            ConfigManager.Initial<DatareadUIPath>();

            //初始化Net
            Net.SetAddres(GameSetting.Appsettings["host"],
                GameSetting.Appsettings["port"]);
            
            //设置游戏后台播放
            Application.runInBackground = true;
        }

        public override void Load()
        {
            UIManager.OpenUI(UIName.Demo);   
        }

        public override void Exit()
        {
            UIManager.CloseUI(UIName.Demo); 
        }
    }
}