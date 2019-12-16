using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected int hp;
    [SerializeField] protected int max_hp;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float jumpSpeed;
    [SerializeField] protected bool groundFlag;
    [SerializeField] protected bool attackFlag;
    [SerializeField] protected bool invincibleFlag;
    private float directionSpeed = 0;

    private Rigidbody2D rb;

    private Animator anim;

    protected enum DirectionType
    {
        up,
        down,
        left,
        right,
    }

    protected enum Status
    {
        enemy,
        normal,
        cheek,
        beam,
        fire,
        cutter,
        seord,
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(0, jumpSpeed);
            anim.SetTrigger("jumpFlag");
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-moveSpeed, 0);
            this.transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(moveSpeed, 0);
            this.transform.localScale = new Vector3(1, 1, 1);
        }


        if (rb.velocity.x <= 1 || rb.velocity.x >= -1)
        {
            anim.SetInteger("walkSpeed", 0);
        }

        if (rb.velocity.x > 1 || rb.velocity.x < -1)
        {
            anim.SetInteger("walkSpeed", 1);
        }

        if (groundFlag)
        {
            anim.SetBool("isGround", true);
        }
        else
        {
            anim.SetBool("isGround", false);
        }
    }

    public virtual void Walk()
    {
        
    }

    public void Run()
    {

    }

    public void Jump()
    {

    }

    public virtual void Attack()
    {

    }

    public void Damege(int power)
    {

    }

    public void Recover(int val)
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            groundFlag = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            groundFlag = false;
        }
    }
}
