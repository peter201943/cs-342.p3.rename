using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomLine : MonoBehaviour
{
    public Slider Money;
    public int MoneyReduceAmount;
    public SpawnPaper SP;

    void Start()
    {
        MoneyReduceAmount = SP.MoneyAmount;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Right")
        {
            Money.value = Money.value - MoneyReduceAmount;
        }/*
        if (collision.gameObject.tag == "Wrong")
        {
            Money.value = Money.value + MoneyReduceAmount;
        }*/
        Destroy(collision.gameObject);
    }

}
