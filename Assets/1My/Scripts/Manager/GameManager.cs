/******************************************************************************
* �� �� �� : 2022-06-19
* ��    �� : ������ ��ü ������ scene�̵��� ���
* �� �� �� :
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public SkillDiceManager skillDiceManager;
    public static GameManager instance;

    private bool bossAlive = false;
    private int clearCount = 0;

    private Vector3 lastTowntransform;

    public Image changeScene;


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
            Debug.LogWarning("���� �ΰ� �̻��� GameManager�� �����մϴ�!");
            Destroy(gameObject);
        }

        //ObjectPoolManager.instance.GetObject("Player");
    }

    //public IEnumerator FadeIn(float time)
    //{
    //    Color color = image.color;
    //    while (color.a > 0f)
    //    {
    //        color.a -= Time.deltaTime / time;
    //        image.color = color;
    //        yield return null;
    //    }
    //}

    //public IEnumerator FadeOut(float time)
    //{
    //    Color color = image.color;
    //    while (color.a < 1f)
    //    {
    //        color.a += Time.deltaTime / time;
    //        image.color = color;
    //        yield return null;
    //    }
    //}


    /**********************************************************
    * ���� : ���ο� ������ ������
    ***********************************************************/
    public void StartNewGame()
    {
        SceneManager.LoadScene("Town");
        UiManager.instance.SetPlayerHp(true);
        StartCoroutine(Delay());    
    }

    /**********************************************************
    * ���� : Ÿ�� ���Ϳ� ������ �� ��Ʋ�ʵ�� �̵�
    ***********************************************************/
    public void MoveBattleField1()
    {
        skillDiceManager.GetRanDice();
        var prefab = GameObject.FindGameObjectWithTag("Player");
        prefab.GetComponent<CharacterController>().enabled = false;
        SceneManager.LoadScene("BattleField1");
        UiManager.instance.SetPlayerAttack(true);
        StartCoroutine(GoBattleField());
    }
    /**********************************************************
    * ���� : Ÿ�� ���Ϳ� ������ �� �غ����� �̵�
    ***********************************************************/
    public void MoveBattleFieldBeach()
    {
        skillDiceManager.GetRanDice();
        var prefab = GameObject.FindGameObjectWithTag("Player");
        prefab.GetComponent<CharacterController>().enabled = false;
        SceneManager.LoadScene("BattleFieldBeach");
        UiManager.instance.SetPlayerAttack(true);
        StartCoroutine(GoBattleField());
    }
    /**********************************************************
    * ���� : ������ ������ �� ���������� �̵�
    ***********************************************************/
    public void MoveBattleFieldBoss()
    {
        skillDiceManager.GetRanDice();
        var prefab = GameObject.FindGameObjectWithTag("Player");
        prefab.GetComponent<CharacterController>().enabled = false;
        SceneManager.LoadScene("BattleFieldBoss");
        UiManager.instance.SetPlayerAttack(true);
        StartCoroutine(GoBattleField());
    }

    /**********************************************************
    * ���� : ��Ż�� �浹���� �� Ÿ������ �̵�
    ***********************************************************/
    public void MoveTown()
    {
        clearCount++;
        if(clearCount == 1)
        {
            SpawnManager.instance.BossSpawning();
        }

        var prefab = GameObject.FindGameObjectWithTag("Player");
        prefab.GetComponent<CharacterController>().enabled = false;
        SceneManager.LoadScene("Town");
        UiManager.instance.SetPlayerAttack(false);
        StartCoroutine(GoTown());
    }

    /**********************************************************
    * ���� : �� ��ȯ�ϴ� ���� ���� ȭ��
    ***********************************************************/
    IEnumerator Delay()
    {
        Debug.Log($"[GameManager] : �������ִ���");

        yield return 0;

        var prefab = ObjectPoolManager.instance.GetObject("Player2");
        var startPoint = GameObject.FindGameObjectWithTag("StartPoint");
        Debug.Log(startPoint);
        prefab.transform.position = startPoint.transform.position;
        //prefab.transform.position = Vector3.zero;

        Debug.Log($"[GameManager] : �÷��̾� ��ġ {prefab.transform.position}");
    }

    /**********************************************************
    * ���� : ��Ʋ�ʵ�� �̵�
    ***********************************************************/
    IEnumerator GoBattleField()
    {
        yield return new WaitForSeconds(0.2f);
        var prefab = GameObject.FindGameObjectWithTag("Player");
        var startPoint = GameObject.FindGameObjectWithTag("StartPoint");
        lastTowntransform = prefab.transform.position;
        prefab.transform.localPosition = startPoint.transform.position;
        prefab.GetComponent<CharacterController>().enabled = true;     
    }

    /**********************************************************
    * ���� : Ÿ������ �̵�
    ***********************************************************/
    IEnumerator GoTown()
    {
        yield return new WaitForSeconds(0.2f);
        var prefab = GameObject.FindGameObjectWithTag("Player");
        prefab.transform.position = lastTowntransform;
        prefab.GetComponent<CharacterController>().enabled = true;
    }

    /**********************************************************
    * ���� : �������Ͱ� ����ִ��� ����
    ***********************************************************/
    public bool IsBossAlive()
    {
        return bossAlive;
    }

    /**********************************************************
    * ���� : �������� ���� ����
    ***********************************************************/
    public void SetBossAlive(bool what)
    {
        bossAlive = what;
    }
}
