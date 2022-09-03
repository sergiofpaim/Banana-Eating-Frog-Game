using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    // Transform is the location of the object
    // Applied as ground layer on the editor
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
            collision.gameObject.transform.SetParent(transform);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
            collision.gameObject.transform.SetParent(null);
    }
}
        
