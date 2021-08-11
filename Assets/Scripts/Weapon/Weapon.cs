using UnityEngine;

public class Weapon : MonoBehaviour, IWeapon
{
    [SerializeField] private float _cooldown;
    [SerializeField] private GameObject _projectile;
    [SerializeField] private GameObject _shootingPosition;

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

    public void Shoot()
    {
        if(_currentCooldown == 0)
        {
            Instantiate(_projectile, _shootingPosition.transform.position, transform.rotation);
            _currentCooldown = _cooldown;
        }        
    }

    //public static GameObject GetProjectileByName(string name)
    //{
    //    GameObject projectile = (GameObject)Resources.Load($"Prefabs/{name}", typeof(GameObject));

    //    if (projectile == null) throw new System.Exception($"Projectile {name} not found!");

    //    return projectile;
    //}
}
