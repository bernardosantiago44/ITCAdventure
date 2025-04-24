using System;
using System.IO;
using UnityEngine;

public class SavePlayerData : MonoBehaviour
{
    private string _json;

    private string SAVE_PATH;

    [SerializeField]
    private CharacterController2D player;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SAVE_PATH = Application.persistentDataPath + "/savefile.itcfile";
        print(SAVE_PATH);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Save();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            Load();
        }
    }

    void Save()
    {
        PlayerData data = new PlayerData(player);
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(SAVE_PATH, json);
        print("Saved!");
    }

    void Load()
    {
        if (File.Exists(SAVE_PATH))
        {
            string json = File.ReadAllText(SAVE_PATH);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);
            ApplyPlayerData(data);
            print("Loaded!");
        }
        else
        {
            print("Save file not found!");
        }
    }

    void ApplyPlayerData(PlayerData data)
    {
        // Set position
        Vector3 newPosition = new Vector3(data.position[0], data.position[1], data.position[2]);
        player.transform.position = newPosition;

        // Set velocity
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(data.velocity[0], data.velocity[1]);

        // Set jumps
        Motion playerMotion = player.GetComponent<Motion>();
        player.jumps = data.jumps;
    }
}