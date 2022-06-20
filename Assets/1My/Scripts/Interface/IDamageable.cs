/******************************************************************************
* 작 성 일 : 2022-06-19
* 내    용 : 데미지를 입을 수 있는 타입들이 상속할 인터페이스
* 수 정 일 :
*******************************************************************************/
using UnityEngine;

public interface IDamageable
{
    // 데미지 크기(damage), 맞은 지점(hitPoint), 맞은 표면의 방향(hitNormal)
    void OnDamage(float damage, Vector3 hitNormal);
}
