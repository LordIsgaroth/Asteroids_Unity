using Spawning;
using UnityEngine;
using UnityEngine.Events;

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
            //GameOver();
        }
        else if (other.tag == "SimpleProjectile" && spaceObject.tag == "Shatters")
        {
            GameObject.Destroy(spaceObject.gameObject);
            SpaceObjectDestroyedEvent.Invoke(spaceObject.Score);

            GenerateShards(spaceObject);
            //AddScore(spaceObject);s
        }
        else if ((other.tag == "SimpleProjectile" && !(spaceObject.tag == "Shatters")) || other.tag == "AdvancedProjectile")
        {
            GameObject.Destroy(spaceObject.gameObject);
            SpaceObjectDestroyedEvent.Invoke(spaceObject.Score);
            //Destroy(spaceObject.gameObject);
            //AddScore(spaceObject);
        }
    }

    private void GenerateShards(SpaceObject enemy)
    {        
        float shardRotationAngle = 50f;
        enemy.transform.Rotate(0, 0, shardRotationAngle);

        SpawnParameters firstShardParameters = new SpawnParameters();
        firstShardParameters.PrefabType = "Shard";
        firstShardParameters.Position = enemy.transform.position;
        firstShardParameters.RotationAngle = shardRotationAngle;
        EnemyCreator.Create(firstShardParameters);

        SpawnParameters secondShardParameters = new SpawnParameters();
        secondShardParameters.PrefabType = "Shard";
        secondShardParameters.Position = enemy.transform.position;
        secondShardParameters.RotationAngle = -shardRotationAngle;
        EnemyCreator.Create(secondShardParameters);

        //GameObject shard1 = Instantiate(, enemy.transform.position, enemy.transform.rotation);
        //shard1.transform.Rotate(0, 0, 45);
        //shard1.GetComponent<SpaceObject>().EnemyCollisionEvent.AddListener(Collision);

        //GameObject shard2 = Instantiate(PrefabsManager.GetPrefabByName("Shard"), enemy.transform.position, enemy.transform.rotation);
        //shard2.transform.Rotate(0, 0, -45);
        //shard2.GetComponent<SpaceObject>().EnemyCollisionEvent.AddListener(Collision);
    }
}
