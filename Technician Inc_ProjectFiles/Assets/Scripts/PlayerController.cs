using System.Collections;
using System.Collections.Generic;
using MLAPI;
using MLAPI.SceneManagement;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    CharacterController cc;
    PlayerSpawner playerSpawn;
    PlayerHealth playerHealth;

    [SerializeField] private float Speed;
    [SerializeField] private float pushPower;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private GameObject triggerToIgnore;
    [SerializeField]private float jumpHeijt = 3f;
    public float groundDistance = 0.5f;

    [SerializeField] GameObject CurrentLevel_Cam;

    [SerializeField] GameObject LeveTwo_Instance;
    [SerializeField] Transform LeveTwo_InstancePos;
    [SerializeField] GameObject LevelThree_Instance;
    [SerializeField] Transform LeveThree_InstancePos;

    [SerializeField] private Transform respawnPoint;
    [SerializeField] private Transform player;
    private bool IsnextLevel = false;
    Camera LevelOne;

    public Transform groundcjeck;
    public LayerMask groundMask;
    public bool LocalPlayer;
    public Vector3 velocity;

    bool Isgrounded;

    void Start()
    {
        triggerToIgnore = GameObject.Find("UpDownTrigger");
        CurrentLevel_Cam = GameObject.Find("LevelOneCam");
        LocalPlayer = IsLocalPlayer;
        cc = GetComponent<CharacterController>();
        playerSpawn = GetComponent<PlayerSpawner>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (LocalPlayer)
        {
            MovePlayer();
            Light light = GetComponentInChildren<Light>();
            light.enabled = false;
        }
    }

    void MovePlayer()
    {
        Isgrounded = Physics.CheckSphere(groundcjeck.position, groundDistance, groundMask);

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"),0f, 0f);

        move = Vector3.ClampMagnitude(move, 1f);
        cc.Move(move * Speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && Isgrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeijt * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);
        if(velocity.y <= -16)
        {
            velocity.y = 0f;
        }

        var collider = triggerToIgnore.GetComponent<CharacterController>();
        Physics.IgnoreCollision(cc, collider, true);

        if (collider == null) 
        {
            print("null");
        }

    }

    IEnumerator DelayNext_Level()
    {
        yield return new WaitForSeconds(1);

        foreach (Camera cameras in Camera.allCameras)
        {
            if (cameras.gameObject.name == "LevelOneCam")
            {
                NetworkSceneManager.SwitchScene("Level2");
                triggerToIgnore = GameObject.Find("UpDownTrigger");
                CurrentLevel_Cam = GameObject.Find("LevelOneCam");
            }
            else if(cameras.gameObject.name == "LevelTwoCam")
            {
                NetworkSceneManager.SwitchScene("EndScene");
                triggerToIgnore = GameObject.Find("UpDownTrigger");
                CurrentLevel_Cam = GameObject.Find("LevelOneCam");
            }
        }

        if (IsLocalPlayer)
        {
            IsnextLevel = true;
            if (IsnextLevel == true)
            {
                this.transform.position = new Vector3(-10f, -1.6f, transform.position.z);
            }
        }
        else
        {
            IsnextLevel = true;
            if (IsnextLevel == true)
            {
                this.transform.position = new Vector3(10f, -3.5f, transform.position.z);
            }
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        var playerHealth = hit.transform.GetComponent<Respawn>();
        if (playerHealth != null)
        {
            player.position = respawnPoint.position;
        }

        if (hit.gameObject.CompareTag("Button1") || hit.gameObject.CompareTag("Button2") || hit.gameObject.CompareTag("Key") || hit.gameObject.CompareTag("Chip"))
        {
            Rigidbody body = hit.collider.attachedRigidbody;

            if (hit.moveDirection.y < -0.3f)
                return;
            Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
            body.velocity = pushDir * pushPower;
        }

        if (hit.gameObject.CompareTag("Finish"))
        {
            StartCoroutine(DelayNext_Level());
            Debug.Log("Finish");
        }

        if (hit.gameObject.CompareTag("Spike"))
        {
            this.playerHealth.TakeDamage(1);
        }
    }
}
