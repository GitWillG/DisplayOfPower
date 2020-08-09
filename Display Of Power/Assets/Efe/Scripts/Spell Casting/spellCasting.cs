using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spellCasting : MonoBehaviour
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
        if(Vector3.Distance(spell.transform.position, targetReference.transform.position) < 1)
        {
            spellAnimator.SetTrigger("Die");
            Debug.Log("Reached");
        }
        if(Input.GetKey(KeyCode.N))
        if(spell != null)
        castSpell(sourceReference, targetReference);

    }

    void castSpell(GameObject source, GameObject target)
    {
        spell = Instantiate(particle, source.transform.position, Quaternion.identity);
        float speed = 20 * Time.deltaTime;
        transform.position = Vector3.MoveTowards(spell.transform.position, target.transform.position, speed);
        spellAnimator.SetTrigger("Spawn");

    }
}
