using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nebel : MonoBehaviour {

   public GameObject player;
    public float radius;
    public Terrain myTerrain;
    // Use this for initialization
    public bool hasNebel;
    public Image mistImage;
    

	void Start () {
        this.GetComponent<SphereCollider>().radius = this.radius;
	}
	
	// Update is called once per frame
	void Update () {
        //  Debug.Log(RenderSettings.fogDensity);
        if (hasNebel)
        {
            if ((player.transform.position - this.transform.position).magnitude > radius-20)
            {
                // RenderSettings.fogDensity += 0.005f;
               var tempColor = mistImage.color;
               tempColor.a += 0.005f;
               mistImage.color = tempColor;

            }
            else
            {
                if (mistImage.color.a >= 0.5f)
                {
                    var tempColor = mistImage.color;
                    tempColor.a -= 0.05f;
                    mistImage.color = tempColor;
                }
                else
                {
                    Color tempColor = mistImage.color;
                    tempColor.a =0.0f;
                    mistImage.color = tempColor;
                }
            }
        }
     
        
        if ((player.transform.position - this.transform.position).magnitude > radius)
        {
            player.transform.position = player.transform.position + ((this.transform.position - player.transform.position).normalized*(radius-1))*2;
            player.transform.position= new Vector3(this.transform.position.x ,myTerrain.terrainData.GetHeight(20, 20) + 20, transform.position.z);
        }
	}
}
