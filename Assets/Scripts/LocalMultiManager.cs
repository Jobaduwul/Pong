using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LocalMultiManager : MonoBehaviour
{
    public Button retryButton;
    public Button mainMenuButton;
    public TextMeshProUGUI victoryText;
    public GameObject ball;
    public bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(ball.transform.position.x < -10)
        {
            victoryText.text = "Player 2 wins";
            isGameOver = true;
        }
        else if(ball.transform.position.x > 10)
        {
            victoryText.text = "Player 1 wins";
            isGameOver = true;
        }

        if(isGameOver)
        {
            retryButton.gameObject.SetActive(true);
            mainMenuButton.gameObject.SetActive(true);
            victoryText.gameObject.SetActive(true);
        }
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadRetry()
    {
        SceneManager.LoadScene(1);
    }
}
