using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventory_sloth : MonoBehaviour
{
    Inventory_Player inventory;
    Stats statsplayer;
    public GameObject player;
    void Start()
    {
        inventory = Inventory_Player.estancia;
        statsplayer = Stats.instance;
    }

    void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UseItem(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UseItem(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            UseItem(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            UseItem(3);
        }


    }
    public void UseItem(int numslot)
    {
        Debug.Log("Aqui hay: "+inventory.items[numslot].nombre);

        if(inventory.items[numslot].cantidad > 0 && inventory.items[numslot].type == TipoItems.PocionFuego && statsplayer.vida < 100) {
            Debug.Log("La usaste");
            statsplayer.addvida(10);
            inventory.items[numslot].cantidad -= 1;

            if(inventory.items[numslot].cantidad < 1)
            {
                inventory.vaciarSlot(numslot, inventory.items[numslot].slot.GetComponent<Image>());
            }
        }
        else if (inventory.items[numslot].cantidad > 0 && inventory.items[numslot].type == TipoItems.PocionHielo && statsplayer.energia < 100)
        {
            statsplayer.addStamina(30);
            inventory.items[numslot].cantidad -= 1;

            if (inventory.items[numslot].cantidad < 1)
            {
                inventory.vaciarSlot(numslot, inventory.items[numslot].slot.GetComponent<Image>());
            }
        }

    }
}
