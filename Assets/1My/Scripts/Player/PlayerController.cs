/******************************************************************************
* 작 성 일 : 2022-06-18
* 내    용 : 플레이어의 컨트롤을 담당
* 수 정 일 :
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
    * 설명 : 사용할 컴포넌트들의 참조를 불러옴
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
    * 설명 : 물리주기에 따라 플레이어를 움직임
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
    * 설명 : 플레이어의 일반공격
    ***********************************************************/
    public void ClickAttack()
    {
        playerAnimator.SetTrigger("Attack");
    }

    /**********************************************************
    * 설명 : 플레이어의 일반공격 이벤트
    ***********************************************************/
    private void Hit()
    {
        Debug.Log("플레이어가 때림");
        Debug.Log(weaponList.CurrentWeapon);
        //if (attackTarget == null)
        //    return;


        weaponList.CurrentWeapon.ExecuteAttack(gameObject, attackTarget);
        MonsterHealth targetHp = attackTarget.GetComponent<MonsterHealth>();
        targetHp.UpdateMonHp();
        attackTarget = null;
    }

    /**********************************************************
    * 설명 : 플레이어의 스킬공격
    ***********************************************************/
    public CircleRangeSkill rubyAttack;
    public void RubyAttack()
    {
        Debug.Log("[PlayerController]플레이어 스킬1사용");
        rubyAttack.Fire(gameObject, transform.position);

    }

    public StartPlayerSkill lineShot;
    public void LineShot()
    {
        Debug.Log("[PlayerController]플레이어 스킬2사용");
        lineShot.Fire(gameObject, transform.position);
    }





}
