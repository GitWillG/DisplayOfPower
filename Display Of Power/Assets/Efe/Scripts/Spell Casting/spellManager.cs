﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using efe;
using TMPro;

public class spellManager : MonoBehaviour
{

    [Header("Casting Abiliy Info")]
    public GameObject sourceReference;
    public GameObject targetReference;
    public spellSO _spellDEMO;
    public Material _baseMaterial;
    factionManager fm;
    audioManager am;
    GameObject projectile;
    [Header("Spell Preview Types")]
    public GameObject circle_radius_preview;
    public GameObject single_radius_preview;
    MouseControl mc;
    immersionManager im;
    GUIManager guim;
    spellSO curSpellPreview;
    CameraControl cc;
    // Cast type tracking
    string[] castTypes = {"Single", "Area", "Self Around"};
    string curCastType;
    public bool castPreviewEnabled = false;
    spellSO curSpell;
    public GameObject spellCollisionObject;
    public int curIndexCallback;
    public GenerateGrid gg;
    public GameObject previewNotficiation;
    GameObject noteInstance;
    GameObject tempStatusParticle;
    BestClickToMove bctm;

    // Start is called before the first frame update
    void Start()
    {   
        // StartCoroutine(castSpell(sourceReference, targetReference, _spellDEMO));
        fm = GetComponent<factionManager>();
        mc = GameObject.FindGameObjectWithTag("SM").GetComponent<MouseControl>();
        guim = GetComponent<GUIManager>();
        am = GetComponent<audioManager>();
        im = GetComponent<immersionManager>();
        cc = Camera.main.GetComponent<CameraControl>();
        bctm = GameObject.FindGameObjectWithTag("SM").GetComponent<BestClickToMove>();

        processPassives();
    }

