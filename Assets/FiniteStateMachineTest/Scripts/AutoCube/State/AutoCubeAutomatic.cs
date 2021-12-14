using FiniteStateMachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���߷����Զ�ģʽ
/// </summary>
public class AutoCubeAutomatic : StateBase
{
    private AutoCubeController controller;
    private int nextIndex; // ��һ��Ѳ�ߵ��±�
    private Vector3 nextPoint; // ��һ��Ѳ�ߵ�

    public override void Init(Enum stateType, FSMController controller)
    {
        this.stateType = stateType;
        this.controller = controller as AutoCubeController;
    }

    public override void OnEnter()
    {
        GetNextPoint();
    }

    public override void OnExit()
    {

    }

    public override void OnUpdate()
    {
        if (ArriveNextPoint()) GetNextPoint();
        MoveTowards();
    }

    /// <summary>
    /// ��ȡ��һ��Ѳ�ߵ�
    /// </summary>
    private void GetNextPoint()
    {
        nextPoint = controller.AutoPoints[nextIndex];
    }

    /// <summary>
    /// �Ƿ񵽴���һ��Ѳ�ߵ�
    /// </summary>
    /// <returns>������</returns>
    private bool ArriveNextPoint()
    {
        var distance = Vector3.Distance(controller.transform.position, nextPoint);
        var result = distance <= controller.AutoBreakDistance;
        if (result) nextIndex = ++nextIndex >= controller.AutoPoints.Length ? 0 : nextIndex;
        return result;
    }

    /// <summary>
    /// ��Ѳ�ߵ��ƶ�
    /// </summary>
    private void MoveTowards()
    {
        var lookAtDirection = nextPoint - controller.transform.position;
        var lookAtRotation = Quaternion.LookRotation(lookAtDirection);
        controller.transform.rotation = Quaternion.RotateTowards(controller.transform.rotation, lookAtRotation, Time.deltaTime * controller.RotateSpeed);
        controller.transform.Translate(Time.deltaTime * controller.MoveSpeed * Vector3.forward);
    }
}
