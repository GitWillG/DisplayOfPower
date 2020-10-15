using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using efe;


namespace efe {

[CreateAssetMenu(menuName = "Spells/Create new...")]
public class spellSO : ScriptableObject
{   
    public GameObject overwriteParticles;
    public bool useOverwrite;

    public enum targetHandling { area, single, self}
    public enum allowedTargets {ally, enemy}

    public enum skillShape { sphere, cube} // DONE
    // public enum types { passive, activeInstant, activeToMouse } // TODO
    public enum nature { earth, ice, fire, arcane, air, life, death, water }
    public enum castAnimationTypes { type_1, type_2, type_3 } // DONE
    public enum spawnPosition
    {
        head, rhand, lhand, chest,
        casterForward, casterBackward, casterRight, casterLeft
    }
    
    public enum effectTypes
    {
        additive, substractive
    }

    public enum visualType
    {
        material, color
    }

    public int spellID; // DONE

    [Header("Base Design")]
    [Space(10)]
    public string spellName; // DONE
    public int effectAmount; // damage for fireball, heal amount for heal
    public effectTypes effectType;
    // public int manaCost; // TODO
    public float cooldown; // DONE
    public float castingDuration; // DONE
    public float delayPostCast; // DONE
    public float spellMoveSpeed; // DONE
    public int spellRange;
    public int actionNeeded;


    // GUI
    public Sprite spellIcon;

    // Skill tree 
    [Header("Skill Aesthetics")]
    [Space(10)]
    public nature SkillNature;
    public skillShape shape; // DONE
    public visualType visualizationMethod;
    public Color baseColor; // DONE
    public Material baseMaterial;
    public float sizeMultiplier; // DONE
    public ParticleSystem skillAura; // DONE

    // Trigger type
    [Header("Trigger Parameters")]
    [Space(10)]
    // public types SkillType; // TODO

    // Skill target system
    [Header("Target Parameters")]
    [Space(10)]
    public targetHandling SkillTargetHandling;
    public allowedTargets allowedTarget;

    // Animation the caster rigged gameobject will play
    [Header("Animation Info")]
    [Space(10)]
    public castAnimationTypes SkillCasterAnimation;
    public bool playEndAnimation;
    public castAnimationTypes SkillEndAnimation;

    // Where should this skill spawn?
    [Header("Spawn & Pyshics Parameters")]
    [Space(10)]
    // public spawnPosition particleSpawnBone; // TODO
    public int heightFromGroundLevel; // DONE
    // public int fallSpeed; // TODO
    public int spawnAmount; // DONE

    [Header("Particle Parameters")]
    [Space(10)]
    // The particle that will spawn on caster
    public GameObject casterParticle;
    // public bool trailWaitForCaster; // TODO
    // The particle that will move to target
    public GameObject targetParticle;
    // public bool returnTrailAfterEnd;

    [Header("Audio")]
    public AudioSource castSFX;
    public AudioSource impactSFX;

    // Screen Effects

    // Camera Effects

    // Environmental Effects

    [Header("Extras")]
    public bool resizeCasterUponCast;
    public bool resizeCasterUponEnd;
    public int resizeAmount;
    // public bool enableOutlineOnStart;
    // public bool enableOutlineOnEnd;
    // public Color outlineColor;



    
}
}