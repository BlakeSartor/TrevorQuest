using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcStats : CharStats {

    public override void Die()
    {
        base.Die();
        //NPc Die

        Destroy(gameObject);
    }

}
