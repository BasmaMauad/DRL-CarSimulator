using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAppear : MonoBehaviour
{
    public GameObject[] car;  //to pass the car to the gameObject
    int carNO;
    float maxMin = 2.3f;
    float Timer;
    float delay = 2f;
    public List<GameObject>_instance;

    // Start is called before the first frame update
    void Start()
    {
        Timer = delay;
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime ;
        if(Timer<=0)
        {
            Vector3 carPosition = new Vector3(Random.Range(-5f, 3.85f), transform.position.y, transform.position.z); // to make car appears from different places
            carNO = Random.Range(0,2);
            _instance.Add(Instantiate(car[carNO], carPosition, transform.rotation));      //give the car the position and rotation of the gameObject
            Timer = delay;
        }
        
    }
  /* private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("HII");
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("HII");
            Destroy(collision.gameObject);
        }
    }*/
}
