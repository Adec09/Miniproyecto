using UnityEngine;



public class CrouchState : MovementBaseState
{
    public override void EnterState(MovimientoPersonaje movement)
    {
        movement.anim.SetBool("Crouching", true);
    }

    public override void UpdateState(MovimientoPersonaje movement)
    {
        if (Input.GetKey(KeyCode.LeftShift)) ExitState(movement, movement.Run);
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if(movement.dir.magnitude<0.1f) ExitState(movement, movement.Idle);
            else ExitState(movement, movement.Walk);
        }

        if (movement.vInput < 0) movement.currentMoveSpeed = movement.crouchBackSpeed;
        else movement.currentMoveSpeed = movement.crouchSpeed;
    }

    void ExitState(MovimientoPersonaje movement, MovementBaseState state)
    {
        movement.anim.SetBool("Crouching", false);
        movement.SwitchState(state);
    }
}
