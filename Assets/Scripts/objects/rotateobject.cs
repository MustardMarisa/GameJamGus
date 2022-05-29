using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateobject : MonoBehaviour
{
    public float rotatex = 0f;
    public float rotatey = 1f;
    public float rotatez = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(new Vector3(rotatex, rotatey, rotatez));
    }
}
