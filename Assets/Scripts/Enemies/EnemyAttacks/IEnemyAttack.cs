/**********************************************************
 * Script Name: IEnemyAttack
 * Author: ��켺
 * Date Created: 2025-05-01
 * Last Modified: 0000-00-00
 * Description: 
 * - ���� ��� ������ �ϰ��� ������� �����ϵ��� ��
 *********************************************************/

using UnityEngine;

namespace EnemyAttack
{
    public interface IEnemyAttack
    {
        void SetProperties(float damage, Vector2? direction = null, float speed = 0f); // ���� �ӵ� �� �ʿ��� �Ӽ� ����
        void Execute(); // ���� ����
    }
}
