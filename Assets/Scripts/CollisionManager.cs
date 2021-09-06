using Spawning;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Управление столкновениями объектов
/// </summary>
public class CollisionManager
{
    private static CollisionManager _instance;

    public UnityEvent PlayerCollidedEvent = new UnityEvent();
    public UnityEvent<int> SpaceObjectDestroyedEvent = new UnityEvent<int>(); 

    private CollisionManager() {}

    public static CollisionManager GetInstanse()
    {
        if (_instance == null) _instance = new CollisionManager();
        return _instance;
    }    

    public void Collision(SpaceObject spaceObject, Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameObject.Destroy(other.gameObject);
            PlayerCollidedEvent.Invoke();
        }
        else if (other.tag == "SimpleProjectile" && spaceObject.tag == "Shatters")
        {
            GameObject.Destroy(spaceObject.gameObject);
            SpaceObjectDestroyedEvent.Invoke(spaceObject.Score);
            GenerateShards(spaceObject);            
        }
        else if ((other.tag == "SimpleProjectile" && !(spaceObject.tag == "Shatters")) || other.tag == "AdvancedProjectile")
        {
            GameObject.Destroy(spaceObject.gameObject);
            SpaceObjectDestroyedEvent.Invoke(spaceObject.Score);            
        }
    }

    private void GenerateShards(SpaceObject enemy)
    {        
        float shardRotationAngle = 50f;        
        float enemyAngle = enemy.transform.rotation.eulerAngles.z;

        SpawnParameters firstShardParameters = new SpawnParameters();
        firstShardParameters.PrefabType = "Shard";
        firstShardParameters.Position = enemy.transform.position;
        firstShardParameters.RotationAngle = enemyAngle + shardRotationAngle;
        EnemyCreator.Create(firstShardParameters);

        SpawnParameters secondShardParameters = new SpawnParameters();
        secondShardParameters.PrefabType = "Shard";
        secondShardParameters.Position = enemy.transform.position;
        secondShardParameters.RotationAngle = enemyAngle - shardRotationAngle;
        EnemyCreator.Create(secondShardParameters);
    }
}
