using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    [SerializeField] private GameObject kirbyHp;
    [SerializeField] private Text score;
    [SerializeField] private Text kirbyLife;

    void Start()
    {
        score.text = "SCORE : 00000000";
    }

    void Update()
    {
        kirbyLife.text = "×" + Player.life.ToString("00");
    }
}
