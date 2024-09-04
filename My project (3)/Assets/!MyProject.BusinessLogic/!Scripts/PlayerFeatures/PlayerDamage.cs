using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour 
{

    void OnCollisionEnter(Collision coll)
    {
        if (!coll.gameObject.CompareTag("Terrain"))
        {
            if (coll.gameObject.TryGetComponent(out Player player))
            {

                player.Health -= 1;

                if (player.IsDead)
                {
                    Destroy(coll.gameObject);
                }

           
            }
            
        }
    }

}
