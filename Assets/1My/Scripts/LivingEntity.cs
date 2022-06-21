/******************************************************************************
* �� �� �� : 2022-06-19
* ��    �� : ����ü ������Ʈ���� ����
* �� �� �� :
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LivingEntity : MonoBehaviour , IDamageable , IAttackable
{
    public float maxHealth { get; protected set; }
    public float currentHealth { get; protected set; }
    public int damage { get; protected set; }
    public bool isDead { get; protected set; }

    public event Action onDeath;

    /**********************************************************
     ���� : Ȱ��ȭ �� ����ü�� �ʱ���� ����
    ***********************************************************/
    protected virtual void OnEnable()
    {
        isDead = false;
        maxHealth = 100;
        currentHealth = maxHealth;
    }


    /**********************************************************
    * ���� : ü�� ȸ��
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
    * ���� : ��� ó��
    ***********************************************************/
    public virtual void Die()
    {
        if(onDeath != null)
        {
            onDeath();
        }

        isDead = true;
    }

    /**********************************************************
    * ���� : ������ ��
    ***********************************************************/
    public void OnAttack(GameObject attacker, Attack attack)
    {
        currentHealth -= attack.Damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;

            Debug.Log("You Die");
        };
    }

    /**********************************************************
    * ���� : �������� ����
    ***********************************************************/
    public virtual void OnDamage(float damage, Vector3 hitNormal)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log($"{gameObject.name}�� {damage} ����, ����ü�� {currentHealth}");
        if(currentHealth == 0 && !isDead)
        {
            Debug.Log("����");
            Die();
        }
    }
}
