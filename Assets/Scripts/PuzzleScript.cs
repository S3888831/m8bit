using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleScript : MonoBehaviour
{

    // stores active move from move order list got by Josh's move script
    string currentMove = "";
    string computersMove = "";
    string prevMove = "";

    // Gets active scene and stores it in activeScene Object through 'name' instance
    Scene activeScene = SceneManager.GetActiveScene();

    void Start()
    {
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

    bool OpeningPuzzle()
    {
        // Italian game
        string[] puzzleExample1Black = { "e5", "Nc6" };
        string[] puzzleExample1White = { "e4", "Ne3", "Bb5" };
        string[] puzzleMoves = new string[6];
        int moveCount = 0;
        bool outcome = false;
        moveCount = 0;
        while (true)
        {
            updateCurrent();
            // If user's move is the expected move in puzzle, register their move and execute next computer move
            if (currentMove == puzzleExample1White[moveCount])
            {
                if (puzzleExample1Black.Length >= moveCount)
                {
                    computersMove = puzzleExample1Black[moveCount]; // Updating computers next move
                    prevMove = currentMove; // Assigning user's previous move
                    puzzleMoves[moveCount] = currentMove;
                    puzzleMoves[moveCount + 1] = computersMove;
                    moveCount++;
                }
                else 
                {
                    outcome = true; // success, puzzle achieved. Break out of while loop
                    break;
                }
            }
            else
            {
                // incorrect move, place user piece back to prevMove
                // Or we could just end game and display a fail message if resetting pieces is too difficult
                resetPiece(puzzleExample1White, puzzleExample1Black);
            }
        }
        return outcome;
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
    bool midEndGame()
    {
        bool outcome = false;
        return outcome;
    }
    bool checkmate()
    {
        bool outcome = false;
        return outcome;
    }
    
}
