using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
