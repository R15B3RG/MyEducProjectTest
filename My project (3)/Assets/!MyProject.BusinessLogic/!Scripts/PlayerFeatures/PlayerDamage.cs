using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{

    
    void OnCollisionEnter(Collision coll)
    {
        Debug.Log("Collision detected with: " + coll.gameObject.name);

        DamageToPlayer(coll);
    }

    private void DamageToPlayer(Collision coll)
    {
        if (!coll.gameObject.CompareTag("Terrain"))
        {
            if (coll.gameObject.TryGetComponent(out PlayerController player))
            {

                player.PlayerStats.Health -= 1;

                Debug.Log("Player health -1");

                if (player.PlayerStats.IsDead)
                {
                    Destroy(coll.gameObject);


                }

            }

        }
    }
}
