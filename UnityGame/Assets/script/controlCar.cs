using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlCar : MonoBehaviour
{
    public float carspeed;
    Vector3 position;
    float maxMin = 2.5f;

    public Uimanager ui;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        position.x += Input.GetAxis("Horizontal") * carspeed * Time.deltaTime;
        
        position.x = Mathf.Clamp(position.x,-5f, 3.8f);
        if (position.y > 8f)
        {
            position.y = -7.44f;
        }
        else
            position.y += Input.GetAxis("Vertical") * carspeed * Time.deltaTime;

        transform.position = position;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            ui.hitsPenalty();
            Destroy(gameObject);
            //Application.LoadLevel("Level1");
            SceneManager.LoadScene("Level1");
        }
            
    }
   
}
