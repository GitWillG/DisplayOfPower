using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using efe;

public class baseAI : MonoBehaviour
{
    public GenerateGrid gridOb;
    public MouseControl mouseController;
    public GameObject target;
    public BestClickToMove clickActions;
    public actorData self;
    public GameObject hexTarget;
    GUIManager guim;
    // Start is called before the first frame update
    void Start()
    {
        self = this.gameObject.GetComponent<actorData>();
        self.isTurn = false;
        gridOb = GameObject.Find("grid").GetComponent<GenerateGrid>();
        mouseController = GameObject.Find("selectionManager").GetComponent<MouseControl>();
        clickActions = GameObject.Find("selectionManager").GetComponent<BestClickToMove>();
        guim = GameObject.FindGameObjectWithTag("GM").GetComponent<GUIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (self.isTurn && !self.belongsToPlayer)
        {
            mouseController.selectionMaterial = mouseController.enemiesMat;
            // Debug.Log(this.name + " says hi to your father");
            int check = Random.Range(0, 2);
            mouseController.playerTurnGUI.SetActive(false);
            if (check == 0 || target == null)
            {
                findClosest();
            }
            //if(check == 2)
            //{
            //    gridOb.EndTurn();
            //}
            else
            {
                if (mouseController.doneMoving)
                {

                    if (self.actionsRemaining > 0)
                    {

                        mouseController.moveAttackSwap();
                        for (int i = 0; i < gridOb.legalHex.Count; i++)
                        {

                            if (gridOb.legalHex[i].transform.childCount > 0 && gridOb.legalHex[i].transform.GetChild(0).GetComponent<actorData>().ownerFaction_string == "Ally")
                            {
                                //Debug.Log("checkattack");

                                clickActions.ClickAttack(self.gameObject, gridOb.legalHex[i]);
                                transform.LookAt(gridOb.legalHex[i].transform);
                                self.actionsRemaining -= 1;
                                // Debug.Log("Dealt 5 damage to " + gridOb.legalHex[i].transform.GetChild(0).gameObject);
                                // guim.updateLog(this.GetComponent<actorData>().actorName + " dealt " + this.GetComponent<actorData>().baseDamage + " to " + gridOb.legalHex[i].transform.GetChild(0).GetComponent<actorData>().actorName);
                                if (gridOb.legalHex[i].transform.GetChild(0).gameObject.GetComponent<actorData>().Life <= 0)
                                {
                                    mouseController.killUnit(gridOb.legalHex[i].transform.GetChild(0).gameObject);


                                }
                                mouseController.moveAttackSwap();
                                if (self.actionsRemaining == 0)
                                {
                                    gridOb.EndTurn();

                                }
                                return;

                            }


                        }
                        mouseController.moveAttackSwap();

                        mouseController.selectHex(this.transform.parent.gameObject);
                        mouseController.doneMoving = false;
                        //mouseController.selectedTarget = this.transform.parent;
                        //Debug.Log(self.actionsRemaining);
                        closeDistance();


                    }
                }

            }
        }
        if (self.isTurn && self.belongsToPlayer)
        {
            if (mouseController.isMove)
            {
                mouseController.selectionMaterial = mouseController.legalMove;

            }
            else
            {

                mouseController.selectionMaterial = mouseController.attackMat;
            }
        }
    }
    private void findClosest()
    {
        List<float> distanceCheck = new List<float>();
        for (int i = 0; i< gridOb.allyList.Count; i++)
        {
            distanceCheck.Add(Vector3.Distance(this.transform.position, gridOb.allyList[i].transform.position));

            float minVal = distanceCheck.Min();
            int index = distanceCheck.IndexOf(minVal);
            target = gridOb.allyList[index].transform.gameObject;
        }
    }
    private void closeDistance()
    {
        //mouseController.selectedTarget = this.transform.parent;
        //mouseController.swapRange();
        List<float> moveDistCheck = new List<float>();
        moveDistCheck.Clear();
        //gridOb.checkMoveLegality(self.MovementRange, this.transform.parent.gameObject, mouseController.legalMove);
        mouseController.currentMask = 1 << 10;

        for (int j = 0; j < gridOb.tempList.Count; j++)
        {
            moveDistCheck.Add(Vector3.Distance(target.transform.parent.position, gridOb.tempList[j].transform.position));
            float minVal = moveDistCheck.Min();
            int index = moveDistCheck.IndexOf(minVal);
            hexTarget = gridOb.tempList[index].transform.gameObject;

        }
        mouseController.runMovement(this.transform.parent.gameObject, hexTarget);
        //Debug.Log("create path");
        //gridOb.choosePath(this.transform.parent.gameObject, hexTarget);
        //Debug.Log("move");
        //mouseController.runMovement();
        self.actionsRemaining -= 1;

    }
    IEnumerator waitsecond()
    {
        yield return new WaitForSeconds(1);

    }
}
