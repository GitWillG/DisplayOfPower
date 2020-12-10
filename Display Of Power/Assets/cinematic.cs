using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class cinematic : MonoBehaviour
{

    public GameObject[] actors;
    public GameObject[] cams;
    public GameObject[] checkpoints;

    public TextMeshProUGUI speaker;
    public TextMeshProUGUI dialog;

    public GameObject test;
    public GameObject test2;

    public GameObject hill;

    bool reached = false;
    int num = 0;

    int checkPointStatus = 0;
    // Start is called before the first frame update
    void Start()
    {

        speaker.GetComponent<TextMeshProUGUI>().text = "";
        dialog.GetComponent<TextMeshProUGUI>().text = "";

        foreach (GameObject t in actors)
        {
            t.GetComponent<NavMeshAgent>().SetDestination(hill.transform.position);
            t.GetComponent<Animator>().SetFloat("Speed", 1);
        }
    }

    // Update is called once per frame
    void Update()
    {

        float distance0 = Vector3.Distance(actors[0].transform.position, checkpoints[0].transform.position);
        if(checkPointStatus == 0)
        { 
            if (distance0 < 7)
            {
                cams[0].SetActive(false);
                cams[1].SetActive(true);

                speaker.GetComponent<TextMeshProUGUI>().text = "Waterbug";
                dialog.GetComponent<TextMeshProUGUI>().text = "We need to find Juno.";


                checkPointStatus = 1;
                Debug.Log("reacj");
            }
        }

        float distance1 = Vector3.Distance(actors[0].transform.position, checkpoints[1].transform.position);
        if (checkPointStatus == 1)
        {
            if (distance1 < 7)
            {
                cams[1].SetActive(false);
                cams[2].SetActive(true);

                speaker.GetComponent<TextMeshProUGUI>().text = "Waterbug";
                dialog.GetComponent<TextMeshProUGUI>().text = "And get his pants.";


                checkPointStatus = 2;
                Debug.Log("reacj");
            }
        }

        float distance2 = Vector3.Distance(actors[0].transform.position, checkpoints[2].transform.position);
        if (checkPointStatus == 2)
        {
            if (distance2 < 7)
            {
                cams[2].SetActive(false);
                cams[3].SetActive(true);

                speaker.GetComponent<TextMeshProUGUI>().text = "Waterbug";
                dialog.GetComponent<TextMeshProUGUI>().text = "He must pay for not eating us.";


                checkPointStatus = 3;
                Debug.Log("reacj");
            }
        }

        float distance3 = Vector3.Distance(actors[0].transform.position, checkpoints[3].transform.position);
        if (checkPointStatus == 3)
        {
            if (distance3 < 7)
            {
                cams[3].SetActive(false);
                cams[4].SetActive(true);

                speaker.GetComponent<TextMeshProUGUI>().text = "Waterbug";
                dialog.GetComponent<TextMeshProUGUI>().text = "We are juicy.";


                checkPointStatus = 4;
                Debug.Log("reacj");
            }
        }

        if (reached == true) return;

        foreach(GameObject n in actors)
        {
            float distance = Vector3.Distance(n.transform.position, hill.transform.position);
            if(distance < 1)
            {
                n.GetComponent<Animator>().SetFloat("Speed", 0);

                num++;
                if(num == actors.Length)
                { 
                    reached = true;
                }
            }
        }


    }
}
