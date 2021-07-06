using System.Collections;
using System.Collections.Generic;
using MLAPI;
using MLAPI.Messaging;
using UnityEngine;

public class OpenDoors : MonoBehaviour
{
    [SerializeField] GameObject Door1;
    [SerializeField] GameObject Door2;
    private bool canOpen;

    void Start()
    {
        canOpen = false; 
    }

    void Update()
    {
        OpenDoorServerRpc();
    }
    [ServerRpc]
    private void OpenDoorServerRpc()
    {
        OpenDoorClientRpc();
    }

    [ClientRpc]
    private void OpenDoorClientRpc()
    {
        canOpen = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(canOpen == true)
        {
            if (collision.gameObject.CompareTag("OpenDoorTrigger1"))
            {
                print("OpenDoorTrigger1");
                Door1.GetComponent<Rigidbody>().velocity = new Vector3(0, 2f, 0);
                Door2.GetComponent<Rigidbody>().velocity = new Vector3(0, 2f, 0);
            }
        }
    }

}
