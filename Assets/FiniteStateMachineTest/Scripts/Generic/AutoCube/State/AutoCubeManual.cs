using DarkFSM.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test.Generic
{
    /// <summary>
    /// 自走方块手动模式
    /// </summary>
    public class AutoCubeManual : State<AutoCubeFSM>
    {
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
            Owner.transform.Rotate(Owner.transform.up, Time.deltaTime * Owner.RotateSpeed * h);
            Owner.transform.Translate(Time.deltaTime * Owner.MoveSpeed * v * Vector3.forward);
        }
    }
}
