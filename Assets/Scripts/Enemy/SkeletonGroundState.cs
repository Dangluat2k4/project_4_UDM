using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonGroundState : EnemyState
{
    protected Enemy_Skeleton enemy;
    public Transform player;
    public SkeletonGroundState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBollName, Enemy_Skeleton enemy) : base(_enemyBase, _stateMachine, _animBollName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        player = GameObject.Find("Player").transform;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        // xet trang thai khi nhan thay co nguoi choi
        if (enemy.IsPlayerDetected() || Vector2.Distance(enemy.transform.position, player.position)<2)
        {
            stateMachine.ChangeState(enemy.battleState);
        }
    }
}
