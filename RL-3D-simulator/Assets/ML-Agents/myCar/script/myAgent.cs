using UnityEngine;
using MLAgents;

public class myAgent : Agent
{
    //private Rigidbody2D carBody;
    public controlCar cc;
    
    Vector3 old_position, pos;
    Quaternion old_rotation;
    EnemyAppear EA;


    void Start()
    {
        // Set Starting location of car
        old_position = gameObject.transform.position;
        old_rotation = gameObject.transform.rotation;
        
        pos = old_position;
        //carBody = GetComponent<Rigidbody2D>();
        EA = FindObjectOfType(typeof(EnemyAppear)) as EnemyAppear;
    }


    public override void CollectObservations()
    {
        //Agent positions
        AddVectorObs(gameObject.transform.position); //pos

        //Enemies position

        if (EA._instance.Count == 0 || cc.collisionflag == 1)
        {
            AddVectorObs(new Vector3(4f, 0f, -8f));
            AddVectorObs(new Vector3(4f, 0f, -8f));
        }
        else if (EA._instance.Count == 1)
            AddVectorObs(new Vector3(4f, 0f, -8f));


        int count_cars = 0,count=0;
        for (int i = 0; i < EA._instance.Count; i++)
        {
            if (EA._instance[i] != null)
            {
                count_cars += 1;
            }
        }

        if (count_cars == 0 && EA._instance.Count > 1)
        {
            AddVectorObs(new Vector3(4f, 0f, -4.5f));
            AddVectorObs(new Vector3(4f, 0f, -4.5f));
        }
        else if (count_cars == 1 && EA._instance.Count == 1)
        {
            AddVectorObs(EA._instance[0].transform.position);
        }
        else if (count_cars==0 && EA._instance.Count==1 )
        {
            AddVectorObs(new Vector3(4f, 0f, -4.5f));
        }
        else
        {
            for (int i = 0; i < EA._instance.Count; i++)
            {
                if (EA._instance[i] != null && count<2)
                {
                    AddVectorObs(EA._instance[i].transform.position);
                    count += 1;
                }
            }
            if(count==1)
                AddVectorObs(new Vector3(4f, 0f, -4.5f));
        }
        
        //// Agent velocity
        //AddVectorObs(carBody.velocity);

    }

    public override void AgentReset()
    {
        
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
        pos.z += direction_y * 0.2f;

        pos.x = Mathf.Clamp(pos.x, -5f, 5f);
        pos.z= Mathf.Clamp(pos.z, -5.8f, 20f);
        if (pos.z > 15f)
        {
            pos.z = -5f;
        }

        gameObject.transform.position = new Vector3(pos.x, 0f, pos.z);

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
        
        // wall collision
        if(pos.x== -5f || pos.x == 5f)
        {
            AddReward(-1f);
            cc.ui.hitsPenalty();
        }
    }
}
