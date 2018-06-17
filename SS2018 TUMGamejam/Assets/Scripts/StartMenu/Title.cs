using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour {

    private Text text;
    private int size;
	// Use this for initialization
	void Start () {
        text = this.GetComponent<Text>();
        size = text.fontSize;
	}
	
	// Update is called once per frame
	void Update () {

        if (text.fontSize <= size+5)
        {
            text.fontSize = text.fontSize +(int)( 1);

        }

        if (text.fontSize > size - 5)
        {
            text.fontSize = text.fontSize - (int)(1 );

        }


    }
}
