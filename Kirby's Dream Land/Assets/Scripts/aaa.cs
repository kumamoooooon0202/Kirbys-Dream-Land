using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aaa : MonoBehaviour
{
    private Rigidbody2D char_rb;
    float move_x;
    public float jumpspeed;
    public float speed = 2.0f;

    void Start()
    {
        char_rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        move_x = 0f;
        if (Input.GetKey(KeyCode.D))
        {
            move_x += speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            move_x -= speed;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            char_rb.AddForce(Vector3.up * jumpspeed);
        }
        var move = move_x * transform.right;
        char_rb.velocity = new Vector2(move.x, char_rb.velocity.y);
    }
}
