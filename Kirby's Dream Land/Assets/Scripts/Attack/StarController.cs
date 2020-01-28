using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    private Transform myTransform;
    private GameObject chara;
    private Vector3 pos;
    Character.DirectionType starDir;

    void Start()
    {
        myTransform = GetComponent<Transform>();
        chara = GameObject.Find("Player");
        pos = myTransform.localPosition;
        starDir = chara.GetComponent<Player>().myDirectionType;
    }

    void Update()
    {
        myTransform.Rotate(new Vector3(0, 0, -5));
        pos = myTransform.position;
        if (starDir == Character.DirectionType.left)
        {
            pos.x -= 0.1f;
        }
        if (starDir == Character.DirectionType.right)
        {
            pos.x += 0.1f;
        }
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(gameObject);
        }
        myTransform.position = pos;
    }

    /// <summary>
    /// 床、壁に触れたら消える
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == "Enemy")
        //{
        //    DeathEffectController.DeathEffect(collision.gameObject.transform.position);
        //    Destroy(collision.gameObject);
        //}
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
