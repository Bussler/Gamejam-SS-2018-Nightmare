using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private float time;

    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(Vector3.forward*5*Time.deltaTime);
        time = time + Time.deltaTime;
        if (time > 3)
        {
          //  this.transform.Rotate(new Vector3(0, Random.Range(-90, 90), 0));
            time = 0;
        }
	}
}
