using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Text textTime;
    [SerializeField] int minute;
    [SerializeField] int second;
    [SerializeField] int millisecond;

    private float time;

    private void Awake()
    {
        textTime = GetComponent<Text>();
    }

    void Start()
    {
        StartCoroutine(Watch());
    }

    IEnumerator Watch()
    {
        while (GameManager.Instance.State)
        {
            time += Time.deltaTime;

            minute = (int)time / 60;
            second = (int)time % 60;
            millisecond = (int)((time - Mathf.Floor(time)) * 100);

            textTime.text = string.Format("{0:D2} : {1:D2} : {2:D2}", minute, second, millisecond);

            yield return null;
        }
    }
}
