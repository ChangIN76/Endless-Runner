using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private bool state;

    public bool State { get { return State; } }

    public void Execute()
    {
        state = true;
    }

    public void Finish()
    {
        state = false;
    }
}
