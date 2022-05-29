using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gSpawner : MonoBehaviour
{
    public GameObject tienda;
    public GameObject monedas;

    public int basuratipo = 0;
    public GameObject[] basura;

    public int enemigoTipo = 0;
    public GameObject[] enemigo;

    public int bbb;



    public gMapa mapa;
    bool loop = true;

    int i=0,r=0;


    void Start()
    {
        mapa = FindObjectOfType<gMapa>();
        bbb = mapa.bb;

        
        float e,q,w;
        int enem = 0;
        while ( r < 9)
        {
            i = 0;
            while (i < 9)
            {
                e = Mathf.RoundToInt(Random.Range(0, 7));
                w = Random.Range(-1.9f, 1.9f);
                q = Random.Range(-1.9f, 1.9f);
                if (e == 1)
                {
                    
                    GameObject a = Instantiate(monedas) as GameObject;
                    a.transform.position = new Vector3((r*4)+w, 0, q+(i*4));
                }
                else if (e == 6)
                {
                    basuratipo= Mathf.RoundToInt(Random.Range(bbb+0, bbb+1));
                    GameObject a = Instantiate(basura[basuratipo]) as GameObject;
                    a.transform.position = new Vector3((r * 4) + e, 0, q + (i * 4));
                }
                else if (e == 5 && enem<4)
                {
                    
                    GameObject a = Instantiate(enemigo[bbb]) as GameObject;
                    a.transform.position = new Vector3((r * 4) + e, 0, q + (i * 4));
                    enem++;
                }
                i++;
            }
            r++;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        while (loop)
        {
            if (mapa.tomarDatos == true)
            {
                
                GameObject a = Instantiate(tienda) as GameObject;
                a.transform.position = new Vector3(mapa.cuartoX*4, 0, mapa.cuartoY*4);

                loop = false;
            }
        }
    }
}
