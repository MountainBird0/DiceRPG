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
    private float playerMoveSpeed = 4.0f;
    private float gravity = 20.0f;

    private Rigidbody playerRigidbody;
    private Animator playerAnimator;
    private PlayerCollision playerCollision;
    private CharacterController playerController;

    private Vector3 moveDir;

    /**********************************************************
    * ���� : ����� ������Ʈ���� ������ �ҷ���
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
    * ���� : �����ֱ⿡ ���� �÷��̾ ������
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
    * ���� : �÷��̾��� �Ϲݰ���
    ***********************************************************/
    public void ClickAttack()
    {
        //playerMoveSpeed = 0;


        playerAnimator.SetTrigger("Attack");
    }

}
