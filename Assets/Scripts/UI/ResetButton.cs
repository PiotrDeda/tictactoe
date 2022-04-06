using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    private void OnMouseUpAsButton()
    {
        GameMediator.Instance.Broadcast("GAME_END");
    }
}
