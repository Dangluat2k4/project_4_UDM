using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{ 

    // attack details
    public Vector2[] attackMovement;
    public bool isBusy {  get; private set; }
    [Header("Move info")]
    public float moveSpeed = 12f;
    public float jumpForce ;

    // Dash info
    public float dashSpeed ;
    public float dashDuration ;
    public float dashDir {  get; private set; }
    [SerializeField] private float dashCooldown ;
    public float dashUsageTimer;

    public PlayerStateMachine stateMachine {get; private set;}
    public PlayerIdleState idleState { get; private set;}
    public PlayerMoveState moveState { get; private set;}


    public PlayerJumpState jumpState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerDashState dashState { get; private set; }
    public PlayerWallSlideState wallSlideState { get; private set; }
    public PlayerWallJumpState playerWallJumpState { get; private set; }
    public PlayerPrimaryAttackState primaryAttack { get; private set; }


    protected override void Awake()
    {
        base.Awake();
        stateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(this,stateMachine,"Idle");
        moveState = new PlayerMoveState(this,stateMachine,"Move");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        airState = new PlayerAirState(this, stateMachine, "Jump");
        dashState = new PlayerDashState(this, stateMachine, "Dash");
        wallSlideState = new PlayerWallSlideState(this, stateMachine, "WallSlide");
        playerWallJumpState = new PlayerWallJumpState(this, stateMachine, "Jump");
        primaryAttack = new PlayerPrimaryAttackState(this, stateMachine, "Attack");
    }
    protected override void Start()
    {
      base.Start();
        stateMachine.Initialize(idleState);

    }
    /*
    public float timer;
    public float cooldown = 5;

    */ 
    // thuc hien ke thua
    protected override void Update() 
    {
        base.Update();
        stateMachine.currentState.Update();
        checkForDashInput();
    }


    public IEnumerator BusyFor(float _seconds)
    {
        isBusy = true;
        yield return new WaitForSeconds(_seconds);
        isBusy = false;
    }
    public void AnimationTrigger()=> stateMachine.currentState.AnimationFinishTriger();
    private void checkForDashInput()
    {
        if (IsWallDetected())
        {
            return;
        }
        dashUsageTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashUsageTimer<0)
        {
            dashUsageTimer = dashCooldown;
            dashDir = Input.GetAxisRaw("Horizontal");
            if(dashDir == 0)
            {
                dashDir = facingDir;
            }
            stateMachine.ChangeState(dashState);
        }
    }
    public void ZeroVelocity()
    {
        rb.velocity = new Vector2(0,0);
    }



}
