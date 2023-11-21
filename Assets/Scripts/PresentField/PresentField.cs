using UnityEngine;

public class PresentField : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject present;

    [Header("Variables")]
    [SerializeField] float rotationSpeed = 50f;
    [SerializeField] int numberOfPresents = 15;
    [SerializeField] float circleRadius = 1f;
    [SerializeField] Vector3 presentScale = new Vector3(0.1f, 0.1f, 1);

    void Start()
    {
        ArrangeObjects();
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    void ArrangeObjects()
    {
        for (int i = 0; i < numberOfPresents; i++)
        {
            float angle = i * (360f / numberOfPresents);
            float radians = Mathf.Deg2Rad * angle;

            float x = transform.position.x + circleRadius * Mathf.Cos(radians);
            float y = transform.position.y + circleRadius * Mathf.Sin(radians);

            Vector3 newPosition = new Vector3(x, y, transform.position.z);

            GameObject newObject = Instantiate(present, newPosition, Quaternion.identity);
            newObject.transform.parent = transform; 

            newObject.transform.localScale = presentScale;
        }
    }
}