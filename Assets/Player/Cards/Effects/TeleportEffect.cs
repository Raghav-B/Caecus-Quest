using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportEffect : CardEffect
{
    public override void ExecuteEffect(Collider[] colliders) {
        int[] mapLimits = TargettedTileController.Instance.GetGameLimits();
        Vector3 pos;
        int randX, randY;
        do {
            randX = Random.Range(mapLimits[0], mapLimits[1] + 1);
            randY = Random.Range(mapLimits[2], mapLimits[3] + 1);
            pos = new Vector3(randX, Player.Instance.transform.position.y, randY);
        } while (!CheckValidLanding(pos));

        Player.Instance.transform.position = pos;
    }

    private bool CheckValidLanding(Vector3 pos) {
        Collider[] colliders = Physics.OverlapSphere(pos, 0.4f);
        for (int i = 0; i < colliders.Length; i++) {
            if (colliders[i].transform.tag == "Enemy" || colliders[i].transform.tag == "Environment") return false;
        }

        return true;
    }
}
