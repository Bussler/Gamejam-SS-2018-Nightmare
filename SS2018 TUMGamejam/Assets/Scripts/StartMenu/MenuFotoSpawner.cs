using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFotoSpawner : MonoBehaviour {

    public GameObject[] foto;
    public float maxTime;
    private float time;

	// Use this for initialization
	void Start () {
        int x = Random.Range(0, foto.Length);
        Instantiate(foto[x], new Vector3(Random.Range(-30, 30), 40, this.transform.position.z),foto[x].transform.rotation );
    }
	
	// Update is called once per frame
	void Update () {
        time = time + Time.deltaTime;
        if(time>= maxTime){
            time = 0;
            int x = Random.Range(0, foto.Length);
            Instantiate(foto[x], new Vector3(Random.Range(-30, 30), 40, this.transform.position.z), foto[x].transform.rotation);

        }
		
	}
}
