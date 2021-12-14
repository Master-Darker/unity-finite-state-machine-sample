using System;

namespace FiniteStateMachine
{
    /// <summary>
    /// ״̬����
    /// </summary>
    public abstract class StateBase
    {
        /// <summary>
        /// ״̬����
        /// </summary>
        protected Enum stateType;
        public Enum StateType { get => stateType; }

        /// <summary>
        /// ״̬��ʼ��
        /// �����״�ʵ����ʱ����
        /// </summary>
        /// <param name="stateType">״̬����</param>
        /// <param name="controller">����״̬��</param>
        public abstract void Init(Enum stateType, FSMController controller);

        /// <summary>
        /// ����״̬
        /// </summary>
        public abstract void OnEnter();

        /// <summary>
        /// �˳�״̬
        /// </summary>
        public abstract void OnExit();

        /// <summary>
        /// ״̬������
        /// </summary>
        public abstract void OnUpdate();
    }
}
