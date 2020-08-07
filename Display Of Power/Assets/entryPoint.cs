using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using efe;

namespace efe{
    public class entryPoint : MonoBehaviour
    {
        public static int curNumber = -1;
        public int entryNumber;
        public locationData entryLocation;
        void Start()
        {
            curNumber++;
            entryNumber = curNumber;
            this.name = "EntryPoint " + entryNumber;
        }
    }
}
