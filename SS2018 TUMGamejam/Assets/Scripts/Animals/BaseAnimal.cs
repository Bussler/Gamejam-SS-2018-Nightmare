using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[DefaultExecutionOrder(-103)]
public class BaseAnimal : MonoBehaviour {

	public PlayerMovement player;
	public bool aggressive = false;

	private AnimalState LAST_STATE = AnimalState.inactive;
	private AnimalState CURRENT_STATE = AnimalState.inactive;
	public AnimalState NEXT_STATE = AnimalState.walking;

	private NavMeshAgent navAgent;
	public Terrain terrain;

	private float timer = 0.0f;

	private bool rotating = false;
	private float rotTime = 0.0f;
	private int rotDirection = 1;

	private Procedural myProcedual;


	public enum AnimalState
	{
		inactive,
		walking,
		standing,
		rotating,
		stare,
		attacking,
	}


	private void Awake()
	{
		transform.position = new Vector3(transform.position.x, terrain.terrainData.GetHeight((int)transform.position.x, (int)transform.position.z) + 0.75f, transform.position.z);
		//transform.Translate(new Vector3(0, terrain.terrainData.GetHeight((int) transform.position.x, (int) transform.position.z) + 1, 0));
	}


	// Use this for initialization
	void Start () {
		navAgent = GetComponent<NavMeshAgent>();
		myProcedual = terrain.GetComponent<Procedural>();
	}
	

	// Update is called once per frame
	void Update () {

		//Debug.Log(CURRENT_STATE);	
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
					Vector3 randDest = new Vector3(transform.position.x + rand.Next(-50, 50), 0, transform.position.z + rand.Next(-50, 50));
					randDest.y = terrain.terrainData.GetHeight((int) randDest.x, (int) randDest.z);

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

					timer += Time.deltaTime;
					if (timer > 30.0f)
					{
						timer = 0.0f;
						NEXT_STATE = AnimalState.rotating;
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
						rotDirection = (int) Math.Round(rand.NextDouble());
						if (rotDirection == 0)
						{
							rotDirection = -1;
						}
					}
					else
					{
						timer += Time.deltaTime;
						transform.Rotate(0, rotDirection * 0.5f, 0);
						if(timer > rotTime)
						{
							rotTime = timer = 0.0f;
							rotating = false;
							NEXT_STATE = AnimalState.standing;
						}
					}

					break;
				}

			case AnimalState.stare:
				{
					if(player != null)
					{
						RotateTo(player.transform.position);
					}

					timer += Time.deltaTime;
					if(timer > 2.0f)
					{
						timer = 0.0f;
						NEXT_STATE = AnimalState.attacking;
					}

					break;
				}

			case AnimalState.attacking:
				{
					Vector3 playerPos = player.transform.position;
					playerPos.y = terrain.terrainData.GetHeight((int)playerPos.x, (int)playerPos.z);

					navAgent.speed = 15.0f;
					navAgent.SetDestination(playerPos);
					navAgent.isStopped = false;

					if(Vector3.Distance(transform.position, player.transform.position) > 200.0f)
					{
						navAgent.speed = 3.5f;
						navAgent.isStopped = true;
						NEXT_STATE = AnimalState.walking;
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


	public void ReportPlayerSight()
	{
		if(aggressive && CURRENT_STATE != AnimalState.stare && CURRENT_STATE != AnimalState.attacking)
		{
			NEXT_STATE = AnimalState.stare;

			timer = 0.0f;
			rotating = false;
			rotTime = 0.0f;
			rotDirection = 1;
			navAgent.isStopped = true;
		}
	}


	public void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			Debug.Log("Player died!");
		}
	}

}
