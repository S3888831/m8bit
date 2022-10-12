using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CB_Change : MonoBehaviour
{
    public GameObject controller;

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);

        controller = GameObject.FindGameObjectWithTag("GameController");
        controller.GetComponent<Game>().SetGameMode("opening");

    }

}
