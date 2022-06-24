/******************************************************************************
* �� �� �� : 2022-06-19
* ��    �� : ����ü ������Ʈ���� ����
* �� �� �� :
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LivingEntity : MonoBehaviour, IAttackable
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
        if (gameObject.CompareTag("BattleMonster"))
        {
            MonsterHealth targetHp = gameObject.GetComponent<MonsterHealth>();
            targetHp.UpdateMonHp();
        }
    }


    /**********************************************************
    * ���� : ü�� ȸ��
    ***********************************************************/
    public virtual void RestoreHealth(float newHealth)
    {
        if (isDead)
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
        if (onDeath != null)
        {
            onDeath();
        }

        isDead = true;
    }

    /**********************************************************
    * ���� : ������ ����
    ***********************************************************/
    public void OnAttack(GameObject attacker, Attack attack)
    {
        currentHealth -= attack.Damage;
        Debug.Log($"[LivingEntity]����ü��{currentHealth}");
        if (gameObject.CompareTag("BattleMonster"))
        {
            MonsterHealth targetHp = gameObject.GetComponent<MonsterHealth>();
            targetHp.UpdateMonHp();
        }

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
            Debug.Log($"[LivingEntity]{gameObject}You Die");
        };
    }

    /**********************************************************
    * ���� : �������� ����
    ***********************************************************/
    //public virtual void OnDamage(float damage, Vector3 hitNormal)
    //{
    //    currentHealth -= damage;
    //    currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

    //    Debug.Log($"{gameObject.name}�� {damage} ����, ����ü�� {currentHealth}");
    //    if (currentHealth == 0 && !isDead)
    //    {
    //        Debug.Log("����");
    //        Die();
    //    }
    //}
}
