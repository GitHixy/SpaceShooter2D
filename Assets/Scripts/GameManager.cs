using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject menuPanel;
    public GameObject gamePanel;
    public Text countdownText;
    public Text startText;

    public EnemySpawner enemySpawner; // Reference to the spawner script

    private void Start()
    {
        menuPanel.SetActive(true);
        gamePanel.SetActive(false);
        enemySpawner.enabled = false; // Disable enemy spawning initially
        startText.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        menuPanel.SetActive(false);
        gamePanel.SetActive(true);
        StartCoroutine(StartGameCountdown());
    }

    private IEnumerator StartGameCountdown()
    {
        int countdown = 5;
        countdownText.gameObject.SetActive(true);

        while (countdown > 0)
        {
            countdownText.text = countdown.ToString();
            yield return new WaitForSeconds(1f);
            countdown--;
        }

        countdownText.gameObject.SetActive(false);

        // Show "START!!" for 1 second
        startText.gameObject.SetActive(true);
        startText.text = "START!";
        yield return new WaitForSeconds(1f);
        startText.gameObject.SetActive(false);

        enemySpawner.enabled = true; // Enable enemy spawning
    }
}
