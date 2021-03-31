using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] int _lives = 3;
    [SerializeField] int _score = 0;

    [SerializeField] Text _livesText;
    [SerializeField] Text _scoreText;
    GameSession[] _gameSessions;
    // Start is called before the first frame update

    private void Awake()
    {
        int _numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (_numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
     
    }
    void Start()
    {
        _livesText.text = _lives.ToString();
        _scoreText.text = _score.ToString();
    }

    public void AddToScore (int _pointsToAdd)
    {
        _score += _pointsToAdd;
        _scoreText.text = _score.ToString();
    }
    public void ProcessPlayerDeath()
    {
        if (_lives > 1)
        {
            _lives--;
            _livesText.text = _lives.ToString();
            int _buildIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(_buildIndex);
        }
        else
        {
            ResetGameSession();
        }
    }

    private void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
