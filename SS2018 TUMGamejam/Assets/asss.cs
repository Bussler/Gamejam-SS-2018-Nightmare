using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asss : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DiamondSquare c = GetComponent<DiamondSquare>();
		c.Reset();
		c.ExecuteDiamondSquare();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
