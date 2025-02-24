using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManuManager : MonoBehaviour
{
    public void Execute()
    {
        StartCoroutine(SceneryManager.Instance.AsyncLoad(1));      
    }

    public void Quit()
    {
        Debug.Log("Quit");
    }

}
