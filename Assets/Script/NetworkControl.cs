using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class NetworkControl : NetworkBehaviour {


    public Text onlineUserCount;
    public GameObject GUIServerScreen;
	// Use this for initialization
	void Start () {
		if(isServer)
        {
            GUIServerScreen.SetActive(true);
        } else
        {
            GUIServerScreen.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
        onlineUserCount.text = "Online Users : "+NetworkManager.singleton.numPlayers.ToString();
    }

    public void StopServer()
    {
        NetworkManager.singleton.StopServer();
    }

}
