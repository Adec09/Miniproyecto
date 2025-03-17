using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;

public class AimStateManager : MonoBehaviour
{

    AimBaseState currentState;
    public HipFireState Hip = new HipFireState();
    public AimState Aim = new AimState();

    [SerializeField] float mouseSense = 1;
    float xAxis, yAxis;
    [SerializeField] Transform cameraFollowPosition;

    [HideInInspector] public Animator anim;
    
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        SwitchState(Hip);
    }

    
    void Update()
    {
        xAxis += Input.GetAxisRaw("Mouse X") * mouseSense;
        yAxis -= Input.GetAxisRaw("Mouse Y") * mouseSense;
        yAxis = Mathf.Clamp(yAxis, -80, 80);

        currentState.UpdateState(this);
    }

    private void LateUpdate()
    {
        cameraFollowPosition.localEulerAngles = new Vector3(yAxis, cameraFollowPosition.localEulerAngles.y, cameraFollowPosition.localEulerAngles.z);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, xAxis, transform.eulerAngles.z);
    }

    public void SwitchState(AimBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}
