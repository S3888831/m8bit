using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game : MonoBehaviour
{

    public GameObject chessPiece;

    public TMP_Text movePositon;

    public int moveCount;

    public TMP_Text move1;
    public TMP_Text move2;
    public TMP_Text move3;
    public TMP_Text move4;
    public TMP_Text move5;

    

    //positions and team for each chess peice
    private GameObject[,] positions = new GameObject[8, 8];
    private GameObject[] playerBlack = new GameObject[16];
    private GameObject[] playerWhite = new GameObject[16];

    private GameObject[,] underAttack = new GameObject[8, 8];

    private string currentPlayer = "white";

    // castling 
    private bool castleWhiteRight = true;
    private bool castleWhiteLeft = true;
    private bool castleBlackRight = true;
    private bool castleBlackLeft = true;


    private bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        playerWhite = new GameObject[]
        {
            Create("whiteRook", 0 , 0),
            Create("whiteKnight", 1, 0),
            Create("whiteBishop", 2, 0),
            Create("whiteQueen", 3, 0),
            Create("whiteKing", 4, 0),
            Create("whiteBishop", 5, 0),
            Create("whiteKnight", 6, 0),
            Create("whiteRook", 7 , 0),

            Create("whitePawn", 0 , 1),
            Create("whitePawn", 1 , 1),
            Create("whitePawn", 2 , 1),
            Create("whitePawn", 3 , 1),
            Create("whitePawn", 4 , 1),
            Create("whitePawn", 5 , 1),
            Create("whitePawn", 6 , 1),
            Create("whitePawn", 7 , 1)
        };

        playerBlack = new GameObject[]
        {
            Create("blackRook", 0 , 7),
            Create("blackKnight", 1, 7),
            Create("blackBishop", 2, 7),
            Create("blackQueen", 3, 7),
            Create("blackKing", 4, 7),
            Create("blackBishop", 5, 7),
            Create("blackKnight", 6, 7),
            Create("blackRook", 7 , 7),

            Create("blackPawn", 0 , 6),
            Create("blackPawn", 1 , 6),
            Create("blackPawn", 2 , 6),
            Create("blackPawn", 3 , 6),
            Create("blackPawn", 4 , 6),
            Create("blackPawn", 5 , 6),
            Create("blackPawn", 6 , 6),
            Create("blackPawn", 7 , 6),
        };

        // set all positions on the board

        for (int i = 0; i < playerBlack.Length; i++)
        {
            SetPosition(playerBlack[i]);
            SetPosition(playerWhite[i]);

        }


    }

    public GameObject Create(string name, int x, int y)
    {
        GameObject obj = Instantiate(chessPiece, new Vector3(0, 0, -1), Quaternion.identity);
        ChessManager cm = obj.GetComponent<ChessManager>();
        cm.name = name;
        cm.SetXBoard(x);
        cm.SetYBoard(y);
        cm.Activate();
        //if (name == "blackKing" || name == "whiteKing")
        //{
        //    cm.SetKing(true);
        //}
        //else
        //{
        //    cm.SetKing(false);
        //}

        return obj;
    }

    public void SetPosition(GameObject obj)
    {
        ChessManager cm = obj.GetComponent<ChessManager>();

        positions[cm.GetXBoard(), cm.GetYBoard()] = obj;
    }


    public void SetPositionEmpty(int x, int y)
    {
        positions[x, y] = null;
    }

    public GameObject GetPosition(int x, int y)
    {
        return positions[x, y];
    }

    public bool PositionOnBoard(int x, int y)
    {
        if (x < 0 || y < 0 || x >= positions.GetLength(0) || y >= positions.GetLength(1)) return false;
        return true;
    }



    // CASTLE SETTERS
    public void SetCastleWhiteRight(bool status)
    {
        castleWhiteRight = status;
    }

    public void SetCastleWhiteLeft(bool status)
    {
        castleWhiteLeft = status;
    }

    public void SetCastleBlackRight(bool status)
    {
        castleBlackRight = status;
    }

    public void SetCastleBlackLeft(bool status)
    {
        castleBlackLeft = status;
    }

    //// CASTLE GETTERS
    //public bool GetCastleWhiteRight()
    //{
    //    return castleWhiteRight;
    //}

    //public bool GetCastleWhiteLeft()
    //{
    //    return castleWhiteLeft;
    //}

    //public bool GetCastleBlackRight()
    //{
    //    return castleBlackRight;
    //}

    //public bool GetCastleBlackLeft()
    //{
    //    return castleBlackLeft;
    //}

    // text setter

    //public void textSetter(string move)
    //{
    //    movePositon.text = move;
    //}

    // move setters

    public void SetMove1(string move)
    {
        move1.text = move;
    }

    public void SetMove2(string move)
    {
        move2.text = move;
    }

    public void SetMove3(string move)
    {
        move3.text = move;
    }

    public void SetMove4(string move)
    {
        move4.text = move;
    }

    public void SetMove5(string move)
    {
        move5.text = move;
    }



    // move count getter

    public int GetMoveCount()
    {
        return moveCount;
    }

    public void IncrementMoveCount()
    {
        moveCount += 1;
    }
}   
