using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCollision : MonoBehaviour
{
    //private UiManager uiManager;

    public void Awake()
    {
        //uiManager = GetComponent<UiManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LivingEntity life = other.GetComponent<LivingEntity>();
            life.OnDamage(10, transform.position);
            Debug.Log( $"[MonsterCollision]{life.name}, {life.currentHealth}, " +
                $"{life.maxHealth}");
            UiManager.instance.UpdatePlayerHp(life.currentHealth, life.maxHealth);
        }

    }
}
