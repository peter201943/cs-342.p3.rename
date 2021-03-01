using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomLine : MonoBehaviour
{
    // Start is called before the first frame update
    public Text Money;
    public int MoneyReduceAmount;
    public SpawnPaper SP;
    void Start()
    {
        MoneyReduceAmount = SP.MoneyAmount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Right")
        {
            int x;
            x = int.Parse(Money.text) - MoneyReduceAmount;

            Money.text = x.ToString();
            Debug.Log(x);
        }
        Destroy(collision.gameObject);
    }


}
