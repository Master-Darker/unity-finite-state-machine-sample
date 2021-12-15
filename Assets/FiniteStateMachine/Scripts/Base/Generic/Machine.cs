using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkFSM.Generic
{
    public class Machine<T> : MonoBehaviour where T : Machine<T>
    {
        // 所有状态 状态缓存
        private Dictionary<Type, State<T>> states = new Dictionary<Type, State<T>>();

        private State<T> state; // 当前状态
        /// <summary>
        /// 当前状态
        /// </summary>
        public State<T> State { get => state; }

        /// <summary>
        /// 改变状态
        /// </summary>
        /// <typeparam name="U">状态类型</typeparam>
        /// <param name="reset">是否重置</param>
        public void ChangeState<U>(bool reset = false) where U : State<T>, new()
        {
            if (state != null && state.GetType() == typeof(U) && !reset) return;
            if (state != null) state.OnExit();
            state = GetState<U>();
            state.OnEnter();
        }

        /// <summary>
        /// 获取状态
        /// 优先在状态缓存池中获取
        /// </summary>
        /// <typeparam name="U">状态类型</typeparam>
        /// <returns>状态</returns>
        private State<T> GetState<U>() where U : State<T>, new()
        {
            var type = typeof(U);
            if (states.ContainsKey(type)) return states[type];
            var newState = new U();
            newState.Init(this as T);
            states.Add(type, newState);
            return newState;
        }

        protected virtual void Update()
        {
            if (state != null) state.OnUpdate();
        }
    }
}
