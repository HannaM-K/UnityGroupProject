using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Canvas canvas;
    public static Vector2 checkpoint = new Vector2(0,0);

    AudioSource audios;
    Rigidbody2D rb;

    public AudioClip deathSound;
    void Awake()
    {
        checkpoint = transform.position;
        audios = gameObject.GetComponent<AudioSource>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    public void Death()
    {
        UIManager.SubstractLife();
        canvas.GetComponent<UIManager>().SetLifeCounter();
        audios.PlayOneShot(deathSound);
        transform.position = checkpoint;
    }
}
