using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

public class MovimientoPersonaje : MonoBehaviour
{

    public float moveSpeed = 3;
    [HideInInspector] public Vector3 dir;
    CharacterController controller;

    [SerializeField] float groundYOffset;
    [SerializeField] LayerMask groundMask;
    Vector3 spherePosition;

    [SerializeField] float gravity = -9.81f;
    Vector3 velocity;

    float hzInput, vInput;

   
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        getDirectionAndMove();
        Gravity();
    }

    void getDirectionAndMove()
    {
        hzInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        dir = transform.forward * vInput + transform.right * hzInput;

        controller.Move(dir * moveSpeed * Time.deltaTime);
        
    }

    bool IsGrounded()
    {
        spherePosition = new Vector3(transform.position.x, transform.position.y - groundYOffset, transform.position.z);

        if (Physics.CheckSphere(spherePosition, controller.radius -0.05f, groundMask)) return true;
        return false;  
    }

    void Gravity()
    {
        if (!IsGrounded()) velocity.y += gravity * Time.deltaTime;
        else if (velocity.y < 0) velocity.y = -2;

        controller.Move(velocity  * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(spherePosition, controller.radius - 0.05f);
    }
}
