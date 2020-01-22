using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player;
    public float followSharpness = 0.5f;

    void FixedUpdate()
    {
        //tu może trzeba będzie coś pozmieniać
        float blend = 1f - Mathf.Pow(1f - followSharpness, Time.deltaTime * 100f);

        transform.position = Vector3.Lerp(transform.position, new Vector3(player.position.x, player.position.y, -1f), blend);
    }
}