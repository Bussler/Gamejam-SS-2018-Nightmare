﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FotoFade : MonoBehaviour {
    public bool fading;
    private MeshRenderer render;
    public float fadeSpeed;
	// Use this for initialization
	void Start () {
        render = this.GetComponent<MeshRenderer>();
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
}
