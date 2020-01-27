using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] private ItemType itemType;
    Player player;

    private enum ItemType
    {
        tomato,
        candy,
    }

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (itemType)
            {
                case ItemType.candy:
                    Destroy(gameObject);
                    break;

                case ItemType.tomato:
                    player.Recover(6);
                    Destroy(gameObject);
                    break;
            }
        }
    }
}
