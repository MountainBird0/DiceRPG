/******************************************************************************
* �� �� �� : 2022-06-21
* ��    �� : ������ �⺻ AI�� ��� 
* �� �� �� :
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour
{
    public enum Status
    {
        Idle,
        Trace,
        Attack,
        Die,
        GameOver,
    }

    private Status currentStatus;

    public Status CurrentStats
    {
        get
        {
            return currentStatus;
        }
        set
        {
            currentStatus = value;
            switch (currentStatus)
            {
                case Status.Idle:
                    timer = idleWaitTime;
                    agent.isStopped = true;
                    break;

                case Status.Trace:
                    agent.destination = target.transform.position;
                    agent.speed = speed;
                    agent.isStopped = false;
                    break;

                case Status.Attack:
                    timer = 0f;
                    agent.isStopped = true;
                    break;
                case Status.Die:
                    timer = 0f;
                    agent.isStopped = true;
                    break;

                case Status.GameOver:
                    agent.isStopped = true;
                    break;

                default:
                    break;
            }
        }
    }

    public Weapon weapon;

    float speed = 1;

    Animator animator;
    NavMeshAgent agent;

    private GameObject target;
    public float idleWaitTime = 1f;
    private float timer;

    private float targetDistance; // �Ⱦ��Ű���

    private float curHp;

    private LivingEntity monsterEntity;

    public GameObject hpBar;
    public GameObject ground;

    void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        monsterEntity = GetComponent<LivingEntity>();
        curHp = monsterEntity.currentHealth;
    }

    private void Start()
    {

        target = GameObject.FindGameObjectWithTag("Player");
        if (target != null)
        {
            Init();


        }
        CurrentStats = Status.Idle;
    }

    private void Update()
    {
        hpBar.transform.rotation = Camera.main.transform.rotation;
        ground.transform.rotation =  Camera.main.transform.rotation;

        if (curHp != monsterEntity.currentHealth)
        {
            animator.SetTrigger("Damaged");
            UpdateMonHp();
            curHp = monsterEntity.currentHealth;
        }
        

        animator.SetFloat("Speed", agent.velocity.magnitude);

        //if (currentStatus != Status.GameOver && player == null)
        //{
        //    CurrentStats = Status.GameOver;
        //    return;
        //}
        if (target != null)
        {
            targetDistance = Vector3.Distance(transform.position, target.transform.position);
        }

        switch (currentStatus)
        {
            case Status.Idle:
                UpdateIdle();
                break;
            case Status.Trace:
                UpdateTrace();
                break;
            case Status.Attack:
                UpdateAttack();
                break;
            case Status.Die:
                UpdateDie();
                break;
        }
    }

    private void Init()
    {
        agent.enabled = true;
    }

    private void UpdateIdle()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            CurrentStats = Status.Trace;
        }
    }

    private void UpdateTrace()
    {

        agent.destination = target.transform.position;
        if (targetDistance < weapon.attackRange)
        {
            CurrentStats = Status.Attack;
        }
    }

    private void UpdateAttack()
    {
        if (targetDistance > weapon.attackRange)
        {
            CurrentStats = Status.Trace;
            return;
        }

        var pos = target.transform.position;
        pos.y = transform.position.y;
        transform.LookAt(pos);

        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            timer = weapon.coolDown;
            animator.SetTrigger("Attack");

        }
    }

    private void UpdateDie()
    {
        agent.isStopped = true;
        animator.SetTrigger("Die");
        StartCoroutine(SetAct());
    }

    private void Hit()
    {
        Debug.Log("hit �尨");
        switch (weapon)
        {
            case Weapon w:
                Debug.Log($"[MonsterController] : {gameObject} hit �̺�Ʈ �߻�");
                w.ExecuteAttack(gameObject, target.gameObject);
                LivingEntity life = target.GetComponent<LivingEntity>();
                Debug.Log($"[MonsterController] : Ÿ����?{target},,�ҷ��� ����ü��{life.currentHealth} ,, �ִ�ü��{life.maxHealth}", target);
                UiManager.instance.UpdatePlayerHp(life.currentHealth, life.maxHealth);
                break;
        }
        //weapon.ExecuteAttack(gameObject, player.gameObject);
    }

    public void Die()
    {
        
        
        animator.SetTrigger("Die");
        StartCoroutine(SetAct());
    }



    IEnumerator SetAct()
    {
        yield return new WaitForSeconds(2f);
        this.gameObject.SetActive(false);

    }

    public void UpdateMonHp()
    {
        Debug.Log("[MonsterHealth] hp�� ������Ʈ");
        hpBar.transform.localScale = new Vector3(1 * (monsterEntity.currentHealth / monsterEntity.maxHealth), 1, 1);

    }
}
