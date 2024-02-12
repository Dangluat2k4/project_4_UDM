using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class PlayerPrimaryAttackState : PlayerState
{
    private int comboCounter;
    private float lastTimeAttacked;
    private float comboWindow= 2;
    public PlayerPrimaryAttackState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        // THOI GIAN HOI CHIEU 
        if (comboCounter > 2 || Time.time >= lastTimeAttacked + comboWindow)
            comboCounter = 0;
        player.anim.SetInteger("ComboCounter", comboCounter);

        // lua chon huong tan cong
        float attackDir = player.facingDir;
        if(xInput !=0)
        {
            attackDir = xInput;
        }
        // thuc hien di chuyen va nhay khi dang tan cong thong gqua vetor2 
        player.SetVelocity(player.attackMovement[comboCounter].x * attackDir, player.attackMovement[comboCounter].y);
        // tao do delay kjhi dang chay va thuc hien tan cong
        stateTimer = .1f;
    }

    public override void Exit()
    {
        base.Exit();
        // bat lai trang thai sau
        player.StartCoroutine("BusyFor", .15f);
        comboCounter++; 
        lastTimeAttacked = Time.time;
    }

    public override void Update()
    {
        base.Update();
        // dung lai tan cong khi dang di chuyen
        if (stateTimer < 0)
        {
            player.ZeroVelocity();
        }
        if (triggerCalled)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }

}
