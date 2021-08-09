using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _borders;    

    void Start()
    {        
        StartCoroutine(SpawnEnemy());
    }
   
    void Update() {}

    private IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(2);

        while(true)
        {
            Vector2 spawnPosition = EnemyGeneration.GetSpawnPosition(_borders);
            GameObject generatedObject = Instantiate(EnemyGeneration.GetEnemy(), spawnPosition, Quaternion.identity);
            //generatedObject.GetComponent<>().MovementDestination = new Vector2(-spawnPosition.x, -spawnPosition.y);            

            yield return new WaitForSeconds(1);
        }

        //yield return null;
    }    
}
