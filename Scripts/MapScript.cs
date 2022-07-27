using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapScript : MonoBehaviour
{

    public void GetScreen(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
