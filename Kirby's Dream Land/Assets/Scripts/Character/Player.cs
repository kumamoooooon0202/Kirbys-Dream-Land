using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
    public static int life = 3;
    [SerializeField] private float hoveringSpeed;
    private bool hoveringFlag;
    private ParticleSystem particle;
    ParticleController parcon;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        mystatus = Status.normal;
        posDif = transform.position.x - farstBG.position.x;
        particle = GetComponent<ParticleSystem>();
        parcon = GetComponent<ParticleController>();
        // 開幕はプログラム上、右を向いている為の処理
        myDirectionType = DirectionType.right;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Damege(1);
            Debug.Log("1のダメージ！");
        }

        if (Input.GetMouseButtonDown(1))
        {
            TextController.AddScore();
        }

        if (Input.GetMouseButtonDown(2))
        {
            TextController.DelLife();
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter) && mystatus == Status.normal)
        {
            parcon.ParticlePlay();
        }

        if (Input.GetKey(KeyCode.KeypadEnter))
        {
            Attack();
            // 攻撃をしている時は動けない為return
            return;
        }

        // Enterキーを離すまで吸い込みをする
        // Flagが立っている時
        if (Input.GetKeyUp(KeyCode.KeypadEnter) && cheekFlag)
        {
            // 吸い込んだので膨らんでいる状態
            mystatus = Status.cheek;
        }

        if (Input.GetKeyUp(KeyCode.KeypadEnter))
        {
            parcon.ParticleStop();
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

        //Debug.Log(rb.velocity.y);
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
        rb.velocity = new Vector2(0, 0);
        anim.SetBool("AttackFlag", true);
    }

    public override void Jump()
    {
        base.Jump();
        //if (groundFlag == false) { return; }
        anim.SetTrigger("jumpFlag");
    }
}
