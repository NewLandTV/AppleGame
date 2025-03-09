using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject panelMainMenu;
    [SerializeField]
    private GameObject panelInGame;
    [SerializeField]
    private GameObject panelGameOver;
    [SerializeField]
    private TextMeshProUGUI textInGameScore;
    [SerializeField]
    private TextMeshProUGUI textGameOverScore;
    [SerializeField]
    private Image timeGauge;
    [SerializeField]
    private float maxTime = 120f;

    private int currentScore;
    private AudioSource audioSource;

    public bool IsGameStart { get; private set; } = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void GameStart()
    {
        IsGameStart = true;

        panelMainMenu.SetActive(false);
        panelInGame.SetActive(true);
        audioSource.Play();

        StartCoroutine(TimeCounter());
    }

    public void IncreaseScore(int addScore)
    {
        currentScore += addScore;
        textInGameScore.text = currentScore.ToString();
    }

    public void ButtonRestart()
    {
        SceneManager.LoadScene(0);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        textGameOverScore.text = $"SCORE\n{currentScore}";
        panelInGame.SetActive(false);
        panelGameOver.SetActive(true);
        audioSource.Stop();
    }

    private IEnumerator TimeCounter()
    {
        float currentTime = maxTime;

        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            timeGauge.fillAmount = currentTime / maxTime;
            Debug.Log(currentTime);

            yield return null;
        }

        GameOver();
    }
}
