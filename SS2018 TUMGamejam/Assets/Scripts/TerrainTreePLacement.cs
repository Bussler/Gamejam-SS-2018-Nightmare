using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainTreePLacement : MonoBehaviour {

    private Terrain terrain;
    // Use this for initialization


    // Update is called once per frame




    public int numberOfObjects; // number of objects to place
    private int currentObjects; // number of placed objects
    public GameObject objectToPlace; // GameObject to place
    private int terrainWidth; // terrain size (x)
    private int terrainLength; // terrain size (z)
    private int terrainPosX; // terrain position x
    private int terrainPosZ; // terrain position z

    void Start()
    {
        terrain = this.gameObject.GetComponent<Terrain>();
        // terrain size x
        terrainWidth = (int)terrain.terrainData.size.x;
        // terrain size z
        terrainLength = (int)terrain.terrainData.size.z;
        // terrain x position
        terrainPosX = (int)terrain.transform.position.x;
        // terrain z position
        terrainPosZ = (int)terrain.transform.position.z;

        for(int i=0; i < numberOfObjects; i++)
        {
            // generate random x position
            int posx = Random.Range(terrainPosX, terrainPosX + terrainWidth);
            // generate random z position
            int posz = Random.Range(terrainPosZ, terrainPosZ + terrainLength);
            // get the terrain height at the random position
            float posy = Terrain.activeTerrain.SampleHeight(new Vector3(posx, 0, posz));
            // create new gameObject on random position
            GameObject newObject = (GameObject)Instantiate(objectToPlace, new Vector3(posx, posy, posz), Quaternion.identity);
            currentObjects += 1;

        }
    }
    // Update is called once per frame

/*
    void Update()
    {
        // generate objects
        if (currentObjects <= numberOfObjects)
        {
            // generate random x position
            int posx = Random.Range(terrainPosX, terrainPosX + terrainWidth);
            // generate random z position
            int posz = Random.Range(terrainPosZ, terrainPosZ + terrainLength);
            // get the terrain height at the random position
            float posy = Terrain.activeTerrain.SampleHeight(new Vector3(posx, 0, posz));
            // create new gameObject on random position
            GameObject newObject = (GameObject)Instantiate(objectToPlace, new Vector3(posx, posy, posz), Quaternion.identity);
            currentObjects += 1;
        }
        if (currentObjects == numberOfObjects)
        {
            Debug.Log("Generate objects complete!");
        }
    }
    */
}

