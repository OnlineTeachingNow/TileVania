using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] int _pointsPerCoin = 5;
    [SerializeField] AudioClip _coinSound;
    int _score;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(_coinSound, Camera.main.transform.position);
            FindObjectOfType<GameSession>().AddToScore(_pointsPerCoin);
            Destroy(this.gameObject);
        }
    }

}
