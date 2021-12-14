using FiniteStateMachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 自走方块手动模式
/// </summary>
public class AutoCubeManual : StateBase
{
    private AutoCubeController controller;

    public override void Init(Enum stateType, FSMController controller)
    {
        this.stateType = stateType;
        this.controller = controller as AutoCubeController;
    }

    public override void OnEnter()
    {

    }

    public override void OnExit()
    {
        
    }

    public override void OnUpdate()
    {
        Move();
    }

    /// <summary>
    /// 控制移动
    /// </summary>
    public void Move()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        controller.transform.Rotate(controller.transform.up, Time.deltaTime * controller.RotateSpeed * h);
        controller.transform.Translate(Time.deltaTime * controller.MoveSpeed * v * Vector3.forward);
    }
}
