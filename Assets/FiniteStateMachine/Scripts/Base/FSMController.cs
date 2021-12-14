using FiniteStateMachine;
using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����״̬������
/// </summary>
public abstract class FSMController : MonoBehaviour
{
    /// <summary>
    /// ��ǰ״̬
    /// </summary>
    protected StateBase state;

    /// <summary>
    /// ����״̬
    /// ״̬����
    /// </summary>
    private Dictionary<string, StateBase> states = new Dictionary<string, StateBase>();

    /// <summary>
    /// �ı�״̬
    /// </summary>
    /// <param name="stateType">״̬����</param>
    /// <param name="reset">�Ƿ�����</param>
    public void ChangeState(Enum stateType, bool reset = false)
    {
        if (state != null && state.StateType.Equals(stateType) && !reset) return;
        if (state != null) state.OnExit();
        state = GetState(stateType);
        state.OnEnter();
    }

    /// <summary>
    /// ��ȡ״̬
    /// ������״̬������л�ȡ
    /// </summary>
    /// <param name="stateType">״̬����</param>
    /// <returns>״̬</returns>
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