    // Update is called once per frame
    void Update()
    {      
        spellShortcuts();
        processPreview();
        
        GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Projectile");
        foreach(GameObject projectile in projectiles)
        {
            if(projectile != null)
            {
                projectileData projData = projectile.GetComponent<projectileData>();

                if(projData.referenceSpell.isProjectileBased == false || projData.referenceSpell.instant == true) 
                {
                    return;
                }
                else
                {

                    float distance = Vector3.Distance(projectile.transform.position, projData.target.transform.position);
                    
                    if(distance < 1)
                    {
                        Destroy(projectile);

                        // Spells like fireball...
                        if(projData.referenceSpell.enableEffects)
                        {
                            if(projData.referenceSpell.effectType == spellSO.effectTypes.substractive)
                            {
                                projData.target.GetComponent<actorData>().Life -= projData.referenceSpell.effectAmount;
                                // Kill if hp is lower than 0
                                if(projData.target.GetComponent<actorData>().Life <= 0)
                                {
                                    projData.target.GetComponent<Animator>().SetTrigger("Die");
                                    bctm.showDamage(projData.source, projData.target);
                                    mc.killUnit(projData.target);
                                }
                                else
                                {
                                    projData.target.GetComponent<Animator>().SetTrigger("takeHit");
                                    bctm.showDamage(projData.source, projData.target);
                                    
                                }
                            }
                            // Spells like healing...etc
                            else if (projData.referenceSpell.effectType == spellSO.effectTypes.additive)
                            {
                                projData.target.GetComponent<actorData>().Life += projData.referenceSpell.effectAmount;
                                bctm.showDamage(projData.source, projData.target);
                                // Debug.Log("Heal");
                            }
                        }


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
                
            }
            else
            {
                return;
            }
        }
    }

    /// <summary>
    /// This script governs the shortcut functionality to cast spells.
    /// </summary>
    void spellShortcuts()
    {
        
            if(mc.lastSelectedTarget == null) return;
            if(mc.isMoving) return;

            actorData data = mc.lastSelectedTarget.GetChild(0).GetComponent<actorData>();
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                if(data.spells[0] != null)
                {
                    startSpellPreview(data.spells[0]);
                }
                else
                {
                    Debug.Log("There is no spell in this slot.");
                }
            }
            if(Input.GetKeyDown(KeyCode.Alpha2))
            {
                if(data.spells[1] != null)
                {
                    startSpellPreview(data.spells[1]);      
                }
                else
                {
                    Debug.Log("There is no spell in this slot.");
                }
            }
            if(Input.GetKeyDown(KeyCode.Alpha3))
            {
                if(data.spells[2] != null)
                {
                    startSpellPreview(data.spells[2]);       
                }
                else
                {
                    Debug.Log("There is no spell in this slot.");
                }
            }
            if(Input.GetKeyDown(KeyCode.Alpha4))
            {
                if(data.spells[3] != null)
                {
                    startSpellPreview(data.spells[3]);            
                }
                else
                {
                    Debug.Log("There is no spell in this slot.");
                }
            }
        

    }


    // For spell shortcuts
    public void startSpellPreview(spellSO spellInQuestion)
    {   

        if(mc.selectedTarget == null) return;
        
        if(mc.lastSelectedTarget.GetChild(0).GetComponent<actorData>().cooldownCounters[curIndexCallback] > 0) 
        {
            guim.updateLog("Spell is in cooldown.", Color.yellow);
            return;
        }
        if(spellInQuestion.isPassive) return;

        GameObject preview;
        noteInstance = Instantiate(previewNotficiation, new Vector2(Screen.width / 2, Screen.height / 2 - 200), Quaternion.identity);
        TextMeshProUGUI noteText = noteInstance.transform.Find("BG").transform.Find("Text").GetComponent<TextMeshProUGUI>();
        
        if(spellInQuestion.SkillTargetHandling == spellSO.targetHandling.area)
        {   
            preview = Instantiate(circle_radius_preview, transform.position, Quaternion.identity);
            curCastType = castTypes[1];
            noteText.text = "Target an area to cast the spell.";
        }
        else if(spellInQuestion.SkillTargetHandling == spellSO.targetHandling.single)
        {
            if(spellInQuestion.allowedTarget == spellSO.allowedTargets.enemy)
            {
                noteText.text = "Target an enemy to cast the spell.";
            }
            else
            {
                noteText.text = "Target an ally to cast the spell.";
            }
            // preview = Instantiate(single_radius_preview, transform.position, Quaternion.identity);
            curCastType = castTypes[0];
        }   
        else if(spellInQuestion.SkillTargetHandling == spellSO.targetHandling.selfaround)
        {
            curCastType = castTypes[2];
            noteText.text = "Click again to cast the spell.";
        }
       
        castPreviewEnabled = true;
        Cursor.SetCursor(guim.cursor_textures[1], Vector2.zero, CursorMode.Auto);
        Debug.Log("Started spell preview. " + spellInQuestion.spellName);
        Destroy(noteInstance, 3);
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

    // For skillbar
    public void startSpellPreview()
    {   

        if(mc.selectedTarget == null) return;

        if(mc.lastSelectedTarget.GetChild(0).GetComponent<actorData>().cooldownCounters[curIndexCallback] > 0) 
        {
            guim.updateLog("Spell is in cooldown.", Color.yellow);
            return;
        }

        if(mc.lastSelectedTarget.GetChild(0).GetComponent<actorData>().spells[curIndexCallback].isPassive) return;

        GameObject preview;
        noteInstance = Instantiate(previewNotficiation, new Vector2(Screen.width / 2, Screen.height / 2 - 200), Quaternion.identity);
        TextMeshProUGUI noteText = noteInstance.transform.Find("BG").transform.Find("Text").GetComponent<TextMeshProUGUI>();
        
        // Passive spells cannot be casted
        

        if(mc.lastSelectedTarget.GetChild(0).GetComponent<actorData>().spells[curIndexCallback].SkillTargetHandling == spellSO.targetHandling.area)
        {   
            preview = Instantiate(circle_radius_preview, transform.position, Quaternion.identity);
            curCastType = castTypes[1];
            noteText.text = "Target an area to cast the spell.";

        }
        else if(mc.lastSelectedTarget.GetChild(0).GetComponent<actorData>().spells[curIndexCallback].SkillTargetHandling == spellSO.targetHandling.single)
        {
           
            if(mc.lastSelectedTarget.GetChild(0).GetComponent<actorData>().spells[curIndexCallback].allowedTarget == spellSO.allowedTargets.enemy)
            {
                noteText.text = "Target an enemy to cast the spell.";
            }
            else
            {
                noteText.text = "Target an ally to cast the spell.";
            }
            // preview = Instantiate(single_radius_preview, transform.position, Quaternion.identity);
            curCastType = castTypes[0];
        }  
        else if(mc.lastSelectedTarget.GetChild(0).GetComponent<actorData>().spells[curIndexCallback].SkillTargetHandling == spellSO.targetHandling.selfaround)
        {
            curCastType = castTypes[2];
            noteText.text = "Click again to cast the spell.";
        }
        // Destroy(noteInstance);

        mc.removeRangeInd();
        mc.clickedHex = true;
        mc.selectedTarget = mc.lastSelectedTarget;
        gg.checkAttackLegality(mc.lastSelectedTarget.GetChild(0).GetComponent<actorData>().spells[curIndexCallback].spellRange, 
            mc.lastSelectedTarget.gameObject, 
            mc.legalMove);

        mc.currentMask = 1 << 10;


        castPreviewEnabled = true;
        Cursor.SetCursor(guim.cursor_textures[1], Vector2.zero, CursorMode.Auto);
        Destroy(noteInstance, 3);
        // Debug.Log("Started spell preview.");
        
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
        if (mc.lastSelectedTarget.GetChild(0).GetComponent<actorData>().spells.Length  > 0)
        {
            if (mc.lastSelectedTarget.GetChild(0).GetComponent<actorData>().spells[curIndexCallback].isPassive) return;
        }

        if(castPreviewEnabled == false) return;
        // if(mc.lastSelectedTarget.GetChild(0) == null) return;
        
        if(mc.lastSelectedTarget == null) return;
            // mc.selectedTarget = mc.lastSelectedTarget;
            GameObject currentSelectedCharacter = mc.lastSelectedTarget.GetChild(0).gameObject;
        if (mc.lastSelectedTarget.GetChild(0).GetComponent<actorData>().spells.Length > 0)
        {
            if (mc.lastSelectedTarget.GetChild(0).GetComponent<actorData>().spells[curIndexCallback] == null) return;
        }
            Debug.Log(curIndexCallback);
            curSpell = mc.lastSelectedTarget.GetChild(0).GetComponent<actorData>().spells[curIndexCallback];
            if(castPreviewEnabled)
            {
                if(curCastType == "Area")
                {
                    GameObject[] radius = GameObject.FindGameObjectsWithTag("RadiusPreview");
                    foreach(GameObject temp in radius)
                    {
                        if(radius != null)
                        {   
                            RaycastHit hit_preview;
                            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit_preview, Mathf.Infinity, 1 << 17))
                            {
                                if(hit_preview.transform.tag == "Terrain")
                                {
                                    temp.transform.position = new Vector3
                                    (
                                        hit_preview.point.x,
                                        hit_preview.point.y,
                                        hit_preview.point.z
                                    );
                                    Debug.Log(hit_preview.transform.gameObject.name);
                                }
                            }
                            
                            //      
                            if(Input.GetMouseButtonDown(0) && gg.legalHex.Contains(hit_preview.transform.gameObject))
                            {
                                Destroy(temp);
                                castPreviewEnabled = false;
                                Debug.Log("Preview finished.");
                                Cursor.SetCursor(guim.cursor_textures[0], Vector2.zero, CursorMode.Auto);
                                

                                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                                RaycastHit hit;
                                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                                {
                                    // if(hit.transform.gameObject.tag == "NPC")
                                    // {
                                        castSpell(currentSelectedCharacter, hit.transform.gameObject, curSpell);
                                        // mc.isMoving = false;
                                    // }
                                    // else
                                    // {
                                    //     Debug.Log("There is no NPCs in this area.");
                                    // }
                                }
                            }
                            else if(Input.GetMouseButtonDown(1))
                            {
                            
                            Destroy(temp);
                                castPreviewEnabled = false;
                                Debug.Log("Preview cancelled.");
                                Cursor.SetCursor(guim.cursor_textures[0], Vector2.zero, CursorMode.Auto);
                                                                        
                                        if(noteInstance != null)
                                        {
                                            Destroy(noteInstance);
                                        }


                            mc.removeRangeInd();
                            mc.selectedTarget = mc.lastSelectedTarget;
                            mc.moveRadius();
                        }
                        }   
                    }
                }
                else if(curCastType == "Single")
                {
                    if(Input.GetMouseButtonDown(0) && gg.legalHex.Contains(mc.selectedTarget.gameObject))
                    {
                        castPreviewEnabled = false;
                        // Debug.Log("Preview finished.");
                        Cursor.SetCursor(guim.cursor_textures[0], Vector2.zero, CursorMode.Auto);
                        //      
                        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                        RaycastHit hit;
                        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                        {
                            if(hit.transform.gameObject.tag == "NPC")
                            {
                                actorData data = hit.transform.gameObject.GetComponent<actorData>();
                                if(curSpell.effectType == spellSO.effectTypes.substractive)
                                {
                                    if(data.ownerFaction_string == "Enemy")
                                    {
                                        castSpell(currentSelectedCharacter, hit.transform.gameObject, curSpell);
                                        // mc.isMoving = false;
                                    }
                                    else
                                    {
                                        guim.updateLog("You cannot target an ally.");
                                        am.playAudio2D("error");
                                                                                
                                        if(noteInstance != null)
                                        {
                                            Destroy(noteInstance);
                                        }
                                    }
                                }
                                else if(curSpell.effectType == spellSO.effectTypes.additive)
                                {
                                    if(data.ownerFaction_string == "Ally")
                                    {
                                        castSpell(currentSelectedCharacter, hit.transform.gameObject, curSpell);
                                        // mc.isMoving = false;
                                    }
                                    else
                                    {
                                        guim.updateLog("You cannot target an enemy.");
                                        am.playAudio2D("error");
                                                                                
                                        if(noteInstance != null)
                                        {
                                            Destroy(noteInstance);
                                        }

                                    }
                                }
                            }
                            else
                            {
                                guim.updateLog("There is no NPC here.");
                                // Debug.Log("There is no NPCs here.");
                                am.playAudio2D("error");
                                        
                                        if(noteInstance != null)
                                        {
                                            Destroy(noteInstance);
                                        }
                            }
                        }
                    }
                    else if(Input.GetMouseButtonDown(1))
                    {
                        castPreviewEnabled = false;
                        // Debug.Log("Preview cancelled.");
                        Cursor.SetCursor(guim.cursor_textures[0], Vector2.zero, CursorMode.Auto);
                        guim.updateLog("Preview cancelled.");
                                
                            if(noteInstance != null)
                            {
                                Destroy(noteInstance);
                            }

                        mc.removeRangeInd();
                        mc.selectedTarget = mc.lastSelectedTarget;
                        mc.moveRadius();
                    }
                }
                else if(curCastType == "Self Around")
                {
                    if(Input.GetMouseButtonDown(0))
                    {
                        List<GameObject> inRangeEnemies = new List<GameObject>();
                        foreach(GameObject hex in gg.legalHex)
                        {
                            if (hex.transform.childCount > 0)
                            {
                                if (hex.transform.GetChild(0).GetComponent<actorData>().ownerFaction_string == "Enemy")
                                {
                                    inRangeEnemies.Add(hex.transform.GetChild(0).gameObject);
                                }
                            }

                        }
                        //GameObject[] NPCs = GameObject.FindGameObjectsWithTag("NPC");
                        foreach(GameObject t in inRangeEnemies)
                        {
                            actorData tData = t.GetComponent<actorData>();
                            if(tData.ownerFaction_string == "Enemy")
                            {
                                currentSelectedCharacter.GetComponent<actorData>().actionsRemaining = curSpell.actionNeeded;
                            
                                castSpell(currentSelectedCharacter, t, curSpell);
                                bctm.showDamage(currentSelectedCharacter, t);
                            }
                            currentSelectedCharacter.GetComponent<actorData>().actionsRemaining -= curSpell.actionNeeded;
                            guim.updateLog(currentSelectedCharacter.GetComponent<actorData>().actorName + " casted a " + curSpell.spellName);
                        }

                        castPreviewEnabled = false;
                        // Debug.Log("Preview finished.");
                        Cursor.SetCursor(guim.cursor_textures[0], Vector2.zero, CursorMode.Auto);
                        inRangeEnemies.Clear();
                    }
                    else if(Input.GetMouseButtonDown(1))
                    {
                        castPreviewEnabled = false;
                        // Debug.Log("Preview cancelled.");
                        Cursor.SetCursor(guim.cursor_textures[0], Vector2.zero, CursorMode.Auto);
                        guim.updateLog("Preview cancelled.");
                                
                                if(noteInstance != null)
                                {
                                    Destroy(noteInstance);
                    }
                    mc.removeRangeInd();
                    mc.selectedTarget = mc.lastSelectedTarget;
                    mc.moveRadius();
                }
                }
            }
        
    }

