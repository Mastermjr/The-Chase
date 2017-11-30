using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private float startX,  startY;
    private float finishX, finishY;
    private Stopwatch watch;

	// Use this for initialization
	void Start () {
        loadMap("Default.map");
        watch = Stopwatch.StartNew();
        spawnPlayer("TestPlayer", PlayerClass.Einstein);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Stopwatch getStopWatch() {
        return watch;
    }

    private void spawnPlayer(string username, PlayerClass pclass) {
        GameObject player = Instantiate(Resources.Load(pclass.ToString()), new Vector3(startX, startY, 0), Quaternion.identity) as GameObject;
    }

    private void loadMap(string filename) {
        var lines = File.ReadAllLines("./Assets/Maps/" + filename);
        int starts = 0;
        int finishes = 0;
        int xpos, ypos;
        ypos = 0;
        foreach (var line in lines) {
            //UnityEngine.Debug.Log(line);
            xpos = 0;
            foreach (char c in line) {
                if (c == '\n') {
                    break;
                }
                string blockname;
                switch (c) {
                    case 'G':
                        blockname = "Block_Grass";
                        break;
                    case 'S':
                        blockname = "Block_Start";
                        startX = xpos;
                        startY = ypos;
                        starts++;
                        break;
                    case 'F':
                        blockname = "Block_Finish";
                        finishX = xpos;
                        finishY = ypos;
                        finishes++;
                        break;
                    case ' ':
                        xpos++;
                        continue;
                    default:
                        throw new UnityException("Block Not Found");
                }
                GameObject go = Instantiate(Resources.Load(blockname), new Vector3(xpos, ypos, 0), Quaternion.identity) as GameObject;
                xpos++;
            }
            ypos--;
        }
        if ((starts != 1) || (finishes != 1)) {
            throw new UnityException("Incorrect Start / Finish Blocks");
        }
    }
}
