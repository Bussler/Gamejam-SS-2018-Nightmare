﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public int state=0;

    // public GameObject[] animalPrefap;
    public Mesh Animal1Stage1;
    public Mesh Animal1Stage2;
    public Mesh Animal1Stage3;


        public Mesh Animal2Stage1;
    public Mesh Animal2Stage2;
    public Mesh Animal2Stage3;

    public Mesh Animal3Stage1;
    public Mesh Animal3Stage2;
    public Mesh Animal3Stage3;

  
    void Start () {
      
		
	}

    // Update is called once per frame

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeState();
        }
    }




    public void ChangeState()
    {
             state++;
             switch (state)
             {
                 case 0: break;
                 case 1:
                     Debug.Log("Switchstate");                 
                     foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Animal1"))
                     {
                         obj.GetComponent<MeshFilter>().mesh = Animal1Stage1;

                     }
                foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Animal2"))
                {
                    obj.GetComponent<MeshFilter>().mesh = Animal2Stage1;

                }
                foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Animal3"))
                {
                    obj.GetComponent<MeshFilter>().mesh = Animal3Stage1;

                }

                TreePrototype[] tps = Terrain.activeTerrain.terrainData.treePrototypes;
                tps[0].prefab = Resources.Load("treeStage1") as GameObject;
                Terrain.activeTerrain.terrainData.treePrototypes = tps;



                break;

                 case 2:
                Debug.Log("Switchstate");
                foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Animal1"))
                {
                    obj.GetComponent<MeshFilter>().mesh = Animal1Stage2;

                }
                foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Animal2"))
                {
                    obj.GetComponent<MeshFilter>().mesh = Animal2Stage2;

                }
                foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Animal3"))
                {
                    obj.GetComponent<MeshFilter>().mesh = Animal3Stage2;

                }

                TreePrototype[] tps2 = Terrain.activeTerrain.terrainData.treePrototypes;    // auch für die neuen büme den indes des tps arrays Anpassen;
                tps2[0].prefab = Resources.Load("treeStage2") as GameObject;
                Terrain.activeTerrain.terrainData.treePrototypes = tps2;
                break;

                 case 3:
                Debug.Log("Switchstate");
                foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Animal1"))
                {
                    obj.GetComponent<MeshFilter>().mesh = Animal1Stage3;

                }
                foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Animal2"))
                {
                    obj.GetComponent<MeshFilter>().mesh = Animal2Stage3;

                }
                foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Animal3"))
                {
                    obj.GetComponent<MeshFilter>().mesh = Animal3Stage3;

                }

                TreePrototype[] tps3 = Terrain.activeTerrain.terrainData.treePrototypes;
                tps3[0].prefab = Resources.Load("treeStage1") as GameObject;
                Terrain.activeTerrain.terrainData.treePrototypes = tps3;
                break;


             }

       



    }
            
         


}
