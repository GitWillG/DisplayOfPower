using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using efe;

namespace efe{
[CreateAssetMenu(menuName = "Cinema/Create a new cutscene")]
public class cinemaSO : ScriptableObject
{
    public List<cinematicSequenceSO> sequences;
    
}
}