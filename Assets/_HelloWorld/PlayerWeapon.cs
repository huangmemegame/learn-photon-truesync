using System.Collections;
using System.Collections.Generic;
using TrueSync;
using UnityEngine;

public class PlayerWeapon : TrueSyncBehaviour
{
    public GameObject projectilePrefab;

    [AddTracking]
    private FP cooldown = 0;

    public override void OnSyncedInput()
    {
        if (Input.GetButton("Fire1"))
        {
            TrueSyncInput.SetByte(2, 1);
        }
        else
        {
            TrueSyncInput.SetByte(2, 0);
        }
    }

    public override void OnSyncedUpdate()
    {
        byte fire = TrueSyncInput.GetByte(2);
        if (fire == 1 && cooldown <= 0)
        {
            TrueSyncManager.SyncedInstantiate(projectilePrefab, tsTransform.position, TSQuaternion.identity);

            Projectile projectile = projectilePrefab.GetComponent<Projectile>();
            projectile.direction = tsTransform.forward;
            projectile.owner = owner;

            cooldown = 1;
        }
        cooldown -= TrueSyncManager.DeltaTime;
    }
}