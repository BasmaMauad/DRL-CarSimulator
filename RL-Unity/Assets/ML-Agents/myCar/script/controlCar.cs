using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlCar : MonoBehaviour
{
    public float carspeed;
    Vector3 position;
    //float maxMin = 2.5f;
    public int collisionflag = 0;
    public Uimanager ui;
    /*public */EnemyAppear E;
    
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        E = FindObjectOfType(typeof(EnemyAppear)) as EnemyAppear;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //remove as we add it to agent script think of it
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collisionflag = 1;
            for (int i = 0; i< E._instance.Count; i++)
            {
                Destroy(E._instance[i]);
                //E._instance.RemoveAt(i);
            }

        }

    }

}
