using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerIdleState : PlayerGroundState
{
    public PlayerIdleState(Player _player, PlayerStateMachine _sStateMachine, string _animBoolName) : base(_player, _sStateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.ZeroVelocity();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if(xInput == player.facingDir && player.IsWallDetected())
        {
            return;
        }
        if(xInput !=0 && !player.isBusy)
        {
            stateMachine.ChangeState(player.moveState);
        }
    }
}
