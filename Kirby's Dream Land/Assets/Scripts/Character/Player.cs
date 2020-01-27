using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
    private static int HP = 0;
    public static int CharacerHp()
    {
        return HP;
    }
    [SerializeField] protected int max_hp = 6;
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
        HP = max_hp;
    }

    void Update()
    {
        directionTypeNum = (int)myDirectionType;
        Debug.Log(directionTypeNum);


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

        // しゃがむ
        Squat();

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
            Run(directionTypeNum);
        }

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.D))
        {
            Run(directionTypeNum);
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

    /// <summary>
    /// リスタート
    /// </summary>
    private void ReStart()
    {

    }

    /// <summary>
    /// ゲームオーバー
    /// </summary>
    private void GameOver()
    {

    }

    /// <summary>
    /// しゃがむ
    /// </summary>
    private void Squat()
    {
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.localScale = new Vector3(directionTypeNum, 0.5f, 1);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            this.transform.localScale = new Vector3(directionTypeNum, 1, 1);
        }
    }

    /// <summary>
    /// 攻撃
    /// </summary>
    public override void Attack()
    {
        base.Attack();
        rb.velocity = new Vector2(0, rb.velocity.y);
        anim.SetBool("AttackFlag", true);
    }

    /// <summary>
    /// ジャンプ
    /// </summary>
    public override void Jump()
    {
        base.Jump();
        //if (groundFlag == false) { return; }
        anim.SetTrigger("jumpFlag");
    }

    /// <summary>
    /// ダメージ
    /// </summary>
    /// <param name="power">ダメージ量</param>
    public void Damege(int power)
    {
        HP = HP - power;
    }

    /// <summary>
    /// 回復
    /// </summary>
    /// <param name="val">回復量</param>
    public void Recover(int val)
    {
        if (max_hp <= HP + val)
        {
            HP = max_hp;
        }
        else
        {
            HP = HP + val;
        }
    }
}
