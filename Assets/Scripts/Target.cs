using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorgue = 10;
    private float xRange = 4;
    private float ySpawnPos = 6;
    //test Consulo0.3
    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(
            RandomTorgue(maxTorgue),
            RandomTorgue(maxTorgue),
            RandomTorgue(maxTorgue),
            ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    Vector3 RandomForce()
    {
        return Vector3.up * RandomTorgue(minSpeed, maxSpeed);
    }

    float RandomTorgue()
    {
        return Random.Range(-maxTorgue, maxTorgue);
    }

    float RandomTorgue(float between)
    {
        return Random.Range(-between, between);
    }

    float RandomTorgue(float from, float to)
    {
        return Random.Range(from, to);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(RandomTorgue(xRange), -ySpawnPos);
    }
}