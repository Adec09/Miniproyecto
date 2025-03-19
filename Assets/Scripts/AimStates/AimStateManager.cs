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
    [HideInInspector] public CinemachineCamera vCam;
    public float adsFov = 40;
    [HideInInspector] public float hipFov;
    [HideInInspector] public float currentFov;
    public float fovSmoothSpeed = 10;
    
    void Start()
    {
        vCam = GetComponentInChildren<CinemachineCamera>();
        hipFov = vCam.Lens.FieldOfView;
        anim = GetComponentInChildren<Animator>();
        SwitchState(Hip);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        xAxis += Input.GetAxisRaw("Mouse X") * mouseSense;
        yAxis -= Input.GetAxisRaw("Mouse Y") * mouseSense;
        yAxis = Mathf.Clamp(yAxis, -65, 65);

        vCam.Lens.FieldOfView = Mathf.Lerp(vCam.Lens.FieldOfView, currentFov, fovSmoothSpeed * Time.deltaTime);

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
