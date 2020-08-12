using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using efe;

// needs to be called "using efe;"
namespace efe
{

    [CreateAssetMenu(menuName = "Factions/Create a new faction")]
    public class factionSO : ScriptableObject
    {
    public string factionName;
    public List<factionSO> allies;
    public List<factionSO> enemies;
    public List<factionSO> neutral; 
    public List<int> temp_relations;
    public List<factionSO> temp_factions;

    }
}
