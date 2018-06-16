using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global:MonoBehaviour  {
    public static int size;

    public void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void OnLevelWasLoaded(int level)
    {
        Debug.Log(size);
    }

}
