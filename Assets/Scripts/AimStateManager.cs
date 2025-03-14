using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;

public class AimStateManager : MonoBehaviour
{

    [HideInInspector] public CinemachineCamera camera;
    public Cinemachine3OrbitRig.AxisState xAxis, yAxis;
    [SerializeField] Transform cameraFollowPosition;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        xAxis.Update(Time.deltaTime);
        yAxis.Update(Time.deltaTime);
    }

    private void LateUpdate()
    {
        cameraFollowPosition.localEulerAngles = new Vector3(yAxis.Value, cameraFollowPosition.localEulerAngles.y, cameraFollowPosition.localEulerAngles.z);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, xAxis.Value, transform.eulerAngles.z);
    }
}
