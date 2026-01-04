using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class FinishLine : MonoBehaviour
{
    public GameObject winPanel;
    public TextMeshProUGUI winText;
    private bool raceFinished = false;

    private void OnTriggerEnter(Collider other)
    {
        if (raceFinished)
            return;
        NavMeshAgent agent = other.GetComponent<NavMeshAgent>();
        if (agent == null)
            return;
        raceFinished = true;
        string winnerName = other.gameObject.name.Replace("(Clone)", "");
        ShowWinUI(winnerName);
    }

    void ShowWinUI(string winnerName)
    {
        winPanel.SetActive(true);
        winText.text = $"{winnerName} Won the race!";
        Time.timeScale = 0f;
    }
}
