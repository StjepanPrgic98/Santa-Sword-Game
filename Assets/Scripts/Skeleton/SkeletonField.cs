using UnityEngine;

public class SkeletonField : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject bat;

    [Header("Variables")]
    [SerializeField] float rotationSpeed = 50f;
    [SerializeField] int numberOfBats = 15;
    [SerializeField] Vector3 batScale = new Vector3(1f, 1f, 1);
    [SerializeField] float initialCircleRadius = 2f;

    void Start()
    {
        InstantiateBats();
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    void InstantiateBats()
    {
        for (int i = 0; i < numberOfBats; i++)
        {
            float angle = i * (360f / numberOfBats);
            float radians = Mathf.Deg2Rad * angle;

            float x = transform.position.x + initialCircleRadius * Mathf.Cos(radians);
            float y = transform.position.y + initialCircleRadius * Mathf.Sin(radians);

            Vector3 newPosition = new Vector3(x, y, transform.position.z);

            GameObject newObject = Instantiate(bat, newPosition, Quaternion.identity);
            newObject.transform.parent = transform;

            newObject.transform.localScale = batScale;
        }
    }
}
