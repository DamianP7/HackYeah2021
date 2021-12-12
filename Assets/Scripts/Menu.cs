using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{

    public void ToggleMusic()
    {
        Music.Instance.Toggle();
    }

    public void Exit()
    {
        Application.Quit();
    }
}