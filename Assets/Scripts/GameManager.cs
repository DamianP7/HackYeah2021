using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int EcoPoints
    {
        get => ecoPoints;
        set
        {
            ecoPoints = value;
            Debug.Log("Eco points: " + value);
            //ecoPointsText.text = ecoPoints.ToString();
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
    Text ecoPointsText;
    Text moneyText;

    private int ecoPoints;
    private int money;

    private void Awake()
    {
        EcoPoints = 0;
        Money = 0;
    }
}
