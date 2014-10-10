using UnityEngine;
using System.Collections;
using System;

namespace Game
{
    public interface IConfigVo<T>
    {
        T Primarykey { get; }
    }
}
