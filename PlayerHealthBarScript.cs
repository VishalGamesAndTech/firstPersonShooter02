using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBarScript : MonoBehaviour
{
    public Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setAmount(float amount)
    {
        healthBar.fillAmount = amount;
    }
}
