using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Movement
{
    /// <summary>
    /// �������� ����� � ���������� ���������
    /// </summary>
    public class ForwardMovement : Movement
    {
        void Update()
        {
            transform.Translate(Vector3.up * _movementSpeed * Time.deltaTime);
        }
    }
}