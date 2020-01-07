using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public static int life = 3;
    [SerializeField] private float hoveringSpeed;
    private bool hoveringFlag;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        mystatus = Status.normal;
        posDif = transform.position.x - farstBG.position.x;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HP -= 1;
        }

        if (Input.GetKey(KeyCode.KeypadEnter))
        {
            Attack();

            // 攻撃をしている時は動けない為return
            return;
        }

        if (Input.GetKeyUp(KeyCode.KeypadEnter))
        {
            anim.SetBool("AttackFlag", false);
        }

        #region 移動処理
        move_x = 0f;
        move_y = 0f;
        // ジャンプの処理
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (mystatus == Status.cheek && groundFlag == false) { return; }
            Jump();
        }

        // 歩く処理
        if (Input.GetKey(KeyCode.A))
        {
            Walk(-1);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Walk(1);
        }

        // 走る処理
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.A))
        {
            Run(-1);
        }

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.D))
        {
            Run(1);
        }

        if (groundFlag)
        {
            
        }

        var move = move_x * transform.right;
        rb.velocity = new Vector2(move.x, rb.velocity.y);
        MoveResriction();
        #endregion 

        #region Animation関連
        if (rb.velocity.x <= 1 || rb.velocity.x >= -1)
        {
            anim.SetInteger("walkSpeed", 0);
        }

        if (rb.velocity.x > 1 || rb.velocity.x < -1)
        {
            anim.SetInteger("walkSpeed", 1);
        }

        if (rb.velocity.x > 3 || rb.velocity.x < -3)
        {
            anim.SetInteger("walkSpeed", 3);
        }

        if (groundFlag)
        {
            anim.SetBool("isGround", true);
        }
        else
        {
            anim.SetBool("isGround", false);
        }

        if (rb.velocity.y < -1)
        {
            anim.SetTrigger("FallFlag");
        }

        Debug.Log(rb.velocity.y);
        #endregion
    }

    private void ReStart()
    {

    }

    private void GameOver()
    {

    }

    public override void Attack()
    {
        base.Attack();
        anim.SetBool("AttackFlag", true);
    }

    public override void Jump()
    {
        base.Jump();
        //if (groundFlag == false) { return; }
        anim.SetTrigger("jumpFlag");
    }
}
