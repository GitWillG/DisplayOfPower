using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spellManager : MonoBehaviour
{

    public GameObject sourceReference;
    public GameObject targetReference;
    public GameObject particle;
    GameObject spell;
    Animator spellAnimator;
    // Start is called before the first frame update
    void Start()
    {   
        spellAnimator = spell.GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {   


    }

    void castSpell(GameObject source, GameObject target)
    {
        spell = Instantiate(particle, source.transform.position, Quaternion.identity);
        float speed = 20 * Time.deltaTime;
        transform.position = Vector3.MoveTowards(spell.transform.position, target.transform.position, speed);
        spellAnimator.SetTrigger("Spawn");

    }
}
