/******************************************************************************
* 작 성 일 : 2022-06-19
* 내    용 : 생명체 오브젝트들의 뼈대
* 수 정 일 :
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
     설명 : 활성화 된 생명체의 초기상태 설정
    ***********************************************************/
    protected virtual void OnEnable()
    {
        Debug.Log("Enable()", this);
        isDead = false;
        currentHealth = maxHealth;
        Debug.Log($"[LivingEntity]현재체력{currentHealth},{gameObject}");
        Debug.Log($"[LivingEntity]최대체력{maxHealth},{gameObject}");
        //if (gameObject.CompareTag("BattleMonster") && currentHealth != 0)
        //{
        //    MonsterHealth targetHp = gameObject.GetComponent<MonsterHealth>();
        //    targetHp.UpdateMonHp();
        //}
    }

    //실험용
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            Debug.Log($"[LivingEntity]현재체력{currentHealth},{gameObject}");
            Debug.Log($"[LivingEntity]최대체력{maxHealth},{gameObject}");
        }
    }

    /**********************************************************
    * 설명 : 체력 회복
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
    * 설명 : 사망 처리
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
    * 설명 : 공격을 받음
    ***********************************************************/
    public void OnAttack(GameObject attacker, Attack attack)
    {
        Debug.Log($"[LivingEntity]맞기전현재체력{currentHealth},{gameObject}", gameObject);
        currentHealth -= attack.Damage;
        Debug.Log($"[LivingEntity]현재체력{currentHealth}");

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
            Debug.Log($"[LivingEntity]{gameObject}You Die");
        };
    }

    /**********************************************************
    * 설명 : 데미지를 입음
    ***********************************************************/
    //public virtual void OnDamage(float damage, Vector3 hitNormal)
    //{
    //    currentHealth -= damage;
    //    currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

    //    Debug.Log($"{gameObject.name}가 {damage} 입음, 남은체력 {currentHealth}");
    //    if (currentHealth == 0 && !isDead)
    //    {
    //        Debug.Log("죽음");
    //        Die();
    //    }
    //}
}
