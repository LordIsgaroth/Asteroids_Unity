using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    
    void Update()
    {
        transform.Translate(Vector3.up * _movementSpeed * Time.deltaTime);
    }
}
