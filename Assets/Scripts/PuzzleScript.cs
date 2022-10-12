using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PuzzleScript : MonoBehaviour
{

    // stores active move from move order list got by Josh's move script
    public GameObject controller;
    string currentMove = "";
    string expectedOutput = "";
    [SerializeField] GameObject victoryScreen;
    string computersMove = "";
    string prevMove = "";
    bool outcome;

    // Gets active scene and stores it in activeScene Object through 'name' instance
    Scene activeScene = SceneManager.GetActiveScene();

    void Start()
    {
        // Gets active scene and stores it in activeScene Object through 'name' instance
        Scene activeScene = SceneManager.GetActiveScene();
        // on Start of active game, it activates the chosen puzzle accordingly
        if (activeScene.name == "openings")
        {
            OpeningPuzzle();
        }
        else if (activeScene.name == "midEndGame")
        {
            midEndGame();
        }
        else
        {
            checkmate();
        }
    }

    void OpeningPuzzle()
    {
        expectedOutput = "Bc4";
        if (String.Equals(controller.GetComponent<Game>().GetMoveHistory(0), expectedOutput))
        {
            // exec success screen
            victoryScreen.SetActive(true);
        }
    }
    void updateCurrent()
    {
        // This function would get user's next move as they play it
    }
    void resetPiece(string[] puzzleArrayWhite, string[] puzzleArrayBlack)
    {
        currentMove = puzzleArrayWhite[0];
        computersMove = puzzleArrayBlack[0];
    }
    void midEndGame()
    {
        expectedOutput = "C8=Q";
        if (String.Equals(controller.GetComponent<Game>().GetMoveHistory(0), expectedOutput))
        {
            // exec success screen
            victoryScreen.SetActive(true);
        }
    }
    void checkmate()
    {
        expectedOutput = "Rg5";
        if (String.Equals(controller.GetComponent<Game>().GetMoveHistory(0), expectedOutput))
        {
            // exec success screen
            victoryScreen.SetActive(true);
        }
    }
    
}
