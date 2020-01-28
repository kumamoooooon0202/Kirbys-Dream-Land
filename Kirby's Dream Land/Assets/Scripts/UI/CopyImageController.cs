using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CopyImageController : MonoBehaviour
{
    private Image nowStatus;
    [SerializeField] private Sprite normal;
    [SerializeField] private Sprite cheek;
    [SerializeField] private Sprite beam;
    [SerializeField] private Sprite fire;
    [SerializeField] private Sprite cutter;
    [SerializeField] private Sprite sword;

    private Character.Status playerStatus;
    
    void Start()
    {
        nowStatus = GetComponent<Image>();
    }

    void Update()
    {
        playerStatus = FindObjectOfType<Character>().mystatus;
        switch (playerStatus)
        {
            case Character.Status.normal:
                nowStatus.sprite = normal;
                break;

            case Character.Status.cheek:
                nowStatus.sprite = cheek;
                break;

            case Character.Status.beam:
                nowStatus.sprite = beam;
                break;

            case Character.Status.fire:
                nowStatus.sprite = fire;
                break;

            case Character.Status.cutter:
                nowStatus.sprite = cutter;
                break;

            case Character.Status.sword:
                nowStatus.sprite = sword;
                break;

            default:
                nowStatus.sprite = normal;
                break;

        }
    }
}
