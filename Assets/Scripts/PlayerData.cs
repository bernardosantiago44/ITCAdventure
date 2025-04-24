using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerData
{
    public float[] position;
    public float[] velocity;
    public int jumps;

    public PlayerData (CharacterController2D player)
    {
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

        velocity = new float[2];
        velocity[0] = player.GetComponent<Rigidbody2D>().linearVelocity.x;
        velocity[1] = player.GetComponent<Rigidbody2D>().linearVelocity.y;

        jumps = player.jumps;
    }
}
