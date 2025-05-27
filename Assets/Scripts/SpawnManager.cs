using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obsticale;
    public Vector3 spawnPostion;
    public float delayTime = 5f;
    public float spawnInterval;
    public float startDelay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("spawnObsticale" ,3, 2);
        InvokeRepeating("Obsticale", startDelay, spawnInterval);
        Invoke("DestroyObject", delayTime);
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(obsticale, spawnPostion, obsticale.transform.rotation);
    }
}
