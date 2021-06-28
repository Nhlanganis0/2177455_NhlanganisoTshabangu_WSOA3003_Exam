using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private TrailRenderer trail;
    [SerializeField]
    private float gravity;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Physics.Raycast(transform.position, Vector3.left, out RaycastHit hit, 3f))
        {
            var player = hit.transform.GetComponent<PlayerController>();
            if (player != null)
            {
                hit.collider.transform.SetParent(transform);
                player.velocity.y -= gravity * Time.deltaTime;
            }
        }*/
    }

}
