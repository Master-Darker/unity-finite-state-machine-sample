using DarkFSM.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test.Generic
{
    /// <summary>
    /// 自走方块状态机
    /// </summary>
    public class AutoCubeFSM : Machine<AutoCubeFSM>
    {
        [Tooltip("自动巡逻点")] [SerializeField] private Vector3[] autoPoints;
        [Tooltip("自动刹车距离")] [SerializeField] private float autoBreakDistance;
        [Tooltip("移动速度")] [SerializeField] private float moveSpeed;
        [Tooltip("旋转速度")] [SerializeField] private float rotateSpeed;

        /// <summary>
        /// 自动巡逻点
        /// </summary>
        public Vector3[] AutoPoints { get => autoPoints; }
        /// <summary>
        /// 自动刹车距离
        /// </summary>
        public float AutoBreakDistance { get => autoBreakDistance; }
        /// <summary>
        /// 移动速度
        /// </summary>
        public float MoveSpeed { get => moveSpeed; }
        /// <summary>
        /// 旋转速度
        /// </summary>
        public float RotateSpeed { get => rotateSpeed; }
    }
}
