using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float jumpForce = 5f;
    private Rigidbody rb;
    public float gravityModifier = 15f;
    [SerializeField] bool canJump;
    private Vector3 originalScale;
    public ParticleSystem dirtParticle; 
    public bool GameOver = false;
    private bool isOnGround = true;
    private Animator anim;
    public GameObject projectile;
    public Vector3 offset;
    public ParticleSystem explosionParticle;
    private AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip crashSound;
 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        originalScale = transform.localScale;
        playerAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //We are using impulse as is it works best for jumping.  
       if(Input.GetButtonDown("Jump") && canJump && isOnGround && !GameOver) 
        {
            dirtParticle.Stop();
            isOnGround = true;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            canJump = true;
            anim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound, 1.0f);

        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 spawnPosition = transform.position + offset;
             Instantiate(projectile, spawnPosition, transform.rotation);
        }

        
    }

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Ground"))
        {
            dirtParticle.Play();
            isOnGround = true;
            
        }
        else if (other.gameObject.CompareTag("Obstacle")) 
        {
            dirtParticle.Stop();
            GameOver = true;
            Debug.Log("Game Over!"); 
            anim.SetBool("Death_b", true);
            anim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            playerAudio.PlayOneShot(crashSound, 1.0f);

        }

     }

  //  private void OnCollisionExit(Collision collision)
  //  {
  //      canJump = false;
   // }
}
