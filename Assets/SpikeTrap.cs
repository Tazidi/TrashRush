using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public float slowFactor = 0.5f;
    public float slowDuration = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RigidbodyMovement player = other.GetComponent<RigidbodyMovement>();
            if (player != null)
            {
                player.ApplySlow(slowFactor, slowDuration);
            }
        }
    }
}