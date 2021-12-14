using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMain : MonoBehaviour
{
    [Tooltip("自走方块控制器")] [SerializeField] private AutoCubeController controller;
    [Tooltip("自动按钮")] [SerializeField] private Button buttonAutomatic;
    [Tooltip("手动按钮")] [SerializeField] private Button buttonManual;

    private void Start()
    {
        buttonAutomatic.onClick.AddListener(SwitchAutomatic);
        buttonManual.onClick.AddListener(SwitchManual);
        buttonAutomatic.onClick.Invoke();
    }

    private void SwitchAutomatic()
    {
        controller.ChangeState(AutoCubeStateType.AutoCubeAutomatic);
        buttonAutomatic.interactable = false;
        buttonManual.interactable = true;
    }

    private void SwitchManual()
    {
        controller.ChangeState(AutoCubeStateType.AutoCubeManual);
        buttonManual.interactable = false;
        buttonAutomatic.interactable = true;
    }
}
