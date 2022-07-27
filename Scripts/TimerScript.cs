using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject GameManager;
    private  bool isWorking;


    void Start()
    {
        isWorking = true;
        InvokeRepeating("DecreaseTime", 0, 1f);
    }


    public void WorkingChanger()
    {
        isWorking = false;
    }

    void DecreaseTime()
    {
        if (isWorking)
        {


            float time = int.Parse(GetComponent<TextMeshProUGUI>().text.ToString());
            time -= 1;

            GetComponent<TextMeshProUGUI>().text = time.ToString();

            if (time <= 0)
            {
                GameManager.GetComponent<GameManager>().MissionFailed();
                Time.timeScale = 0;
                isWorking = false;
            }

        }
    }

}
