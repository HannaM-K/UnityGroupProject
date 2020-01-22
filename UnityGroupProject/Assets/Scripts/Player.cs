using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Canvas canvas;
    public static Vector2 checkpoint = new Vector2(0,0);
    Animator am;
    AudioSource audios;

    public AudioClip deathSound;
    void Awake()
    {
        checkpoint = transform.position;
        audios = gameObject.GetComponent<AudioSource>();
        am = gameObject.GetComponent<Animator>();
    }

    public void Death()
    {
        UIManager.SubstractLife();
        canvas.GetComponent<UIManager>().SetLifeCounter();
        transform.position = checkpoint;

        am.SetBool("isJumping", true);
        audios.PlayOneShot(deathSound);
    }
}
