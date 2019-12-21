using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected int hp = 10;
    [SerializeField] protected int max_hp = 10;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float jumpSpeed;
    [SerializeField] protected bool groundFlag;
    [SerializeField] protected bool attackFlag;
    [SerializeField] protected bool invincibleFlag;

    [SerializeField] protected Transform farstBG;
    [SerializeField] protected Transform lastBG;


    protected float move_x;
    protected float posDif;

    protected Rigidbody2D rb;
    protected Animator anim;

    protected DirectionType myDirectionType;
    [SerializeField] protected Status mystatus;

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

    /// <summary>
    /// 歩く
    /// </summary>
    /// <param name="direction">1:右 -1:左</param>
    public virtual void Walk(int direction)
    {
        move_x += moveSpeed * direction;
        this.transform.localScale = new Vector3(direction, 1, 1);
        if (direction < 0)
        {
            myDirectionType = DirectionType.left;
        }
        else
        {
            myDirectionType = DirectionType.right;
        }
    }

    /// <summary>
    /// 走る
    /// </summary>
    /// <param name="direction">1:右 -1:左</param>
    public void Run(int direction)
    {
        move_x += moveSpeed * direction * 2;
        this.transform.localScale = new Vector3(direction, 1, 1);
        if (direction < 0)
        {
            myDirectionType = DirectionType.left;
        }
        else
        {
            myDirectionType = DirectionType.right;
        }
    }

    /// <summary>
    /// ジャンプ
    /// </summary>
    public virtual void Jump()
    {
        rb.AddForce(Vector3.up * jumpSpeed);
    }

    /// <summary>
    /// 攻撃
    /// </summary>
    public virtual void Attack()
    {
        switch (mystatus)
        {
            // 敵
            case Status.enemy:
                break;

            // 通常
            case Status.normal:
                Debug.Log("吸い込み攻撃！");
                break;

            // 頬張り
            case Status.cheek:
                Debug.Log("吐き出し攻撃！");
                break;

            // ビーム
            case Status.beam:
                Debug.Log("ビーム攻撃！");
                break;

            // ファイア
            case Status.fire:
                Debug.Log("ファイア攻撃！");
                break;

            // カッター
            case Status.cutter:
                Debug.Log("カッター攻撃！");
                break;

            // ソード
            case Status.seord:
                Debug.Log("ソード攻撃！");
                break;

            default:
                break;
        }
    }

    /// <summary>
    /// ダメージ
    /// </summary>
    /// <param name="power">ダメージ量</param>
    public void Damege(int power)
    {

    }

    /// <summary>
    /// 回復
    /// </summary>
    /// <param name="val">回復量</param>
    public void Recover(int val)
    {

    }

    /// <summary>
    /// 移動制限
    /// </summary>
    protected void MoveResriction()
    {
        if (transform.position.x < farstBG.position.x + posDif)
        {
            transform.position = new Vector3(farstBG.position.x + posDif, this.transform.position.y, 0);
        }
        if (transform.position.x > lastBG.position.x - posDif)
        {
            transform.position = new Vector3(lastBG.position.x - posDif, this.transform.position.y, 0);
        }
    }

    /// <summary>
    /// 接地判定
    /// </summary>
    /// <param name="collision"></param>
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
