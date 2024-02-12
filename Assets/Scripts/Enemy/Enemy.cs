using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
   [SerializeField] protected LayerMask whatIsPlayer;
    // Move info
    public float moveSpeed;
    public float idleTime;

    // attack info
    public float attackDistance;
    // thoi gian hoi chieu
    public float attackCooldown;
    [HideInInspector] public float lastTimeAttacked;
     public EnemyStateMachine stateMachine { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new EnemyStateMachine();
    }

    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();
       // Debug.Log(IsPlayerDetected().collider.gameObject.name + "I SEE");
    }
    // cap nhat trang thai tan cong
    public virtual void AnimationFinishTrigger() => stateMachine.currentState.AnimationFinishTrigger();
    public virtual RaycastHit2D IsPlayerDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, 50, whatIsPlayer);

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + attackDistance * facingDir, transform.position.y));

    }
    public void SetZeroVelocity()
    {
        rb.velocity = new Vector2(0, 0);
    }
}
