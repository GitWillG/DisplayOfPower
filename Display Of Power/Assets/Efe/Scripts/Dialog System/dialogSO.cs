using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using efe;

namespace efe{
    public class dialogSO : MonoBehaviour
    {
        public string title;
        public string text;
        public AudioSource voiceClip;
        public dialogSO linkedDialog;
        public bool hasLink;
        public actorData speaker;
        
    }
}
