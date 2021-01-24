using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI : MonoBehaviour
{
    static public UI ui;
    public int life;
    [SerializeField] GameObject[] LifeIndik;
    public int score;
    [SerializeField] GameObject player, lifePanel, scorePanel, diePanel, gameOver,itogScore;
    private void Awake()
    {
        ui = this;
        life = 3;
        score = 0;
        lifePanel.SetActive(true);
        scorePanel.SetActive(true);
        diePanel.SetActive(false);
        gameOver.SetActive(false);
    }

    private void Update()
    {
        scorePanel.GetComponent<Text>().text = score.ToString();
        switch (life)
        {
            case 3:
                LifeIndik[0].SetActive(true);
                LifeIndik[1].SetActive(true);
                LifeIndik[2].SetActive(true);
                break;
            case 2:
                LifeIndik[0].SetActive(true);
                LifeIndik[1].SetActive(true);
                LifeIndik[2].SetActive(false);
                break;
            case 1:
                LifeIndik[0].SetActive(true);
                LifeIndik[1].SetActive(false);
                LifeIndik[2].SetActive(false);
                break;
            case 0:
                lifePanel.SetActive(false);
                scorePanel.SetActive(false);
                player.SetActive(false);
                diePanel.SetActive(false);
                gameOver.SetActive(true);
                itogScore.GetComponent<Text>().text = $"Ваш счёт: {score}";
                break;
        }
    }

    public void ShotMetior()
    {
        score+=2;
    }

    public void die()
    {
        if (life >= 2)
        {
            diePanel.SetActive(true);
        }
        life--;
    }

    public void ContinueGame()
    {
        diePanel.SetActive(false);
        player.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("game");
    }
}
