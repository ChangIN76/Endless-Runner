using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManuManager : MonoBehaviour
{
    public void Execute()
    {
        GameManager.Instance.Execute();

        StartCoroutine(SceneryManager.Instance.AsyncLoad(1));      
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
}
