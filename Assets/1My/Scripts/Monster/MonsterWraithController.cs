/******************************************************************************
* 작 성 일 : 2022-06-23
* 내    용 : 보스몬스터 Wraith의 AI를 담당 
* 수 정 일 :
*******************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterWraithController : MonoBehaviour
{
    public enum Status
    {
        Idle,
        Trace,
        Attack,
        Charging,
        Spin,
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
                    gauge.SetActive(false);

                    agent.destination = target.transform.position;
                    agent.speed = speed;
                    agent.isStopped = false;
                    break;

                case Status.Attack:
                    timer = 0f;
                    agent.isStopped = true;
                    break;

                case Status.Charging:
                    gauge.SetActive(true);
                    chargingTime = 3f;
                    charging.transform.localScale = new Vector2(1,1);
                    agent.isStopped = true;
                    break;

                case Status.Die:
                    timer = 0f;
                    agent.isStopped = true;
                    break;

                case Status.Spin:
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

    public GameObject gauge;
    public GameObject charging;
    private float chargingSpeed = 2f;
    private float chargingTime = 3f;


    public float idleWaitTime = 1f;
    private float timer;

    private float targetDistance; // 안쓸거같음

    private int attackCount = 0;

    private float curHp;

    private LivingEntity monsterEntity;

    public GameObject hpBar;
    public GameObject ground;

    private bool isDie = false;

    void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        gauge.SetActive(false);
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

        if (curHp <= 0 && !isDie)
        {
            currentStatus = Status.Die;
            isDie = true;
        }

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
            case Status.Charging:
                UpdateCharging();
                break;
            case Status.Spin:
                UpdateSpin();
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
            if (attackCount >= 3)
            {
                CurrentStats = Status.Charging;
            }
            else
            {
                CurrentStats = Status.Attack;
            }
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
            Debug.Log($"[MonsterWraithController]공격횟수증가 : {attackCount}");
            if (attackCount >= 3)
            {
                CurrentStats = Status.Charging;
                return;
            }
            animator.SetTrigger("Attack");
            attackCount++;
        }
    }

    /**********************************************************
    * 설명 : 스킬 공격 전 차지
    ***********************************************************/
    private void UpdateCharging()
    {
        chargingTime -= Time.deltaTime;

        if (chargingTime > 0)
        {
            charging.transform.localScale = new Vector2(charging.transform.localScale.x + (chargingSpeed * Time.deltaTime),
               charging.transform.localScale.y + (chargingSpeed * Time.deltaTime));
        }
        else
        {
            CurrentStats = Status.Spin;
        }
    }

    private void UpdateSpin()
    {
        //charging.transform.localScaleㄴ = new Vector2(1+ (charging.transform.localScale.x * chargingSpeed),
        //1+ (charging.transform.localScale.y * chargingSpeed));
        attackCount = 0;
        SpinAttack();
        CurrentStats = Status.Trace;

    }


    /**********************************************************
    * 설명 : 스킬 공격
    ***********************************************************/
    public CircleRangeSkill Spin;
    private void  SpinAttack()
    {
        Debug.Log("[MonsterWraithController]몬스터 스핀 사용");
        Spin.Fire(gameObject, transform.position, 8);
        animator.SetTrigger("Skill1");

    }


    private void Hit()
    {
        Debug.Log("hit 드감");
        switch (weapon)
        {
            case Weapon w:
                Debug.Log($"[MonsterController] : {gameObject} hit 이벤트 발생");
                w.ExecuteAttack(gameObject, target.gameObject);
                LivingEntity life = target.GetComponent<LivingEntity>();
                UiManager.instance.UpdatePlayerHp(life.currentHealth, life.maxHealth);
                break;
        }
        //weapon.ExecuteAttack(gameObject, player.gameObject);
    }

    public void UpdateDie()
    {
        gauge.SetActive(false);
        charging.SetActive(false);
        CurrentStats = Status.GameOver;
        agent.isStopped = true;
        monsterEntity.Die();
        animator.SetTrigger("Die");
        StartCoroutine(SetAct());
    }

    IEnumerator SetAct()
    {
        yield return new WaitForSeconds(5f);
        this.gameObject.SetActive(false);

    }

    public void UpdateMonHp()
    {
        Debug.Log("[MonsterHealth] hp바 업데이트");
        hpBar.transform.localScale = new Vector3(1 * (monsterEntity.currentHealth / monsterEntity.maxHealth), 1, 1);

    }
}
