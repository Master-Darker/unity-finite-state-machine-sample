using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkFSM.Generic
{
    /// <summary>
    /// 泛型状态类
    /// </summary>
    /// <typeparam name="T">具体状态类</typeparam>
    public abstract class State<T> where T : Machine<T>
    {
        private T owner; // 所属状态机
        /// <summary>
        /// 所属状态机
        /// </summary>
        public T Owner { get => owner; }

        /// <summary>
        /// 状态初始化
        /// </summary>
        /// <param name="machine">所属状态机</param>
        public void Init(T machine)
        {
            owner = machine;
        }

        /// <summary>
        /// 进入状态
        /// </summary>
        public abstract void OnEnter();
        /// <summary>
        /// 退出状态
        /// </summary>
        public abstract void OnExit();
        /// <summary>
        /// 状态运行中
        /// </summary>
        public abstract void OnUpdate();
    }
}
