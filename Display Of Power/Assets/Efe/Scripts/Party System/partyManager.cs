using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using efe;

namespace efe{
public class partyManager : MonoBehaviour
{
    gameManager gm;
    locationManager lm;
    public GameObject partyBase;
    int maxPartyAmount = 5;
    int curPartyAmount;
    // Start is called before the first frame update
    void Start()
    {   
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<gameManager>();
        lm = gm.GetComponent<locationManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(locationData temp in lm.locations)
        {
            if(curPartyAmount < maxPartyAmount)
            {
                factionSO owner = temp.ownerFaction;
                GameObject newParty = Instantiate(partyBase, temp.transform.position, Quaternion.identity);
                partyData newData = newParty.GetComponent<partyData>();
                newData.partyName = "Party of " + owner.factionName;
                curPartyAmount++;
                Debug.Log(newData.partyName + " spawned at " + newParty.name);
            }
        }
    }
}
}