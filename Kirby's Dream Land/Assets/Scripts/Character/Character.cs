using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    #region 変数
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float jumpSpeed;
    [SerializeField] protected bool groundFlag;
    [SerializeField] protected bool attackFlag;
    [SerializeField] protected bool invincibleFlag;
    [SerializeField] protected Transform farstBG;
    [SerializeField] protected Transform lastBG;
    [SerializeField] private GameObject star;
    protected bool cheekFlag = false;

    protected float move_x;
    protected float move_y;
    protected float posDif;

    protected Rigidbody2D rb;
    protected Animator anim;

    public DirectionType myDirectionType;
    protected int directionTypeNum = 0;
    public Status mystatus;
    #endregion

    /// <summary>
    /// キャラクターの向いている方向
    /// </summary>
    public enum DirectionType
    {
        left = -1,
        up,
        right,
        down,
    }

    /// <summary>
    /// キャラクターの状態
    /// </summary>
    public enum Status
    {
        enemy,
        normal,
        cheek,
        beam,
        fire,
        cutter,
        sword,
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
                Vacuum(directionTypeNum);
                break;

            // 頬張り
            case Status.cheek:
                Debug.Log("吐き出し攻撃！");
                SpittingAttack(1);
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
            case Status.sword:
                Debug.Log("ソード攻撃！");
                break;

            default:
                break;
        }
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

        if (transform.position.y > 4.5)
        {
            transform.position = new Vector3(this.transform.position.x, 4.5f, 0);
            rb.velocity = new Vector2(0, 0);
        }
    }

    /// <summary>
    /// 吸い込み攻撃
    /// </summary>
    /// <param name="direction">1:右 -1:左</param>
    private void Vacuum(int direction)
    {
        Vector2 pos = new Vector2(this.transform.position.x + (direction * 2f), transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(pos, new Vector2(direction * 1, 0), 1f);
        Debug.DrawLine(this.transform.position, pos, Color.red);
        if (hit.collider == null) { return; }
        if (hit.collider.tag == "Enemy")
        {
            DeathEffectController.DeathEffect(hit.collider.transform.position);
            Destroy(hit.collider.gameObject);
            TextController.AddScore();
            cheekFlag = true;
        }
    }

    /// <summary>
    /// 吐き出し攻撃
    /// </summary>
    /// <param name="direction">1:右 -1:左</param>
    private void SpittingAttack(int direction)
    {
        // 吐き出し攻撃処理
        Instantiate(star, this.transform.position, Quaternion.identity);
        // 吐き出したのでノーマル状態に戻る
        mystatus = Status.normal;
        cheekFlag = false;
    }

    /// <summary>
    /// 接地判定
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            groundFlag = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            groundFlag = false;
        }
    }

}
