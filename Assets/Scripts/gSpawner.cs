using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gSpawner : MonoBehaviour
{
    public GameObject tienda;
    public GameObject monedas;

    public int basuratipo = 0;
    public GameObject[] basura;
    public GameObject[] posiones;


    public GameObject[] enemigo;

    public int bbb;

    private float giroRandom;

    private Vector3 yyy, xxx, zzz;



    public gMapa mapa;
    bool loop = true;

    int i = 0, r = 0;


    void Start()
    {
        mapa = FindObjectOfType<gMapa>();
        bbb = mapa.bb;


        float e, q, w;
        int enem = 0;
        Quaternion xx = Quaternion.AngleAxis(xxx.x, new Vector3(0f, 0f, 0f));
        Quaternion zz = Quaternion.AngleAxis(zzz.z, new Vector3(0f, 0f, 0f));
        while (r < 9)
        {
            i = 0;
            while (i < 9)
            {
                e = Mathf.RoundToInt(Random.Range(0, 7));
                w = Random.Range(-1.9f, 1.9f);
                q = Random.Range(-1.9f, 1.9f);
                giroRandom = Random.Range(0f, 359f);
                if (e == 1)
                {

                    GameObject a = Instantiate(monedas) as GameObject;
                    a.transform.position = new Vector3((r * 4), 0,(i * 4));
                    yyy.y = giroRandom;
                    Quaternion yy = Quaternion.AngleAxis(yyy.y, new Vector3(0f, 1f, 0f));
                    a.transform.rotation = yy * xx * zz;
                }
                else if (e == 2 || e == 3)
                {
                    basuratipo = Mathf.RoundToInt(Random.Range(0, 1));
                    GameObject a = Instantiate(posiones[basuratipo]) as GameObject;
                    a.transform.position = new Vector3((r * 4), 1,(i * 4));
                    yyy.y = giroRandom;
                    Quaternion yy = Quaternion.AngleAxis(yyy.y, new Vector3(0f, 1f, 0f));
                    a.transform.rotation = yy * xx * zz;
                }
                else if (e == 6 || e == 7)
                {
                    basuratipo = Mathf.RoundToInt(Random.Range(bbb + 0, bbb + 1));
                    GameObject a = Instantiate(basura[basuratipo]) as GameObject;
                    a.transform.position = new Vector3((r * 4) + e, 0, q + (i * 4));
                    yyy.y = giroRandom;
                    Quaternion yy = Quaternion.AngleAxis(yyy.y, new Vector3(0f, 1f, 0f));
                    a.transform.rotation = yy * xx * zz;
                }
                else if (e == 5 && enem < 4)
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
                a.transform.position = new Vector3(mapa.cuartoX * 4, 0, mapa.cuartoY * 4);

                loop = false;
            }
        }
    }
}
