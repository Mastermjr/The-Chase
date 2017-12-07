using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class WebAPI {

    private static string fetchedString;

    public static IEnumerator requestURL(string url) {
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.Send();
        if (false) {
            //Debug.Log("Error: " + www.error);
        } else {
            //Debug.Log("Downloaded: " + www.downloadHandler.text);
            fetchedString = www.downloadHandler.text;
            // byte[] results = www.downloadHandler.data;

            //ArticlesCollection article = JsonUtility.FromJson<ArticlesCollection>(www.downloadHandler.text);
        }
    }

    public static GameLevel[] parseLastFetch() {
        // json

        //levels[i] = new GameLevel();

        //return //array of GameLevel
        return Enumerable.Repeat<GameLevel>(null, 1).ToArray(); ;
    }
}
