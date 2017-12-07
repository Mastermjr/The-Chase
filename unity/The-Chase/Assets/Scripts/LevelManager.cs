using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    private GameLevel levelSelected;
    private string levelData;
    private GameLevel[] levels;

	// Use this for initialization
	void Start () {
        WebAPI.requestURL("HARDCODED_LEVEL_FETCH");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void playLevel() {
        File.WriteAllText("./Assets/Maps/Default.map", "Hey\n");//levelSelected.map);
        SceneManager.LoadScene("GamePlay");
    }
}
