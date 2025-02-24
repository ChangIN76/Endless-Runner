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
    private static bool applicationIsQuitting = false; // ����Ƽ ���� �� ����� ����

    public static T Instance
    {
        get
        {
            if (applicationIsQuitting)
            {
                Debug.LogWarning($"[Singleton] {typeof(T)} �ν��Ͻ��� �̹� �����Ǿ����ϴ�.");
                return null;
            }

            if (instance == null)
            {
                instance = FindObjectOfType<T>();

                if (instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(T).Name);
                    instance = singletonObject.AddComponent<T>();

                    DontDestroyOnLoad(singletonObject); // �� ���� �� ���� ����
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
            Destroy(gameObject); // �ߺ� ���� ����
        }
    }

    private void OnApplicationQuit()
    {
        applicationIsQuitting = true;
    }
}