    public void castSpell(GameObject source, GameObject target, spellSO spellData)
    {

        if(noteInstance != null)
        {
            Destroy(noteInstance);
        }

        actorData sourceActor = source.GetComponent<actorData>();
        actorData targetActor = target.GetComponent<actorData>();
        Animator sourceAnimator = source.GetComponent<Animator>();
        Animator targetAnimator = target.GetComponent<Animator>();

        if(sourceActor.actionsRemaining >= spellData.actionNeeded)
        {
            if(sourceActor.isTurn)
            {

                // Reduce action points of the source from action needed of spell
                sourceActor.actionsRemaining -= spellData.actionNeeded;
                if(sourceActor.actionsRemaining == 0)
                {
                    gg.EndTurn();
                }
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

                if(spellData.casterParticle != null)
                {
                    // Spawn caster particle on caster
                    GameObject temp = Instantiate(spellData.casterParticle, source.transform.position, Quaternion.identity);
                    Destroy(temp, 3);
                    temp.transform.parent = source.transform;
                }
                if(spellData.targetParticle != null)
                {
                    // Spawn target particle on target
                    GameObject temp = Instantiate(spellData.targetParticle, target.transform.position, Quaternion.identity);
                    Destroy(temp, 3);
                    temp.transform.parent = source.transform;
                }

                if(spellData.isProjectileBased)
                {
                    // Debug.Log(1);
                    for(int i = 0; i <= spellData.spawnAmount; i++)
                    {
                        if(spellData.useOverwrite == true)
                        {
                            Vector3 spawnPosition = new Vector3(
                                source.transform.position.x,
                                source.transform.position.y,
                                source.transform.position.z

                            );
                            if(spellData.overwriteParticles != null)
                            {
                                projectile = Instantiate(spellData.overwriteParticles, source.transform.position, Quaternion.identity);
                                Debug.Log("Overwritten.");
                            }
                        }
                        else
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
                        // Add spellCollision object and parent
                        // Used for detecting any props
                        GameObject spellColl = Instantiate(spellCollisionObject, projectile.transform.position, Quaternion.identity);
                        spellColl.transform.parent = projectile.transform;
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
                        if(spellData.skillAura != null)
                        {
                            GameObject aura = Instantiate(spellData.skillAura.gameObject, projectile.transform.position, Quaternion.identity);
                            aura.transform.parent = projectile.transform;
                        }
                        if(spellData.visualizationMethod == spellSO.visualType.material)
                        {
                            // Give material
                            projectile.GetComponent<Renderer>().material = _baseMaterial;
                        }
                        else
                        {
                            //Recolor
                            projectile.GetComponent<Renderer>().material.color = spellData.baseColor;
                        }
                    }
                }
                // if not projectile based, it means projectile doesnt have a distance to go but automatically spawn on target
                else if(!spellData.isProjectileBased && !spellData.instant)
                {
                    projectile = Instantiate(spellData.overwriteParticles, target.transform.position, Quaternion.identity);
                    projectile.transform.parent = source.transform;
                    projectileData projData = projectile.AddComponent<projectileData>();
                    projData.source = source;
                    projData.target = target;
                    projData.referenceSpell = spellData;

                    if(spellData.applyStatus)
                    {
                        targetActor.hasStatus = true;
                        targetActor.statusDuration = spellData.statusDuration;
                        targetActor.statusEffect = spellData.statusEffectPerTurn;
                        targetActor.statusSpellReference = spellData;
                    }

                    bctm.showDamage(source, target);
                }   
                
                if(spellData.SkillTargetHandling == spellSO.targetHandling.selfaround)
                {
                    if(spellData.effectType == spellSO.effectTypes.substractive)
                    {
                        Debug.Log(spellData.effectAmount);
                        target.GetComponent<actorData>().Life -= spellData.effectAmount;
                        if(targetActor.Life <= 0)
                        {
                            targetAnimator.SetTrigger("Die");
                            mc.killUnit(target);
                        }
                        else
                        {
                            targetAnimator.SetTrigger("takeHit");
                        }
                    }
                    else
                    {
                        target.GetComponent<actorData>().Life += spellData.effectAmount;
                    }

                    if(spellData.applyStatus)
                    {
                        targetActor.hasStatus = true;
                        targetActor.statusDuration = spellData.statusDuration;
                        targetActor.statusEffect = spellData.statusEffectPerTurn;
                        targetActor.statusSpellReference = spellData;
                    }
                    
                }
                if(spellData.instant)
                {
                    if(spellData.effectType == spellSO.effectTypes.substractive)
                    {
                        target.GetComponent<actorData>().Life -= spellData.effectAmount;
                        if(targetActor.Life <= 0)
                        {
                            targetAnimator.SetTrigger("Die");
                            bctm.showDamage(source, target);
                            mc.killUnit(target);
                        }
                        else
                        {
                            targetAnimator.SetTrigger("takeHit");
                            bctm.showDamage(source, target);
                        }
                    }
                    else
                    {
                        target.GetComponent<actorData>().Life += spellData.effectAmount;
                    }

                    if(spellData.applyStatus)
                    {
                        targetActor.hasStatus = true;
                        targetActor.statusDuration = spellData.statusDuration;
                        targetActor.statusEffect = spellData.statusEffectPerTurn;
                        targetActor.statusSpellReference = spellData;
                    }

                    
                }          

                if(spellData.SkillTargetHandling != spellSO.targetHandling.selfaround)
                {
                    // Debug.Log("Cast" + spellData.spellName);
                    guim.updateLog(source.name + " casted a " + spellData.spellName);
                    sourceActor.cooldownCounters[curIndexCallback] = spellData.cooldown;
                }

            }

            cc.panToObject(target);
            
            
        }
        else if(spellData.actionNeeded > sourceActor.actionsRemaining)
        {
            guim.updateLog("You don't have enough action points.", Color.red);
            am.playAudio2D("error");
        }
        else
        {
            guim.updateLog("It is not this character's turn.", Color.red);
            am.playAudio2D("error");
        }


    }

