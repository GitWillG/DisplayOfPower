using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using efe;
using UnityEngine.UI;
using TMPro;
using UnityEditor.UnityLinker;

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
        ////If Left click detected
        //if (Input.GetMouseButtonUp(0))
        //{
        //    //creating raycast to detect where mouse is clicked
        //    RaycastHit hit;

        //    //creates a raycast from the camera to the location of the mouse
        //    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        //    {
        //        //destination on the nav mesh is the location of where the raycast hit
        //        agent.destination = hit.point;
        //    }

        //}
        // unit.GetComponent<NavMeshAgent>().enabled = true;

        agent = unit.GetComponent<NavMeshAgent>();
        actorData data = unit.GetComponent<actorData>();
        data.changeLookTarget(targetHex);

        agent.destination = new Vector3(targetHex.transform.position.x, unit.transform.position.y, targetHex.transform.position.z);

        unit.transform.SetParent(targetHex.transform);
        cc.trackObject(unit);


        //unitCol = unit.GetComponent<Renderer>();

        //if (Input.GetMouseButtonDown(0))
        //{
        //    if (unitCol.material == selectedMaterial)
        //    {
        //        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //        RaycastHit hit;
        //        if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << 8))
        //        {

        //        }
        //    }
        //}
    }
    public void ClickAttack(GameObject unit, GameObject targetHex)
    {
        if(targetHex.transform.GetChild(0).GetComponent<actorData>().ownerFaction_string == unit.GetComponent<actorData>().ownerFaction_string)
        {
            guim.updateLog("You cannot attack your ally.");
            return;
        }
        // unit = source/dealer
        // targetHex = target/receiver
        //subtract life from targetted unit equal to "damage" of selected unit
        actorData unitData = unit.GetComponent<actorData>();
        
        GameObject targetUnit = targetHex.transform.GetChild(0).gameObject;
        actorData targetData = targetUnit.GetComponent<actorData>();

        Animator targetAnimator = targetHex.GetComponentInChildren<Animator>();
        Animator sourceAnimator = unit.GetComponent<Animator>();

        unitData.changeLookTarget(targetUnit);
        targetData.changeLookTarget(unit);

        targetHex.GetComponentInChildren<actorData>().Life -= unitData.baseDamage;
        // targetHex.GetComponentInChildren<actorData>().statObject.life -= unit.GetComponent<actorData>().baseDamage;
        Vector3 bloodSpawn = new Vector3(
            targetHex.transform.GetChild(0).transform.position.x,
            targetHex.transform.GetChild(0).transform.position.y + 1,
            targetHex.transform.GetChild(0).transform.position.z
        );
        GameObject bloodTemp = Instantiate(feedbackParticle, bloodSpawn, Quaternion.identity);
        Destroy(bloodTemp, 2);


        Vector3 indicatorPos = new Vector3(
            targetHex.transform.GetChild(0).transform.position.x,
            targetHex.transform.GetChild(0).transform.position.y + 2,
            targetHex.transform.GetChild(0).transform.position.z
        );
        
        showDamage(unit, targetHex);
        //showActionActor(unit);
        

        guim.updateLog(unit.GetComponent<actorData>().actorName + " dealt " + unit.GetComponent<actorData>().baseDamage + " to " + 
            targetHex.GetComponentInChildren<actorData>().actorName);


        targetAnimator.SetTrigger("takeHit");
        sourceAnimator.SetTrigger("basicAttack");

        cc.panToObject(unit);
        cc.panToObjectWithDelay(targetUnit, 1);


    }

    public void showDamage(GameObject unit, GameObject targetHex)
    {
        Vector3 indicatorPos = new Vector3(
            targetHex.transform.GetChild(0).transform.position.x,
            targetHex.transform.GetChild(0).transform.position.y + 1,
            targetHex.transform.GetChild(0).transform.position.z
        );
        GameObject temp = Instantiate(numberIndicator, indicatorPos, Quaternion.identity);
        GameObject temp2 = temp.transform.Find("Number").gameObject;
        int reversed = unit.GetComponent<actorData>().baseDamage * -1;
        if(unit.GetComponent<actorData>().ownerFaction_string == "Ally")
        {
            temp2.GetComponent<TextMeshProUGUI>().color = Color.green;
        }
        else
        {
            temp2.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        temp2.GetComponent<TextMeshProUGUI>().text = reversed.ToString();
        Destroy(temp, 2);
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
