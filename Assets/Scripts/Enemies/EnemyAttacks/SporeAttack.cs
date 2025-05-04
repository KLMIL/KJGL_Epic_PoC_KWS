/**********************************************************
 * Script Name: SporeAttack
 * Author: 김우성
 * Date Created: 2025-05-01
 * Last Modified: 2025-05-04
 * Description: 
 * - 식물 몬스터 중, 포자 공격 기능
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
        //Debug.Log($"SporeAttack initialized with damage: {_damage}, direction: {_direction}, speed: {_speed}");
    }

    public void Execute()
    {
        // 필요 시 추가 로직 작성
    }

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Health playerHealth = collision.GetComponent<Health>();
            if (playerHealth != null)
            {
                Debug.Log($"SporeAttack hit Player, dealing {_damage} damage");
                // 2025-05-04 KWS
                // TakeDamage 함수 수정을 위해 임시 문자열 삽입
                playerHealth.TakeDamage(_damage, "Unknown");
            }
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Destroy(gameObject, 5f); // 5초 후 제거
    }
}
