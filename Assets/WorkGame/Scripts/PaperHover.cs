using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaperHover : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Pattern;
    public Slider Money;
    public int MoneyAmount;
    public AudioSource CollectSound, BadSound;
    void Start()
    {
        BadSound = GameObject.Find("BadSFX").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        if (!Pattern.activeInHierarchy)
        {
            CollectSound.Play();
        }
        Pattern.SetActive(true);

        // TEMP DEBUG
        // Debug.Log("Ha");
    }
  
    public void SendMoney()
    {
        if (this.gameObject.tag == "Right")
        {
            Money.value = Money.value + MoneyAmount;
        }

        if(this.gameObject.tag == "Wrong")
        {
            BadSound.Play();
            Money.value = Money.value - MoneyAmount;
        }
        Destroy(this.gameObject);
    }

}
