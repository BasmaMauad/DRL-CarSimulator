using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadMove : MonoBehaviour
{
    public float speed;
    Vector2 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //speed = Input.GetAxis("Vertical") * Time.deltaTime*2;
        offset = new Vector2(0, Time.time * speed);   ///set x axis equal zero as we only want to move vertical
        GetComponent<Renderer>().material.mainTextureOffset = offset;

    }
}
