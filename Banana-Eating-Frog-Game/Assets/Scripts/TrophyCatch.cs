using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrophyCatch : MonoBehaviour
{
    private AudioSource finishSound;

    private const int TOTAL_OF_BANANAS = 7;

    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && ItemCollector.Bananas == TOTAL_OF_BANANAS)
        {
            finishSound.Play();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
