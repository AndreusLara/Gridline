using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour
{
    public GameObject piece;
   
    public GameObject[,] positions = new GameObject[8, 8];
    public GameObject[] playerPiece = new GameObject[6];



    //Start is called before the first frame update
    // On Start the pieces in the units space are made for placement in the game
    void Start()
    {
        playerPiece = new GameObject[]
        {
            Create("white_rook",50,50), Create("white_knight",1,0), Create("white_bishop",2,0), Create("white_queen",3,0),
            Create("white_king",4,0), Create("white_pawn",0,1)
        };

        for (int i = 0; i < playerPiece.Length; i++)
        {
            SetPosition(playerPiece[i]);

        }
    }
    // Used to  manage pieces on the board, pieces are created then will be placed based on the get from the grid map.
    public GameObject Create(string name, int x, int y)
    {
        GameObject obj = Instantiate(piece, new Vector3(0, 0, -1), Quaternion.identity);
        Pieces cm = obj.GetComponent<Pieces>();
        cm.name = name;
        cm.SetXBoard(x);
        cm.SetYBoard(y);
        cm.Activate();
        return obj;
    }
    // sets position of sprites on top of board from returned value onclick
    public void SetPosition(GameObject obj)
    {
        Pieces cm = obj.GetComponent<Pieces>();

        positions[cm.GetXBoard(), cm.GetYBoard()] = obj;
    }
    // used to remove objects from board
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



    /*
    // Update is called once per frame
    void Update()
    {
        
    }
    */
}