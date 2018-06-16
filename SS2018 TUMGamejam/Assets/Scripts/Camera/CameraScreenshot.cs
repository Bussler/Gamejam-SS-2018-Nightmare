using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;


 
public class CameraScreenshot : MonoBehaviour
{
    private bool animalInView;
    private BoxCollider coll;
    public Transform SpawnPoint;

    public GameObject[] fotos;

    public int FileCounter = 0;

    public GameObject Shadow;
    private GameObject shadowObj;

    public void Start()
    {
        coll = this.GetComponent<BoxCollider>();
        coll.enabled = false;
    }

    private void Update()
    {
      /*  if (Input.GetKeyUp(KeyCode.Space))
        {
            if (animalInView)
            {
                CamCapture();
            }

        }
        */
        coll.enabled = false;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            coll.enabled = true;
           
        }
    }

    void CamCapture()
    {

        ChangeEnviorment();

      
            Debug.Log("capture");
            Camera Cam = GetComponent<Camera>();

            RenderTexture currentRT = RenderTexture.active;
            RenderTexture.active = Cam.targetTexture;

            Cam.Render();

            Texture2D Image = new Texture2D(Cam.targetTexture.width, Cam.targetTexture.height);
            Image.ReadPixels(new Rect(0, 0, Cam.targetTexture.width, Cam.targetTexture.height), 0, 0);
            Image.Apply();
            RenderTexture.active = currentRT;

            var Bytes = Image.EncodeToPNG();
           // Destroy(Image);
        fotos[FileCounter].GetComponent<MeshRenderer>().sharedMaterial.mainTexture = Image;


       // File.WriteAllBytes(Application.dataPath + "/Resources/" + FileCounter + ".png", Bytes);
        
          //  fotos[FileCounter].GetComponent<MeshRenderer>().sharedMaterial.mainTexture = Resources.Load("" + 0) as Texture;

            FileCounter++;
            coll.enabled = false;
        animalInView = false;


        Destroy(shadowObj);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Animal")
        {
            animalInView = true;

            CamCapture();
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Animal")
        {

            Debug.Log("Stay");

        }
    }

    private void ChangeEnviorment()
    {
      shadowObj=  Instantiate(Shadow, SpawnPoint.position, Quaternion.identity) as GameObject;

    }

}


