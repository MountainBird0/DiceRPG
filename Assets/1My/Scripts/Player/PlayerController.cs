/******************************************************************************
* �� �� �� : 2022-06-18
* ��    �� : �÷��̾��� ��Ʈ���� ���
* �� �� �� :
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : LivingEntity
{
    private float playerMoveSpeed = 10.0f;
    private float gravity = 20.0f;

    private Rigidbody playerRigidbody;
    private Animator playerAnimator;
    private PlayerCollision playerCollision;
    private CharacterController playerController;

    private GameObject attackTarget;
    private WeaponList weaponList;

    private InputManager inputManager;

    private Vector3 moveDir;
    private Vector3 rotDir;

    public LineRenderer playerSkillRange;

    private float curHp;

    /**********************************************************
    * ���� : ����� ������Ʈ���� ������ �ҷ���
    ***********************************************************/
    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        playerController = GetComponent<CharacterController>();
        playerCollision = GetComponent<PlayerCollision>();
        //DontDestroyOnLoad(gameObject);

        curHp = currentHealth;
    }

    private void Start()
    {
        playerController.enabled = true;
    }

    private void FixedUpdate()
    {
        moveDir.y -= gravity * Time.deltaTime;
    }


    /**********************************************************
    * ���� : �����ֱ⿡ ���� �÷��̾ ������
    ***********************************************************/
    private void Update()
    {
        if (curHp != currentHealth)
        {
            playerAnimator.SetTrigger("Damaged");
            curHp = currentHealth;
        }

        moveDir = new Vector3(inputManager.moveX, moveDir.y, inputManager.moveZ);
        rotDir = new Vector3(inputManager.moveX, 0, inputManager.moveZ);

        playerController.Move(moveDir * Time.deltaTime * playerMoveSpeed);
        

        if (inputManager.IsMove())
        {
            transform.rotation = Quaternion.LookRotation(rotDir);
        }

        playerAnimator.SetFloat("Move", inputManager.MoveValue());
    }


    /**********************************************************
    * ���� : �÷��̾��� �Ϲݰ���
    ***********************************************************/
    public void ClickAttack()
    {
        playerAnimator.SetTrigger("Attack");
    }

    /**********************************************************
    * ���� : �÷��̾��� �Ϲݰ��� �̺�Ʈ
    ***********************************************************/
    private void Hit()
    {
        Debug.Log("�÷��̾ ����");
        Debug.Log(weaponList.CurrentWeapon);
        //if (attackTarget == null)
        //    return;

        weaponList.CurrentWeapon.ExecuteAttack(gameObject, attackTarget);
        MonsterHealth targetHp = attackTarget.GetComponent<MonsterHealth>();
        targetHp.UpdateMonHp();
        attackTarget = null;
    }

    /**********************************************************
    * ���� : �÷��̾��� ��ų����
    ***********************************************************/
    public CircleRangeSkill rubyAttack;
    public void RubyAttack()
    {
        playerAnimator.SetTrigger("Skill1");
        rubyAttack.Fire(gameObject, transform.position, 10);
    }

    public CircleRangeSkill groundSlap;
    public void GroundSlap()
    {
        playerAnimator.SetTrigger("Skill1");
        groundSlap.Fire(gameObject, transform.position, 10);
    }

    public StartPlayerSkill lineShot;
    public void LineShot()
    {
        Debug.Log("[PlayerController]�÷��̾� ��ų2���");
        DrawRangeLineShot();
        lineShot.Fire(gameObject, transform.position, 8);
    }
    public void DrawRangeLineShot()
    {
        playerSkillRange.SetPosition(0, transform.position);
        playerSkillRange.SetPosition(1, transform.position + transform.forward * 3);
    }
}
