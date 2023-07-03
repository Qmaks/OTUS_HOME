using System;
using Declarative;

namespace Lessons.StateMachines.States
{
    // [Serializable]
    // public sealed class RunState : CompositeState
    // {
    //     public MoveState moveState;
    //     
    //     [Construct]
    //     public void ConstructSelf()
    //     {
    //         SetStates(moveState);
    //     }
    //     
    //     [Construct]
    //     public void ConstructSubStates(CharacterVisual visual, CharacterMovement movement)
    //     {
    //         moveState.Construct(movement.movementDirection, movement.moveInDirectionEngine,
    //             movement.rotateInDirectionEngine);
    //     }
    // }
}