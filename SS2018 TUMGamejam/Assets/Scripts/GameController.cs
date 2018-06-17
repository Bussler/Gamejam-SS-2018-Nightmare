using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    private int state=0;
    public Light light;

    // public GameObject[] animalPrefap;
    public GameObject Animal1Stage1;
    public GameObject Animal1Stage2;
    public GameObject Animal1Stage3;


        public GameObject Animal2Stage1;
    public GameObject Animal2Stage2;
    public GameObject Animal2Stage3;

  

    public GameObject TreeStage1;
    public GameObject TreeStage2;
    public GameObject TreeStage3;

    public Material[] skybox;

  
    void Start () {
      
		
	}

    // Update is called once per frame

    public void Update()
    {
        
    }




    public void ChangeState(int i)
    {
             state+=i;
             switch (state)
             {
                 case 0:
                foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Tree"))
                {
                    Instantiate(TreeStage1, obj.transform.position, obj.transform.rotation);
                    Destroy(obj);
                    Debug.Log("TreeIt");
                }
                break;
                 case 1:
                     Debug.Log("Switchstate");                 
                     foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Animal1"))
                     {
                    GameObject temp = Instantiate(Animal1Stage1, obj.transform.position, obj.transform.rotation);
                    Destroy(obj);
                    temp.GetComponent<BaseAnimal>().player = GameObject.Find("Player").GetComponent<PlayerMovement>();
                    Terrain t = GameObject.Find("Terrain").GetComponent<Terrain>();
                    temp.GetComponent<BaseAnimal>().terrain = t;
                    temp.GetComponent<BaseAnimal>().enabled = true;
                }
                foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Animal2"))
                {
                    
                   GameObject temp = Instantiate(Animal2Stage1, obj.transform.position, obj.transform.rotation);
                    temp.GetComponent<BaseAnimal>().player=GameObject.Find("Player").GetComponent<PlayerMovement>();
                    Terrain t = GameObject.Find("Terrain").GetComponent<Terrain>();
                    temp.GetComponent<BaseAnimal>().terrain = t;
                    Destroy(obj);
                    temp.GetComponent<BaseAnimal>().enabled = true;
                }
              


          
                  foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Tree"))
                 {
                    Debug.Log("TreeIt");
                    Instantiate(TreeStage2, obj.transform.position, obj.transform.rotation);
                    Destroy(obj);

                }
                light.intensity = 0.5f;
                RenderSettings.skybox = skybox[1];

                break;

                 case 2:
                Debug.Log("Switchstate");
                foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Animal1"))
                {
                    GameObject temp = Instantiate(Animal1Stage2, obj.transform.position, obj.transform.rotation);
                    Destroy(obj);
                    temp.GetComponent<BaseAnimal>().player = GameObject.Find("Player").GetComponent<PlayerMovement>();
                    Terrain t = GameObject.Find("Terrain").GetComponent<Terrain>();
                    temp.GetComponent<BaseAnimal>().terrain = t;
                    temp.GetComponent<BaseAnimal>().enabled = true;
                }
                foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Animal2"))
                {
                  GameObject temp =  Instantiate(Animal2Stage2, obj.transform.position, obj.transform.rotation);
                    Destroy(obj);
                    temp.GetComponent<BaseAnimal>().player = GameObject.Find("Player").GetComponent<PlayerMovement>();
                    Terrain t = GameObject.Find("Terrain").GetComponent<Terrain>();
                    temp.GetComponent<BaseAnimal>().terrain = t;
                    temp.GetComponent<BaseAnimal>().enabled = true;

                }




                foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Tree"))
                {
                    Debug.Log("TreeIt");
                    Instantiate(TreeStage3, obj.transform.position,new Quaternion(-180,obj.transform.rotation.y, obj.transform.rotation.z,1));
                    Destroy(obj);

                }
                light.intensity = 0.1f;
                RenderSettings.skybox = skybox[2];
                break;

                 case 3:

                //win Game
                SceneManager.LoadScene("winning");
             
                break;


             }

       



    }
            
         


}
