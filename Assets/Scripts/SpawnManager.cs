using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject[] objectPrefabs;
    public Vector3 spawnPostion;
    public PlayerMovement _playerMovement;
    private PlayerMovement playerControllerScript;
    public float minY = 1;
    public float maxY = 4;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("spawnObstacle", 3, 2);
        

        // playerControllerScript = gameObject.Find("Player").GetComponent<PlayerMovement>();
    }

   

    // Update is called once per frame
    void spawnObstacle()
    {
        //Was unable to get crouching to fully work, however this is the code to randomize the height of the obstacle along the Y axis. Would need to change spawnPosition to a new Vector3 and set the RandomY to complete this.
        //float randomY = Random.Range(minY, maxY);
        // Vector3 spawnPosition = new Vector3(transform.position.x, randomY, transform.position.z);
        // int index = Random.Range(0, objectPrefabs.Length);
        int index = Random.Range(0, objectPrefabs.Length);
        Instantiate(objectPrefabs[index], spawnPostion, objectPrefabs[index].transform.rotation);
    }

    private void Update()
    {

        if (_playerMovement.GameOver == true)
        {
            CancelInvoke("spawnObstacle");
        }

    }
}
