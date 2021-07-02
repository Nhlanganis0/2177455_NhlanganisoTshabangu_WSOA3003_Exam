using System.Collections;
using System.Collections.Generic;
using MLAPI;
using MLAPI.NetworkVariable;
using UnityEngine;

public class PlayerHealth : NetworkBehaviour
{
    NetworkVariableInt health = new NetworkVariableInt(100);
    NetworkVariableInt nextLevel = new NetworkVariableInt(0);
    NetworkVariableBool IsNextLevel = new NetworkVariableBool(false);
    public int ActualHealth = 100;
    public int ActualLevelNumber = 0;

    [SerializeField] GameObject CurrentLevel_Cam;
    [SerializeField] GameObject LeveTwo_Instance;
    [SerializeField] Transform LeveTwo_InstancePos;
    [SerializeField] GameObject LevelThree_Instance;
    [SerializeField] Transform LeveThree_InstancePos;

    private bool IsnextLevel = false;

    private void Start()
    {
        CurrentLevel_Cam = GameObject.Find("LevelOneCam");
    }

    void Update()
    {
        ActualHealth = health.Value;
        ActualLevelNumber = nextLevel.Value;
        IsnextLevel = IsNextLevel.Value;
    }

    public void TakeDamage(int damage)
    {
        health.Value -= damage;
    }

    /*public void NextLevel_bool(bool value)
    {
        IsnextLevel = value;
        if (IsnextLevel == true)
        {
            print("works");
            StartCoroutine(DelayNext_Level());
        }
    }

    IEnumerator DelayNext_Level()
    {
        yield return new WaitForSeconds(2);
        foreach (Camera cameras in Camera.allCameras)
        {
            if (cameras.gameObject.name == "LevelOneCam")
            {
                Instantiate(LeveTwo_Instance, LeveTwo_InstancePos.position, Quaternion.identity);
                CurrentLevel_Cam.SetActive(false);
            }
            else if (cameras.gameObject.name == "LevelThreeCam")
            {
                Instantiate(LevelThree_Instance, LeveTwo_InstancePos.position, Quaternion.identity);
                CurrentLevel_Cam.SetActive(false);
            }
        }

        if (IsLocalPlayer)
        {
            IsnextLevel = true;
            if (IsnextLevel == true)
            {
                this.transform.position = new Vector3(-6f, -4f, transform.position.z);
            }
        }
        else
        {
            IsnextLevel = true;
            if (IsnextLevel == true)
            {
                this.transform.position = new Vector3(6f, -4f, transform.position.z);
            }
        }
    }*/
}
