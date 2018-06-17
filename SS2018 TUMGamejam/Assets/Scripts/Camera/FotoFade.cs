using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FotoFade : MonoBehaviour {
    public bool fading;
    private MeshRenderer render;
    public float fadeSpeed;

	public GameController controller;
	// Use this for initialization
	void Start () {
        render = this.GetComponent<MeshRenderer>();
		controller = GameObject.FindObjectOfType<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (fading)
        {
             render.material.color = new Color(render.material.color.r + fadeSpeed*Time.deltaTime, render.material.color.g+Time.deltaTime * fadeSpeed, render.material.color.b + fadeSpeed*Time.deltaTime);
           // render.material.color = new Color(1, 1, 1);
        }
	}

    public void Fade()
    {

        fading = true;

    }
	
	public void SetBlack() {
		render.material.color = new Color(0, 0, 0);
	}
	
	
	public void ChangeEnviorment() {

		controller.ChangeState(1);

	}
	
}
