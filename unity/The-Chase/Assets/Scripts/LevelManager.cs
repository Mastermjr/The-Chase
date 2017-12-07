using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    private GameLevel levelSelected;

	// Use this for initialization
	void Start () {
        fetchLevel(0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void fetchLevel(int levelIndex) {
        GameLevel level = new GameLevel();
        int levelID = levelIndex;
        /*level.map = getMap(levelID);
        level.description = getDescription(levelID);
        level.score = getScore(levelID);*/
        levelSelected = level;
    }

    public void playLevel() {
        File.WriteAllText("./Assets/Maps/Default.map", "Hey\n");//levelSelected.map);
        SceneManager.LoadScene("GamePlay");
    }
}
