/**********************************************************
 * Script Name: RootAttack
 * Author: 김우성
 * Date Created: 2025-05-01
 * Last Modified: 2025-05-04
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
                Health playerHealth = collision.GetComponent<Health>();
                if (playerHealth != null)
                {
                    // 2025-05-04 KWS
                    // TakeDamage 함수 수정을 위해 임시 문자열 삽입
                    playerHealth.TakeDamage(_damage, "Unknown");
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

