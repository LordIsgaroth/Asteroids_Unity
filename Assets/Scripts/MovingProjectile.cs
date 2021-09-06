using Movement;
using UnityEngine;

/// <summary>
/// ���������� ������
/// </summary>
public class MovingProjectile : MonoBehaviour
{
    [SerializeField] protected float _movementSpeed;

    private MovementView _movementView;

    public void Awake()
    {
        _movementView = GetComponent<MovementView>();
        _movementView.MovementSpeed = _movementSpeed;        
    }
}
