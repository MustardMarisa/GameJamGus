using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class gMapa : MonoBehaviour
{
    public string nombreEsena;
    public int bb = 2;
    public int mx=4;
    public int cuartoX,cuartoY;
    public GameObject[] piso, o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11;
    private Vector3 yyy, xxx, zzz;
    private int[,] mOcupado =new int [10,10], mtipo = new int[10, 10], mObjeto = new int[10, 10];
    private int[] ruta = new int[ 100];
    private int contador=0;
    private int l, k,j;
    public bool tomarDatos = false;

    private string bbPrefab="terreno";


    private void Awake()
    {
       // loadData();
    }
    private void OnDestroy()
    {
        //seveData();
    }
    // Start is called before the first frame update
    void Start()
    {
        limpiar();
        casiilaInicial();
        crearMapa();
        
        spawnCuarto();
        dibujar();
    }
    private void loadData()
    {
        bb = PlayerPrefs.GetInt(bbPrefab, 0);
    }
    private void seveData()
    {
        PlayerPrefs.SetInt(bbPrefab, bb);
    }
    public void finNivel()
    {
        if (bb < 2)
            bb++;
        else
            bb = 0;
        SceneManager.LoadScene(nombreEsena);
    }
    void crearMapa()
    {
        int cont = 0;

        while (cont < 100)
        {
            cont = 0;


            for (int p = 0; p < 10; p++)
            {
                for (int o = 0; o < 10; o++)
                {
                    if (mOcupado[p, o] == 1)
                    {
                        cont++;
                    }
                }
            }
            if (cont != 0)
            {
                int pp = Mathf.RoundToInt(Random.Range(0, 3));
                int oo = ruta[contador - 1];
                l = 0;
                k = 0;
                while (oo > 9)
                {
                    l++;
                    oo -= 10;
                }
                while (oo > 0)
                {
                    k++;
                    oo--;
                }
                //pp = 0;
                // l,  k
                int cuatro = 0;
                while (cuatro < 4)
                {
                    if (pp == 0)//arribo
                    {
                        j = l + 1;
                        if (j < 10)
                        {
                            if (mOcupado[j, k] == 0)
                            {
                                mOcupado[j, k] = 1;
                                mtipo[j, k] += 10;
                                mtipo[l, k] += 1000;

                                ruta[contador] = k + (j * 10);
                                contador++;
                                cuatro = 5;
                            }
                            else
                            {
                                pp++;
                            }

                        }
                        else
                        {
                            pp++;
                        }
                    }
                    else if (pp == 1)//derecha
                    {
                        j = k + 1;
                        if (j < 10)
                        {
                            if (mOcupado[l, j] == 0)
                            {
                                mOcupado[l, j] = 1;
                                mtipo[l, j] += 1;
                                mtipo[l, k] += 100;

                                ruta[contador] = j + (l * 10);
                                contador++;
                                cuatro = 5;
                            }
                            else
                            {
                                pp++;
                            }

                        }
                        else
                        {
                            pp++;
                        }
                    }
                    else if (pp == 2)//abajo
                    {
                        j = l - 1;
                        if (j >= 0)
                        {
                            if (mOcupado[j, k] == 0)
                            {
                                mOcupado[j, k] = 1;
                                mtipo[j, k] += 1000;
                                mtipo[l, k] += 10;

                                ruta[contador] = k + (j * 10);
                                contador++;
                                cuatro = 5;
                            }
                            else
                            {
                                pp++;
                            }

                        }
                        else
                        {
                            pp++;
                        }
                    }
                    else if (pp == 3)//izquirda
                    {
                        j = k - 1;
                        if (j >= 0)
                        {
                            if (mOcupado[l, j] == 0)
                            {
                                mOcupado[l, j] = 1;
                                mtipo[l, j] += 100;
                                mtipo[l, k] += 1;

                                ruta[contador] = j + (l * 10);
                                contador++;
                                cuatro = 5;
                            }
                            else
                            {
                                pp = 0;
                            }

                        }
                        else
                        {
                            pp = 0;
                        }

                    }
                    cuatro++;
                }
                if (cuatro == 4)
                {
                    contador--;
                }

            }



        }
    }

    void limpiar()
    {
        for (int p = 0; p < 10; p++)
        {
            for (int o = 0; o < 10; o++)
            {
                mOcupado[p, o] = 0;
                mtipo[p, o] = 0;
                mObjeto[p, o] = 0;
            }
        }
    }
    void spawnCuarto()
    {
        int r = Mathf.RoundToInt(Random.Range(1, 8));
        int e = Mathf.RoundToInt(Random.Range(1, 8));
        cuartoX = r;
        cuartoY = e;
        tomarDatos = true;
        for (int q = -1; q < 2; q++)
        {
            for (int w = -1; w < 2; w++)
            {
                if (r + q >= 0 && r + q < 10 && e + w >= 0 && e + w < 10)
                {
                    if (q == 0 && w == 0)
                    {
                        mtipo[r, e] = 0;
                    }
                    else
                    {
                        if (q == -1)
                        {
                            mtipo[r + q, e + w] += 20;
                        }
                        else if (q == 1)
                        {
                            mtipo[r + q, e + w] += 2000;
                        }

                        if (w == -1)
                        {
                            mtipo[r + q, e + w] += 2;
                        }
                        else if (w == 1)
                        {
                            mtipo[r + q, e + w] += 200;
                        }
                        mObjeto[r + q, e + w] = 1;

                    }

                }
            }
        }
    }
    void dibujarCuarto(int x, int y)
    {
        Quaternion xx = Quaternion.AngleAxis(xxx.x, new Vector3(0f, 0f, 0f));
        Quaternion zz = Quaternion.AngleAxis(zzz.z, new Vector3(0f, 0f, 0f));
        float mm=0, ce=0, de=0, un=0;
        int guardar=0;
        guardar = mtipo[x, y];

        

        if (guardar >= 2000)
        {
            mm++;
            guardar -= 2000;
        }
        if (guardar >= 1000)
        {
            mm += .5f;
            guardar -= 1000;
        }
        if (guardar >= 200)
        {
            ce++;
            guardar -= 200;
        }
        if (guardar >= 100)
        {
            ce += .5f;
            guardar -= 100;
        }
        if (guardar >= 20)
        {
            de++;
            guardar -= 20;
        }
        if (guardar >= 10)
        {
            de += .5f;
            guardar -= 10;
        }
        if (guardar >= 2)
        {
             un++;
            guardar -= 2;
        }
        if (guardar >= 1)
        {
            un += .5f;
            guardar -= 1;
        }


        
        

        
        
        if (mm>=1)
        {
            if (ce >= 1)
            {
                if (ce == 1.5 && mm == 1.5)
                {
                    GameObject a = Instantiate(o9[bb]) as GameObject;
                    a.transform.position = new Vector3(x * mx, 0, y * mx);
                    yyy.y = -90;
                    Quaternion yy = Quaternion.AngleAxis(yyy.y, new Vector3(0f, 1f, 0f));
                    a.transform.rotation = yy * xx * zz;
                    Debug.Log("9   "+x+","+y);
                }
                else if (ce == 1.5 )
                {
                    GameObject a = Instantiate(o10[bb]) as GameObject;
                    a.transform.position = new Vector3(x * mx, 0, y * mx);
                    yyy.y = -90;
                    Quaternion yy = Quaternion.AngleAxis(yyy.y, new Vector3(0f, 1f, 0f));
                    a.transform.rotation = yy * xx * zz;
                    Debug.Log("10   " + x + "," + y);
                }
                else if (mm == 1.5)
                {
                    GameObject a = Instantiate(o11[bb]) as GameObject;
                    a.transform.position = new Vector3(x * mx, 0, y * mx);
                    yyy.y = 90;
                    Quaternion yy = Quaternion.AngleAxis(yyy.y, new Vector3(0f, 1f, 0f));
                    a.transform.rotation = yy * xx * zz;
                    Debug.Log("11   " + x + "," + y);
                }
                else
                {
                    GameObject a = Instantiate(o6[bb]) as GameObject;
                    a.transform.position = new Vector3(x * mx, 0, y * mx);
                    yyy.y = 180;
                    Quaternion yy = Quaternion.AngleAxis(yyy.y, new Vector3(0f, 1f, 0f));
                    a.transform.rotation = yy * xx * zz;
                    Debug.Log("6   " + x + "," + y);
                }
            }
            else if (un >= 1)
            {
                if (un == 1.5 && mm == 1.5)
                {
                    GameObject a = Instantiate(o9[bb]) as GameObject;
                    a.transform.position = new Vector3(x * mx, 0, y * mx);
                    yyy.y = 00;
                    Quaternion yy = Quaternion.AngleAxis(yyy.y, new Vector3(0f, 1f, 0f));
                    a.transform.rotation = yy * xx * zz;
                    Debug.Log("9   " + x + "," + y);
                }
                else if (un == 1.5)
                {
                    GameObject a = Instantiate(o11[bb]) as GameObject;
                    a.transform.position = new Vector3(x * mx, 0, y * mx);
                    yyy.y = 180;
                    Quaternion yy = Quaternion.AngleAxis(yyy.y, new Vector3(0f, 1f, 0f));
                    a.transform.rotation = yy * xx * zz;
                    Debug.Log("10   " + x + "," + y);
                }
                else if (mm == 1.5)
                {
                    GameObject a = Instantiate(o10[bb]) as GameObject;
                    a.transform.position = new Vector3(x * mx, 0, y * mx);
                    yyy.y = 0;
                    Quaternion yy = Quaternion.AngleAxis(yyy.y, new Vector3(0f, 1f, 0f));
                    a.transform.rotation = yy * xx * zz;
                    Debug.Log("11   " + x + "," + y);
                }
                else
                {
                    GameObject a = Instantiate(o6[bb]) as GameObject;
                    a.transform.position = new Vector3(x * mx, 0, y * mx);
                    yyy.y = -90;
                    Quaternion yy = Quaternion.AngleAxis(yyy.y, new Vector3(0f, 1f, 0f));
                    a.transform.rotation = yy * xx * zz;
                    Debug.Log( "6   " + x + "," + y);
                }
            }
            else
            {
                if (mm == 1.5)
                {
                    GameObject a = Instantiate(o8[bb]) as GameObject;
                    a.transform.position = new Vector3(x * mx, 0, y * mx);
                    yyy.y = -90;
                    Quaternion yy = Quaternion.AngleAxis(yyy.y, new Vector3(0f, 1f, 0f));
                    a.transform.rotation = yy * xx * zz;
                    Debug.Log("8   " + x + "," + y);
                }
                else
                {
                    GameObject a = Instantiate(o7[bb]) as GameObject;
                    a.transform.position = new Vector3(x * mx, 0, y * mx);
                    yyy.y = 90;
                    Quaternion yy = Quaternion.AngleAxis(yyy.y, new Vector3(0f, 1f, 0f));
                    a.transform.rotation = yy * xx * zz;
                    Debug.Log("7   " + x + "," + y);
                }
            }
        }
        else if (de >= 1)
        {
            if (ce >= 1)
            {

                if (ce == 1.5 && de == 1.5)
                {
                    GameObject a = Instantiate(o9[bb]) as GameObject;
                    a.transform.position = new Vector3(x * mx, 0, y * mx);
                    yyy.y = 180;
                    Quaternion yy = Quaternion.AngleAxis(yyy.y, new Vector3(0f, 1f, 0f));
                    a.transform.rotation = yy * xx * zz;
                }
                else if (ce == 1.5)
                {
                    GameObject a = Instantiate(o11[bb]) as GameObject;
                    a.transform.position = new Vector3(x * mx, 0, y * mx);
                    yyy.y = 0;
                    Quaternion yy = Quaternion.AngleAxis(yyy.y, new Vector3(0f, 1f, 0f));
                    a.transform.rotation = yy * xx * zz;
                }
                else if (de == 1.5)
                {
                    GameObject a = Instantiate(o10[bb]) as GameObject;
                    a.transform.position = new Vector3(x * mx, 0, y * mx);
                    yyy.y = 180;
                    Quaternion yy = Quaternion.AngleAxis(yyy.y, new Vector3(0f, 1f, 0f));
                    a.transform.rotation = yy * xx * zz;
                }
                else
                {
                    GameObject a = Instantiate(o6[bb]) as GameObject;
                    a.transform.position = new Vector3(x * mx, 0, y * mx);
                    yyy.y = 90;
                    Quaternion yy = Quaternion.AngleAxis(yyy.y, new Vector3(0f, 1f, 0f));
                    a.transform.rotation = yy * xx * zz;
                }
            }
            else if (un >= 1)
            {
                if (un == 1.5 && de == 1.5)
                {
                    GameObject a = Instantiate(o9[bb]) as GameObject;
                    a.transform.position = new Vector3(x * mx, 0, y * mx);
                    yyy.y = 90;
                    Quaternion yy = Quaternion.AngleAxis(yyy.y, new Vector3(0f, 1f, 0f));
                    a.transform.rotation = yy * xx * zz;
                }
                else if (un == 1.5)
                {
                    GameObject a = Instantiate(o10[bb]) as GameObject;
                    a.transform.position = new Vector3(x * mx, 0, y * mx);
                    yyy.y = 90;
                    Quaternion yy = Quaternion.AngleAxis(yyy.y, new Vector3(0f, 1f, 0f));
                    a.transform.rotation = yy * xx * zz;
                }
                else if (de == 1.5)
                {
                    GameObject a = Instantiate(o11[bb]) as GameObject;
                    a.transform.position = new Vector3(x * mx, 0, y * mx);
                    yyy.y = -90;
                    Quaternion yy = Quaternion.AngleAxis(yyy.y, new Vector3(0f, 1f, 0f));
                    a.transform.rotation = yy * xx * zz;
                }
                else
                {
                    GameObject a = Instantiate(o6[bb]) as GameObject;
                    a.transform.position = new Vector3(x * mx, 0, y * mx);
                    yyy.y = 0;
                    Quaternion yy = Quaternion.AngleAxis(yyy.y, new Vector3(0f, 1f, 0f));
                    a.transform.rotation = yy * xx * zz;
                }
            }
            else
            {
                if (de == 1.5)
                {
                    GameObject a = Instantiate(o8[bb]) as GameObject;
                    a.transform.position = new Vector3(x * mx, 0, y * mx);
                    yyy.y = 90;
                    Quaternion yy = Quaternion.AngleAxis(yyy.y, new Vector3(0f, 1f, 0f));
                    a.transform.rotation = yy * xx * zz;
                }
                else
                {
                    GameObject a = Instantiate(o7[bb]) as GameObject;
                    a.transform.position = new Vector3(x * mx, 0, y * mx);
                    yyy.y = -90;
                    Quaternion yy = Quaternion.AngleAxis(yyy.y, new Vector3(0f, 1f, 0f));
                    a.transform.rotation = yy * xx * zz;
                }
            }
        }
        else if (ce >= 1)
        {
            if (ce == 1.5)
            {
                GameObject a = Instantiate(o8[bb]) as GameObject;
                a.transform.position = new Vector3(x * mx, 0, y * mx);
                yyy.y = 180;
                Quaternion yy = Quaternion.AngleAxis(yyy.y, new Vector3(0f, 1f, 0f));
                a.transform.rotation = yy * xx * zz;
            }
            else
            {
                GameObject a = Instantiate(o7[bb]) as GameObject;
                a.transform.position = new Vector3(x * mx, 0, y * mx);
                yyy.y = 0;
                Quaternion yy = Quaternion.AngleAxis(yyy.y, new Vector3(0f, 1f, 0f));
                a.transform.rotation = yy * xx * zz;
            }
        }
        else
        {
            if (un == 1.5)
            {
                GameObject a = Instantiate(o8[0]) as GameObject;
                a.transform.position = new Vector3(x * mx, 0, y * mx);
                yyy.y = 0;
                Quaternion yy = Quaternion.AngleAxis(yyy.y, new Vector3(0f, 1f, 0f));
                a.transform.rotation = yy * xx * zz;
            }
            else
            {
                GameObject a = Instantiate(o7[0]) as GameObject;
                a.transform.position = new Vector3(x * mx, 0, y * mx);
                yyy.y = 180;
                Quaternion yy = Quaternion.AngleAxis(yyy.y, new Vector3(0f, 1f, 0f));
                a.transform.rotation = yy * xx * zz;
            }
        }
    }
    void dibujar()
    {
        
        Quaternion xx = Quaternion.AngleAxis(xxx.x, new Vector3(0f, 0f, 0f));
        Quaternion zz = Quaternion.AngleAxis(zzz.z, new Vector3(0f, 0f, 0f));
        for (int p = 0; p < 10; p++)
        {
            for (int o = 0; o < 10; o++)
            {
                if (mObjeto[p,o] == 0)
                {

                
                    if (mtipo[p, o] == 1)
                    {
                            GameObject a = Instantiate(o1[bb]) as GameObject;
                            a.transform.position = new Vector3(p * mx, 0, o * mx);
                            yyy.y = 90;
                            Quaternion yy = Quaternion.AngleAxis(yyy.y, new Vector3(0f, 1f, 0f));
                            a.transform.rotation = yy * xx * zz;
                    }
                    else if (mtipo[p, o] == 10)
                    {
                            GameObject a = Instantiate(o1[bb]) as GameObject;
                            a.transform.position = new Vector3(p * mx, 0, o * mx);
                            yyy.y = 180;
                            Quaternion yy = Quaternion.AngleAxis(yyy.y, new Vector3(0f, 1f, 0f));
                            a.transform.rotation = yy * xx * zz;
                    }
                    else if (mtipo[p, o] == 100)
                    {
                            GameObject a = Instantiate(o1[bb]) as GameObject;
                            a.transform.position = new Vector3(p * mx, 0, o * mx);
                            yyy.y = -90;
                            Quaternion yy = Quaternion.AngleAxis(yyy.y, new Vector3(0f, 1f, 0f));
                            a.transform.rotation = yy * xx * zz;
                    }

                    else if (mtipo[p, o] == 1000)
                    {
                            GameObject a = Instantiate(o1[bb]) as GameObject;
                            a.transform.position = new Vector3(p * mx, 0, o * mx);
                            yyy.y = 0;
                            Quaternion yy = Quaternion.AngleAxis(yyy.y, new Vector3(0f, 1f, 0f));
                            a.transform.rotation = yy * xx * zz;
                    }
                    else if(mtipo[p, o] == 11)
                    {
                            GameObject a = Instantiate(o2[bb]) as GameObject;
                            a.transform.position = new Vector3(p * mx, 0, o * mx);
                            yyy.y = 180;
                            Quaternion yy = Quaternion.AngleAxis(yyy.y, new Vector3(0f, 1f, 0f));
                            a.transform.rotation = yy * xx * zz;
                    }
                    else if (mtipo[p, o] == 110)
                    {
                            GameObject a = Instantiate(o2[bb]) as GameObject;
                            a.transform.position = new Vector3(p * mx, 0, o * mx);
                            yyy.y = -90;
                            Quaternion yy = Quaternion.AngleAxis(yyy.y, new Vector3(0f, 1f, 0f));
                            a.transform.rotation = yy * xx * zz;
                    }
                    else if (mtipo[p, o] == 1100)
                    {
                            GameObject a = Instantiate(o2[bb]) as GameObject;
                            a.transform.position = new Vector3(p * mx, 0, o * mx);
                            yyy.y = 0;
                            Quaternion yy = Quaternion.AngleAxis(yyy.y, new Vector3(0f, 1f, 0f));
                            a.transform.rotation = yy * xx * zz;
                    }
                    else if (mtipo[p, o] == 1001)
                    {
                            GameObject a = Instantiate(o2[bb]) as GameObject;
                            a.transform.position = new Vector3(p * mx, 0, o * mx);
                            yyy.y = 90;
                            Quaternion yy = Quaternion.AngleAxis(yyy.y, new Vector3(0f, 1f, 0f));
                            a.transform.rotation = yy * xx * zz;
                    }
                    else if (mtipo[p, o] == 101)
                    {
                            GameObject a = Instantiate(o5[bb]) as GameObject;
                            a.transform.position = new Vector3(p * mx, 0, o * mx);
                            yyy.y = 90;
                            Quaternion yy = Quaternion.AngleAxis(yyy.y, new Vector3(0f, 1f, 0f));
                            a.transform.rotation = yy * xx * zz;
                    }
                    else if (mtipo[p, o] == 1010)
                    {
                            GameObject a = Instantiate(o5[bb]) as GameObject;
                            a.transform.position = new Vector3(p * mx, 0, o * mx);
                    }
                    else if (mtipo[p, o] == 1111)
                    {
                            GameObject a = Instantiate(o4[bb]) as GameObject;
                            a.transform.position = new Vector3(p * mx, 0, o * mx);
                    }
                    else if (mtipo[p, o] == 1110)
                    {
                            GameObject a = Instantiate(o3[bb]) as GameObject;
                            a.transform.position = new Vector3(p * mx, 0, o * mx);
                            yyy.y = 180;
                            Quaternion yy = Quaternion.AngleAxis(yyy.y, new Vector3(0f, 1f, 0f));
                            a.transform.rotation = yy * xx * zz;
                    }
                    else if (mtipo[p, o] == 1101)
                    {
                            GameObject a = Instantiate(o3[bb]) as GameObject;
                            a.transform.position = new Vector3(p * mx, 0, o * mx);
                            yyy.y = -90;
                            Quaternion yy = Quaternion.AngleAxis(yyy.y, new Vector3(0f, 1f, 0f));
                            a.transform.rotation = yy * xx * zz;
                    }
                    else if (mtipo[p, o] == 1011)
                    {
                            GameObject a = Instantiate(o3[bb]) as GameObject;
                            a.transform.position = new Vector3(p * mx, 0, o * mx);
                            yyy.y = 0;
                            Quaternion yy = Quaternion.AngleAxis(yyy.y, new Vector3(0f, 1f, 0f));
                            a.transform.rotation = yy * xx * zz;
                    }
                    else if (mtipo[p, o] == 111)
                    {
                            GameObject a = Instantiate(o3[bb]) as GameObject;
                            a.transform.position = new Vector3(p * mx, 0, o * mx);
                            yyy.y = 90;
                            Quaternion yy = Quaternion.AngleAxis(yyy.y, new Vector3(0f, 1f, 0f));
                            a.transform.rotation = yy * xx * zz;
                    }
                    else if (mtipo[p, o] == 0)
                    {
                        GameObject a = Instantiate(piso[bb]) as GameObject;
                        a.transform.position = new Vector3(p * mx, 0, o * mx);
                        yyy.y = 90;
                        Quaternion yy = Quaternion.AngleAxis(yyy.y, new Vector3(0f, 1f, 0f));
                        a.transform.rotation = yy * xx * zz;
                    }

                }

                else
                {
                        dibujarCuarto(p,o);
                }
                
                //mObjeto[p, o] = 0;
            }
        }
        
    }
    void casiilaInicial()
    {
         
        int p = Mathf.RoundToInt(Random.Range(0, 9));
        int o  = Mathf.RoundToInt(Random.Range(0, 9));
        //p = 0;o = 0; 
        mOcupado[p, o] = 1;

        ruta[contador] = o + (p * 10);
        contador++;
    }
}
