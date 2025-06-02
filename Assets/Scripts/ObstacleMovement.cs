using UnityEngine;

public class ObsticaleMovement : MonoBehaviour
{
    public float moveSpeed = 7f;
    private PlayerMovement playerControllerScript;
    private Rigidbody rb;
    private float leftBound = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Projectile")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
