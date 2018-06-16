using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {

    public string levelNameMain;

    public void ChangeLevel()
    {
        SceneManager.LoadScene(levelNameMain);

    }
}
