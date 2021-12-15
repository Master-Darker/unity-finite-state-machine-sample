using System;
using System.Collections.Generic;
using UnityEngine;

namespace DarkFSM
{
    /// <summary>
    /// 有限状态机基类
    /// </summary>
    public abstract class FSMController : MonoBehaviour
    {
        /// <summary>
        /// 当前状态
        /// </summary>
        protected StateBase state;

        /// <summary>
        /// 所有状态
        /// 状态缓存
        /// </summary>
        private Dictionary<string, StateBase> states = new Dictionary<string, StateBase>();

        /// <summary>
        /// 改变状态
        /// </summary>
        /// <param name="stateType">状态类型</param>
        /// <param name="reset">是否重置</param>
        public void ChangeState(Enum stateType, bool reset = false)
        {
            if (state != null && state.StateType.Equals(stateType) && !reset) return;
            if (state != null) state.OnExit();
            state = GetState(stateType);
            state.OnEnter();
        }

        /// <summary>
        /// 获取状态
        /// 优先在状态缓存池中获取
        /// </summary>
        /// <param name="stateType">状态类型</param>
        /// <returns>状态</returns>
        private StateBase GetState(Enum stateType)
        {
            var stateKey = stateType.ToString();
            if (states.ContainsKey(stateKey)) return states[stateKey];
            var newState = Activator.CreateInstance(Type.GetType(stateKey)) as StateBase;
            newState.Init(stateType, this);
            states.Add(stateKey, newState);
            return newState;
        }

        protected virtual void Update()
        {
            if (state != null) state.OnUpdate();
        }
    }
}
