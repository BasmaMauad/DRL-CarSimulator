using UnityEngine;
using MLAgents;

public class myAgent : Agent
{
    private Rigidbody2D carBody;
    // Start is called before the first frame update
    public controlCar cc;
    //public GameObject enemy1;
    //public GameObject enemy2;
    //public GameObject enemy3;
    Vector3 old_position, pos/*,pos_enemy1,pos_enemy2,pos_enemy3*/;
    Quaternion old_rotation;
    EnemyAppear EA;

    void Start()
    {
        // Set Starting location of car
        old_position = gameObject.transform.position;
        old_rotation = gameObject.transform.rotation;

        //Set Starting location of enemies
       // pos_enemy1 = enemy1.transform.position;
        //pos_enemy2 = enemy2.transform.position;
        //pos_enemy3 = enemy3.transform.position;

        pos = old_position;
        carBody = GetComponent<Rigidbody2D>();
    }
   

    public override void CollectObservations()
    {
        //Agent positions
        AddVectorObs(pos);

        // Agent velocity
        AddVectorObs(carBody.velocity);

    }

    public override void AgentReset()
    {
        // Destory any Enemy Car if exists one
        //enemy1.transform.position = pos_enemy1;
        //enemy2.transform.position = pos_enemy2;
        //enemy3.transform.position = pos_enemy3;

        //Destroy(EA._instance);
        //for (int i = 0; i < cc.E._instance.Capacity; i++)
        //{
        //    Destroy(cc.E._instance[i]);
        //    cc.E._instance.RemoveAt(i);
        //}
        // Revert Position of car
        gameObject.transform.position = old_position;
        gameObject.transform.rotation = old_rotation;
        pos = old_position;
        
    }

    float speed = 40f;
    public override void AgentAction(float[] vectorAction, string textAction)
    {
        // Get the action index for movement
        var movement = (int)vectorAction[0];

        int direction_x = 0;
        int direction_y = 0;
        switch (movement)
        {
            case 1:
                direction_x = -1;
                break;
            case 2:
                direction_x = 1;
                break;
            case 3:
                direction_y = -1;
                break;
            case 4:
                direction_y = 1;
                break;
        }
        pos.x += direction_x * 0.2f;
        pos.y += direction_y * 0.2f;

        pos.x = Mathf.Clamp(pos.x, -5f, 3.8f);
        if (pos.y > 8f)
        {
            pos.y = -7.44f;
        }

        gameObject.transform.position = new Vector3(pos.x, pos.y, 0f);

        if (cc.collisionflag == 1)
        {
            Done();
            SetReward(-1f);
            cc.collisionflag = 0;
            cc.ui.hitsPenalty();
        }
        else if (movement == 4)
        {
            AddReward(0.5f);
            cc.ui.forwardReward();
        }

        else if (movement == 1 || movement == 2)
        {
            AddReward(0.2f);
            cc.ui.XReward();
        }
    }
}
