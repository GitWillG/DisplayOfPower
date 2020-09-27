using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using will;

namespace will{

public class populateCharList : MonoBehaviour
{
	//public GameObject prefab; // This is our prefab object that will be exposed in the inspector

	//public int numberToCreate; // number of objects to create. Exposed in inspector
	public GenerateGrid genGrid;

	void Start()
	{
		Populate();
	}


	void Populate()
	{
		GameObject newObj; // Create GameObject instance

		for (int i = 0; i < genGrid.charPrefabList.Count; i++)
		{
			// Create new instances of our prefab until we've created as many as we specified
			newObj = (GameObject)Instantiate(genGrid.charPrefabList[i].menuItem, transform);

			// Randomize the color of our image
		}

	}
}
}