﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    private ParticleSystem particle;

    private void Start()
    {
        
    }

    public void ParticlePlay()
    {
        particle = GetComponent<ParticleSystem> ();
        particle.Play();
    }

    public void ParticleStop()
    {
        particle = GetComponent<ParticleSystem>();
        particle.Stop();
    }

    private void OnParticleTrigger()
    {
        
    }
}