using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using efe;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace efe{
[RequireComponent(typeof(AudioSource))]
public class audioManager : MonoBehaviour
{   

    public List<AudioClip> allClips;
    AudioClip result;
    AudioSource source;
    // Start is called before the first frame update
    void Start()
    {   
        source = GetComponent<AudioSource>();

        Object[] resource_audio = Resources.LoadAll("Sounds", typeof(AudioClip));
        foreach(AudioClip curResource in resource_audio)
        {
            allClips.Add(curResource);
            // Debug.Log(curResource.factionName);
        }
    }

    void Update()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            if (EventSystem.current.currentSelectedGameObject.GetComponent<Button>() != null)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    playAudio2D("MenuClick");
                }
                
            }
        }
    }
    public void playAudio2D(string audioID)
    {
        foreach(AudioClip temp in allClips)
        {
            if(temp.name.Contains(audioID))
            {
                result = temp;
                break;
            }
        }
        source.PlayOneShot(result);
        // Debug.Log(result.name + " played.");
    }
}
}