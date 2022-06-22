/******************************************************************************
* �� �� �� : 2022-06-18
* ��    �� : �÷��̾��� ��Ʈ���� ���
* �� �� �� :
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float playerMoveSpeed = 10.0f;
    private float gravity = 20.0f;

    private Rigidbody playerRigidbody;
    private Animator playerAnimator;
    private PlayerCollision playerCollision;
    private CharacterController playerController;

    private GameObject attackTarget;
    private WeaponList weaponList;

    private Vector3 moveDir;
    private Vector3 rotDir;

    /**********************************************************
    * ���� : ����� ������Ʈ���� ������ �ҷ���
    ***********************************************************/
    private void Awake()
    {

        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        playerController = GetComponent<CharacterController>();
        playerCollision = GetComponent<PlayerCollision>();
        DontDestroyOnLoad(gameObject);
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
        moveDir = new Vector3(InputManager.instance.moveX, moveDir.y, InputManager.instance.moveZ);
        rotDir = new Vector3(InputManager.instance.moveX, 0, InputManager.instance.moveZ);

        playerController.Move(moveDir * Time.deltaTime * playerMoveSpeed);
        

        if (InputManager.instance.IsMove())
        {
            transform.rotation = Quaternion.LookRotation(rotDir);
        }

        playerAnimator.SetFloat("Move", InputManager.instance.MoveValue());
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
        Debug.Log("[PlayerController]�÷��̾� ��ų1���");
        rubyAttack.Fire(gameObject, transform.position);

    }

    public StartPlayerSkill lineShot;
    public void LineShot()
    {
        Debug.Log("[PlayerController]�÷��̾� ��ų2���");
        lineShot.Fire(gameObject, transform.position);
    }





}
