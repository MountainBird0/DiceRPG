using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    public GameObject playerUI;
    public Image hpBar;

    /**********************************************************
     * ���� : ���� ���۰� ���ÿ� �̱����� ����
     ***********************************************************/
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

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

    private void Start()
    {
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name != "Title")
        {
            playerUI.SetActive(true);
        }
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
