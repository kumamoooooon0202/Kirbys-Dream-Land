using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    [SerializeField] private GameObject kirbyHp;
    [SerializeField] private Text score;
    [SerializeField] private Text kirbyLife;
    private static int nowScore = 0;

    void Start()
    {
        
    }

    void Update()
    {
        score.text = "SCORE : " + nowScore.ToString("00000000");
        kirbyLife.text = "×" + Player.life.ToString("00");
    }

    public static void AddScore()
    {
        nowScore += 500;
    }

    public static void DelLife()
    {
        Player.life -= 1;
    }
}
