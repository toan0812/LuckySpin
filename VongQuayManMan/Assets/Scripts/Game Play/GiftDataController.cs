using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftDataController : GameLuckSpin
{
    public static GiftDataController Instance;
    public List<GameObject> ListData;

    protected override void Awake()
    {
        base.Awake();
        Instance = this;
    }
}
