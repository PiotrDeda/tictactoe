using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public partial class Tile : MonoBehaviour
{
    [SerializeField] int _tileId = 0;
    [SerializeField] SpriteRenderer _sprite = null;

    private void Start()
    {
        RefreshImage();
    }

    private void OnMouseUpAsButton()
    {
        if (GameManager.Instance.GetGameStatus() == GameStatus.TurnPlayer1 && BoardController.Instance.GetTileShape(_tileId) == ShapeTypes.Blank)
        {
            BoardController.Instance.ChangeTileShape(_tileId, ShapeTypes.Circle);
            GameMediator.Instance.Broadcast("CHANGE_TURN");
        }
        else if (GameManager.Instance.GetGameStatus() == GameStatus.TurnPlayer2 && BoardController.Instance.GetTileShape(_tileId) == ShapeTypes.Blank)
        {
            BoardController.Instance.ChangeTileShape(_tileId, ShapeTypes.Cross);
            GameMediator.Instance.Broadcast("CHANGE_TURN");
        }

        RefreshImage();
    }

    public void RefreshImage()
    {
        _sprite.sprite = BoardController.Instance.GetTileShape(_tileId).Sprite;
    }
}
