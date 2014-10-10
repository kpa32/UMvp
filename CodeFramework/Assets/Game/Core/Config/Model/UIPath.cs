using UnityEngine;
using System.Collections;

namespace Game
{
    public class UIPath:IConfigVo<int>
    {
        public string Name { get; set; }

        public int Depth { get; set; }

        public string Path { get; set; }

        public Vector3 Position { get; set; }

        public int Primarykey
        {
            get { return 0; }
        }
    }
}