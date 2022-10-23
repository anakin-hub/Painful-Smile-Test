using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class EndGameManager : MonoBehaviour
{
    [SerializeField] protected SwapInformation _info;
    [SerializeField] TMP_Text _scoreText;


    void Start()
    {
        _info = FindObjectOfType<SwapInformation>();
        _scoreText.text = _info.FinalScore.ToString();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        _info.DestroyObject();
    }
}
