using System;

namespace DarkFSM
{
    /// <summary>
    /// 状态基类
    /// </summary>
    public abstract class StateBase
    {
        /// <summary>
        /// 状态类型
        /// </summary>
        protected Enum stateType;
        public Enum StateType { get => stateType; }

        /// <summary>
        /// 状态初始化
        /// 仅在首次实例化时调用
        /// </summary>
        /// <param name="stateType">状态类型</param>
        /// <param name="controller">所属状态机</param>
        public abstract void Init(Enum stateType, FSMController controller);

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
