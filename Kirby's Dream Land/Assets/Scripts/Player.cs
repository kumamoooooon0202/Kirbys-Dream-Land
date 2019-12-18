using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private int life;
    [SerializeField] private float hoveringSpeed;
    private bool hoveringFlag;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
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
        // ジャンプの処理
        if (Input.GetKeyDown(KeyCode.Space))
        {
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

        var move = move_x * transform.right;
        rb.velocity = new Vector2(move.x, rb.velocity.y);
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
    }

    // 当たり続けている間、値がとれたらいいなぁ
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Door")
    //    {
    //        Debug.Log("aaa");
    //    }
    //}
}
