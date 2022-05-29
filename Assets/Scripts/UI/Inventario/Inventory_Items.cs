using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_Items : MonoBehaviour
{
    Inventory_Player inventory;
    public ParticleSystem particulas;
    public Sprite sprite;
    public string nameItem;
    public TipoItems type;

    public Sprite pocioncuracion;
    public Sprite pocionstamina;
    public Sprite pociontiempo;

    public GameObject tienda;

    public void closemenu()
    {
        tienda.SetActive(false);
    }
    void Start()
    {
        inventory = Inventory_Player.estancia;
    }

    public void curacion()
    {
        for (int id = 0; id < inventory.items.Length; id++) { 
            if (inventory.items[id].lleno == true && inventory.items[id].type == TipoItems.Moneda && inventory.items[id].cantidad < 6)
            {
                for (int i = 0; i < inventory.items.Length; i++)
                {
                    if (inventory.items[i].lleno == false)
                    {
                        inventory.items[i].lleno = true;
                        inventory.items[i].cantidad = 1;
                        inventory.items[i].type = TipoItems.PocionFuego;
                        inventory.items[i].nombre = "Fuego";
                        inventory.items[i].textslot.text = inventory.items[i].cantidad.ToString();
                        inventory.items[i].slot.GetComponent<Image>().sprite = pocioncuracion;
                        inventory.items[i].slot.GetComponent<Image>().enabled = true;
                        break;
                    }

                    if (inventory.items[i].lleno == true && inventory.items[i].type == TipoItems.PocionFuego && inventory.items[i].cantidad < 64)
                    {
                        Debug.Log("Item estanqueado");
                        inventory.items[i].cantidad += 1;
                        inventory.items[i].textslot.text = inventory.items[i].cantidad.ToString();
                        break;
                    }

                }

            }
        }
        
    }

    public void stamina()
    {
        for (int i = 0; i < inventory.items.Length; i++)
        {
            if (inventory.items[i].lleno == false)
            {
                inventory.items[i].lleno = true;
                inventory.items[i].cantidad = 1;
                inventory.items[i].type = TipoItems.PocionHielo;
                inventory.items[i].nombre = "Hielo";
                inventory.items[i].textslot.text = inventory.items[i].cantidad.ToString();
                inventory.items[i].slot.GetComponent<Image>().sprite = pocionstamina;
                inventory.items[i].slot.GetComponent<Image>().enabled = true;
                break;
            }

            if (inventory.items[i].lleno == true && inventory.items[i].type == TipoItems.PocionHielo && inventory.items[i].cantidad < 64)
            {
                Debug.Log("Item estanqueado");
                inventory.items[i].cantidad += 1;
                inventory.items[i].textslot.text = inventory.items[i].cantidad.ToString();
                break;
            }

        }
    }
    public void tiempo()
    {
        for (int i = 0; i < inventory.items.Length; i++)
        {
            if (inventory.items[i].lleno == false)
            {
                inventory.items[i].lleno = true;
                inventory.items[i].cantidad = 1;
                inventory.items[i].type = TipoItems.PocionStamina;
                inventory.items[i].nombre = "Stamina";
                inventory.items[i].textslot.text = inventory.items[i].cantidad.ToString();
                inventory.items[i].slot.GetComponent<Image>().sprite = pociontiempo;
                inventory.items[i].slot.GetComponent<Image>().enabled = true;
                break;
            }

            if (inventory.items[i].lleno == true && inventory.items[i].type == TipoItems.PocionStamina && inventory.items[i].cantidad < 64)
            {
                Debug.Log("Item estanqueado");
                inventory.items[i].cantidad += 1;
                inventory.items[i].textslot.text = inventory.items[i].cantidad.ToString();
                break;
            }

        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Item Agregado");
            for(int i = 0; i < inventory.items.Length; i++)
            {
                if (inventory.items[i].lleno == false) {
                    inventory.items[i].lleno = true;
                    inventory.items[i].cantidad = 1;
                    inventory.items[i].type = type;
                    inventory.items[i].nombre = name;
                    inventory.items[i].textslot.text = inventory.items[i].cantidad.ToString();
                    inventory.items[i].slot.GetComponent<Image>().sprite = sprite;
                    inventory.items[i].slot.GetComponent<Image>().enabled = true;
                    Destroy(this.gameObject);
                    Instantiate(particulas, transform.position, Quaternion.identity);
                    break;
                }

                if (inventory.items[i].lleno==true && inventory.items[i].type == type && inventory.items[i].cantidad < 64)
                {
                    Debug.Log("Item estanqueado");
                    inventory.items[i].cantidad += 1;
                    inventory.items[i].textslot.text = inventory.items[i].cantidad.ToString();
                    Destroy(gameObject);
                    Instantiate(particulas,transform.position,Quaternion.identity);
                    break;
                }
                
            }
        }
    }
}
