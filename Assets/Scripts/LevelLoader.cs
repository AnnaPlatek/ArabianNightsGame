using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {


    
	// Use this for initialization
	void Start () {
        Invoke("LoadFirstLevel", 4f);
	}
	
    void LoadFirstLevel()
    {
        SceneManager.LoadScene(1);       
    }
}
