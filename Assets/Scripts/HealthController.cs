using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthController : MonoBehaviour
{
    public TMP_Text healthText;
    public int maxHealth = 15;
    public static int health = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        healthText = GameObject.Find("Health").GetComponent<TMP_Text>();
        health = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        UpdateGUI();
    }


    public void UpdateGUI()
    {
        healthText.text = "Health: " + health;
        if(health <= 0)
        {
            Debug.Log("Player loses");
        }
    }

    public static void Damage(int damage)
    {
        health -= damage;
    }
}

