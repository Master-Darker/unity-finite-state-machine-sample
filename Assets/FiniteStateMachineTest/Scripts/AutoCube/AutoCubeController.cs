using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���߷��������
/// </summary>
public class AutoCubeController : FSMController
{
    [Tooltip("�Զ�Ѳ�ߵ�")] [SerializeField] private Vector3[] autoPoints;
    [Tooltip("�Զ�ɲ������")] [SerializeField] private float autoBreakDistance;
    [Tooltip("�ƶ��ٶ�")] [SerializeField] private float moveSpeed;
    [Tooltip("��ת�ٶ�")] [SerializeField] private float rotateSpeed;

    /// <summary>
    /// �Զ�Ѳ�ߵ�
    /// </summary>
    public Vector3[] AutoPoints { get => autoPoints; }
    /// <summary>
    /// �Զ�ɲ������
    /// </summary>
    public float AutoBreakDistance { get => autoBreakDistance; }
    /// <summary>
    /// �ƶ��ٶ�
    /// </summary>
    public float MoveSpeed { get => moveSpeed; }
    /// <summary>
    /// ��ת�ٶ�
    /// </summary>
    public float RotateSpeed { get => rotateSpeed; }
}

/// <summary>
/// ���߷���״̬����
/// </summary>
public enum AutoCubeStateType
{
    AutoCubeAutomatic, AutoCubeManual
}
