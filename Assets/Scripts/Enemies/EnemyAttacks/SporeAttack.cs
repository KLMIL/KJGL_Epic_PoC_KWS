/**********************************************************
 * Script Name: SporeAttack
 * Author: ��켺
 * Date Created: 2025-05-01
 * Last Modified: 0000-00-00
 * Description: 
 * - �Ĺ� ���� ��, ���� ���� ���
 *********************************************************/

using EnemyAttack;
using UnityEngine;

public class SporeAttack : MonoBehaviour, IEnemyAttack
{
    Vector2 _direction;
    float _speed;
    float _damage;

    public void SetProperties(float damage, Vector2? direction = null, float speed = 0f)
    {
        _damage = damage;
        _direction = direction ?? Vector2.zero;
        _speed = speed;
        Debug.Log($"SporeAttack initialized with damage: {_damage}, direction: {_direction}, speed: {_speed}");
    }

    public void Execute()
    {
        // �ʿ� �� �߰� ���� �ۼ�
    }

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                Debug.Log($"SporeAttack hit Player, dealing {_damage} damage");
                playerHealth.TakeDamage(_damage);
            }
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Destroy(gameObject, 5f); // 5�� �� ����
    }
}
