using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LivingEntity : MonoBehaviour
{
    public float startingHealth = 100f;//시작 체력
    public float startingMana = 0f;//시작 마나

    // protected 클래스 외부에서는 기본적으로 접근할 수 없으나 파생 클래스(자식 클래스)에서는 접근이 가능하다.
    public float health {  get; protected set; } //현재 체력  
    public float mana { get; protected set; }   // 현제 마나
    public bool dead {  get; protected set; } // 사망 상테  

    //생명체가 활성화될 떄 상태를 리셋
    // virtual 가상
    protected virtual void OnEnable()
    {
        //사망하지 않은 상태로 시작
        dead = false;
         //체력을 시작 체력으로 초기화
        health = startingHealth;
        mana = startingMana;
    }

    // 피해를 받는 기능
    public virtual void OnEnable(float damage)
    {
        health -= damage;

        if(health <= 0 && !dead)
        {
            Die();
            Debug.Log("적을 처치 했습니다.");
        }
    }

    //사망처리
    public virtual void Die()
    {
        //onDeath 이벤트에 등록된 메서드가 있다면 실행
     //  if (onDeath != null) 적 등록 후 사용
        {
     //       onDeath();
        }
        dead = true;
    }
}
