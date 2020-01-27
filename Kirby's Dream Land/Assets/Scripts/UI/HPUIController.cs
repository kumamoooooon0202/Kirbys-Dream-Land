using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPUIController : MonoBehaviour
{
    private GameObject[] hpBox = new GameObject[6];
    [SerializeField] private Sprite Hp;
    [SerializeField] private Sprite notHp;

    private int playerHp;

    void Start()
    {
        for (int i = 0; i < hpBox.Length; i++)
        {
            hpBox[i] = this.transform.GetChild(i).gameObject;
        }
    }

    void Update()
    {
        playerHp = FindObjectOfType<Player>().CharacerHp();

        if (playerHp <= 0)
        {
            for (int i = 0; i < hpBox.Length; i++)
            {
                hpBox[i].GetComponent<Image>().sprite = notHp;
            }
            return;
        }
        for (int i = 0; i < playerHp; i++)
        {
            hpBox[i].GetComponent<Image>().sprite = Hp;
        }

        for (int i = playerHp; i < hpBox.Length; i++)
        {
            hpBox[i].GetComponent<Image>().sprite = notHp;
        }
    }
}
