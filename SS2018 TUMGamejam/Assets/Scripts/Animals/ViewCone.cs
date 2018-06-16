using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewCone : MonoBehaviour {

	public BaseAnimal animal;

	private PlayerMovement player;


	// Use this for initialization
	void Start () {
		player = animal.player;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Player")
		{
			animal.ReportPlayerSight(collision.gameObject);
		}
	}

}
