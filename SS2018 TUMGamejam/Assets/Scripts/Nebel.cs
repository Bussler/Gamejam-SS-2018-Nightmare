using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nebel : MonoBehaviour {

   public GameObject player;
    public float radius;
    // Use this for initialization
    public bool hasNebel;
	void Start () {
        this.GetComponent<SphereCollider>().radius = this.radius;
	}
	
	// Update is called once per frame
	void Update () {
        //  Debug.Log(RenderSettings.fogDensity);
        if (hasNebel)
        {
            if ((player.transform.position - this.transform.position).magnitude > radius - 2)
            {
                RenderSettings.fogDensity += 0.005f;

            }
            else
            {
                if (RenderSettings.fogDensity >= 0.0005f)
                {
                    RenderSettings.fogDensity -= 0.01f;
                }
                else
                {
                    RenderSettings.fogDensity = 0;
                }
            }
        }
     
        
        if ((player.transform.position - this.transform.position).magnitude > radius)
        {
            player.transform.position = player.transform.position + ((this.transform.position - player.transform.position).normalized*(radius-1))*2;



        }
	}
}
