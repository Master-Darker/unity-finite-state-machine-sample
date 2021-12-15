using DarkFSM.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test.Generic
{
    /// <summary>
    /// 自走方块自动模式
    /// </summary>
    public class AutoCubeAutomatic : State<AutoCubeFSM>
    {
        private int nextIndex; // 下一个巡逻点下标
        private Vector3 nextPoint; // 下一个巡逻点

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
            nextPoint = Owner.AutoPoints[nextIndex];
        }

        /// <summary>
        /// 是否到达下一个巡逻点
        /// </summary>
        /// <returns>到达结果</returns>
        private bool ArriveNextPoint()
        {
            var distance = Vector3.Distance(Owner.transform.position, nextPoint);
            var result = distance <= Owner.AutoBreakDistance;
            if (result) nextIndex = ++nextIndex >= Owner.AutoPoints.Length ? 0 : nextIndex;
            return result;
        }

        /// <summary>
        /// 朝巡逻点移动
        /// </summary>
        private void MoveTowards()
        {
            var lookAtDirection = nextPoint - Owner.transform.position;
            var lookAtRotation = Quaternion.LookRotation(lookAtDirection);
            Owner.transform.rotation = Quaternion.RotateTowards(Owner.transform.rotation, lookAtRotation, Time.deltaTime * Owner.RotateSpeed);
            Owner.transform.Translate(Time.deltaTime * Owner.MoveSpeed * Vector3.forward);
        }
    }
}
