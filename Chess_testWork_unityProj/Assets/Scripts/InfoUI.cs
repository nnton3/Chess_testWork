using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InfoUI : MonoBehaviour
{
    private Player player;
    [SerializeField] private Text currentTeamName;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        UpdateCurrentTeamName();
        player.playersSwapped.AddListener(UpdateCurrentTeamName);
    }

    public void UpdateCurrentTeamName()
    {
        currentTeamName.text = $"Now move {player.CurrentPlayer.ToString()}";
    }

    [SerializeField] private GameObject gameoverWindow;
    [SerializeField] private Text whoWinner;
    public void GameOver(string winnerName)
    {
        gameoverWindow.SetActive(true);
        whoWinner.text = $"{winnerName} is win!";
    }
}
