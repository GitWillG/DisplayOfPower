using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using efe;
using TMPro;

namespace efe{

public class cinematicManager : MonoBehaviour
{
    public bool isCinematicRunning;
    public GameObject cinematicGUI;
    public float lineDuration;

    GUIManager guim;
    [Header("Camera Info")]
    public Camera cineCam;
    [Header("Auto-filled at start")]
    [SerializeField]
    Camera lastActiveCam;
    
    [Header("GUI Contents - Auto-filled at start")]
    [SerializeField]
    TextMeshProUGUI _dialogTextArea;
    [SerializeField]
    TextMeshProUGUI _speakerName;
    [SerializeField]
    Sprite _speakerPortrait;
    [SerializeField]
    GameObject instanceCinematicGUI;
    [Header("Cutscenes")]
    public List<cinemaSO> cutscenes;
    cinemaSO curCutscene;
    int curCutsceneIndex = 0;
    [Header("Sequences in Cutscenes")]
    cinematicSequenceSO curSequence;
    int curSequenceIndex = 0;
    List<cinematicSequenceSO> listSequences;

    void Start()
    {
        guim = GameObject.FindGameObjectWithTag("GM").GetComponent<GUIManager>();
        
        InvokeRepeating("UpdateCinema", 0, lineDuration);
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            enableCinema(cutscenes[curCutsceneIndex]);
        }
    }
    public void enableCinema(cinemaSO cutscene)
    {
        
        if(!isCinematicRunning)
        {
            
            curCutscene = cutscene;

            lastActiveCam = Camera.main;
            Camera.main.enabled = false;
            cineCam.gameObject.SetActive(true);
            cineCam = Camera.main;
            
            instanceCinematicGUI = Instantiate(cinematicGUI, new Vector2(Screen.width / 2, Screen.height /2), Quaternion.identity);
            _dialogTextArea = instanceCinematicGUI.transform.Find("DialogArea").GetComponent<TextMeshProUGUI>();
            _speakerName = instanceCinematicGUI.transform.Find("SpeakerName").GetComponent<TextMeshProUGUI>();
            _speakerPortrait = instanceCinematicGUI.transform.Find("Avatar").GetComponent<Sprite>();

            isCinematicRunning = true;
            Debug.Log("Cinematic enabled.");
        }
        else
        {
            curCutscene = null;

            lastActiveCam = Camera.main;
            Camera.main.enabled = true;

            guim.closeGUI(instanceCinematicGUI);
            cineCam.gameObject.SetActive(false);
            isCinematicRunning = false;
            Debug.Log("Cinematic disabled.");
        }

    }


    public void playSequence(cinematicSequenceSO sequence)
    {
        GameObject speaker = GameObject.Find(sequence.speakerID);
        Sprite speakerAvatar = speaker.GetComponent<actorData>().cinematicAvatar;
        // _dialogTextArea.text = speakerDialog;
        _speakerName.text = speaker.name;
        _speakerPortrait = speakerAvatar;
    }

    public void UpdateCinema()
    {
        if(isCinematicRunning)
        {
            curSequenceIndex++;
            listSequences = curCutscene.sequences;
            curSequence = listSequences[curSequenceIndex];
            playSequence(curSequence);
            Debug.Log("Cinema updated.");
        }
    }

    public void actorTalk()
    {
        
    }
    
}
}
