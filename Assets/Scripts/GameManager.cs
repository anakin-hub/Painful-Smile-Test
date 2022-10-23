using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] protected SwapInformation _swapInformationScene;
    [SerializeField] protected PlayerMovement _player;
    [SerializeField] protected int _points;
    [SerializeField] protected float _matchTime;
    [SerializeField] protected bool _gameIsOver;
    [SerializeField] protected TMP_Text _pointsText;

    void Awake()
    {
        _swapInformationScene = FindObjectOfType<SwapInformation>();

        _gameIsOver = false;
        _points = 0;

        _matchTime = _swapInformationScene.GameSessionTime;
        gameObject.GetComponent<EnemiesSpawner>().SetSpawnTime(_swapInformationScene.EnemySpawnTime);

        if (_matchTime > 180)
            _matchTime = 180;
        if (_matchTime < 60)
            _matchTime = 60;

        StartCoroutine(GameTimeOut());
    }

    void Update()
    {
        if (_player.GetCurrentHP() <= 0 && !_gameIsOver)
            StartCoroutine(EndGame());
    }

    public void Reward()
    {
        _points++;
        _pointsText.text = _points.ToString();
    }

    IEnumerator GameTimeOut()
    {
        yield return new WaitForSeconds(_matchTime);
        if( !_gameIsOver )
            StartCoroutine(EndGame());
    }

    IEnumerator EndGame()
    {
        _gameIsOver = true;
       _player.DeathScene();
        _swapInformationScene.FinalScore = _points;
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(2);
    }

}
