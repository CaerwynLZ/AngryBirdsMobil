using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject wincanvas;
    public GameObject losecanvas;
    public GameObject slinger;
    public GameObject enemyHold;
    Slingshot s;
    WinCondition hold;

    public GameObject[] stars;

    public Text textCounter;

    public void Start()
    {
        stars[0].SetActive(true);
        stars[1].SetActive(true);
        stars[2].SetActive(true);

        Time.timeScale = 1;
        losecanvas.SetActive(false);
        wincanvas.SetActive(false);
        s = slinger.GetComponent<Slingshot>();
        hold = enemyHold.GetComponent<WinCondition>();

        textCounter.text = s.count + "X";
    }

    private void Update()
    {
        textCounter.text = s.count + "X";


        if (s.count <= 0 && hold.check)
        {
            losecanvas.SetActive(true);
            Time.timeScale = 0;
        }
        if (hold.check == false && s.count > 0)
        {
            wincanvas.SetActive(true);
            Time.timeScale = 0;
        }

        if (s.count <= 6)
        {
            stars[2].SetActive(false);
        }
        if (s.count <= 4)
        {
            stars[1].SetActive(false);
        }
        if (s.count <= 2)
        {
            stars[0].SetActive(false);
        }

    }
    public void QuitGame()
    {
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Application.Quit();
    }

    public void LaunchGame()
    {
        SceneManager.LoadScene(1);
    }

    public void NextLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
