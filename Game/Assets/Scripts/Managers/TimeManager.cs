using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : Singleton<TimeManager>
{
    [SerializeField] float activeTime;
    [SerializeField] float increaseTime;

    public float ActiveTime
    { 
        get { return activeTime; }
    }

    public float IncreaseTime
    { 
        get { return increaseTime; } 
    }

    protected override void Awake()
    {
        base.Awake();

        activeTime = 2.5f;
        increaseTime = 2.5f;
    }

    private void Start()
    {
        StartCoroutine(Decrease());
    }

    IEnumerator Decrease()
    {
        while (GameManager.Instance.State && activeTime > 0.5f)
        {
            if (GameManager.Instance.State == false) yield return null;

            yield return CoroutineCache.WaitForSecond(4.0f);

            activeTime -= 0.25f;

            Debug.Log(activeTime);
        }
    }
}
