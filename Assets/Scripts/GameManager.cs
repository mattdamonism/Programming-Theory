using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Animal SelectedAnimal { get; set; }
    public string ZooID;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        } 
        Instance = this;
        DontDestroyOnLoad(Instance);
    }

    public void SetZooID(string zooId)
    {
        ZooID = zooId;
    }

    public string GetZooID()
    {
        return ZooID;
    }
}
