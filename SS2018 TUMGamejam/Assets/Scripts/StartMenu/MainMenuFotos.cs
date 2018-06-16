using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuFotos : MonoBehaviour {
    private Rigidbody rigid;
	// Use this for initialization
	void Start () {
        //  this.transform.rotation = new Quaternion(Random.Range(60, 120), Random.Range(120, 200), Random.Range(-50, 10), 0);
        rigid = this.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        
        if (this.transform.position.y < -30)
        {
            Destroy(this.gameObject);
          
        }
	}
}
