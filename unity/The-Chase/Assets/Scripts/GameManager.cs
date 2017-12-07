using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject canvas;
    public GameObject submit;
    public GameObject username;

    private float startX,  startY;
    private float finishX, finishY;
    private Stopwatch watch;
    private float bestTime;
    private float yourTime;
    private string displayName;

	// Use this for initialization
	void Start () {
        loadMap("Default.map");
        watch = Stopwatch.StartNew();
        spawnPlayer("TestPlayer", PlayerClass.Einstein);
        canvas.SetActive(false);

        // Todo: call from database to get this number
        StartCoroutine(WebAPI.getMap("1"));
        bestTime = 10f;
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

    public void levelFinish(float millisec) {
        float sec = millisec / 1000f;
        yourTime = sec;
        canvas.SetActive(true);
        submit.SetActive(false);
        Text t = GameObject.Find("FinishTime").GetComponent<Text>();
        t.text = sec.ToString("#.##") + "sec";
        if (sec < bestTime) {
            submit.SetActive(true);
        }
    }

    public void restartLevel() {
        SceneManager.LoadScene("GamePlay");
    }

    public void submitScore() {
        // call functions to push to database, use variable: yourTime, displayName
        bestTime = yourTime;
        string displayName = username.GetComponent<Text>().text;
        UnityEngine.Debug.Log("YOUR NAME:" + displayName);
        submit.SetActive(false);
    }


    private void loadMap(string filename) {
        var lines = .Split(new string[] { "\n", "\r\n" }, System.StringSplitOptions.RemoveEmptyEntries);
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
                    case 'T':
                        blockname = "Block_Stone";
                        break;
                    case 'R':
                        blockname = "Block_Granite";
                        break;
                    case 'B':
                        blockname = "Block_Brick";
                        break;
                    case 'L':
                        blockname = "Block_Log";
                        break;
                    case 'C':
                        blockname = "Block_Cobble";
                        break;
                    case 'P':
                        blockname = "Block_Planks";
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
