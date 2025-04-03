using UnityEngine;

public class UserPreferences : MonoBehaviour {
    public static UserPreferences Shared { get; private set; }
    public int Difficulty { get; private set; } = 1; // 0 Low | 1 Medium | 2 High

    private void Awake() {
        if (Shared == null) {
            Shared = this;
            LoadDifficulty();
        } else {
            Destroy(gameObject);
        }
    }

    private void LoadDifficulty() {
        Difficulty = PlayerPrefs.GetInt("Difficulty", 1);
    }

    public void SetDifficulty(int difficulty) {
        Difficulty = difficulty;
        PlayerPrefs.SetInt("Difficulty", difficulty);
        PlayerPrefs.Save();
    }
}
