using System;
using UnityEngine;

public static class EnemyGeneration
{
    private enum SpawnMode
    {
        top = 0,
        bottom = 1,
        left = 2,
        right = 3
    }

    public static GameObject GetEnemy()
    {
        GameObject enemy = (GameObject)Resources.Load("Prefabs/Asteroid", typeof(GameObject));       

        return enemy;
    }

    public static Vector2 GetSpawnPosition(GameObject borders)
    {
        Collider2D bordersCollider = borders.GetComponent<Collider2D>();

        if (bordersCollider == null) throw new Exception("Borders does not contain Collider2D!");

        float topBorder = bordersCollider.bounds.max.y;
        float bottomBorder = bordersCollider.bounds.min.y;
        float leftBorder = bordersCollider.bounds.min.x;
        float rightBorder = bordersCollider.bounds.max.x;

        SpawnMode spawnMode = GetSpawnMode();
        float spawnX = 0;
        float spawnY = 0;

        switch(spawnMode)
        {
            case SpawnMode.top:
                spawnY = topBorder;
                spawnX = UnityEngine.Random.Range(leftBorder, rightBorder);
                break;
            case SpawnMode.bottom:
                spawnY = bottomBorder;
                spawnX = UnityEngine.Random.Range(leftBorder, rightBorder);
                break;
            case SpawnMode.left:
                spawnX = leftBorder;
                spawnY = UnityEngine.Random.Range(bottomBorder, topBorder);
                break;
            case SpawnMode.right:
                spawnX = rightBorder;
                spawnY = UnityEngine.Random.Range(bottomBorder, topBorder);
                break;          
        }

        return new Vector2(spawnX, spawnY);
    }

    private static SpawnMode GetSpawnMode()
    {
        return (SpawnMode)Enum.GetValues(typeof(SpawnMode)).GetValue(UnityEngine.Random.Range(0,4));
    }
}
