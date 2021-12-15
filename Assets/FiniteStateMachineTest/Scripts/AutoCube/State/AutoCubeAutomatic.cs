using DarkFSM;
using System;
using UnityEngine;

/// <summary>
/// 自走方块自动模式
/// </summary>
public class AutoCubeAutomatic : StateBase
{
    private AutoCubeController controller;
    private int nextIndex; // 下一个巡逻点下标
    private Vector3 nextPoint; // 下一个巡逻点

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
    /// 获取下一个巡逻点
    /// </summary>
    private void GetNextPoint()
    {
        nextPoint = controller.AutoPoints[nextIndex];
    }

    /// <summary>
    /// 是否到达下一个巡逻点
    /// </summary>
    /// <returns>到达结果</returns>
    private bool ArriveNextPoint()
    {
        var distance = Vector3.Distance(controller.transform.position, nextPoint);
        var result = distance <= controller.AutoBreakDistance;
        if (result) nextIndex = ++nextIndex >= controller.AutoPoints.Length ? 0 : nextIndex;
        return result;
    }

    /// <summary>
    /// 朝巡逻点移动
    /// </summary>
    private void MoveTowards()
    {
        var lookAtDirection = nextPoint - controller.transform.position;
        var lookAtRotation = Quaternion.LookRotation(lookAtDirection);
        controller.transform.rotation = Quaternion.RotateTowards(controller.transform.rotation, lookAtRotation, Time.deltaTime * controller.RotateSpeed);
        controller.transform.Translate(Time.deltaTime * controller.MoveSpeed * Vector3.forward);
    }
}
