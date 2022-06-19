/******************************************************************************
* 작 성 일 : 2022-06-19
* 내    용 : 생명체 오브젝트들의 뼈대
* 수 정 일 :
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LivingEntity : MonoBehaviour , IDamageable
{
    public float maxHealth { get; protected set; }
    public float currentHealth { get; protected set; }
    public bool isDead { get; protected set; }
    public event Action onDeath;

    /**********************************************************
     설명 : 활성화 된 생명체의 초기상태 설정
    ***********************************************************/
    protected virtual void OnEnable()
    {
        isDead = false;
        currentHealth = maxHealth;
    }

    /**********************************************************
    * 설명 : 데미지를 입음
    ***********************************************************/
    public virtual void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal)
    {
        currentHealth -= damage;

        if(currentHealth <= 0 && !isDead)
        {
            Die();
        }
    }

    /**********************************************************
    * 설명 : 체력 회복
    ***********************************************************/
    public virtual void RestoreHealth(float newHealth)
    {
        if(isDead)
        {
            return;
        }
        currentHealth += newHealth;
    }

    /**********************************************************
    * 설명 : 사망 처리
    ***********************************************************/
    public virtual void Die()
    {
        if(onDeath != null)
        {
            onDeath();
        }

        isDead = true;
    }
}
