using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    private Text text;

    private string[] sentence = new string[5];
    private int sentenceNum = -1;
    private int textNum;

    private float textSpeed = 0.1f;
    private float maxTextSpeed;

    private bool textFlag = false;

    void Start()
    {
        text = GetComponent<Text>();
        Sentence();
        maxTextSpeed = textSpeed;
    }

    void Update()
    {
        if (sentenceNum > 4) { return; }

        if (Input.GetMouseButtonDown(0)/* && a == false*/) // ここ付ければスキップ不可能
        {
            textNum = 0;
            textFlag = true;
            sentenceNum++;
        }

        textSpeed -= Time.deltaTime;
        if (textSpeed <= 0 && textFlag)
        {
            DisplaySentence();
            textSpeed = maxTextSpeed;
            textNum++;
            if (sentence[sentenceNum].Length == textNum - 1)
            {
                textFlag = false;
            }
        }
    }

    public void Sentence()
    {
        sentence[0] = "こんにちは";
        sentence[1] = "私は神です";
        sentence[2] = "松下竜祐くん";
        sentence[3] = "UNDERHEAVEN";
        sentence[4] = "HalfToyParty";
    }

    public void DisplaySentence()
    {
        text.text = sentence[sentenceNum].Substring(0, textNum);
    }
}
