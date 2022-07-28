using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingbalance = 150;
    [SerializeField] int currentBalance;
    public int CurrentBalance { get { return currentBalance; } }

    [SerializeField] TMP_Text displayBalance;

    public void Awake()
    {
        currentBalance = startingbalance;
        UpdateBalance();
    }
    public void Desposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateBalance();
    }
    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        UpdateBalance();

        if (currentBalance <= 0)
        {
            ReloadScene();
        }
    }

    public void UpdateBalance()
    {
        displayBalance.text = "Gold: " + currentBalance;
    }

    public void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
