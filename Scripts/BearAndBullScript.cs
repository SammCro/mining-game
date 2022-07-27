using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearAndBullScript : MonoBehaviour
{
    // Start is called before the first frame update


    public string TypeOfAnimal;
    public GameObject Claw;
    public GameObject GameManager;


    private bool CanMove;
    public float Direction;

    void Start()
    {
        CanMove = true;
    }


    void Update()
    {
        if (CanMove)
        {
            Vector2 samet = gameObject.transform.position;
            samet.x = gameObject.transform.position.x + Time.deltaTime * Direction;
            gameObject.transform.position = samet;
        }
    }


    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.CompareTag("Claw"))
        {
            CanMove = false;
            coll.gameObject.GetComponentInParent<HookMovement>().SetMoveDownFalse();
            gameObject.transform.SetParent(Claw.transform);
        }

        if (coll.gameObject.CompareTag("LimitExecute"))
        {
            switch (TypeOfAnimal)
            {
                case "Bear":
                    GameManager.GetComponent<GameManager>().BullOrBear("Bear");
                    Destroy(gameObject);
                    return;
                case "Bull":
                    GameManager.GetComponent<GameManager>().BullOrBear("Bull");
                    Destroy(gameObject);
                    return;

            }
        }


        if (coll.CompareTag("Right"))
        {
            Debug.Log("Samet");

            switch (TypeOfAnimal)
            {
                case "Bull":

                    Debug.Log("Samet");
                    Direction *= -1f;
                    gameObject.transform.rotation = new Quaternion(0, 0, 180,0);

                    return;
                case "Bear":
                    Debug.Log("Samet");
                    Direction *= -1f;
                    gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
                    return;
            }
        }

        if (coll.CompareTag("Left"))
        {

            Debug.Log("Samet");
            switch (TypeOfAnimal)
            {
                case "Bull":
                    Debug.Log("Samet");
                    Direction *= 1f;
                    gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);

                    return;
                case "Bear":
                    Debug.Log("Samet");
                    Direction *= 1f;
                    gameObject.transform.rotation = new Quaternion(0, 0, 180, 0);
                    return;
            }
        }


    }
}
