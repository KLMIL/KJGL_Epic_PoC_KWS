/**********************************************************
 * Script Name: RootAttack
 * Author: 김우성
 * Date Created: 2025-05-01
 * Last Modified: 0000-00-00
 * Description: 
 * - 식물 몬스터의 뿌리 공격 기능 구현
 *********************************************************/

using UnityEngine;


namespace EnemyAttack
{
    public class RootAttack : MonoBehaviour, IEnemyAttack
    {
        float _damage;

        public void SetProperties(float damage, Vector2? direction = null, float speed = 0f)
        {
            _damage = damage;
        }

        public void Execute()
        {
            // 뿌리 공격은 즉시 실행
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(_damage);
                }
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            Destroy(gameObject, 2f);
        }
    }
}

