using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using efe;

namespace efe{
    [CreateAssetMenu(menuName = "Dialogs/Create a new dialog file")]
    public class dialogSO : ScriptableObject
    {
        public string title;
        public string dialogText;
        public AudioSource voiceClip;
        public dialogSO linkedDialog;
        public bool hasLink;
        public actorData speaker;
        
    }
}
