using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public GameObject canvasUI;
    public Transform cameraTarget;
    public float cameraSpeed = 5f;

    private bool gameStarted = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void StartGame()
    {
        canvasUI.SetActive(false);
        gameStarted = true;
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        gameStarted = false;
        canvasUI.SetActive(true);
    }

    public void SaveGame() {}

    public void LoadGame() {}

    // Update is called once per frame
    void Update() {}
}
