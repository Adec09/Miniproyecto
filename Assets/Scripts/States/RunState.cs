using UnityEngine;

public class RunState : MovementBaseState
{
    public override void EnterState(MovimientoPersonaje movement)
    {
        movement.anim.SetBool("Running",true);
    }

    public override void UpdateState(MovimientoPersonaje movement)
    {
        if (Input.GetKeyUp(KeyCode.LeftShift)) ExitState(movement, movement.Walk);
        else if (movement.dir.magnitude<0.1f) ExitState(movement, movement.Idle);

        if (movement.vInput < 0) movement.currentMoveSpeed = movement.runBackSpeed;
        else movement.currentMoveSpeed = movement.runSpeed;
    }

    void ExitState(MovimientoPersonaje movement, MovementBaseState state)
    {
        movement.anim.SetBool("Running", false);
        movement.SwitchState(state);
    }
}
