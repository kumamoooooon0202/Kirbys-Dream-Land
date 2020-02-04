using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private AudioClip jump;        // ジャンプ
    [SerializeField] private AudioClip hovering;    // ホバリング
    [SerializeField] private AudioClip landing;     // 着地
    [SerializeField] private AudioClip run;         // 走り
    [SerializeField] private AudioClip damege;      // ダメージ
    [SerializeField] private AudioClip vacuum;      // 吸い込み
    [SerializeField] private AudioClip spitting;    // 吐き出し
    [SerializeField] private AudioClip beam;        // ビーム
    [SerializeField] private AudioClip fire;        // ファイア
    [SerializeField] private AudioClip cutter;      // カッター
    [SerializeField] private AudioClip sword;       // ソード
    [SerializeField] private AudioClip death;       // 死亡

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    /// <summary>
    /// 攻撃時の効果音
    /// </summary>
    /// <param name="status"></param>
    public void ChangeAttackAudio(Player.Status status)
    {
        switch (status)
        {
            case Player.Status.normal:
                audioSource.clip = vacuum;
                break;

            case Player.Status.cheek:
                audioSource.clip = spitting;
                break;

            case Player.Status.beam:
                audioSource.clip = beam;
                break;

            case Player.Status.fire:
                audioSource.clip = fire;
                break;

            case Player.Status.cutter:
                audioSource.clip = cutter;
                break;

            case Player.Status.sword:
                audioSource.clip = sword;
                break;
        }
        if (audioSource.clip == null) return;
        // Audioの再生
        audioSource.Play();
    }

    public void JumpAudio()
    {
        audioSource.PlayOneShot(jump);
    }

    /// <summary>
    /// ダメージ音
    /// </summary>
    public void DamegeAusio()
    {
        audioSource.clip = damege;
        audioSource.Play();
    }

    /// <summary>
    /// 効果音を止める
    /// </summary>
    public void AudioStop()
    {
        audioSource.Stop();
    }

    /// <summary>
    /// 死亡音
    /// </summary>
    public void DeathAudio()
    {
        audioSource.clip = death;
        audioSource.Play();
    }
}
