using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHealth : LivingEntity
{
    public GameObject hpBar;
    public GameObject ground;


    private void Awake()
    {
        maxHealth = 100f;
    }

    private void Update()
    {
        hpBar.transform.rotation = Camera.main.transform.rotation;
        ground.transform.rotation =  Camera.main.transform.rotation;

    }

    public void UpdateMonHp()
    {
        Debug.Log("[MonsterHealth] hp바 업데이트");
        hpBar.transform.localScale = new Vector3(1 * (currentHealth / maxHealth), 1, 1);

    }
}
