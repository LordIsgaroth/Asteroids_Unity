using UnityEngine;

/// <summary>
/// Работа с префабами
/// </summary>
public static class PrefabsManager
{
    public static GameObject GetPrefabByName(string name)
    {
        GameObject prefab = (GameObject)Resources.Load($"Prefabs/{name}", typeof(GameObject));

        if (prefab == null) throw new System.Exception($"Prefab with name {name} not found!");

        return prefab;
    }
}
