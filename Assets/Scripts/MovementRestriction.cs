using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������������ ����� ������ �� ������� ������� ����
/// </summary>
public class MovementRestriction : MonoBehaviour
{
    [SerializeField] private Player player;

    void OnTriggerExit2D(Collider2D other)
    {
        //����� ����� ������� �� ������� ����� ������� - �� ������������ ������� � ��������������� ��� ������� �������
        player.transform.position = new Vector3(-player.transform.position.x, -player.transform.position.y);
    }
}
