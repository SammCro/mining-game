using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject[] LowCoins;
    private GameObject[] HighCoins;

    public GameObject Win;
    public GameObject Lose;
    public GameObject CanvasOfGameplay;
    public GameObject TimeObject;


    public GameObject canvasNormal;
    public GameObject canvasBull;
    public GameObject canvasBear;



    void Start()
    {
        Time.timeScale = 1;
        LowCoins = GameObject.FindGameObjectsWithTag("Low");
        HighCoins = GameObject.FindGameObjectsWithTag("High");
    }

    // Update is called once per frame
    void Update()
    {
        LowCoins = GameObject.FindGameObjectsWithTag("Low");
        HighCoins = GameObject.FindGameObjectsWithTag("High");
    }


    public void BullOrBear(string typeOfAnimal)
    {
        Invoke("ReDoEveryThings",10f);



        switch (typeOfAnimal)
        {
            case "Bear":


                canvasBear.SetActive(true);
                canvasBull.SetActive(false);
                canvasNormal.SetActive(false);


                for (int i = 0; i < LowCoins.Length; i++)
                {
                    LowCoins[i].GetComponent<CoinScript>().SetValueOfCoin(2);
                }

                for (int i = 0; i < HighCoins.Length; i++)
                {
                    HighCoins[i].GetComponent<CoinScript>().SetValueOfCoin(-2);
                }

                return;


            case "Bull":

                canvasBear.SetActive(false);
                canvasBull.SetActive(true);
                canvasNormal.SetActive(false);


                for (int i = 0; i < LowCoins.Length; i++)
                {
                    LowCoins[i].GetComponent<CoinScript>().SetValueOfCoin(-2);
                }

                for (int i = 0; i < HighCoins.Length; i++)
                {
                    HighCoins[i].GetComponent<CoinScript>().SetValueOfCoin(2);
                }

                return;
        }
    }

    public void MissionFailed()
    {
        Lose.SetActive(true);
        CanvasOfGameplay.SetActive(false);
    }

    public void LevelPassed()
    {
        TimeObject.GetComponent<TimerScript>().WorkingChanger();
        Win.SetActive(true);
        CanvasOfGameplay.SetActive(false);
        Time.timeScale = 0;
    }

    public void GetScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    void ReDoEveryThings()
    {
        canvasBear.SetActive(false);
        canvasBull.SetActive(false);
        canvasNormal.SetActive(true);

        for (int i = 0; i < LowCoins.Length; i++)
        {
            LowCoins[i].GetComponent<CoinScript>().SetInitial();
        }

        for (int i = 0; i < HighCoins.Length; i++)
        {
            HighCoins[i].GetComponent<CoinScript>().SetInitial();
        }
    }
}
