/******************************************************************************
* 작 성 일 : 2022-06-21
* 내    용 : 무기를 장착할 곳
* 수 정 일 :
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponList : MonoBehaviour
{
    public Weapon[] weapons = new Weapon[3];
    private Weapon currentWeapon;
    private GameObject weaponGo;
    //private HeroController heroCtrl;

    public Weapon CurrentWeapon
    {
        get { return currentWeapon; }
    }

    public void EquipWeapon(Weapon newWeapon, Transform parent)
    {
        if (newWeapon == null)
            return;

        UnequipWeapon();
        currentWeapon = newWeapon;
        weaponGo = Instantiate(newWeapon.prefab, parent);
    }

    public void UnequipWeapon()
    {
        if (weaponGo == null)
        {
            return;
        }
        currentWeapon = null;
        Destroy(weaponGo);
    }

    private void Awake()
    {
        //heroCtrl = GetComponent<HeroController>();
    }

    public void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    EquipWeapon(weapons[0], heroCtrl.weaponDummy);
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    EquipWeapon(weapons[1], heroCtrl.weaponDummy);
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    EquipWeapon(weapons[2], heroCtrl.weaponDummy);
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha0))
        //{
        //    UnequipWeapon();
        //}
    }
}
