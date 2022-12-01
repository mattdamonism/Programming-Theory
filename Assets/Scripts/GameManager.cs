using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TMP_Text text;

    public string PlayerName;

    public User user;

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

    public void SetZooInfo(string jwt)
    {
        user = JsonUtility.FromJson<User>(jwt);
        text.text = user.username;
    }

    [Serializable]
    public class User
    {
        public string username;
        public string primaryAddress;
        public string mirrorAddress;
        public string mirrorBalance;
        public string chainId;
        public string verify2FASuccessTimes;
        public string createTime;
        public string iat;
        public string allowance;
    }
}
