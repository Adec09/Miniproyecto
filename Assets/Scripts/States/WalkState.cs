using UnityEngine;

public class WalkState : MovementBaseState
{
    public override void EnterState(MovimientoPersonaje movement)
    {
        movement.anim.SetBool("Walking", true);
    }

    public override void UpdateState(MovimientoPersonaje movement)
    {
        if (Input.GetKey(KeyCode.LeftShift)) ExitState(movement, movement.Run);
        else if(Input.GetKeyDown(KeyCode.LeftControl)) ExitState(movement, movement.Crouch);
        else if(movement.dir.magnitude<0.1f) ExitState(movement, movement.Idle);

        if (movement.vInput < 0) movement.currentMoveSpeed = movement.walkBackSpeed;
        else movement.currentMoveSpeed= movement.walkSpeed;
    }

    void ExitState(MovimientoPersonaje movement, MovementBaseState state)
    {
        movement.anim.SetBool("Walking", false);
        movement.SwitchState(state);
    }
}
