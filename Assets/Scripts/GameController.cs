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
            Vector2 spawnPosition = EnemyGeneration.GetSpawnPosition(_borders);
            GameObject generatedObject = Instantiate(EnemyGeneration.GetEnemy(), spawnPosition, Quaternion.identity);            
            generatedObject.GetComponent<Enemy>().EnemyCollisionEvent.AddListener(EnemyCollision);

            yield return new WaitForSeconds(_spawnCooldown);
        }        
    }

    private void EnemyCollision(GameObject enemy, Collider2D other)
    {
        if(other.tag == "Player")
        {
            Destroy(other.gameObject);
        }
        else if(other.tag == "Projectile")
        {
            Destroy(enemy);            
        }
    }
}
