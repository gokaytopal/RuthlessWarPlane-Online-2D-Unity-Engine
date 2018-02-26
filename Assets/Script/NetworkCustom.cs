using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class NetworkCustom : NetworkManager {
    public bool serverType = false;
    public void StartupHost()
    {
        SetPort();
        serverType = true;
        NetworkManager.singleton.StartServer();
    }

    public void JoinGame()
    {
        SetIpAddress();
        SetPort();
        serverType = false;
        NetworkManager.singleton.StartClient();
        
    }

    void SetIpAddress()
    {
        string ipAddress = "81.214.131.77";
        NetworkManager.singleton.networkAddress = ipAddress;
    }
    void SetPort()
    {
        NetworkManager.singleton.networkPort = 7777;
    }

    void OnLevelWasLoaded(int level)
    {
        if(level==0)
        {
            SetupMenuScaneButtons();
        }else
        {
            SetupOtherScaneButtons();
        }
    }

    void SetupMenuScaneButtons()
    {
        GameObject.Find("ButtonStartHost").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("ButtonStartHost").GetComponent<Button>().onClick.AddListener(StartupHost);

        GameObject.Find("ButtonJoinGame").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("ButtonJoinGame").GetComponent<Button>().onClick.AddListener(StartupHost);
    }

    void SetupOtherScaneButtons()
    {
       
    }

}
