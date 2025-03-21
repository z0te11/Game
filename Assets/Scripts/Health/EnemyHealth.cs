using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class EnemyHealth : Health
{
    public override void Die()
    {
        base.Die();
        GetComponent<BehaviourManager>().enabled = false;
        GetComponent<Collider>().enabled = false;
        if (CheckPhotonMine()) PhotonNetwork.Destroy(gameObject);
    }

    private bool CheckPhotonMine()
    {
        return GetComponent<PhotonView>().IsMine;
    }

}
