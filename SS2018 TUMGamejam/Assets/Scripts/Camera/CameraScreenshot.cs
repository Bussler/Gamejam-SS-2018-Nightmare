using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;


 
public class CameraScreenshot : MonoBehaviour
{
    private bool animalInView;
    private BoxCollider coll;
    public Camera Cam;
    public FotoFade foto;
    public AudioSource audio;
    public GameController controller;

   
   // public Transform SpawnPoint;

    public GameObject[] fotos;

    public int FileCounter = 0;

    //public GameObject Shadow;
  //  private GameObject shadowObj;

    public void Start()
    {
       Cam = this.GetComponent<Camera>();
        coll = this.GetComponent<BoxCollider>();
        coll.enabled = false;
        audio = this.GetComponent<AudioSource>();
    
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            coll.enabled = true;
           
        }
    }

    void CamCapture()
    {

       // ChangeEnviorment();
       foto.SetBlack();
        audio.Play();
            Debug.Log("capture");

      //  controller.ChangeState(1);
            RenderTexture currentRT = RenderTexture.active;
            RenderTexture.active = Cam.targetTexture;

            Cam.Render();

            Texture2D image = new Texture2D(Cam.targetTexture.width, Cam.targetTexture.height);
            image.ReadPixels(new Rect(0, 0, Cam.targetTexture.width, Cam.targetTexture.height), 0, 0);
            image.Apply();
            RenderTexture.active = currentRT;

            var Bytes = image.EncodeToPNG();
           // Destroy(Image);
        fotos[FileCounter].GetComponent<MeshRenderer>().sharedMaterial.mainTexture = image;


       // File.WriteAllBytes(Application.dataPath + "/Resources/" + FileCounter + ".png", Bytes);
        
          //  fotos[FileCounter].GetComponent<MeshRenderer>().sharedMaterial.mainTexture = Resources.Load("" + 0) as Texture;

            //FileCounter++;
            coll.enabled = false;
        animalInView = false;
        foto.fading = true;
        foto.GetComponent<Animator>().SetTrigger("shoot");
       // controller.ChangeState(-1);
        // Destroy(shadowObj);
    }

    public void OnTriggerEnter(Collider other)
    {
        if  (other.tag == "Animal1"||other.tag == "Animal2"||other.tag == "Animal3")
        {
            animalInView = true;

            CamCapture();
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Animal1"||other.tag == "Animal2"||other.tag == "Animal3")
        {

            Debug.Log("Stay");

        }
    }

    private void ChangeEnviorment()
    {
     // shadowObj=  Instantiate(Shadow, SpawnPoint.position, Quaternion.identity) as GameObject;

    }

}


