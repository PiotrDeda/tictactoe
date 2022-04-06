using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    private void OnMouseUpAsButton()
    {
        GameMediator.Instance.Broadcast("GAME_START");
    }
}
