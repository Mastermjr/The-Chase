using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class WebAPI : MonoBehaviour {

    public static IEnumerator Get(string url)
    {
        UnityWebRequest www = UnityWebRequest.Get(url);
        UnityEngine.Debug.Log("Error: ");
        yield return www.SendWebRequest();
        if (www.isNetworkError)
        {
            UnityEngine.Debug.Log("Error: " + www.error);
        }
        else
        {
            UnityEngine.Debug.Log("Downloaded: " + www.downloadHandler.text);
            // byte[] results = www.downloadHandler.data;

          //  ArticlesCollection article = JsonUtility.FromJson<ArticlesCollection>(www.downloadHandler.text);
        }
    }

}

