using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SelectLevelSize : MonoBehaviour {

    public Dropdown dropdown;
    public int smallSize;
    public int mediumSize;
    public int bigSize;

	// Use this for initialization
	void Start () {
        dropdown = this.GetComponent<Dropdown>();
        ChangeLevelSize();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeLevelSize()
    {
        switch (dropdown.value)
        {
            case 0:
            Global . size = smallSize;
                break;
                ;
            case 1:
                Global.size = mediumSize;
                break;
                ;
            case 2:
                Global.size = bigSize;
                break;
                ;

        }
        

    }
}
