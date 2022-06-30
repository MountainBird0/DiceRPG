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
    public float maxHealth;
    public float currentHealth { get;  set; }
    public int damage { get; protected set; }
    public bool isDead { get; protected set; }

    public event Action onDeath;

    /**********************************************************
     ���� : Ȱ��ȭ �� ����ü�� �ʱ���� ����
    ***********************************************************/
    protected virtual void OnEnable()
    {
        Debug.Log("Enable()", this);
        isDead = false;
        currentHealth = maxHealth;
        Debug.Log($"[LivingEntity]����ü��{currentHealth},{gameObject}");
        Debug.Log($"[LivingEntity]�ִ�ü��{maxHealth},{gameObject}");
        //if (gameObject.CompareTag("BattleMonster") && currentHealth != 0)
        //{
        //    MonsterHealth targetHp = gameObject.GetComponent<MonsterHealth>();
        //    targetHp.UpdateMonHp();
        //}
    }

    //�����
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            Debug.Log($"[LivingEntity]����ü��{currentHealth},{gameObject}");
            Debug.Log($"[LivingEntity]�ִ�ü��{maxHealth},{gameObject}");
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
        //if(currentHealth > maxHealth)
        //{
        //    currentHealth = maxHealth;
        //}
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
        int ranNum = UnityEngine.Random.Range(1, 7);
        string name = "Dice"+ranNum.ToString();

        var dice = ObjectPoolManager.instance.GetObject(name);
        Vector3 dropPos = transform.position;
        dropPos.y = transform.position.y + 1;
        dice.transform.position = dropPos;
        isDead = true;
    }

    /**********************************************************
    * ���� : ������ ����
    ***********************************************************/
    public void OnAttack(GameObject attacker, Attack attack)
    {
        Debug.Log($"[LivingEntity]�±�������ü��{currentHealth},{gameObject}", gameObject);
        currentHealth -= attack.Damage;
        Debug.Log($"[LivingEntity]����ü��{currentHealth}");

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
