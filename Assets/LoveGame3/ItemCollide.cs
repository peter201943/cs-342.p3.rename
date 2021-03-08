using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollide : MonoBehaviour
{
    private PaperHover paperHover;
    public AudioSource GoodSound, BadSound;

    private void Start()
    {
        paperHover = GetComponent<PaperHover>();
        GoodSound = GameObject.Find("KissSFX").GetComponent<AudioSource>();
        BadSound = GameObject.Find("BadSFX").GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            GoodSound.Play();
            paperHover.SendMoney();
        }
    }
}
