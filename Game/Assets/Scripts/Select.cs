using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Select : MonoBehaviour
{
    [SerializeField] Text buttenText;

    private void Awake()
    {
        buttenText = GetComponentInChildren<Text>();
    }

    public void OnEnter()
    {
        buttenText.fontSize = 90;
    }

    public void OnLeave()
    {
        buttenText.fontSize = 75;
    }

    public void OnSelect()
    {
        buttenText.fontSize = 50;
    }
}
