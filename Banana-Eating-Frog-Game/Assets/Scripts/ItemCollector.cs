using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private static int bananas = 0;

    [SerializeField] private Text bananasText;
    [SerializeField] private AudioSource collectedSound;

    public static int Bananas { get => bananas; }

    void Start()
    {
        if (bananasText is not null)
            bananasText.text = $"Bananas: {bananas}";
    }

    // On trigger so that the player enters the object on a collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Banana"))
        {
            Destroy(collision.gameObject);
            bananas++;
            bananasText.text = $"Bananas: {bananas}";
            collectedSound.Play();
        }
    }

    internal static void Reset()
    {
        bananas = 0;
    }
}
