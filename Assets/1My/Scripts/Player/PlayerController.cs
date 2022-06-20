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
    private float playerMoveSpeed = 4.0f;
    private float gravity = 20.0f;

    private Rigidbody playerRigidbody;
    private Animator playerAnimator;
    private PlayerCollision playerCollision;
    private CharacterController playerController;

    private Vector3 moveDir;

    /**********************************************************
    * 설명 : 사용할 컴포넌트들의 참조를 불러옴
    ***********************************************************/
    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);

        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerController = GetComponent<CharacterController>();
        playerCollision = GetComponent<PlayerCollision>();
    }

    /**********************************************************
    * 설명 : 물리주기에 따라 플레이어를 움직임
    ***********************************************************/
    private void Update()
    {
        moveDir = new Vector3(InputManager.instance.moveX, 0, InputManager.instance.moveZ);

        playerController.Move(moveDir * Time.deltaTime * playerMoveSpeed);

        if(InputManager.instance.IsMove())
        {
            transform.rotation = Quaternion.LookRotation(moveDir);
        }

        playerAnimator.SetFloat("Move", InputManager.instance.MoveValue());
    }


    /**********************************************************
    * 설명 : 플레이어의 일반공격
    ***********************************************************/
    public void ClickAttack()
    {
        //playerMoveSpeed = 0;


        playerAnimator.SetTrigger("Attack");
    }

}
