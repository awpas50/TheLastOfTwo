using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Boundary : MonoBehaviour
{
    public GameObject respawnLocation1;
    public GameObject respawnLocation2;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameObject player = other.gameObject;
            player.GetComponent<PlayerStat>().deathCounter += 1;
            player.GetComponent<PlayerStat>().deathCounterText.text = player.GetComponent<PlayerStat>().deathCounter.ToString();
            player.GetComponent<FauxGravityBody>().placeOnSurface = false;
            Teleport(player);
        }
    }

    void Teleport(GameObject player)
    {
        CameraShaker.Instance.ShakeOnce(8f, 4f, 0.1f, 1f);
        player.transform.position = respawnLocation1.transform.position;
    }
}
