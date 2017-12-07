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
    private int levelID;

	// Use this for initialization
	void Start () {
        setActive(0);
        WebAPI.requestURL("HARDCODED_LEVEL_FETCH");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setActive(int levelIndex) {
        levelID = levelIndex;
    }

    public void playLevel() {
        File.WriteAllText("./Assets/Maps/Default.map", levels[levelID].map);
        SceneManager.LoadScene("GamePlay");
    }
}
