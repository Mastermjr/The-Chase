using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public class WebAPI {

    private static string fetchedString;
    public static string currMap;
    public static float highscore;
    public static string user;

    public static IEnumerator getMap(string map) {
        string url = "https://the-chase-9c245.firebaseio.com/Maps/Map" + map + ".json";
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.Send();

        //get request
        Debug.Log("Downloaded: " + www.downloadHandler.text);
        currMap = www.downloadHandler.text;
    }

    public static IEnumerator getHighScores(string url, float time) {
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.Send();
        if (www.isNetworkError) {
            Debug.Log("Error: " + www.error);
        } else {
            Debug.Log("Downloaded: " + www.downloadHandler.text);
            fetchedString = www.downloadHandler.text;
        }
    }

    public static IEnumerator putHighScores(string url, float time) {
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.Send();
        if (www.isNetworkError) {
            Debug.Log("Error: " + www.error);
        } else {
            Debug.Log("Downloaded: " + www.downloadHandler.text);
            fetchedString = www.downloadHandler.text;
        }
    }

    public static void parseLastFetch() {
        //setup new Level Manager
        var map = JSON.Parse(fetchedString);
        user =  map["user"].Value;
        highscore = float.Parse(map["time"].Value);
    }
}
