using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] protected SwapInformation _info;
    [SerializeField] protected GameObject _mainMenuGroup;
    [SerializeField] protected GameObject _optionsMenuGroup;
    [SerializeField] protected TMP_Text _spawnTimeText;
    [SerializeField] protected TMP_Text _gameTimeText;

    void Start()
    {
        _mainMenuGroup.SetActive(true);
        _optionsMenuGroup.SetActive(false);

        _gameTimeText.text = _info.GameSessionTime.ToString();
        _spawnTimeText.text = _info.EnemySpawnTime.ToString();
    }

    
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OptionsMenu()
    {
        _mainMenuGroup.SetActive(false);
        _optionsMenuGroup.SetActive(true);
    }

    public void MainMenu()
    {
        _mainMenuGroup.SetActive(true);
        _optionsMenuGroup.SetActive(false);
    }

    public void IncreaseSpawnTime()
    {
        _info.EnemySpawnTime++;
        if (_info.EnemySpawnTime > 180)
            _info.EnemySpawnTime = 180;
        _spawnTimeText.text = _info.EnemySpawnTime.ToString();
    }

    public void DecreaseSpawnTime()
    {
        _info.EnemySpawnTime--;
        if( _info.EnemySpawnTime < 1 )
            _info.EnemySpawnTime = 1;
        _spawnTimeText.text = _info.EnemySpawnTime.ToString();
    }


    public void IncreaseGameTime()
    {
        _info.GameSessionTime++;
        if (_info.GameSessionTime > 180)
            _info.GameSessionTime = 180;
        _gameTimeText.text = _info.GameSessionTime.ToString();
    }

    public void DecreaseGameTime()
    {
        _info.GameSessionTime--;
        if (_info.GameSessionTime < 60)
            _info.GameSessionTime = 60;
        _gameTimeText.text = _info.GameSessionTime.ToString();
    }
}
