using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce = 5f;
    private Rigidbody rb;
    public float gravityModifier = 15f;
    [SerializeField] bool canJump;

    public ParticleSystem dirtParticle; 
    public bool isGameOver = false;
    private bool isOnGround;
    private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        //We are using impulse as is it works best for jumping.  
       if(Input.GetButtonDown("Jump") && canJump && isOnGround && !isGameOver) { dirtParticle.Stop(); }
        {

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            canJump = false;
            anim.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        canJump = true;

        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        } else if(collision.gameObject.CompareTag("Obstacle"))
        {

            isGameOver = true;
            Debug.Log("Game Over!");
        }
        anim.SetBool("Death_b", true);
        anim.SetInteger("DeathType_int", 1);
    }

  //  private void OnCollisionExit(Collision collision)
  //  {
  //      canJump = false;
   // }
}
