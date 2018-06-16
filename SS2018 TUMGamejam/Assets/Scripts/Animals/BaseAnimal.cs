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

	private float standingTimer = 0.0f;
	private Boolean rotating = false;

	public enum AnimalState
	{
		none,
		walking,
		standing,
	}


	// Use this for initialization
	void Start () {
		navAgent = GetComponent<NavMeshAgent>();
	}
	

	// Update is called once per frame
	void Update () {
		LAST_STATE = CURRENT_STATE;
		CURRENT_STATE = NEXT_STATE;

		Behavior();
	}


	private void Behavior()
	{
		switch (CURRENT_STATE)
		{
			case AnimalState.walking:
				{
					if(LAST_STATE != CURRENT_STATE)
					{
						System.Random r = new System.Random();
						navAgent.SetDestination(new Vector3(r.Next(-30, 30), r.Next(-30, 30), r.Next(-30, 30)));
					}
					navAgent.isStopped = false;
					if(navAgent.remainingDistance < 0.5f)
					{
						NEXT_STATE = AnimalState.standing;
					}
					break;
				}
			case AnimalState.standing:
				{
					System.Random r = new System.Random();

					if(standingTimer >= 4.5f)
					{
						rotating = true;
					}

					if (rotating)
					{
						RotateToPlayer();
					}

					standingTimer += Time.deltaTime;
					if(standingTimer > 20.0f)
					{
						standingTimer = 0.0f;
						rotating = false;
						NEXT_STATE = AnimalState.walking;
					}

					break;
				}
		}
	}


	public void RotateToPlayer()
	{
		Quaternion lookRotation;
		Vector3 direction;

		//find the vector pointing from our position to the target
		direction = (new Vector3(0, 0, 0) - transform.position).normalized;

		//create the rotation we need to be in to look at the target
		lookRotation = Quaternion.LookRotation(direction);

		//rotate us over time according to speed until we are in the required rotation
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 0.5f);
	}
}
