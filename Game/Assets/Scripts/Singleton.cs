using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get { return Instance; }
    }

    protected virtual void Awake()
    {
        if(instance == null)
        {
            instance = (T)FindAnyObjectByType(typeof(T));
        }
        else 
        {
            Destroy(instance);

            return;
        }

        DontDestroyOnLoad(gameObject);
    }

}
*/

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    private static bool applicationIsQuitting = false; // 유니티 종료 시 재생성 방지

    public static T Instance
    {
        get
        {
            if (applicationIsQuitting)
            {
                Debug.LogWarning($"[Singleton] {typeof(T)} 인스턴스는 이미 삭제되었습니다.");
                return null;
            }

            if (instance == null)
            {
                instance = FindObjectOfType<T>();

                if (instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(T).Name);
                    instance = singletonObject.AddComponent<T>();

                    DontDestroyOnLoad(singletonObject); // 씬 변경 시 삭제 방지
                }
            }

            return instance;
        }
    }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject); // 중복 생성 방지
        }
    }

    private void OnApplicationQuit()
    {
        applicationIsQuitting = true;
    }
}

