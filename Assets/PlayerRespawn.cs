using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 spawnPoint;

    void Start()
    {
        spawnPoint = transform.position;  // Simpan posisi awal player
    }

    public void Respawn()
    {
        transform.position = spawnPoint;
    }
}

