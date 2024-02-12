using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    // components
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }

    ///  collision info
    public Transform attackCkeck;
    public float attackCkeckRadius;
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected float groundCheckDistance;
    [SerializeField] protected Transform wallCheck;
    [SerializeField] protected float wallCheckDistance;
    [SerializeField] protected LayerMask whatIsGround;


    // trai thai lat mat
    public int facingDir { get; private set; } = 1;
    protected bool facingRight = true;
    protected virtual void Awake()
    {
        
    }
    protected virtual void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    protected virtual void Update()
    {
        
    }
    // tao ham thuc hien 1 cuoc tan cong
    public virtual void Damage()
    {
        Debug.Log(gameObject.name + "was damaged");
    }


    // collision
    // virtual de o che do cong khai
    public virtual bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
    public virtual bool IsWallDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, wallCheckDistance, whatIsGround);
    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
        // thuc hien tan cong
        Gizmos.DrawWireSphere(attackCkeck.position, attackCkeckRadius);
    }


    // xet vat ly
    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
        FlipController(_xVelocity);
    }



    // Flip trang thai lat mat
    public virtual void  Flip()
    {
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
    public virtual void FlipController(float _x)
    {
        if (_x > 0 && !facingRight) { Flip(); }
        else if (_x < 0 && facingRight)
        {
            Flip();
        }
    }
}