    public void processCooldowns()
    {
        GameObject[] NPCs = GameObject.FindGameObjectsWithTag("NPC");
        foreach(GameObject temp in NPCs)
        {
            actorData actor = temp.GetComponent<actorData>();
            for(int z = 0; z < actor.cooldownCounters.Count; z++)
            {
                if(actor.cooldownCounters[z] > 0)
                {
                    actor.cooldownCounters[z] -= 1;
                }
                else if(actor.cooldownCounters[z] == 0)
                {
                    guim.updateLog("Cooldown refreshed on " + actor.spells[z].spellName + ".");
                    return;
                }
            }
        }
    }

    public void processStatuses()
    {
        GameObject[] NPCs = GameObject.FindGameObjectsWithTag("NPC");
        foreach(GameObject temp in NPCs)
        {
            actorData actor = temp.GetComponent<actorData>();
            if(actor.hasStatus)
            {
                if(actor.statusSpellReference.statusType == spellSO.statusTypes.substractive)
                {
                    actor.Life -= actor.statusEffect;
                    
                }
                else
                {
                    actor.Life += actor.statusEffect;
                }

                if(actor.Life == 0)
                {
                    mc.killUnit(temp);
                }

                actor.statusDuration -= 1;
                if(actor.statusDuration == 0)
                {
                    actor.hasStatus = false;
                }

                
                if(actor.statusSpellReference.overwriteStatusVisual)
                {
                    tempStatusParticle = Instantiate(actor.statusSpellReference.statusOverwriteParticle, actor.transform.position, Quaternion.identity); 
                }
                else
                {
                    tempStatusParticle = Instantiate(actor.statusSpellReference.statusParticle.gameObject, actor.transform.position, Quaternion.identity); 
                    
                }
                tempStatusParticle.transform.parent = actor.transform;
                Destroy(tempStatusParticle, 3);

                guim.updateLog(actor.actorName + " gets status effects from " + actor.statusSpellReference.spellName);
            }
        }
    }

