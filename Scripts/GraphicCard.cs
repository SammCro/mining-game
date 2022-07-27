using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GraphicCard : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Cards;


    public GameObject Claw;

    void Awake()
    {
        if (PlayerPrefs.HasKey("Cards"))
        {
            Cards.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("Cards").ToString();
        }
        else
        {
            PlayerPrefs.SetInt("Cards",0);
            Cards.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("Cards").ToString();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Claw"))
        {
            col.gameObject.GetComponentInParent<HookMovement>().SetMoveDownFalse();
            gameObject.transform.SetParent(Claw.transform);
        }
        else if (col.CompareTag("LimitExecute"))
        {
            if (PlayerPrefs.HasKey("Cards"))
            {
                int NumberoFcARDS = PlayerPrefs.GetInt("Cards");
                NumberoFcARDS += 1;

                PlayerPrefs.SetInt("Cards", NumberoFcARDS);

                Cards.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("Cards").ToString();
            }



            Destroy(gameObject);
        }

    }
}
