using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float _delay = 1f;
    [SerializeField] float _slowMotion = 0.2f;
    int _thisBuildIndex;

    private void Start()
    {
        _thisBuildIndex = SceneManager.GetActiveScene().buildIndex;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(StartingNextScene());
        }
    }

    private IEnumerator StartingNextScene()
    {
        Time.timeScale = _slowMotion;
        yield return new WaitForSeconds(_delay);
        Time.timeScale = 1f;
        SceneManager.LoadScene(_thisBuildIndex + 1);
    }
}
