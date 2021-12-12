using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public int EcoPoints
    {
        get => ecoPoints;
        set
        {
            ecoPoints = value;
            Debug.Log("Eco points: " + value);
            ecoPointsBar.fillAmount = ecoPoints * 0.1f;
            if(value > 10)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    public int Money
    {
        get => money;
        set
        {
            money = value;
            Debug.Log("Money: " + value);
            //moneyText.text = money.ToString();
        }
    }


    [SerializeField]
    Image ecoPointsBar;
    Text moneyText;

    private int ecoPoints;
    private int money;

    private void Awake()
    {
        EcoPoints = 0;
        Money = 0;
    }
}
