using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class MovimientiPersonaje : MonoBehaviour
{

    public float moveSpeed = 3;
    [HideInInspector] public Vector3 dir;
    private CharacterController controller;
    
    float hzInput, vInput;

   
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        getDirectionAndMove();
    }

    void getDirectionAndMove()
    {
        hzInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        dir = transform.forward * vInput + transform.right * hzInput;

        controller.Move(dir * moveSpeed * Time.deltaTime);
        
    }
}
