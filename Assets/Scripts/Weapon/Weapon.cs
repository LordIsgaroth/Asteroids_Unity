using UnityEngine;

public class Weapon : MonoBehaviour, IWeapon
{
    [SerializeField] protected float _cooldown;
    [SerializeField] protected GameObject _projectile;
    [SerializeField] protected GameObject _shootingPosition;

    protected float _currentCooldown;

    protected void Start()
    {
        _currentCooldown = 0;
    }

    protected void Update()
    {
        ReduceCooldown();
    }
    
    private void ReduceCooldown()
    {
        if (_currentCooldown > 0) _currentCooldown -= Time.deltaTime;
        else if (_currentCooldown < 0) _currentCooldown = 0;
    }

    public virtual void Shoot()
    {
        if(_currentCooldown == 0)
        {
            Instantiate(_projectile, _shootingPosition.transform.position, transform.rotation);
            _currentCooldown = _cooldown;
        }        
    }
}
