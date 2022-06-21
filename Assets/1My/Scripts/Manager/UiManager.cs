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
     * 설명 : 게임 시작과 동시에 싱글톤을 구성
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
            Debug.LogWarning("씬에 두개 이상의 UiManager 존재합니다!");
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
        Debug.Log("newstart 누름");
        GameManager.instance.StartNewGame();
    }
}
