using UnityEngine;

public class MoveForwardLoop : MonoBehaviour
{
    public float speed = 2f;            // Kecepatan gerak
    public float distance = 20f;        // Jarak maksimum dari posisi awal

    private Vector3 startPos;           // Posisi awal
    private float traveled = 0f;        // Jarak yang sudah ditempuh

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float moveStep = speed * Time.deltaTime;

        // Gerak maju sesuai arah hadap objek (local Z+)
        transform.Translate(Vector3.forward * moveStep);

        traveled += moveStep;

        // Jika sudah menempuh jarak, kembali ke posisi awal
        if (traveled >= distance)
        {
            transform.position = startPos;
            traveled = 0f;
        }
    }
}
