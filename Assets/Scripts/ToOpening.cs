using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToOpening : MonoBehaviour
{

    public GameObject controller;


    public void ChangeToOpening(string gameMode)
    {
        controller.GetComponent<Game>().SetGameMode("opening");
        Debug.Log(controller.GetComponent<Game>().GetGameMode());
    }


}
