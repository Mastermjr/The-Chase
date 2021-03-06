﻿using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.Networking;
using SimpleJSON;

public class WebAPI : MonoBehaviour {

    private static string fetchedString;
    public static string currMap;

    public static int selectedMapID = 1;

    public static IEnumerator getMap(string map) {
        string url = "https://the-chase-9c245.firebaseio.com/Maps/Map" + map + ".json";
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.Send();

        //get request
        UnityEngine.Debug.Log("Downloaded: " + www.downloadHandler.text);
        currMap = www.downloadHandler.text;

        GameManager gm = GameObject.Find("GameLoader").GetComponent<GameManager>();
        gm.loadMap("Default.map");
        gm.watch = Stopwatch.StartNew();
        gm.spawnPlayer("TestPlayer", PlayerClass.Einstein);
        gm.canvas.SetActive(false);

        // Todo: call from database to get this number
        gm.bestTime = 10f;
    }

    public static IEnumerator putHighScores(string url, float time) {
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.Send();
        if (false) {
            //Debug.Log("Error: " + www.error);
        } else {
            //Debug.Log("Downloaded: " + www.downloadHandler.text);
            fetchedString = www.downloadHandler.text;
        }
    }

    public static void parseLastFetch() {
        //setup new Level Manager
        LevelManager man = new LevelManager();
        man.level = new GameLevel();

        var map = JSON.Parse(fetchedString);
        man.level.user =  map["user"].Value;
        man.level.highscore = float.Parse(map["time"].Value);
    }
}
