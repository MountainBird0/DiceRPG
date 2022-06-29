/******************************************************************************
* 작 성 일 : 2022-06-18
* 내    용 : 플레이어의 컨트롤을 담당
* 수 정 일 :
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour //LivingEntity
{
    private float playerMoveSpeed = 5.0f;
    private float gravity = 20.0f;

    private Animator playerAnimator;
    private CharacterController playerController;

    private InputManager inputManager;

    private Vector3 moveDir;
    private Vector3 rotDir;

    public LineRenderer playerSkillRange;

    private LivingEntity playerEntity;

    private float curHp;

    private bool isSuperArmor = false;

    public GameObject effectPrefabChannelRed;
    public GameObject effectPrefabRegenerateRed;

    /**********************************************************
    * 설명 : 사용할 컴포넌트들의 참조를 불러옴
    ***********************************************************/
    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerAnimator = GetComponent<Animator>();
        playerController = GetComponent<CharacterController>();
        //DontDestroyOnLoad(gameObject);

        playerEntity = GetComponent<LivingEntity>();

        curHp = playerEntity.currentHealth;
        
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
        if (curHp != playerEntity.currentHealth)
        {
            if(!isSuperArmor)
            {
                playerAnimator.SetTrigger("Damaged");
            }
            curHp = playerEntity.currentHealth;
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
    * 설명 : 플레이어의 일반공격
    ***********************************************************/
    //public void ClickAttack()
    //{
    //    playerAnimator.SetTrigger("Attack");
    //}

    /**********************************************************
    * 설명 : 플레이어의 일반공격 이벤트
    ***********************************************************/
    //private void Hit()
    //{
    //    //Debug.Log("플레이어가 때림");
    //    //Debug.Log(weaponList.CurrentWeapon);
    //    //if (attackTarget == null)
    //    //   return;

    //    //weaponList.CurrentWeapon.ExecuteAttack(gameObject, attackTarget);
    //    //MonsterHealth targetHp = attackTarget.GetComponent<MonsterHealth>();
    //    //targetHp.UpdateMonHp();
    //    //attackTarget = null;
    //}

    /**********************************************************
    * 설명 : 플레이어의 스킬공격
    ***********************************************************/
    public BasicAttackSkill basicAttack;
    public void BasicAttack()
    {
        playerAnimator.SetTrigger("Attack");
        basicAttack.Fire(gameObject, transform.position, 10);
    }

    public CircleRangeSkill rubyAttack;
    public void RubyAttack()
    {
        playerAnimator.SetTrigger("Skill1");
        rubyAttack.Fire(gameObject, transform.position, 8);
    }

    public CircleRangeSkill groundSlap;
    public void GroundSlap()
    {
        isSuperArmor = true;
        playerMoveSpeed = 7f;
        playerAnimator.SetTrigger("Dash");
        Dash();
        StartCoroutine(RGroundSlap());
    }
    private void Dash()
    {
        var go = Instantiate(effectPrefabChannelRed, transform.position, transform.rotation);
        go.transform.position = transform.position;
        Destroy(go, 2f);

        playerController.Move(gameObject.transform.forward * Time.deltaTime * 2);
        
    }
    IEnumerator RGroundSlap()
    {
        yield return new WaitForSeconds(1.7f);
        Vector3 pos = transform.position + transform.forward * 2;
        groundSlap.Fire(gameObject, pos, 8);
        playerMoveSpeed = 3f;

        isSuperArmor=false;
    }

    public StartPlayerSkill lineShot;
    public void LineShot()
    {
        Debug.Log("[PlayerController]플레이어 스킬2사용");
        //DrawRangeLineShot();
        lineShot.Fire(gameObject, transform.position, 8);
    }
    //public void DrawRangeLineShot()
    //{
    //    playerSkillRange.SetPosition(0, transform.position);
    //    playerSkillRange.SetPosition(1, transform.position + transform.forward * 3);
    //}
}
