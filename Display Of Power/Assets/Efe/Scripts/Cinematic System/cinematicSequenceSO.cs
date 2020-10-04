using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using efe;

namespace efe{

[CreateAssetMenu(menuName = "Cinema/Create a new sequence")]
public class cinematicSequenceSO : ScriptableObject
{
    public string speakerID;
    public string speakerDialog;
    public int speakOrder;
}
}