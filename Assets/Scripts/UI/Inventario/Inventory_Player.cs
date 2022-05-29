using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public enum TipoItems
{
    Vacio,
    PocionStamina,
    PocionFuego,
    PocionHielo,
    Moneda,
    PocionCuracion
}

[System.Serializable]
public class Itemclass
{
    public int cantidad;
    public TipoItems type;
    public bool lleno;
    public string nombre;
    public GameObject slot;
    public TMP_Text textslot;
}


public class Inventory_Player : MonoBehaviour
{
    

    public static Inventory_Player estancia;
    public Itemclass[] items;

    public void vaciarSlot(int numslot,Image img)
    {
        items[numslot].lleno = false;
        items[numslot].cantidad = 0;
        items[numslot].textslot.text = items[numslot].cantidad.ToString();
        items[numslot].type = TipoItems.Vacio;
        img.sprite = null;
        img.enabled = false;
    }

    private void Awake()
    {
        estancia = this;
    }

  
}


