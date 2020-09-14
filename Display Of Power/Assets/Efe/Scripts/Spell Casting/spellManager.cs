using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using efe;

public class spellManager : MonoBehaviour
{

    public GameObject sourceReference;
    public GameObject targetReference;
    public spellSO _spellDEMO;
    public Material _baseMaterial;

    GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {   
        StartCoroutine(castSpell(sourceReference, targetReference, _spellDEMO));
    }

    // Update is called once per frame
    void Update()
    {   
        
        GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Projectile");
        foreach(GameObject projectile in projectiles)
        {
            if(projectile != null)
            {
                projectileData projData = projectile.GetComponent<projectileData>();
                float distance = Vector3.Distance(projectile.transform.position, projData.target.transform.position);
                
                if(distance < 1)
                {
                    Destroy(projectile);
                    projData.target.GetComponent<Animator>().SetTrigger("Die");
                    Debug.Log("Projectile destroyed.");
                    break;
                }
                else
                {
                    projectile.transform.position = Vector3.MoveTowards(
                    projectile.transform.position, 
                    projData.target.transform.position,
                    projData.referenceSpell.spellMoveSpeed * Time.deltaTime
                    );
                    Debug.Log(projectile.name + " moving to " + projData.target.name);
                }
                
            }
            else
            {
                return;
            }
        }
    }

    IEnumerator castSpell(GameObject source, GameObject target, spellSO spellData)
    {
        actorData sourceActor = source.GetComponent<actorData>();
        actorData targetActor = target.GetComponent<actorData>();
        Animator sourceAnimator = source.GetComponent<Animator>();
        Animator targetAnimator = target.GetComponent<Animator>();
        
        yield return new WaitForSeconds(spellData.cooldown + spellData.castingDuration + spellData.delayPostCast);

        // Caster
        if(spellData.SkillCasterAnimation == spellSO.castAnimationTypes.type_1)
        {
            sourceAnimator.SetTrigger("Cast1");
        }
        else if(spellData.SkillCasterAnimation == spellSO.castAnimationTypes.type_2)
        {
            sourceAnimator.SetTrigger("Cast2");
        }
        else if(spellData.SkillCasterAnimation == spellSO.castAnimationTypes.type_3)
        {
            sourceAnimator.SetTrigger("Cast3");
        }

        // Spawn caster particle on caster
        Instantiate(spellData.casterParticle, source.transform.position, Quaternion.identity);
        // Spawn target particle on target
        Instantiate(spellData.targetParticle, target.transform.position, Quaternion.identity);
        // Debug.Log(1);
        for(int i = 0; i <= spellData.spawnAmount; i++)
        {
            // Debug.Log(2);
            // Spawn a primitive based on skill shape
            if(spellData.shape == spellSO.skillShape.cube)
            {
                projectile = GameObject.CreatePrimitive(PrimitiveType.Cube);
            }
            else if(spellData.shape == spellSO.skillShape.sphere)
            {
                projectile = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            }
            // Adjust ground level
            projectile.transform.position = new Vector3
            (
                source.transform.position.x,
                source.transform.position.y + spellData.heightFromGroundLevel,
                source.transform.position.z
            );
            // Used for tracking in update
            projectile.tag = "Projectile";
            // Add projectileData to projectile to store target and source
            projectileData projData = projectile.AddComponent<projectileData>();
            projData.source = source;
            projData.target = target;
            projData.referenceSpell = spellData;
            // Adjust size
            projectile.transform.localScale = new Vector3(1, 1, 1);
            projectile.transform.localScale *= spellData.sizeMultiplier;
            // Editor usage
            projectile.name = "Projectile from " + spellData.spellName + " " + spellData.spellID;
            // Spawn aura and attach
            GameObject aura = Instantiate(spellData.skillAura.gameObject, projectile.transform.position, Quaternion.identity);
            aura.transform.parent = projectile.transform;
            // Give material
            projectile.GetComponent<Renderer>().material = _baseMaterial;
            //Recolor
            projectile.GetComponent<Renderer>().material.color = spellData.baseColor;
            // Debug
            Debug.Log("Spell casted.");
        }
        
    }
}
