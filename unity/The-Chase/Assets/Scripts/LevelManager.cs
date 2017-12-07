using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    private GameLevel levelSelected;
    private string levelData;
    public GameLevel level;
    private int levelID;

	// Use this for initialization
	void Start () {
        string map = "map1";
        setActive(0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setActive(int levelIndex) {
        levelID = levelIndex;
    }

    public void playLevel() {
        //TODO: put in file path for map file
        File.WriteAllText("./Assets/Maps/Default.map", "HARDCODE MAP FILEPATH");
        SceneManager.LoadScene("GamePlay");
    }
}
