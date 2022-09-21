using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlate : MonoBehaviour
{
    public GameObject controller;

    GameObject reference = null;

    int matrixX;
    int matrixY;

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

        if (attack)
        {
            GameObject chessP = controller.GetComponent<Game>().GetPosition(matrixX, matrixY);

            Destroy(chessP);
        }

        controller.GetComponent<Game>().SetPositionEmpty(reference.GetComponent<ChessManager>().GetXBoard(),
            reference.GetComponent<ChessManager>().GetYBoard());

        reference.GetComponent<ChessManager>().SetXBoard(matrixX);
        reference.GetComponent<ChessManager>().SetYBoard(matrixY);
        reference.GetComponent<ChessManager>().SetCoords();

        controller.GetComponent<Game>().SetPosition(reference);

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
}
