using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHealth : MonoBehaviour
{
    public GameObject hpBar;
    public GameObject ground;

    private LivingEntity monsterEntity;

    private void Awake()
    {
        monsterEntity = GetComponent<LivingEntity>();
    }


    private void Update()
    {
        hpBar.transform.rotation = Camera.main.transform.rotation;
        ground.transform.rotation =  Camera.main.transform.rotation;
    }



    public void UpdateMonHp()
    {
        Debug.Log("[MonsterHealth] hp바 업데이트");
        hpBar.transform.localScale = new Vector3(1 * (monsterEntity.currentHealth / monsterEntity.maxHealth), 1, 1);

    }
}
