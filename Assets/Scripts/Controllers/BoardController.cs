using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    public static BoardController Instance { get; private set; }

    private Shape[] _board = new Shape[] { ShapeTypes.Blank, ShapeTypes.Blank, ShapeTypes.Blank,      // 0 1 2
                                            ShapeTypes.Blank, ShapeTypes.Blank, ShapeTypes.Blank,      // 3 4 5
                                            ShapeTypes.Blank, ShapeTypes.Blank, ShapeTypes.Blank };    // 6 7 8
    
    void Awake()
    {
        if (Instance == null) { Instance = this; } else { Debug.Log("Warning: multiple " + this + " in scene!"); Destroy(gameObject); }
    }

    public void DoBoardCheck()
    {
        if (
            (_board[0] == ShapeTypes.Circle && _board[3] == ShapeTypes.Circle && _board[6] == ShapeTypes.Circle) ||
            (_board[1] == ShapeTypes.Circle && _board[4] == ShapeTypes.Circle && _board[7] == ShapeTypes.Circle) ||
            (_board[2] == ShapeTypes.Circle && _board[5] == ShapeTypes.Circle && _board[8] == ShapeTypes.Circle) ||
            (_board[0] == ShapeTypes.Circle && _board[1] == ShapeTypes.Circle && _board[2] == ShapeTypes.Circle) ||
            (_board[3] == ShapeTypes.Circle && _board[4] == ShapeTypes.Circle && _board[5] == ShapeTypes.Circle) ||
            (_board[6] == ShapeTypes.Circle && _board[7] == ShapeTypes.Circle && _board[8] == ShapeTypes.Circle) ||
            (_board[0] == ShapeTypes.Circle && _board[4] == ShapeTypes.Circle && _board[8] == ShapeTypes.Circle) ||
            (_board[2] == ShapeTypes.Circle && _board[4] == ShapeTypes.Circle && _board[6] == ShapeTypes.Circle)
            )
        {
            GameMediator.Instance.Broadcast("GAME_END",GameStatus.VictoryPlayer1);
        }
        else if (
            (_board[0] == ShapeTypes.Cross && _board[3] == ShapeTypes.Cross && _board[6] == ShapeTypes.Cross) ||
            (_board[1] == ShapeTypes.Cross && _board[4] == ShapeTypes.Cross && _board[7] == ShapeTypes.Cross) ||
            (_board[2] == ShapeTypes.Cross && _board[5] == ShapeTypes.Cross && _board[8] == ShapeTypes.Cross) ||
            (_board[0] == ShapeTypes.Cross && _board[1] == ShapeTypes.Cross && _board[2] == ShapeTypes.Cross) ||
            (_board[3] == ShapeTypes.Cross && _board[4] == ShapeTypes.Cross && _board[5] == ShapeTypes.Cross) ||
            (_board[6] == ShapeTypes.Cross && _board[7] == ShapeTypes.Cross && _board[8] == ShapeTypes.Cross) ||
            (_board[0] == ShapeTypes.Cross && _board[4] == ShapeTypes.Cross && _board[8] == ShapeTypes.Cross) ||
            (_board[2] == ShapeTypes.Cross && _board[4] == ShapeTypes.Cross && _board[6] == ShapeTypes.Cross)
            )
        {
            GameMediator.Instance.Broadcast("GAME_END", GameStatus.VictoryPlayer2);
        }
    }
    
    public void RefreshImages()
    {
        foreach (Tile tile in FindObjectsOfType<Tile>())
        {
            tile.RefreshImage();
        }
    }

    public void ChangeTileShape(int id, Shape shape)
    {
        _board[id] = shape;
        RefreshImages();
        DoBoardCheck();
    }

    public Shape GetTileShape(int id)
    {
        return _board[id];
    }
}
