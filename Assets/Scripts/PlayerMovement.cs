using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce = 5f;
    private Rigidbody rb;
    public float gravityModifier = 15f;
    [SerializeField] bool canJump;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        //We are using impulse as is it works best for jumping.  
       if(Input.GetButtonDown("Jump") && canJump)
       {
          
           rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            canJump = false;
       }
    }

    private void OnCollisionEnter(Collision collision)
    {
        canJump = true;
    }

  //  private void OnCollisionExit(Collision collision)
  //  {
  //      canJump = false;
   // }
}
