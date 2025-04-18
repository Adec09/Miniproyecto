using UnityEngine;

public class IdleState : MovementBaseState
{
    public override void EnterState(MovimientoPersonaje movement)
    {

    }

    public override void UpdateState(MovimientoPersonaje movement)
    { 
        if (movement.dir.magnitude > 0.1f) 
        {
            if (Input.GetKey(KeyCode.LeftShift)) movement.SwitchState(movement.Run);
            else movement.SwitchState(movement.Walk);
        }
        if (Input.GetKeyDown(KeyCode.LeftControl)) movement.SwitchState(movement.Crouch);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            movement.previousState = this;
            movement.SwitchState(movement.Jump);
        }
        
    }
}
