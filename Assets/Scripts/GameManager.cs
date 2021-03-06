using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    [SerializeField] SaveData _saveData;

    [SerializeField] GameObject _enmies;
    [SerializeField] GameObject _gameOver;
    [SerializeField] TextMeshProUGUI _scoreText;
    [SerializeField] TextMeshProUGUI _highScoreText;

    float _yPostion = 6;
    float _rangeX = 14;
    float _score = 0;
    float _highScore = 0;

    float _timeDelay = 2.0f;
    float _timeRate = 1.5f;

    public bool _isPlaying;

    // Start is called before the first frame update
    void Start()
    {
        _isPlaying = true;
        InvokeRepeating("SpawnEnemies", _timeDelay, _timeRate);
        LoadHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isPlaying)
        {
            DisplayScore();
            DisplayHighScore();
        }
        
        else
        {
            DisplayGameOver();
        }
    }

    void SpawnEnemies()
    {
        if (_isPlaying)
        {
            Instantiate(_enmies, RandomPosition(), _enmies.transform.rotation);
        }
        
    }

    Vector2 RandomPosition()
    {
        float randomXPos = Random.Range(-_rangeX, _rangeX);
        Vector3 randomPos = new Vector3(randomXPos, _yPostion, 0);
        return randomPos;
    }

    public void AddScore(float scoreToAdd)
    {
        _score += scoreToAdd;
    }

    void DisplayScore()
    {
        _scoreText.SetText("Score: " + _score);
    }

    void DisplayHighScore()
    {
        _highScoreText.SetText("High Score: " + _highScore);
    }

    public void GameOver()
    {
        _isPlaying = false;
        CheckHighScore();
        DisplayHighScore();
    }

    void DisplayGameOver()
    {
        _gameOver.SetActive(true);
    }

    void CheckHighScore()
    {
        if (_score > _highScore)
        {
            _highScore = _score;
            SaveHighScore();
        }
    }

    void SaveHighScore()
    {
        _saveData._highScore = _highScore;

        SaveManager.Save(_saveData);
    }

    void LoadHighScore()
    {
        _saveData = SaveManager.Load();
        _highScore = _saveData._highScore;
    }

    public void PlayAgain()
    {
        _score = 0;
        SceneManager.LoadScene("Main Scene");
    }

    public void ExitPlayMode()
    {
        EditorApplication.ExitPlaymode();
    }
}
