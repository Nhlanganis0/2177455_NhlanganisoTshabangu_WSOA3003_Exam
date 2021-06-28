using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Messaging;

public class PlayerSpawner : NetworkBehaviour
{
    CharacterController cc;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        Respawn();
    }

    void Update()
    {
        
    }

    public void Respawn()
    {
        if (IsLocalPlayer)
        {
            RespawnServerRpc();
        }
        else
        {
            RespawnLocalClientRpc(GetSpawnPos_Player());
        }
    }

    [ServerRpc]
    void RespawnServerRpc()
    {
        RespawnLocalClientRpc(GetSpawnPos_LocalPlayer());
    }

    [ClientRpc]
    void RespawnLocalClientRpc(Vector3 spawnPosition)
    {
        cc.enabled = false;
        transform.position = spawnPosition;
        cc.enabled = true;
    }

    Vector3 GetSpawnPos_Player()
    {
        float x = 4f;
        float y = -4f;
        float z = -6f;
        return new Vector3(x, y, z);
    }

    Vector3 GetSpawnPos_LocalPlayer()
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

            else if (cameras.gameObject.CompareTag("LevelThree" ))
            {
                levelThree = true;
            }
        }

        if(levelOne == true)
        {
             x = -4f;
             y = -4f;
             z = -6f;
        }
        else if(levelTwo == true)
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
}
