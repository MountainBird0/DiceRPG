/******************************************************************************
* 작 성 일 : 2022-06-21
* 내    용 : 전체적인 UI를 관리
* 수 정 일 :
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
     * 설명 : 게임 시작과 동시에 싱글톤을 구성
     ***********************************************************/
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("씬에 두개 이상의 UiManager 존재합니다!");
            Destroy(gameObject);
        }

        //ObjectPoolManager.instance.GetObject("Player");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("인밴열기 누름");

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
    * 설명 : 현재 씬에 따라 UI 활성화
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
        Debug.Log("newstart 누름");
        GameManager.instance.StartNewGame();
    }

    public void OnClickAttack()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().BasicAttack();
    }

    public void OnClickSkill1()
    {
        //Debug.Log("[UiManager]스킬버튼 누름");

        var player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().RubyAttack();
    }

    public void OnClickSkill2()
    {
        Debug.Log("[UiManager]스킬2 버튼 누름");

        var player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().LineShot();
    }

    //public void OnClickSkillSlot1()
    //{
    //    //Debug.Log("[UiManager]스킬버튼 누름");

    //    var player = GameObject.FindGameObjectWithTag("Player");
    //    player.GetComponent<PlayerController>().RubyAttack();
    //    // gameObject.GetComponent<Image>().sprite
    //    //    = Resources.Load("Skill/RedIcon", typeof(Sprite)) as Sprite;
    //}
}

//GetComponent<Button>().interactable = true;

//GetComponent<Button>().interactable = false;
