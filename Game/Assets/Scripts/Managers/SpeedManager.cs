using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class SpeedManager : MonoBehaviour
{
    [SerializeField] UnityEvent callback;

    [SerializeField] static float speed;   // 초기 속도
    [SerializeField] float limitSpeed = 50.0f;   // 최대 속도

    public static float Speed
    { 
        get { return speed; }
    } 

    private void Awake()
    {
        speed = 20.0f; // 초기 속도 설정

        StartCoroutine(Increase()); // 속도 증가 코루틴 시작
    }

    IEnumerator Increase()
    {
        while (GameManager.Instance.State && Speed < limitSpeed)
        {      
            yield return CoroutineCache.WaitForSecond(TimeManager.Instance.IncreaseTime);

            if (callback != null)
            {
                callback.Invoke();
            }

            speed += 2; // 속도 증가         
        }
    }
}


