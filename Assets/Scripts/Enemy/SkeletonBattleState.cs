using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBattleState : EnemyState
{
    private Transform player;
    private Enemy_Skeleton enemy;
    private int moveDrir;
    public SkeletonBattleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBollName, Enemy_Skeleton enemy) : base(_enemyBase, _stateMachine, _animBollName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        player = GameObject.Find("Player").transform;
    }
    public override void Update()
    {
        base.Update();

        if(enemy.IsPlayerDetected())
        {
            stateTimer = enemy.BattleTime;

            if(enemy.IsPlayerDetected().distance<enemy.attackDistance)
            {
                if(CanAttack())
                stateMachine.ChangeState(enemy.attackState);
            }
        }
        else
        {
            if (stateTimer < 0 || Vector2.Distance(player.transform.position, enemy.transform.position)>7)
            {
                stateMachine.ChangeState(enemy.idleState);
            }
        }



        if ((player.position.x > enemy.transform.position.x))
            moveDrir = 1;


        else if(player.position.x < enemy.transform.position.x)
      
            moveDrir = -1;
            enemy.SetVelocity(enemy.moveSpeed * moveDrir, rb.velocity.y);
    }
    public override void Exit()
    {
        base.Exit();
    }
    public bool CanAttack()
    {
        if(Time.time >= enemy.lastTimeAttacked + enemy.attackCooldown)
        {
            enemy.lastTimeAttacked = Time.time;
            return true;
        }
        Debug.Log(" Attack is on coodlown");
        return false;
    }
  
}
