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

    public override void Die()
    {
        base.Die();
        this.gameObject.SetActive(false);
    }

    public void UpdateMonHp()
    {
        Hpbar.transform.localScale = new Vector3(1 * (currentHealth / maxHealth), 1, 1);

    }
}
