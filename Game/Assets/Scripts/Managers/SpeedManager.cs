using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpeedManager : MonoBehaviour
{
    [SerializeField] private float InstallSpeed = 20f; // 초기 속도
    [SerializeField] private float limitSpeed = 50f;   // 최대 속도

    WaitForSeconds waitForSeconds = new WaitForSeconds(2.5f); // 2.5초 대기

    public static float Speed { get; private set; } // 현재 속도를 저장하는 static 변수

    private void Awake()
    {
        Speed = InstallSpeed; // 초기 속도 설정

        StartCoroutine(Increase()); // 속도 증가 코루틴 시작
    }

    private IEnumerator Increase()
    {
        while (Speed < limitSpeed)
        {
            yield return waitForSeconds;

            Speed += 2; // 속도 증가

            Speed = Mathf.Min(Speed, limitSpeed); // 최대 속도 제한

            Debug.Log(Speed);
        }
    }
}


