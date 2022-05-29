using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Stats : MonoBehaviour
{
    public static Stats instance;
    public float vida;
    public float energia;
    public float velocidadstamina = 4f;
    public GameObject player;
    public Text stamina;
    public Text Health;

    private void Awake()
    {
        instance = this;
    }

    public void addvida(int cantidad)
    {
        vida += cantidad;
        if (vida > 100)
        {
            vida = 100;
        }
    }

    public void removevida(int cantidad)
    {
        vida -= cantidad;
        if (vida < 0)
        {
            vida = 0;
            //Game over
            //SceneManager.LoadScene("GameOver");
        }
    }

    public void setvida(int cantidad)
    {
        vida = cantidad;
        if (vida > 100)
        {
            vida = 100;
        }
    }
    ///*STAMINA
    public void addStamina(int cantidad)
    {
        energia += cantidad;
        if (energia > 100)
        {
            energia = 100;
        }
    }

    public void removeStamina(int cantidad)
    {
        energia -= cantidad;
        if (energia < 0)
        {
            energia = 0;
        }
    }

    public void setStamina(int cantidad)
    {
        energia = cantidad;
        if (energia > 100)
        {
            energia = 100;
        }
    }

    // Update is called once per frame
    void Update()
    {
        stamina.text = Mathf.Ceil(energia).ToString();
        Health.text = vida.ToString();

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (energia > 0) {
                player.GetComponent<PlayerMovement>().speed = 5.0f;
                energia -= Time.deltaTime* velocidadstamina;
            }
        }
        else {
            if (energia < 99)
            {
                player.GetComponent<PlayerMovement>().speed = 3.0f;
                energia += Time.deltaTime * 2f;
            }
        }
        
    }
}
