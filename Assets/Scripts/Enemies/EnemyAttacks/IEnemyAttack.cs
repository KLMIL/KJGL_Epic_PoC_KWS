/**********************************************************
 * Script Name: IEnemyAttack
 * Author: 김우성
 * Date Created: 2025-05-01
 * Last Modified: 0000-00-00
 * Description: 
 * - 적의 모든 공격이 일관된 방식으로 동작하도록 함
 *********************************************************/

using UnityEngine;

namespace EnemyAttack
{
    public interface IEnemyAttack
    {
        void SetProperties(float damage, Vector2? direction = null, float speed = 0f); // 공격 속도 등 필요한 속성 설정
        void Execute(); // 공격 실행
    }
}
