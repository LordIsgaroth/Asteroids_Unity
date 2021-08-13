using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerInformation _player;
    [SerializeField] private GameObject _borders;
    [SerializeField] private float _spawnCooldown;

    void Start()
    {        
        StartCoroutine(SpawnEnemy());
    }
   
    void Update() {}

    private IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(_spawnCooldown);

        while(true)
        {
            SpawnParameters spawnParameters = EnemyGeneration.GetSpawnParameters(_borders);
            GameObject generatedObject = Instantiate(EnemyGeneration.GetEnemy(), spawnParameters.Position, Quaternion.identity);
            generatedObject.transform.Rotate(0, 0, spawnParameters.RotationAngle);
            generatedObject.GetComponent<SpaceObject>().EnemyCollisionEvent.AddListener(Collision);

            yield return new WaitForSeconds(_spawnCooldown);
        }        
    }

    private void Collision(GameObject enemy, Collider2D other)
    {
        if(other.tag == "Player")
        {
            Destroy(other.gameObject);
        }
        else if(other.tag == "SimpleProjectile" && enemy.tag == "Shatters")
        {
            Destroy(enemy);
            GenerateShards(enemy);
        }
        else if((other.tag == "SimpleProjectile" && !(enemy.tag == "Shatters")) || other.tag == "AdvancedProjectile")
        {
            Destroy(enemy);
        }
    }

    private void GenerateShards(GameObject enemy)
    {
        GameObject shard1 = Instantiate(EnemyGeneration.GetPrefabByName("Shard"), enemy.transform.position, enemy.transform.rotation);
        shard1.transform.Rotate(0, 0, 45);
        shard1.GetComponent<SpaceObject>().EnemyCollisionEvent.AddListener(Collision);

        GameObject shard2 = Instantiate(EnemyGeneration.GetPrefabByName("Shard"), enemy.transform.position, enemy.transform.rotation);
        shard2.transform.Rotate(0, 0, -45);
        shard2.GetComponent<SpaceObject>().EnemyCollisionEvent.AddListener(Collision);
    }
}
