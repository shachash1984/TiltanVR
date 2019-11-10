using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroTracking : MonoBehaviour {

#if UNITY_EDITOR
    private void Awake()
    {
        Transform playerTransform = transform.parent;
        GameObject camPivot = new GameObject("CameraPivot");
        camPivot.transform.rotation = Quaternion.Euler(90, 0, -45f);
        camPivot.transform.parent = playerTransform;
        transform.parent = camPivot.transform;
        //camPivot.transform.parent = FindObjectOfType<MyPlayerController>().transform;
    }

    private void Start()
    {
        Input.gyro.enabled = true;
    }

    private void Update()
    {
        GyroModifyCamera();
    }

    public static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }

    void GyroModifyCamera()
    {
        transform.localRotation = GyroToUnity(Input.gyro.attitude);
    }
#endif
}
