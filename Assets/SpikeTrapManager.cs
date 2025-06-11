using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapManager : MonoBehaviour
{
    public GameObject[] spikeTraps; // Drag 5 trap ke array ini di Inspector
    public float trapInterval = 18f; // 90 detik dibagi 5 = 18 detik sekali muncul

    private List<int> availableIndices = new List<int>();

    private void Start()
    {
        foreach (GameObject trap in spikeTraps)
        {
            trap.SetActive(false); // Pastikan semua trap tidak aktif di awal
        }

        for (int i = 0; i < spikeTraps.Length; i++)
        {
            availableIndices.Add(i);
        }

        StartCoroutine(ActivateTraps());
    }

    IEnumerator ActivateTraps()
    {
        while (availableIndices.Count > 0)
        {
            yield return new WaitForSeconds(trapInterval);

            int randomIndex = Random.Range(0, availableIndices.Count);
            int trapToActivate = availableIndices[randomIndex];
            availableIndices.RemoveAt(randomIndex);

            spikeTraps[trapToActivate].SetActive(true);
        }
    }
}
