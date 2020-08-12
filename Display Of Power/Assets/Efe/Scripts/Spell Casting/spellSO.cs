using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spellSO : ScriptableObject
{
    public string spellName;
    public ParticleSystem startParticle;
    public ParticleSystem trailParticle;
    public ParticleSystem finishParticle;
    public GameObject particleBase;
    public float particleSpeed;
    public Animator particleAnimator;

    
}
