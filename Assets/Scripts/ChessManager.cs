using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessManager : MonoBehaviour
{
    // References
    public GameObject controller;
    public GameObject movePlate;

    //positions
    private int xBoard = -1;
    private int yBoard = -1;

    //variable to keep track of black or white player
    private string player;

    //references for all sprites that the pieces can be
    public Sprite blackQueen, blackKnight, blackBishop, blackKing, blackRook, blackPawn;
    public Sprite whiteQueen, whiteKnight, whiteBishop, whiteKing, whiteRook, whitePawn;

    public void Activate()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        //take the instantiated location and adjust the transform
        SetCoords();

        switch (this.name)
        {
            case "blackQueen": this.GetComponent<SpriteRenderer>().sprite = blackQueen; player = "black"; break;
            case "blackKnight": this.GetComponent<SpriteRenderer>().sprite = blackKnight; player = "black"; break;
            case "blackBishop": this.GetComponent<SpriteRenderer>().sprite = blackBishop; player = "black"; break;
            case "blackKing": this.GetComponent<SpriteRenderer>().sprite = blackKing; player = "black"; break;
            case "blackRook": this.GetComponent<SpriteRenderer>().sprite = blackRook; player = "black"; break;
            case "blackPawn": this.GetComponent<SpriteRenderer>().sprite = blackPawn; player = "black"; break;

            case "whiteQueen": this.GetComponent<SpriteRenderer>().sprite = whiteQueen; player = "white"; break;
            case "whiteKnight": this.GetComponent<SpriteRenderer>().sprite = whiteKnight; player = "white"; break;
            case "whiteBishop": this.GetComponent<SpriteRenderer>().sprite = whiteBishop; player = "white"; break;
            case "whiteKing": this.GetComponent<SpriteRenderer>().sprite = whiteKing; player = "white"; break;
            case "whiteRook": this.GetComponent<SpriteRenderer>().sprite = whiteRook; player = "white"; break;
            case "whitePawn": this.GetComponent<SpriteRenderer>().sprite = whitePawn; player = "white"; break;
        }
    }

    public void SetCoords()
    {
        float x = xBoard;
        float y = yBoard;

        x *= 1.12f;
        y *= 1.12f;

        x += -4.1f;
        y += -3.55f;

        this.transform.position = new Vector3(x, y, -1.0f);
    }

    // x board getter
    public int GetXBoard()
    {
        return xBoard;
    }

    // x board setter
    public void SetXBoard(int x)
    {
        xBoard = x;
    }

    // y board getter 
    public int GetYBoard()
    {
        return yBoard;
    }

    // y board setter
    public void SetYBoard(int y)
    {
        yBoard = y;
    }

    public void OnMouseUp()
    {
        DestroyMovePlates();

        InitiateMovePlates();
    }

    public void DestroyMovePlates()
    {
        GameObject[] movePlates = GameObject.FindGameObjectsWithTag("MovePlate");
        for (int i = 0; i < movePlates.Length; i++)
        {
            Destroy(movePlates[i]);
        }
    }

    public void InitiateMovePlates()
    {
        switch (this.name)
        {
            case "blackQueen":
            case "whiteQueen":
                LineMovePlate(1, 0);
                LineMovePlate(0, 1);
                LineMovePlate(1, 1);
                LineMovePlate(-1, 0);
                LineMovePlate(0, -1);
                LineMovePlate(-1, -1);
                LineMovePlate(-1, 1);
                LineMovePlate(1, -1);
                break;
            case "blackKnight":
            case "whiteKnight":
                LMovePlate();
                break;
            case "blackBishop":
            case "whiteBishop":
                LineMovePlate(1, 1);
                LineMovePlate(1, -1);
                LineMovePlate(-1, 1);
                LineMovePlate(-1, -1);
                break;
            case "blackKing":
            case "whiteKing":
                SurroundMovePlate();
                break;
            case "blackRook":
            case "whiteRook":
                LineMovePlate(1, 0);
                LineMovePlate(0, 1);
                LineMovePlate(-1, 0);
                LineMovePlate(0, -1);
                break;
            case "blackPawn":
                PawnMovePlate(xBoard, yBoard - 1);
                break;
            case "whitePawn":
                PawnMovePlate(xBoard, yBoard + 1);
                break;
        }
    }


    public void LineMovePlate(int xIncrement, int yIncrement)
    {
        Game sc = controller.GetComponent<Game>();

        int x = xBoard + xIncrement;
        int y = yBoard + yIncrement;

        while (sc.PositionOnBoard(x,y) && sc.GetPosition(x,y) == null)
        {
            MovePlateSpawn(x, y);
            x += xIncrement;
            y += yIncrement;
        }

        if (sc.PositionOnBoard(x,y) && sc.GetPosition(x,y).GetComponent<ChessManager>().player != player)
        {
            MovePlateAttackSpawn(x, y);
        }
    }

    public void LMovePlate()
    {
        PointMovePlate(xBoard + 1, yBoard + 2);
        PointMovePlate(xBoard - 1, yBoard + 2);
        PointMovePlate(xBoard + 2, yBoard + 1);
        PointMovePlate(xBoard + 2, yBoard - 1);
        PointMovePlate(xBoard + 1, yBoard - 2);
        PointMovePlate(xBoard - 1, yBoard - 2);
        PointMovePlate(xBoard - 2, yBoard + 1);
        PointMovePlate(xBoard - 2, yBoard - 1);
    }

    public void SurroundMovePlate()
    {
        PointMovePlate(xBoard, yBoard + 1);
        PointMovePlate(xBoard, yBoard - 1);
        PointMovePlate(xBoard - 1, yBoard + 0);
        PointMovePlate(xBoard - 1, yBoard - 1);
        PointMovePlate(xBoard - 1, yBoard + 1);
        PointMovePlate(xBoard + 1, yBoard + 0);
        PointMovePlate(xBoard + 1, yBoard - 1);
        PointMovePlate(xBoard + 1, yBoard + 1);
    }

    public void PointMovePlate(int x, int y)
    {
        Game sc = controller.GetComponent<Game>();
        if (sc.PositionOnBoard(x,y))
        {
            GameObject chessP = sc.GetPosition(x, y);

            if (chessP == null)
            {
                MovePlateSpawn(x, y);
            }
            else if (chessP.GetComponent<ChessManager>().player != player)
            {
                MovePlateAttackSpawn(x, y);
            }
        }
    }

    public void PawnMovePlate(int x, int y)
    {
        Game sc = controller.GetComponent<Game>();
        if (sc.PositionOnBoard(x, y))
        {
            if (sc.GetPosition(x, y) == null)
            {
                MovePlateSpawn(x, y);
            }

            if (sc.PositionOnBoard(x + 1, y) && sc.GetPosition(x + 1, y) != null && sc.GetPosition(x + 1, y).GetComponent<ChessManager>().player != player)
            {
                MovePlateAttackSpawn(x + 1, y);
            }

            if (sc.PositionOnBoard(x - 1, y) && sc.GetPosition(x - 1, y) != null && sc.GetPosition(x - 1, y).GetComponent<ChessManager>().player != player)
            {
                MovePlateAttackSpawn(x - 1, y);
            }
        }
    }


    public void MovePlateSpawn(int matrixX, int matrixY)
    {
        float x = matrixX;
        float y = matrixY;

        x *= 1.12f;
        y *= 1.12f;

        x += -4.1f;
        y += -3.55f;


        GameObject mp = Instantiate(movePlate, new Vector3(x, y, -3.0f), Quaternion.identity);

        MovePlate mpScript = mp.GetComponent<MovePlate>();
        mpScript.SetReference(gameObject);
        mpScript.SetCoords(matrixX, matrixX);
    }

    public void MovePlateAttackSpawn(int matrixX, int matrixY)
    {
        float x = matrixX;
        float y = matrixY;

        x *= 1.12f;
        y *= 1.12f;

        x += -4.1f;
        y += -3.55f;


        GameObject mp = Instantiate(movePlate, new Vector3(x, y, -3.0f), Quaternion.identity);

        MovePlate mpScript = mp.GetComponent<MovePlate>();
        mpScript.attack = true;
        mpScript.SetReference(gameObject);
        mpScript.SetCoords(matrixX, matrixX);
    }
}
