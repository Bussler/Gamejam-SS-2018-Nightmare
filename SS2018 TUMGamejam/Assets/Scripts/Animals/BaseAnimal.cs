using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseAnimal : MonoBehaviour {

	private AnimalState LAST_STATE = AnimalState.none;
	private AnimalState CURRENT_STATE = AnimalState.none;
	private AnimalState NEXT_STATE = AnimalState.walking;

	private NavMeshAgent navAgent;

	private bool rotating = false;
	private float rotTimer = 0.0f;
	private float rotTime = 0.0f;


	public enum AnimalState
	{
		none,
		walking,
		standing,
		rotating,
	}


	// Use this for initialization
	void Start () {
		navAgent = GetComponent<NavMeshAgent>();
	}
	

	// Update is called once per frame
	void Update () {

		Debug.Log(CURRENT_STATE);	
		Behavior();

		LAST_STATE = CURRENT_STATE;
		CURRENT_STATE = NEXT_STATE;
	}


	private void Behavior()
	{
		switch (CURRENT_STATE)
		{
			case AnimalState.walking:
				{
					System.Random rand = new System.Random();
					Vector3 randDest = new Vector3(rand.Next(-25, 25), 0, rand.Next(-25, 25));

					if (LAST_STATE != CURRENT_STATE)
					{
						navAgent.SetDestination(randDest);
						navAgent.isStopped = false;
					}

					if(Vector3.Distance(transform.position, randDest) < 2.0f)
					{
						if (navAgent.isStopped == false)
						{
							navAgent.isStopped = true;
							NEXT_STATE = AnimalState.standing;
						}
					}


					break;
				}

			case AnimalState.standing:
				{
					System.Random rand = new System.Random();
					int r = rand.Next(500);

					if(r == 7 || r == 119)
					{
						NEXT_STATE = AnimalState.rotating;
					}
					else if(r == 43)
					{
						NEXT_STATE = AnimalState.walking;
					}

					break;
				}

			case AnimalState.rotating:
				{
					System.Random rand = new System.Random();

					if (rotating == false)
					{
						rotTime = rand.Next(1, 2);
						rotating = true;
					}
					else
					{
						rotTimer += Time.deltaTime;
						transform.Rotate(0, 0.5f, 0);
						if(rotTimer > rotTime)
						{
							rotTime = rotTimer = 0.0f;
							rotating = false;
							NEXT_STATE = AnimalState.standing;
						}
					}

					break;
				}
		}
	}


	public void RotateTo(Vector3 view)
	{
		Quaternion lookRotation;
		Vector3 direction;

		//find the vector pointing from our position to the target
		direction = (view - transform.position).normalized;

		//create the rotation we need to be in to look at the target
		lookRotation = Quaternion.LookRotation(direction);

		//rotate us over time according to speed until we are in the required rotation
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 0.5f);
	}
}