    void processPassives()
    {
        GameObject[] NS = GameObject.FindGameObjectsWithTag("NPC");
        foreach(GameObject n in NS)
        {
            
            actorData data = n.GetComponent<actorData>();

            foreach(spellSO s in data.spells)
            {
                if(s.isPassive)
                {
                    if(s.affectsOnlyAllies)
                    {
                        foreach(GameObject e in NS)
                        {
                            actorData dataE = e.GetComponent<actorData>();
                            if(dataE.ownerFaction_string == data.ownerFaction_string)
                            {
                                if(s.buffType == spellSO.buffTypes.buff)
                                {
                                    if(s.buffProperty == spellSO.buffProperties.damage)
                                    {
                                        int result = dataE.baseDamage / s.buffAmount;
                                        dataE.baseDamage += result;
                                        dataE.affectedbyBuff = true;
                                        dataE.buffProperty = "Damage";
                                        
                                    }
                                    if(s.buffProperty == spellSO.buffProperties.health)
                                    {
                                        int result = dataE.Life / s.buffAmount;
                                        dataE.Life += result;
                                        dataE.affectedbyBuff = true;
                                        dataE.buffProperty = "Health";
                                    }
                                }
                                if(s.buffType == spellSO.buffTypes.debuff)
                                {
                                    if(s.buffProperty == spellSO.buffProperties.damage)
                                    {
                                        int result = dataE.baseDamage / s.buffAmount;
                                        dataE.baseDamage -= result;
                                        dataE.affectedbyDebuff = true;
                                        dataE.buffProperty = "Damage";
                                        
                                    }
                                    if(s.buffProperty == spellSO.buffProperties.health)
                                    {
                                        int result = dataE.Life / s.buffAmount;
                                        dataE.Life -= result;
                                        dataE.affectedbyDebuff = true;
                                        dataE.buffProperty = "Health";
                                    }
                                } 
                                dataE.buffHeld = s.buffAmount;
                                dataE.buffName = s.spellName;
                                
                            }
                        }
                        
                        
                    }
                }
            }
        }
    }

    public void refreshAP()
    {
        GameObject[] NS = GameObject.FindGameObjectsWithTag("NPC");
        foreach(GameObject n in NS)
        {
            actorData data = n.GetComponent<actorData>();
            data.actionsRemaining = data.idealAP;
        }
    }
}
