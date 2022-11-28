using System.Net;
using System;
using System.IO;
using UnityEngine;

public class APIClient
{
    private const string url = "https://catfact.ninja/fact";

      public static string GetCatFact()
    {
        Debug.Log("Getting cat fact");
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();
        CatFact fact = JsonUtility.FromJson<CatFact>(jsonResponse);
        return fact.fact;
    }

    [Serializable]
    class CatFact
    {
        public string fact;
        public int length;
    }
}
