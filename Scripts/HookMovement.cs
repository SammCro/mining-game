using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public float minZ = -55f, maxZ = 55f;
    public float rotate_Speed = 5f;

    private float rotate_Angle;
    private bool rotate_Right;
    private bool can_Rotate;

    public float move_Speed = 3f;
    private float initial_MoveSpeed;

    public float min_Y = -2.5f;
    private float inital_Y;

    private bool move_Down;

    private RopeRenderer ropeRenderer;


    void Awake()
    {
        ropeRenderer = GetComponent<RopeRenderer>();

    }


    void Start()
    {

        inital_Y = transform.position.y;

        initial_MoveSpeed = move_Speed;

        can_Rotate = true;

    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        GetInput();
        MoveRope();
    }

    void Rotate()
    {
        if (!can_Rotate)
        {
            return;
        }

        if (rotate_Right)
        {
            rotate_Angle += rotate_Speed * Time.deltaTime;
        }
        else
        {
            rotate_Angle -= rotate_Speed * Time.deltaTime;
        }

        transform.rotation = Quaternion.AngleAxis(rotate_Angle,Vector3.forward);


        if (rotate_Angle >= maxZ)
        {
            rotate_Right = false;
        }
        else if (rotate_Angle <= minZ)
        {
            rotate_Right = true;
        }

    }

    public void SetMoveDownFalse()
    {
        move_Down = false;
    }

    void GetInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (can_Rotate)
            {
                can_Rotate = false;
                move_Down = true;
            }
        }
    }

    void MoveRope()
    {
        if (can_Rotate)
        {
            return;
        }

        if (!can_Rotate)
        {
            Vector3 temp = transform.position;

            if (move_Down)
            {
                temp -= transform.up * Time.deltaTime * move_Speed;
            }
            else
            {
                temp += transform.up * Time.deltaTime * move_Speed;
            }

            transform.position = temp;


            if (temp.y <= min_Y)
            {
                move_Down = false;
            }

            if (temp.y >= inital_Y)
            {
                can_Rotate = true;
                move_Speed = initial_MoveSpeed;

                ropeRenderer.RenderLine(Vector3.zero, false);

            }

            ropeRenderer.RenderLine(temp,true);

        }
    }
}
