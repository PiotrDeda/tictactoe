using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public static AIController Instance { get; private set; }

    void Awake()
    {
        if (Instance == null) { Instance = this; } else { Debug.Log("Warning: multiple " + this + " in scene!"); Destroy(gameObject); }
    }

    // TODO: może się wylosować kilka razy ten sam tile i for przejdzie po całej tablicy i nie wykona ruchu, ale będzie wolne miejsce, które nie zostało trafione, naprawić
    public void MakeMove(Shape playerShape)
    {
        bool helper = true;
        for (int i = 0; i < 9; i++)
        {
            if (BoardController.Instance.GetTileShape(i) == ShapeTypes.Blank)
            {
                while (helper)
                {
                    int rand = Random.Range(0, 8);
                    if (BoardController.Instance.GetTileShape(rand) == ShapeTypes.Blank)
                    {
                        BoardController.Instance.ChangeTileShape(rand, playerShape);
                        helper = false;
                    }
                }
                break;
            }
        }
    }
}
