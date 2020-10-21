using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using efe;


namespace efe {

[CreateAssetMenu(menuName = "Spells/Create new...")]
public class spellSO : ScriptableObject
{   
    [Space(5)]
    [Header("Hover your mouse to parameters to learn more.")]
    [Space(5)]
    [Header("SPELL EDITOR")]
    [Tooltip("If you are outsourcing the projectile - eg, an asset store particle, put it here as a prefab, then check useOverwrite.")]
    public GameObject overwriteParticles;
    public bool useOverwrite;

    public enum targetHandling { area, single, self, selfaround}
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
    [Tooltip("Name of the spell.")]
    public string spellName; // DONE
    [Header("Damage/Healing Functionality")]
    [Tooltip("Set enable effects on if you want etc: Fireball to damage or Heal to heal. Off, if you want spells like Teleportation or Sleep.")]
    public bool enableEffects;
    public int effectAmount; // damage for fireball, heal amount for heal
    public effectTypes effectType;
    [Header("Substractive Spell Properties")]
    public bool applyStatus;
    public int statusDuration;
    public int damagePerTurn;
    public bool isProjectileBased;
    // public int manaCost; // TODO
    [Header("Other Gameplay Functionality")]
    public float cooldown; // DONE
    public float castingDuration; // DONE
    public float delayPostCast; // DONE
    public float spellMoveSpeed; // DONE
    public int spellRange;
    [Tooltip("Action point cost after casting a spell.")]
    public int actionNeeded;


    [Tooltip("2D sprite used for GUI for this icon. Size doesn't matter. Ratio must be 1:1, square.")]
    // GUI
    public Sprite spellIcon;

    // Skill tree 
    [Header("Skill Aesthetics")]
    [Space(10)]
    [Tooltip("If you are not outsourcing, then you can use here to create a projectile of your own.")]
    public nature SkillNature;
    [Tooltip("Base shape of the projectile.")]
    public skillShape shape; // DONE
    [Tooltip("You can assign a single color or a material to the projectile here. Choose the method.")]
    public visualType visualizationMethod;
    public Color baseColor; // DONE
    public Material baseMaterial;
    [Tooltip("Adjusts the size of the projectile.")]
    public float sizeMultiplier; // DONE
    [Tooltip("This is a particle system that will be attached on projectile as it moves. E.g - it can be a smoke particle on a meteor.")]
    public ParticleSystem skillAura; // DONE

    // Trigger type
    [Header("Trigger Parameters")]
    [Space(10)]
    // public types SkillType; // TODO

    // Skill target system
    [Header("Target Parameters")]
    [Space(10)]
    [Tooltip("This parameter controls whether a skill is single-cast or area. They will have different previews in battle. Area spell will deal effects to both ally and enemy.")]
    public targetHandling SkillTargetHandling;
    [Tooltip("Set constraints on which type of actors you can use this spell on. E.g - heal on allies, fireball on enemies")]
    public allowedTargets allowedTarget;

    // Animation the caster rigged gameobject will play
    [Header("Animation Info")]
    [Space(10)]
    [Tooltip("This animation plays when an actor casts this spell.")]
    public castAnimationTypes SkillCasterAnimation;
    [Tooltip("This is extra. But might be cool if you want actor to play an animation when spell is finished. This is called when spell deals its effects, not after casting is done.")]
    public bool playEndAnimation;
    [Tooltip("After you check playEndAnimation, you can choose which animation for actor to play.")]
    public castAnimationTypes SkillEndAnimation;

    // Where should this skill spawn?
    [Header("Spawn & Pyshics Parameters")]
    [Space(10)]
    // public spawnPosition particleSpawnBone; // TODO
    [Tooltip("This is the distance projectile will preserve between the ground and itself.")]
    public int heightFromGroundLevel; // DONE
    // public int fallSpeed; // TODO
    [Tooltip("How many projectiles you want to spawn? This effects both overwrriten and customized projectiles.")]
    public int spawnAmount; // DONE

    [Header("Particle Parameters")]
    [Space(10)]
    // The particle that will spawn on caster
    [Tooltip("The particle that will play upon actor casting this spell.")]
    public GameObject casterParticle;
    // public bool trailWaitForCaster; // TODO
    // The particle that will move to target
    [Tooltip("The particle that will play on target after actor cast this spell.")]
    public GameObject targetParticle;
    // public bool returnTrailAfterEnd;

    [Header("Audio")]
    [Tooltip("Audio to play after actor casts this spell.")]
    public AudioSource castSFX;
    [Tooltip("Audio to play after projectile reaches its target.")]
    public AudioSource impactSFX;

    // Screen Effects

    // Camera Effects

    // Environmental Effects

    [Header("Extras")]
    [Tooltip("You can make the actor bigger/smaller after cast. Extra.")]
    public bool resizeCasterUponCast;
    public bool resizeCasterUponEnd;
    [Tooltip("Adjust how much.")]
    public int resizeAmount;
    // public bool enableOutlineOnStart;
    // public bool enableOutlineOnEnd;
    // public Color outlineColor;



    
}
}