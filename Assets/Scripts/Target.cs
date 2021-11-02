using UnityEngine;

public class Target : MonoBehaviour {
    private Rigidbody targetRb;
    private GameManager gameManager;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = 6;
    public int pointValue;
    public ParticleSystem explosionParticle;

    //test consulo0.7
    // Start is called before the first frame update
    void Start() {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(
                RandomTorque(maxTorque),
                RandomTorque(maxTorque),
                RandomTorque(maxTorque),
                ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnMouseDown() {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
    }

    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }

    Vector3 RandomForce() {
        return Vector3.up * RandomTorque(minSpeed, maxSpeed);
    }

    float RandomTorque() {
        return Random.Range(-maxTorque, maxTorque);
    }

    float RandomTorque(float between) {
        return Random.Range(-between, between);
    }

    float RandomTorque(float from, float to) {
        return Random.Range(from, to);
    }

    Vector3 RandomSpawnPos() {
        return new Vector3(RandomTorque(xRange), -ySpawnPos);
    }
}