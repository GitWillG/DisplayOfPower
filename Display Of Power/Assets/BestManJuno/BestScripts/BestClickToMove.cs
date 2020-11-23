using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using efe;
using UnityEngine.UI;
using TMPro;
//using UnityEditor.UnityLinker;

public class BestClickToMove : MonoBehaviour
{
    public NavMeshAgent agent;
    public NavMeshSurface surface;

    Renderer unitCol;
    public Material selectedMaterial;

    public Vector3 location;
    // Just a particle system
    public GameObject feedbackParticle;
    // A GUI element in "world space" that has a text 
    public GameObject numberIndicator;
    // A GUI element in "world space" that has a text 
    public GameObject actionIndicator;
                       
    GUIManager guim;
    CameraControl cc;

    string resultAction;
    GenerateGrid gg;

    int resultDamage;


    // Start is called before the first frame update
    void Start()
    {
        guim = GameObject.FindGameObjectWithTag("GM").GetComponent<GUIManager>();
        cc = Camera.main.GetComponent<CameraControl>();
        gg = GameObject.FindGameObjectWithTag("GG").GetComponent<GenerateGrid>();
        //agent = GetComponent<NavMeshAgent>();

        //surface.BuildNavMesh();
    }

    // Update is called once per frame
    void Update()
    {
        //ClickMove();
    }

    public void ClickMove(GameObject unit, GameObject targetHex)
    {


        agent = unit.GetComponent<NavMeshAgent>();
        actorData data = unit.GetComponent<actorData>();
        //data.changeLookTarget(targetHex);

        //agent.updateRotation = false;
        //Vector3 relativePos = (targetHex.transform.position - unit.transform.position).normalized;
        //Quaternion newRotate = Quaternion.LookRotation(relativePos);
        //agent.transform.rotation = newRotate;

        agent.destination = new Vector3(targetHex.transform.position.x, unit.transform.position.y, targetHex.transform.position.z);

        unit.transform.SetParent(targetHex.transform);
        //cc.trackObject(unit);


       
    }





    public void ClickAttack(GameObject unit, GameObject targetHex)
    {

        // Disable friendly fire
        if(targetHex.transform.GetChild(0).GetComponent<actorData>().ownerFaction_string == unit.GetComponent<actorData>().ownerFaction_string)
        {
            guim.updateLog("You cannot attack your ally.");
            return;
        }

        // unit = source/dealer
        // targetHex = target/receiver
        //subtract life from targetted unit equal to "damage" of selected unit
        // Grab the references
        actorData unitData = unit.GetComponent<actorData>();
        
        GameObject targetUnit = targetHex.transform.GetChild(0).gameObject;
        actorData targetData = targetUnit.GetComponent<actorData>();

        Animator targetAnimator = targetHex.GetComponentInChildren<Animator>();
        Animator sourceAnimator = unit.GetComponent<Animator>();


        // Calculate the result damage
        resultDamage = unitData.baseDamage;
        resultDamage -= targetData.baseArmor;

        if(targetData.curStance == actorData.stances.defensive)
        {
            resultDamage /= 2;
            guim.updateLog(targetData.actorName + " soaked half the damage.");
        }

        unitData.changeLookTarget(targetUnit);
        targetData.changeLookTarget(unit);

        // APPLY THE RESULTING DAMAGE
        targetHex.GetComponentInChildren<actorData>().Life -= resultDamage;

        // Show the result damage as feedback
        showDamage(unit, targetHex);

        // Spawn blood particles
        // targetHex.GetComponentInChildren<actorData>().statObject.life -= unit.GetComponent<actorData>().baseDamage;
        Vector3 bloodSpawn = new Vector3(
            targetHex.transform.GetChild(0).transform.position.x,
            targetHex.transform.GetChild(0).transform.position.y + 1,
            targetHex.transform.GetChild(0).transform.position.z
        );
        GameObject bloodTemp = Instantiate(feedbackParticle, bloodSpawn, Quaternion.identity);
        Destroy(bloodTemp, 2);


        //Vector3 indicatorPos = new Vector3(
        //    targetHex.transform.GetChild(0).transform.position.x,
        //    targetHex.transform.GetChild(0).transform.position.y + 2,
        //    targetHex.transform.GetChild(0).transform.position.z
        //);
        //showActionActor(unit);
        

        // Update the log
        guim.updateLog(unit.GetComponent<actorData>().actorName + " dealt " + unit.GetComponent<actorData>().baseDamage + " to " + 
            targetHex.GetComponentInChildren<actorData>().actorName);

        // Play the animations
        targetAnimator.SetTrigger("takeHit");
        sourceAnimator.SetTrigger("basicAttack");

        // Pan to camera to target
        //cc.panToObject(targetUnit);
        //cc.panToObjectWithDelay(targetUnit, 1);


    }

    public void showDamage(GameObject unit, GameObject targetHex)
    {
        Vector3 indicatorPos = new Vector3(
            targetHex.transform.GetChild(0).transform.position.x,
            targetHex.transform.GetChild(0).transform.position.y + 5,
            targetHex.transform.GetChild(0).transform.position.z
        );
        GameObject temp = Instantiate(numberIndicator, indicatorPos, Quaternion.identity);
        GameObject temp2 = temp.transform.Find("Number").gameObject;

        int reversed = resultDamage * -1;

        if(unit.GetComponent<actorData>().ownerFaction_string == "Ally")
        {
            temp2.GetComponent<TextMeshProUGUI>().color = Color.green;
        }
        else
        {
            temp2.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        temp2.GetComponent<TextMeshProUGUI>().text = reversed.ToString();
        Destroy(temp, 4);
        //Debug.Log(temp + " " + temp2);
    }

    public void showActionActor(GameObject unit)
    {
        // Spawn position for text GUI
        Vector3 indicatorPos = new Vector3(
            unit.transform.position.x,
            unit.transform.position.y + 4,
            unit.transform.position.z
        );

        // Spawn then store
        GameObject temp = Instantiate(actionIndicator, indicatorPos, Quaternion.identity);
        // Get the text reference in the child
        GameObject temp2 = temp.transform.Find("Text").gameObject;
        // Get the actor data reference present on every actor                                                    
        actorData data = unit.GetComponent<actorData>();

        if(data.attackType == actorData.attackTypes.ranged)
        {
            resultAction = "Shooting";
        }
        else
        {
            return;
        }

        if (data.ownerFaction_string == "Ally")
        {
            temp2.GetComponent<TextMeshProUGUI>().color = Color.green;
        }
        else
        {
            temp2.GetComponent<TextMeshProUGUI>().color = Color.red;
        }

        temp2.GetComponent<TextMeshProUGUI>().text = resultAction;

        Destroy(temp, 2);
        gg.ObjectsToDestroyAtEndTurn.Add(temp);
        
        
        Debug.Log(temp + " " + temp2);
    }

}
