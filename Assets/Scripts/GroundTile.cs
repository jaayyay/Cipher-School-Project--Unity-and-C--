using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] GameObject obstaclePrefab;

    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile(true);
        Destroy(gameObject, 2);
    }

    public void SpawnObstacle()
    {
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    public void SpawnCoins()
    {
        int coinsToSpawn = 8;

        for (int i = 0; i < coinsToSpawn; i++)
        {
            GameObject temp = Instantiate(coinPrefab,transform);
            temp.transform.position = GetRandomPointsInCollider(GetComponent<Collider>());
        }
    }
    
    Vector3 GetRandomPointsInCollider (Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );

        if(point != collider.ClosestPoint(point))
        {
            point = GetRandomPointsInCollider(collider);
        }

        point.y = 1;
        return point;
    }
}
