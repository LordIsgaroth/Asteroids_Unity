
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] float _cooldown;
    private float _currentCooldown;

    private void Start()
    {
        _currentCooldown = 0;
    }

    private void Update()
    {
        ReduceCooldown();
    }
    
    private void ReduceCooldown()
    {
        if (_currentCooldown > 0) _currentCooldown -= Time.deltaTime;
        else if (_currentCooldown < 0) _currentCooldown = 0;
    }

    public void Shoot(GameObject projectilePrefab)
    {
        if(_currentCooldown == 0)
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
            _currentCooldown = _cooldown;
        }        
    }

    public static GameObject GetProjectileByName(string name)
    {
        GameObject projectile = (GameObject)Resources.Load($"Prefabs/{name}", typeof(GameObject));

        if (projectile == null) throw new System.Exception($"Projectile {name} not found!");

        return projectile;
    }
}
