using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCameraFollow : MonoBehaviour
{
    [Tooltip("跟随目标")] [SerializeField] private Transform target;
    [Tooltip("跟随偏移")] [SerializeField] private Vector3 offset;
    [Tooltip("移动速度")] [SerializeField] private float moveSpeed;
    [Tooltip("旋转速度")] [SerializeField] private float rotateSpeed;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void LateUpdate()
    {
        if (target == null) return;
        var followPoint = target.TransformPoint(offset);
        var followdirection = target.position - followPoint;
        var followRotation = Quaternion.LookRotation(followdirection);
        mainCamera.transform.rotation = Quaternion.RotateTowards(mainCamera.transform.rotation, followRotation, Time.deltaTime * rotateSpeed);
        mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, followPoint, Time.deltaTime * moveSpeed);
    }
}
