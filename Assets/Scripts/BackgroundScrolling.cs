using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Vector3 startPosition;
    float backgroundWidth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
        backgroundWidth = GetComponent<BoxCollider>().size.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        if(transform.position.x < startPosition.x - (backgroundWidth/2))
        {
            transform.position = startPosition;
        }
    }
}
