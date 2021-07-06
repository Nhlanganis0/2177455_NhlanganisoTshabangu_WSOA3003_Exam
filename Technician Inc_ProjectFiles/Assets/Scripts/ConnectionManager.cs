using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Spawning;
using MLAPI.Transports.UNET;
using System;

public class ConnectionManager : MonoBehaviour
{
    [SerializeField] GameObject connectionButtonPanel;
    public string IP_Address = "127.0.0.1";
    UNetTransport transport;

    public void Host()
    {
        connectionButtonPanel.SetActive(false);
        NetworkManager.Singleton.ConnectionApprovalCallback += ApprovalCheck;
        NetworkManager.Singleton.StartHost(LocalPlayerSpawn(), Quaternion.identity);
    }

    private void ApprovalCheck(byte[] connectionData, ulong clientID, NetworkManager.ConnectionApprovedDelegate callBack)
    {
        bool approve = System.Text.Encoding.ASCII.GetString(connectionData) == "1234"; 
        callBack(true, null, approve, NonLocalPlayerSpawn(), Quaternion.identity);
    }

    public void Join()
    {
        transport = NetworkManager.Singleton.GetComponent<UNetTransport>();
        transport.ConnectAddress = IP_Address;
        connectionButtonPanel.SetActive(false);
        NetworkManager.Singleton.NetworkConfig.ConnectionData = System.Text.Encoding.ASCII.GetBytes("1234");
        NetworkManager.Singleton.StartClient();
    }

    Vector3 LocalPlayerSpawn()
    {
        float x = 0f;
        float y = 0f;
        float z = 0f;

        bool levelOne = false;
        bool levelTwo = false;
        bool levelThree = false;

        foreach (Camera cameras in Camera.allCameras)
        {
            if (cameras.gameObject.CompareTag("LevelOneCam"))
            {
                levelOne = true;
            }
            else if (cameras.gameObject.CompareTag("LevelTwoCam"))
            {
                levelTwo = true;
            }

            else if (cameras.gameObject.CompareTag("LevelThree"))
            {
                levelThree = true;
            }
        }

        if (levelOne == true)
        {
            x = -4f;
            y = -4f;
            z = -6f;
        }
        else if (levelTwo == true)
        {
            x = 24f;
            y = -2.5f;
            z = 10.3f;
        }
        else if (levelThree == true)
        {
            //ble
        }
        return new Vector3(x, y, z);
    }

    Vector3 NonLocalPlayerSpawn()
    {
        float x = 4f;
        float y = -4f;
        float z = -6f;
        return new Vector3(x, y, z);
    }

    public void IP_AddressSwithed(string newAdress)
    {
        this.IP_Address = newAdress;
    }
}
