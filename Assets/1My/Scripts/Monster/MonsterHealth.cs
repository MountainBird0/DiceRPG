using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHealth : LivingEntity
{
    public GameObject Hpbar;

    public Camera cameraToLookAt;

    private void Awake()
    {
        cameraToLookAt = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        maxHealth = 100f;
    }


    private void Update()
    {


        //Hpbar.transform.localScale = new Vector3(1 * (currentHealth / maxHealth), 1, 1);     
    }

    

    public void UpdateMonHp()
    {
        Debug.Log("[MonsterHealth] hp바 업데이트");
        Hpbar.transform.localScale = new Vector3(1 * (currentHealth / maxHealth), 1, 1);

    }
}
