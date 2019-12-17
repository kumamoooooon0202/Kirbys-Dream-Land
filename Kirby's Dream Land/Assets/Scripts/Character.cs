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

    protected float move_x;

    protected Rigidbody2D rb;
    protected Animator anim;

    DirectionType myDirectionType;

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
        
    }

    void Update()
    {
        
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
    public void Jump()
    {
        rb.AddForce(Vector3.up * jumpSpeed);
        anim.SetTrigger("jumpFlag");
    }

    /// <summary>
    /// 攻撃
    /// </summary>
    public virtual void Attack()
    {
        anim.SetBool("AttackFlag", true);
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
