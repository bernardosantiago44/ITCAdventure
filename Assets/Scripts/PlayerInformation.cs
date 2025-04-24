using UnityEngine;

public class PlayerInformation : MonoBehaviour {
    public static PlayerInformation Shared { get; private set; }
    public int Difficulty { get; private set; } = 1; // 0 Low | 1 Medium | 2 High
    public int Coins { get; private set; } = 0;
    public int Lives { get; private set; } = 3;

    private void Awake() {
        if (Shared == null) {
            Shared = this;
            LoadDifficulty();
            LoadCoins();
            LoadLives();
            DontDestroyOnLoad(this);
        } else {
            Destroy(this);
        }
    }

    private void LoadDifficulty() {
        Difficulty = PlayerPrefs.GetInt("Difficulty", 1);
    }

    private void LoadCoins() {
        Coins = PlayerPrefs.GetInt("Coins", 0);
    }

    public void AddCoins(int amount) {
        Coins += amount;
        PlayerPrefs.SetInt("Coins", Coins);
        PlayerPrefs.Save();
    }

    private void LoadLives() {
        Lives = PlayerPrefs.GetInt("Lives", 3);
    }

    public void SetDifficulty(int difficulty) {
        Difficulty = difficulty;
        PlayerPrefs.SetInt("Difficulty", difficulty);
        PlayerPrefs.Save();
    }
}
