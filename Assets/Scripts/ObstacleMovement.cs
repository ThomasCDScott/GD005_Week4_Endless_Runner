using UnityEngine;

public class ObsticaleMovement : MonoBehaviour
{
    public float moveSpeed = 7f;
    private PlayerMovement playerControllerScript;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerControllerScript = gameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);


    }
}
