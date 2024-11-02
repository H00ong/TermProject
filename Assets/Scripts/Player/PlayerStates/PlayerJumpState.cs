using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName)
        : base(_player, _stateMachine, _animBoolName) { }

    public override void Enter()
    {
        base.Enter();

        player.SetVelocity(player.Rb.velocity.x, player.jumpForce);
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
