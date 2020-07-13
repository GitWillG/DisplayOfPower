using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace efe
{
public class rigHumanoid : MonoBehaviour
{



    // Mirroring items 
    // Left bones are used as reference to mirror to right bones. So model thinking about left hand/foot bones.
    // Items that will be mirrored to right will have its scale reversed and parented to the bone accordingly.

    public GameObject l_glove_bone;
    public GameObject r_glove_bone;
    public GameObject helmet_bone;
    public GameObject armor_set_bone;
    public GameObject l_boots_bone;
    public GameObject r_boots_bone;

    public GameObject cape_bone;
    public GameObject left_hand_item_placement_bone;
    public GameObject right_hand_item_placement_bone;

    public itemSO curGlove;
    public itemSO curHelmet;

    public itemSO curArmorSet;

    public itemSO curBoots;

    public List<GameObject> bones;

    public List<GameObject> parentedObjects;

    bool mirrorContinue = false;
    string[] mirrorType = {"Boots will be mirrored.", "Gloves will be mirrored.", "Nothing will be mirrored. "};
    string curMirrorType;

    [ContextMenu("rigHumanoid")]
    // Start is called before the first frame update
    void Start()
    {   
        if(curBoots != null)
        {
            GameObject spawned = Instantiate(curBoots.itemMesh, l_boots_bone.transform.position, Quaternion.identity);
            mirrorItemToBone(curBoots);
            spawned.transform.parent = l_boots_bone.transform;
            // StartCoroutine("destroyItem", spawned); 
        }
        if(curGlove != null)
        {
            GameObject spawned = Instantiate(curGlove.itemMesh, l_glove_bone.transform.position, Quaternion.identity);
            spawned.transform.parent = l_glove_bone.transform;
            mirrorItemToBone(curGlove);
            // StartCoroutine("destroyItem", spawned);
        }
        if(curArmorSet != null)
        {
            GameObject spawned = Instantiate(curArmorSet.itemMesh, armor_set_bone.transform.position, Quaternion.identity);
            spawned.transform.parent = armor_set_bone.transform;
            // StartCoroutine("destroyItem", spawned);
        }
        if(curHelmet != null)
        {
            GameObject spawned = Instantiate(curHelmet.itemMesh, helmet_bone.transform.position, Quaternion.identity);
            spawned.transform.parent = helmet_bone.transform;
            // StartCoroutine("destroyItem", spawned);
        }
        Debug.Log("Initiliazed NPC gear.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator destroyItem(GameObject item)
    {
        yield return new WaitForSeconds(3);
        Object.DestroyImmediate(item);
    }

    void mirrorItemToBone(itemSO item)
    {

        // Optimize later - cache getcomponent on start
        if(item.curType == itemSO.itemTypes.type_boots)
        {
            mirrorContinue = true;
            curMirrorType = mirrorType[0];
        }
        else if(item.curType == itemSO.itemTypes.type_glove)
        {
            mirrorContinue = true;
            curMirrorType = mirrorType[1];
        }
        else{
            mirrorContinue = false;
            curMirrorType = mirrorType[2];
        }

            if(mirrorContinue)
            {
                Debug.Log(curMirrorType);
                if(curMirrorType == mirrorType[0]) // boots
                {
                    GameObject spawned = Instantiate(item.itemMesh, r_boots_bone.transform.position, Quaternion.identity);
                    spawned.transform.parent = r_boots_bone.transform;
                }
                else if(curMirrorType == mirrorType[1]) // gloves
                {
                    GameObject spawned = Instantiate(item.itemMesh, r_glove_bone.transform.position, Quaternion.identity);
                    spawned.transform.parent = r_glove_bone.transform;
                }
            }
    }
}
}
