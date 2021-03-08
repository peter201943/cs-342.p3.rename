using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollide : MonoBehaviour
{
    private PaperHover paperHover;

    private void Start()
    {
        paperHover = GetComponent<PaperHover>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            paperHover.SendMoney();
        }
    }
}
