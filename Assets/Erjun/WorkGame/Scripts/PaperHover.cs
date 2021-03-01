using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaperHover : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Pattern;
    public Text Money;
    public int MoneyAmount;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        Pattern.SetActive(true);
        Debug.Log("Ha");
    }
  
    public void SendMoney()
    {
        if(this.gameObject.tag == "Right")
        {
            int x;
            x = int.Parse(Money.text) + MoneyAmount;

            Money.text = x.ToString();
            Destroy(this.gameObject);
        }

        if(this.gameObject.tag == "Wrong")
        {
            int x;
            x = int.Parse(Money.text) - MoneyAmount;

            Money.text = x.ToString();
            Destroy(this.gameObject);
        }
    }
}
