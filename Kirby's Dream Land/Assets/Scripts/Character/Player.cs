using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : Character
{
    private int hp = 0;
    public int CharacerHp() { return hp; }
    [SerializeField] protected int max_hp = 6;
    public static int life = 0;
    [SerializeField] private float hoveringSpeed;
    private bool hoveringFlag = false;
    [SerializeField] private float invisibleTime;
    private float maxInvisibleTime;
    public bool InvisibleFlag
    {
        get { return invincibleFlag; }
        set { invincibleFlag = value; }
    }
    [SerializeField] private float time;
    private ParticleSystem particle;
    ParticleController parcon;
    SpriteRenderer sprite;
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
        hp = max_hp;
        maxInvisibleTime = invisibleTime;
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        GameOver();     // ゲームオーバー
        Invincible();   // 無敵時間
        FallDeath();    // 落下死判定
        Squat();        // しゃがむ

        directionTypeNum = (int)myDirectionType;

        if (Input.GetKeyDown(KeyCode.Return) && mystatus == Status.normal)
        {
            parcon.ParticlePlay();
        }

        if (Input.GetKey(KeyCode.Return))
        {
            Attack();
            // 攻撃をしている時は動けない為return
            return;
        }


        // Enterキーを離すまで吸い込みをする
        // Flagが立っている時
        if (Input.GetKeyUp(KeyCode.Return) && cheekFlag)
        {
            // 吸い込んだので膨らんでいる状態
            mystatus = Status.cheek;
        }

        if (Input.GetKeyUp(KeyCode.Return))
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
        if (hp == 0 && life == 0 || life < 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    /// <summary>
    /// 落下死判定
    /// </summary>
    private void FallDeath()
    {
        if (gameObject.transform.position.y <= -4)
        {
            life--;
            // リスタートの処理追加
            // 死亡アニメーション追加予定
        }
    }

    /// <summary>
    /// しゃがむ
    /// </summary>
    private void Squat()
    {
        // スライディングの追加
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
    public void Damege()
    {
        hp--;
    }

    /// <summary>
    /// 回復
    /// </summary>
    /// <param name="val">回復量</param>
    public void Recover(int val)
    {
        if (max_hp <= hp + val)
        {
            hp = max_hp;
        }
        else
        {
            hp = hp + val;
        }
    }

    /// <summary>
    /// 無敵
    /// </summary>
    public void Invincible()
    {
        if (invincibleFlag)
        {
            sprite.color = GetAlphaColor(sprite.color);
            invisibleTime -= Time.deltaTime;
            if (invisibleTime <= 0)
            {
                invincibleFlag = false;
                invisibleTime = maxInvisibleTime;
                sprite.color = new Color(1, 1, 1, 1);
            }
        }
    }

    /// <summary>
    /// キャラの点滅
    /// </summary>
    /// <param name="color"></param>
    /// <returns></returns>
    private Color GetAlphaColor(Color color)
    {
        time += Time.deltaTime * 15.0f;
        color.a = Mathf.Sin(time) * 0.5f + 0.5f;
        return color;
    }

    /// <summary>
    /// 敵に触れたらダメージ&無敵時間
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && invincibleFlag == false)
        {
            Damege();
            invincibleFlag = true;
        }
    }
}
