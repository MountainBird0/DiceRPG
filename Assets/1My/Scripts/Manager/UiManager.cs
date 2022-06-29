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
    public GameObject Smithy;

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
                //InventoryManager.instance.FreshSmithySlot();
            }
        }
    }

    /**********************************************************
    * ���� : ���� ���� ���� UI Ȱ��ȭ
    ***********************************************************/
    public void SetPlayerHp(bool tf)
    {
        playerHp.SetActive(tf);
        inven.SetActive(true);
        StartCoroutine(InvenOff());
    }

    IEnumerator InvenOff()
    {
        yield return new WaitForSeconds(0.1f);      
        inven.SetActive(false);
    }

    public void SetPlayerAttack(bool tf)
    {
        playerAttack.SetActive(tf);
    }
    public void SetSmithy(bool tf)
    {
        Smithy.SetActive(tf);
    }
    public void OnClickExit()
    {
        Smithy.SetActive(false);
    }


    public void UpdatePlayerHp(float curHp, float maxHp)
    {
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
        player.GetComponent<PlayerController>().BasicAttack();
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

    //public void OnClickSkillSlot1()
    //{
    //    //Debug.Log("[UiManager]��ų��ư ����");

    //    var player = GameObject.FindGameObjectWithTag("Player");
    //    player.GetComponent<PlayerController>().RubyAttack();
    //    // gameObject.GetComponent<Image>().sprite
    //    //    = Resources.Load("Skill/RedIcon", typeof(Sprite)) as Sprite;
    //}
}

//GetComponent<Button>().interactable = true;

//GetComponent<Button>().interactable = false;
