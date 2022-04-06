using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public partial class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] Text _gameStatusText = null;
    [SerializeField] bool _computerPlayer = false;
    GameStatus _gameStatus = GameStatus.Setup;

    void Awake()
    {
        if (Instance == null) { Instance = this; } else { Debug.Log("Warning: multiple " + this + " in scene!"); Destroy(gameObject); }
    }

    private void Start()
    {
        GameMediator.Instance.AddHandler("CHANGE_TURN", ChangeTurn);
        GameMediator.Instance.AddHandler("GAME_START", GameStart);
        GameMediator.Instance.AddHandler("GAME_END", GameEnd);

        _gameStatusText.text = "";
    }

    public void ChangeTurn(object obj)
    {
        if (_computerPlayer)
        {
            AIController.Instance.MakeMove(ShapeTypes.Cross);
            
            return;
        }
        if (obj == null)
        {
            if (_gameStatus == GameStatus.TurnPlayer1)
            {
                _gameStatus = GameStatus.TurnPlayer2;
                _gameStatusText.text = "Player 2's Turn";
            }
            else if (_gameStatus == GameStatus.TurnPlayer2)
            {
                _gameStatus = GameStatus.TurnPlayer1;
                _gameStatusText.text = "Player 1's Turn";
            }
        }
        else if (new GameStatus[] { GameStatus.TurnPlayer1, GameStatus.TurnPlayer2 }.Contains(_gameStatus))
        {
            if (obj.Equals(GameStatus.TurnPlayer1))
            {
                _gameStatus = GameStatus.TurnPlayer1;
                _gameStatusText.text = "Player 1's Turn";
            }
            else if (obj.Equals(GameStatus.TurnPlayer2))
            {
                _gameStatus = GameStatus.TurnPlayer2;
                _gameStatusText.text = "Player 2's Turn";
            }
        }
    }

    public void GameStart(object obj)
    {
        if (new[] { GameStatus.Setup, GameStatus.VictoryPlayer1, GameStatus.VictoryPlayer2 }.Contains(_gameStatus))
        {
            for (int i = 0; i < 9; i++)
            {
                BoardController.Instance.ChangeTileShape(i, ShapeTypes.Blank);
            }
            _gameStatus = GameStatus.TurnPlayer1;
            _gameStatusText.text = "Player 1's Turn";
        }
    }

    public void GameEnd(object obj)
    {
        if (obj == null)
        {
            for (int i = 0; i < 9; i++)
            {
                BoardController.Instance.ChangeTileShape(i, ShapeTypes.Blank);
            }
            _gameStatusText.text = "";
            _gameStatus = GameStatus.Setup;
        }
        else
        {
            if (obj.Equals(GameStatus.VictoryPlayer1))
            {
                _gameStatusText.text = "Player 1 Won!";
                _gameStatus = GameStatus.VictoryPlayer1;
            }
            else if (obj.Equals(GameStatus.VictoryPlayer2))
            {
                _gameStatusText.text = "Player 2 Won!";
                _gameStatus = GameStatus.VictoryPlayer2;
            }
        }
    }

    public GameStatus GetGameStatus()
    {
        return _gameStatus;
    }
}
