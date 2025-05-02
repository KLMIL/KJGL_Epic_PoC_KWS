/**********************************************************
 * Script Name: Explosion
 * Author: 김우성
 * Date Created: 2025-05-02
 * Last Modified: 0000-00-00
 * Description
 * - 폭발 프리팹(SaltExplosion)의 생명 주기와 트리거 감지 관리
 *********************************************************/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Explosion: MonoBehaviour
{
    [SerializeField] float _duration = 0.5f; // 폭발 지속시간
    [SerializeField] int _damage = 5; // 대미지
    [SerializeField] float _radius = 0.5f; // 폭발 범위
    [SerializeField] bool _continuousDamage = false;
    
    CircleCollider2D _collider2D;

    private void Awake()
    {
        _collider2D = GetComponent<CircleCollider2D>();
        if (_collider2D != null)
        {
            _collider2D.radius = _radius;
        }
    }

    private void Start()
    {
        Destroy(gameObject, _duration);
    }

    private void Update()
    {
        if (_continuousDamage)
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, _radius);
            foreach (Collider2D hit in hits)
            {
                Debug.Log("Explosion Damage");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_continuousDamage)
        {
            Debug.Log("Explosion Enter Damage");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_continuousDamage)
        {
            Debug.Log("Explosion Stay Damage");
        }
    }

    public void SetDamage(int newDamage)
    {
        _damage = newDamage;
        transform.GetComponent<AttackTrigger>().SetDamage(_damage);
    }
}