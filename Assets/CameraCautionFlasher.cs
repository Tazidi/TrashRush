using UnityEngine;
using UnityEngine.UI;

public class CameraCautionFlasherMulti : MonoBehaviour
{
    public Camera mainCamera;
    public Transform[] targetObjects;    // ← sekarang jadi array!
    public Image cautionImage;
    public float margin = 5f;
    public float flashSpeed = 0.5f;

    private bool isFlashing = false;
    private float timer = 0f;

    void Update()
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(mainCamera);
        bool anyNear = false;

        // Cek semua objek
        foreach (Transform obj in targetObjects)
        {
            Bounds bounds = new Bounds(obj.position, Vector3.one * margin);
            if (GeometryUtility.TestPlanesAABB(planes, bounds))
            {
                anyNear = true;
                break;
            }
        }

        if (anyNear)
        {
            if (!isFlashing)
            {
                isFlashing = true;
                cautionImage.gameObject.SetActive(true);
            }

            // Kedip (flash)
            timer += Time.deltaTime;
            float alpha = Mathf.Abs(Mathf.Sin(timer * Mathf.PI / flashSpeed));
            Color color = cautionImage.color;
            color.a = alpha;
            cautionImage.color = color;
        }
        else
        {
            isFlashing = false;
            cautionImage.gameObject.SetActive(false);
            timer = 0f;
        }
    }
}
