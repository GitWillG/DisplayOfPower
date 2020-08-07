using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using efe;

namespace efe{

    [CreateAssetMenu(menuName = "Light/Create new light preset")]
    public class lightSO : ScriptableObject
    {
        public Color lightColor;
        public float strength;
        public float[] snowCity_parameters = {};
    }
}
