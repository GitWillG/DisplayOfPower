﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using efe;

public class spellManager : MonoBehaviour
{

    [Header("Casting Abiliy Info")]
    public GameObject sourceReference;
    public GameObject targetReference;
    public spellSO _spellDEMO;
    public Material _baseMaterial;
    factionManager fm;
    GameObject projectile;
    [Header("Spell Preview Types")]
    public GameObject circle_radius_preview;
    public GameObject single_radius_preview;
    MouseControl mc;
    GUIManager guim;
    spellSO curSpellPreview;
    // Cast type tracking
    string[] castTypes = {"Single", "Area"};
    string curCastType;
    public bool castPreviewEnabled = false;
    spellSO curSpell;
    // Start is called before the first frame update
    void Start()
    {   
        // StartCoroutine(castSpell(sourceReference, targetReference, _spellDEMO));
        fm = GetComponent<factionManager>();
        mc = GameObject.FindGameObjectWithTag("SM").GetComponent<MouseControl>();
        guim = GetComponent<GUIManager>();
    }

    // Update is called once per frame
    void Update()
    {   
        processPreview();
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
                    // Debug.Log("Projectile destroyed.");

                    factionSO sourceFaction = projData.source.GetComponent<actorData>().ownerFaction;
                    factionSO targetFaction = projData.target.GetComponent<actorData>().ownerFaction;
                    if(sourceFaction == null && targetFaction == null)
                    {
                        return;
                    }

                    fm.changeDiplomacyByReference(sourceFaction, targetFaction, -15);
                    // fm.changeDiplomacyByString("Fire Water Fearless", 2);
                    break;
                }
                else
                {
                    projectile.transform.position = Vector3.MoveTowards(
                    projectile.transform.position, 
                    projData.target.transform.position,
                    projData.referenceSpell.spellMoveSpeed * Time.deltaTime
                    );
                    // Debug.Log(projectile.name + " moving to " + projData.target.name);
                }
                
            }
            else
            {
                return;
            }
        }
    }

    public void startSpellPreview()
    {   
        GameObject preview;
        if(mc.selectedTarget.GetChild(0).GetComponent<actorData>().spells[0].SkillTargetHandling == spellSO.targetHandling.area)
        {   
            preview = Instantiate(circle_radius_preview, transform.position, Quaternion.identity);
            curCastType = castTypes[1];

        }
        else if(mc.selectedTarget.GetChild(0).GetComponent<actorData>().spells[0].SkillTargetHandling == spellSO.targetHandling.single)
        {
            preview = Instantiate(single_radius_preview, transform.position, Quaternion.identity);
            curCastType = castTypes[0];
        }   
        castPreviewEnabled = true;
        Cursor.SetCursor(guim.cursor_textures[1], Vector2.zero, CursorMode.Auto);

        // Remove already existing previews if there is one
        // GameObject[] radiusPreviews = GameObject.FindGameObjectsWithTag("RadiusPreview");
        // if(radiusPreviews != null)
        // {
        //     foreach(GameObject temp in radiusPreviews)
        //     {
        //         Destroy(temp);
        //     }
        // }
        // mc.isMoving = true;
        // curSpellPreview = mc.selectedTarget.GetChild(0).GetComponent<actorData>().spells[0];
        // else if(spellData.SkillTargetHandling == spellSO.targetHandling.single)
        // {

        // }
    }

    public void processPreview()
    {   
        GameObject currentSelectedCharacter = mc.selectedTarget.GetChild(0).gameObject;
        curSpell = mc.selectedTarget.GetChild(0).GetComponent<actorData>().spells[0];
        if(castPreviewEnabled)
        {
            if(curCastType == "Area" || curCastType == "Single")
            {
                GameObject[] radius = GameObject.FindGameObjectsWithTag("RadiusPreview");
                foreach(GameObject temp in radius)
                {
                    if(radius != null)
                    {
                        Vector3 tempMouse = Input.mousePosition;
                        tempMouse.z = 11;
                        temp.transform.position = Camera.main.ScreenToWorldPoint(tempMouse);
                        //      
                        if(Input.GetMouseButtonDown(0))
                        {
                            Destroy(temp);
                            castPreviewEnabled = false;
                            Debug.Log("Preview finished.");
                            //      
                            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                            RaycastHit hit;
                            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                            {
                                if(hit.transform.gameObject.tag == "NPC")
                                {
                                    castSpell(currentSelectedCharacter, hit.transform.gameObject, curSpell);
                                    Cursor.SetCursor(guim.cursor_textures[0], Vector2.zero, CursorMode.Auto);
                                    // mc.isMoving = false;
                                }
                                else
                                {
                                    Debug.Log("There is no NPCs in this area.");
                                }
                            }
                        }
                    }   
                }
            }
        }
    }

    public void castSpell(GameObject source, GameObject target, spellSO spellData)
    {
        actorData sourceActor = source.GetComponent<actorData>();
        actorData targetActor = target.GetComponent<actorData>();
        Animator sourceAnimator = source.GetComponent<Animator>();
        Animator targetAnimator = target.GetComponent<Animator>();
        
        // yield return new WaitForSeconds(1);

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
            projectile.transform.localScale *= spellData.sizeMultiplier /4;
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
            // Debug.Log("Spell casted.");
        }
        
    }
}
