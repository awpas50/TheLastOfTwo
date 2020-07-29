using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Boundary : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            CameraShaker.Instance.ShakeOnce(8f, 4f, 0.1f, 1f);
            AudioManager.instance.Play(SoundList.PlayerFallEffect);

            GameObject player = other.gameObject;
            PlayerStat playerStat = player.GetComponent<PlayerStat>();
            playerStat.RestoreHealth();
            playerStat.AddScore(playerStat.opponent);
            playerStat.Respawn(playerStat.respawnLocation);
            player.GetComponent<FauxGravityBody>().placeOnSurface = false;
        }
    }
}
