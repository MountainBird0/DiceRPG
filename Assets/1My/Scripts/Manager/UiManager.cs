/******************************************************************************
* �� �� �� : 2022-06-21
* ��    �� : ��ü���� UI�� ����
* �� �� �� :
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    public GameObject playerHp;
    public GameObject playerAttack;
    public Image hpBar;

    public GameObject inven;
    private bool isInvenOpen = false;

    /**********************************************************
     * ���� : ���� ���۰� ���ÿ� �̱����� ����
     ***********************************************************/
    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("���� �ΰ� �̻��� UiManager �����մϴ�!");
            Destroy(gameObject);
        }

        //ObjectPoolManager.instance.GetObject("Player");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("�ι꿭�� ����");

            if (!isInvenOpen)
            {
                inven.SetActive(true);
                isInvenOpen = true;
            }
            else
            {
                inven.SetActive(false);
                isInvenOpen = false;
            }
        }

    }


    /**********************************************************
    * ���� : ���� ���� ���� UI Ȱ��ȭ
    ***********************************************************/
    public void SetPlayerHp(bool tf)
    {
        playerHp.SetActive(tf);
    }
    public void SetPlayerAttack(bool tf)
    {
        playerAttack.SetActive(tf);
    }




    public void UpdatePlayerHp(float curHp, float maxHp)
    {
        //Hpbar.transform.localScale = new Vector3(1 * (player.GetComponent<PlayerHealth>().currentHealth
          //      / player.GetComponent<PlayerHealth>().maxHealth), 1, 1);
        hpBar.fillAmount = curHp / maxHp;

    }

    public void OnClickNewStart()
    {
        Debug.Log("newstart ����");
        GameManager.instance.StartNewGame();
    }

    public void OnClickAttack()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().ClickAttack();
    }

    public void OnClickSkill1()
    {
        //Debug.Log("[UiManager]��ų��ư ����");

        var player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().RubyAttack();
    }

    public void OnClickSkill2()
    {
        Debug.Log("[UiManager]��ų2 ��ư ����");

        var player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().LineShot();
    }
}

//GetComponent<Button>().interactable = true;

//GetComponent<Button>().interactable = false;
