using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEffectController : MonoBehaviour
{
    private static ParticleSystem deathEffect;
    private static Transform transform;

    void Start()
    {
        deathEffect = GetComponent<ParticleSystem>();
        transform = GetComponent<Transform>();
    }

    public static void DeathEffect(Vector3 pos)
    {
        transform.position = pos;
        deathEffect.Play();
    }
}
