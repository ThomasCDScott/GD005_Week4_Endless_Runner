using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacle;
    public Vector3 spawnPostion;
    public PlayerMovement _playerMovement;
    private PlayerMovement playerControllerScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("spawnObstacle", 3, 2);
        playerControllerScript = gameObject.Find("Player").GetComponent<PlayerMovement>();
    }

   

    // Update is called once per frame
    void spawnObstacle()
    {
        Instantiate(obstacle, spawnPostion, obstacle.transform.rotation);
    }

    private void Update()
    {
        if (_playerMovement.isGameOver == true)
        {
            CancelInvoke("spawnObstacle");
        }

    }
}
