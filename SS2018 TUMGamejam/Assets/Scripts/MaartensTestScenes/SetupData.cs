using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupData : MonoBehaviour {

    private TerrainTreePLacement placement;

    // Use this for initialization
    void Start () {

        Procedural terrainStuff = GameObject.Find("Terrain").GetComponent<Procedural>();
        Terrain myTerrain = terrainStuff.GetComponent<Terrain>();
        float TWidth= terrainStuff.width;

        //setup nebel
        GameObject nebelObj = GameObject.Find("Nebel");
        nebelObj.transform.position = new Vector3(TWidth/2, 0, TWidth/2);
        Nebel mynebel = nebelObj.GetComponent<Nebel>();
        mynebel.radius = (TWidth / 2);

        //setup player
        GameObject playerObj = GameObject.Find("Player");
        playerObj.transform.position = new Vector3(TWidth/2, myTerrain.terrainData.GetHeight((int)TWidth/2,(int)TWidth/2)+5, TWidth/2);

        //setup trees
        placement = GameObject.Find("Terrain").GetComponent<TerrainTreePLacement>();
        placement.Place();

        //setup animals
       

    }



}
