using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        loadMap("Default.map");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void loadMap(string filename) {
        var lines = File.ReadAllLines("./Assets/Maps/" + filename);
        int xpos, ypos;
        ypos = 0;
        foreach (var line in lines) {
            Debug.Log(line);
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
                        blockname = "Block_Stone";
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
    }
}
