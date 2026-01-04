using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class FinishLine : MonoBehaviour
{
    public GameObject winPanel;
    public TextMeshProUGUI winText;
    private bool raceFinished = false;

    public void Awake()
    {
        MoveAgent.PlayerTouchedFinishLine += OnPlayerTouchedFinishLine;
    }
    
    

    private void OnPlayerTouchedFinishLine(GameObject player)
    {
        if (raceFinished)
            return;
        if (!player.CompareTag("Player"))
            return;
        raceFinished = true;
        string winnerName = player.name.Replace("(Clone)", "");
        ShowWinUI(winnerName);
    }
    
    
    void ShowWinUI(string winnerName)
    {
        winPanel.SetActive(true);
        winText.text = $"{winnerName} Won the race!";
        Time.timeScale = 0f;
    }
}
