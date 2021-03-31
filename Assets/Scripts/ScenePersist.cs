using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersist : MonoBehaviour
{

    int _startingSceneIndex;
    // Start is called before the first frame update
    private void Awake()
    {
        int _numberOfScenePersists = FindObjectsOfType<ScenePersist>().Length;
        if (_numberOfScenePersists > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        _startingSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        int _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (_currentSceneIndex != _startingSceneIndex)
        {
            Destroy(gameObject);
        }
    }
}
