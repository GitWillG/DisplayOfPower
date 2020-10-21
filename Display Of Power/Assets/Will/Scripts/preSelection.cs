using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using will;

namespace will{

    public class preSelection : MonoBehaviour
    {
        public List<GameObject> availableHeroes = new List<GameObject>();
        public GameObject grid;
        public GameObject preGO;
        public List<GameObject> selectedHero;
        public GameObject currentHero;
        public int k = 0;
        public TextMeshProUGUI testField;
        public List<TextMeshProUGUI> outputFields;
        int i = 0;
        // Start is called before the first frame update
        void Start()
        {
            selectedHero = new List<GameObject>();
            if (availableHeroes != null)
            {
                if(availableHeroes.Count > 0)
                currentHero = availableHeroes[k];
            }
            if (outputFields[0] != null)
            {
                testField = outputFields[0];

            }
        }

        // Update is called once per frame
        void Update()
        {
            if(currentHero != null)
            {
                testField.text = currentHero.name;

            }
        
        }
        public void makeGrid()
        {
            grid.SetActive(true);
            //preGO.SetActive(false);

        }
        public void nextHero()
        {
            if ((k+1) <= (availableHeroes.Count-1))
            {
                k += 1;
                
            }
            else
            {
                k = 0;
            }
            currentHero = availableHeroes[k];
        }
        public void prevHero()
        {
            if ((k -1) >= 0)
            {
                k -= 1;

            }
            else
            {
                k = availableHeroes.Count -1;
            }
            currentHero = availableHeroes[k];
        }
        public void confirmHero()
        {
            selectedHero.Add(currentHero);
            
            if (i+1 <= outputFields.Count-1)
            {
                i++;
                testField = outputFields[i];
            }
        }
    }
}