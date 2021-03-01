using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomLine : MonoBehaviour
{
    public Text Money;
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
            int x;
            x = int.Parse(Money.text) - MoneyReduceAmount;

            Money.text = x.ToString();

            // DEBUG Show current score
            // Debug.Log(x);
        }
        Destroy(collision.gameObject);
    }

}
