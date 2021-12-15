using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Test.Generic
{
    /// <summary>
    /// 主界面UI
    /// </summary>
    public class UIMain : MonoBehaviour
    {
        [Tooltip("自走方块控制器")] [SerializeField] private AutoCubeFSM fsm;
        [Tooltip("自动按钮")] [SerializeField] private Button buttonAutomatic;
        [Tooltip("手动按钮")] [SerializeField] private Button buttonManual;

        private void Start()
        {
            buttonAutomatic.onClick.AddListener(SwitchAutomatic);
            buttonManual.onClick.AddListener(SwitchManual);
            buttonAutomatic.onClick.Invoke();
        }

        /// <summary>
        /// 切换自动模式
        /// </summary>
        private void SwitchAutomatic()
        {
            fsm.ChangeState<AutoCubeAutomatic>();
            buttonAutomatic.interactable = false;
            buttonManual.interactable = true;
        }

        /// <summary>
        /// 切换手动模式
        /// </summary>
        private void SwitchManual()
        {
            fsm.ChangeState<AutoCubeManual>();
            buttonManual.interactable = false;
            buttonAutomatic.interactable = true;
        }
    }
}
