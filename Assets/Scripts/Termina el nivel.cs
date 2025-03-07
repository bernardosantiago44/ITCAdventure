using UnityEngine;
using UnityEngine.SceneManagement; // Needed for scene loading

public class WinTrigger : MonoBehaviour
{
    public string winTag = "WinZone"; // Tag for the win object
    public string bossTag = "Boss"; // Tag for the boss
    public string nextSceneName = "NextLevel"; // Change to your scene name

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(winTag))
        {
            print("You Win!"); // Console log
            // SceneManager.LoadScene(nextSceneName);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(bossTag))
        {
            print("Oh no! Collision with " + collision.transform.name);
        }
    }


}