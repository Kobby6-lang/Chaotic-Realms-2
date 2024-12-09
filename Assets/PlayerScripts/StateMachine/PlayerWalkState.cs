using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    private float footstepTimer = 0f;
    private float footstepInterval = 0.5f; // Adjust this to match the walking speed

    public PlayerWalkState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory) { }

    public override void EnterState()
    {
        Ctx.Animator.SetBool(Ctx.IsWalkingHash, true);
        Ctx.Animator.SetBool(Ctx.IsRunningHash, false);
    }

    public override void UpdateState()
    {
        CheckSwitchStates();
        Ctx.AppliedMovementX = Ctx.CurrentMovementInput.x * 3.5f;
        Ctx.AppliedMovementZ = Ctx.CurrentMovementInput.y * 3.5f;
        HandleFootsteps();
    }

    public override void ExitState() { }

    public override void InitializeSubState() { }

    public override void CheckSwitchStates()
    {
        if (!Ctx.IsMovementPressed)
        {
            SwitchState(Factory.Idle());
        }
        else if (Ctx.IsMovementPressed && Ctx.IsRunPressed)
        {
            SwitchState(Factory.Run());
        }
    }

    private void HandleFootsteps()
    {
        footstepTimer += Time.deltaTime;
        if (footstepTimer >= footstepInterval)
        {
            PlayFootstepSound();
            footstepTimer = 0f;
        }
    }

    private void PlayFootstepSound()
    {
        if (Ctx.footstepSounds.Length > 0)
        {
            int index = Random.Range(0, Ctx.footstepSounds.Length);
            Ctx.audioSource.PlayOneShot(Ctx.footstepSounds[index], Ctx.footstepVolume);
        }
    }
}
