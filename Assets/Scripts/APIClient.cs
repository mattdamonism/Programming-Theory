using System.Net;
using System;
using System.IO;
using UnityEngine;

public class APIClient
{
    private const string url = "https://catfact.ninja/fact";

    private static CatFact catFact;

    public static CatFact GetCatFact()
    {
        return catFact;
    }

    public static void FetchFact()
    {
        Debug.Log("Getting cat fact");
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();
        CatFact fact = JsonUtility.FromJson<CatFact>(jsonResponse);
        catFact = fact;
    }

    [Serializable]
    public class CatFact
    {
        public string fact;
        public int lenght;
    }
}
