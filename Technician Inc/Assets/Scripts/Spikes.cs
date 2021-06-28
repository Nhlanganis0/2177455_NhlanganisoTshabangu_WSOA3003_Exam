using System.Collections;
using System.Collections.Generic;
using MLAPI.Messaging;
using MLAPI;
using UnityEngine;

public class Spikes : NetworkBehaviour
{
    [SerializeField] TrailRenderer spike_Trail;
    [SerializeField] Transform bulletBarrel;

    /*void Update()
    {
        ShootRayServerRpc();
    }

    [ServerRpc]

    void ShootRayServerRpc()
    {
        if (Physics.Raycast(bulletBarrel.position, bulletBarrel.up, out RaycastHit hit, 1f))
        {
            var playerHealth = hit.transform.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);
                print("Player");
            }
        }

        ShootRayClientRpc();
    }

    [ClientRpc]

    void ShootRayClientRpc()
    {
        var bullet = Instantiate(spike_Trail, bulletBarrel.position, Quaternion.identity);
        bullet.AddPosition(bulletBarrel.position);

        if (Physics.Raycast(bulletBarrel.position, bulletBarrel.up, out RaycastHit hit, 0.5f))
        {
            bullet.transform.position = hit.point;
        }
        else
        {
            bullet.transform.position = bulletBarrel.position + (bulletBarrel.up * 0.5f);
        }
    }*/
}
