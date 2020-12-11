using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
using UnityEngine.SceneManagement;

public class cinematic : MonoBehaviour
{

    public GameObject[] actors;
    public GameObject[] cams;
    public GameObject[] checkpoints;

    public TextMeshProUGUI speaker;
    public TextMeshProUGUI dialog;

    //public GameObject test;
    //public GameObject test2;

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

                speaker.GetComponent<TextMeshProUGUI>().text = "Aelee";
                dialog.GetComponent<TextMeshProUGUI>().text = "Commander, we are too close to their camps.";


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

                speaker.GetComponent<TextMeshProUGUI>().text = "Gallion";
                dialog.GetComponent<TextMeshProUGUI>().text = "Keep moving, we have to get through their territory.";


                checkPointStatus = 2;
            }
        }

        float distance2 = Vector3.Distance(actors[0].transform.position, checkpoints[2].transform.position);
        if (checkPointStatus == 2)
        {
            if (distance2 < 12)
            {
                cams[2].SetActive(false);
                cams[3].SetActive(true);

                speaker.GetComponent<TextMeshProUGUI>().text = "";
                dialog.GetComponent<TextMeshProUGUI>().text = "";

                checkPointStatus = 3;
            }
        }

        float distance3 = Vector3.Distance(actors[0].transform.position, checkpoints[3].transform.position);
        if (checkPointStatus == 3)
        {
            if (distance3 < 14)
            {
                cams[3].SetActive(false);
                cams[4].SetActive(true);

                checkPointStatus = 4;

            }
        }

        float distance4 = Vector3.Distance(actors[0].transform.position, checkpoints[4].transform.position);
        if (checkPointStatus == 4)
        {
            if (distance4 < 10)
            {
                cams[4].SetActive(false);
                cams[5].SetActive(true);

                speaker.GetComponent<TextMeshProUGUI>().text = "Silvrene";
                dialog.GetComponent<TextMeshProUGUI>().text = "Well, if it looks like we’ll have to go through this group.";

                checkPointStatus = 5;
  
            }
        }

        float distancehill = Vector3.Distance(actors[0].transform.position, hill.transform.position);
        if (checkPointStatus == 5)
        {
            if (distancehill < 7)
            {                   
                cams[5].SetActive(false);
                cams[6].SetActive(true);

                speaker.GetComponent<TextMeshProUGUI>().text = "Briar";
                dialog.GetComponent<TextMeshProUGUI>().text = "Ready yourselves.";

                checkPointStatus = 6;

                foreach (GameObject n in actors)
                {
                    n.GetComponent<Animator>().SetFloat("Speed", 0);

                }

                StartCoroutine("StartBattle");
            }
        }

    }

    IEnumerator StartBattle()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Master");
    }
}
