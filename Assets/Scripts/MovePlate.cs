using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class MovePlate : MonoBehaviour
{
    public GameObject controller;

    public GameObject blackLeftRook;

    GameObject reference = null;


    int matrixX;
    int matrixY;
    string notation;

    // movement = false, attacking = true
    public bool attack = false;

    public void Start()
    {
        if (attack)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }

    }

    public void OnMouseUp()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        controller.GetComponent<Game>().IncrementMoveCount();

        if (attack)
        {
            GameObject chessP = controller.GetComponent<Game>().GetPosition(matrixX, matrixY);

            Destroy(chessP);

        }

        controller.GetComponent<Game>().SetPositionEmpty(reference.GetComponent<ChessManager>().GetXBoard(),
            reference.GetComponent<ChessManager>().GetYBoard());



        // Displays algebraic notation in console

        //Get piece name of currently selected piece and store in string
        string pieceName = reference.GetComponent<ChessManager>().name;

        // if capturing, add 'x' betweeen piece and position
        if (attack)
        {
            notation = reference.GetComponent<ChessManager>().GetPiece() + "x" + GetChessNotation(matrixX, matrixY);

            //if a pawn is capturing, add the file it came from to the notation
            if (pieceName == "blackPawn" || pieceName == "whitePawn")
            {
                notation = GetFile(reference.GetComponent<ChessManager>().GetXBoard()) + notation;
            }
        }
        else
        {
            notation = reference.GetComponent<ChessManager>().GetPiece() + GetChessNotation(matrixX, matrixY);
        }

        Debug.Log(notation);

        if (notation == "Bc4")
        {
            controller.GetComponent<Game>().Winner();
        }
        else
        {
            controller.GetComponent<Game>().Loser();
        }

        switch (controller.GetComponent<Game>().GetMoveCount())
        {
            case 1:
                controller.GetComponent<Game>().SetMove1(notation);
                break;
            case 2:
                controller.GetComponent<Game>().SetMove2(notation);
                break;
            case 3:
                controller.GetComponent<Game>().SetMove3(notation);
                break;
            case 4:
                controller.GetComponent<Game>().SetMove4(notation);
                break;
            case 5:
                controller.GetComponent<Game>().SetMove5(notation);
                break;
        }


        controller.GetComponent<Game>().AddMove(notation);

        reference.GetComponent<ChessManager>().SetXBoard(matrixX);
        reference.GetComponent<ChessManager>().SetYBoard(matrixY);
        reference.GetComponent<ChessManager>().SetCoords();

        controller.GetComponent<Game>().SetPosition(reference);

        controller.GetComponent<Game>().NextTurn();

        reference.GetComponent<ChessManager>().DestroyMovePlates();

    }

    public void SetCoords(int x, int y)
    {
        matrixX = x;
        matrixY = y;
    }

    public void SetReference(GameObject obj)
    {
        reference = obj;
    }

    public GameObject GetReference()
    {
        return reference;
    }

    // POSITION CONVERTER

    public string GetChessNotation(string piece, int x, int y)
    {
        string[] xAxis = { "a", "b", "c", "d", "e", "f", "g", "h" };
        string[] yAxis = { "1", "2", "3", "4", "5", "6", "7", "8" };

        string notation = piece + xAxis[x] + yAxis[y];

        return notation;

    }

    public string GetChessNotation(int x, int y)
    {
        string[] xAxis = { "a", "b", "c", "d", "e", "f", "g", "h" };
        string[] yAxis = { "1", "2", "3", "4", "5", "6", "7", "8" };

        string notation = xAxis[x] + yAxis[y];

        return notation;

    }

    public string GetFile(int x)
    {
        string[] xAxis = { "a", "b", "c", "d", "e", "f", "g", "h" };

        string notation = xAxis[x];

        return notation;

    }



}
