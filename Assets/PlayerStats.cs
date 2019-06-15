using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private int goldAvailable;
    public int GoldAvailable
    {
        get => goldAvailable;
        set
        {
            goldAvailable = value;
            OnGoldUpdated.Invoke(goldAvailable);
        }
    }

    private int woodAvailable;
    public int WoodAvailable 
    {
        get => woodAvailable;
        set {
            woodAvailable = value;
            OnWoodUpdated.Invoke(woodAvailable);
        }
    }
    private int steelAvailable;
    public int SteelAvailable 
    {
        get => steelAvailable;
        set {
            steelAvailable = value;
            OnSteelUpdated.Invoke(steelAvailable);
        }
    }
    public static PlayerStats Instance { get; private set; }
    public Action<int> OnGoldUpdated;
    public Action<int> OnWoodUpdated;
    public Action<int> OnSteelUpdated;

    public void Awake()
    {
        Instance = this;
    }

    public void AddResource(Resource producedResource, int producedAmount)
    {
        switch (producedResource)
        {
            case Resource.Gold:
                GoldAvailable += producedAmount;
                break;
            case Resource.Wood:
                WoodAvailable += producedAmount;
                break;
            case Resource.Steel:
                SteelAvailable += producedAmount;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(producedResource), producedResource, null);
        }
    }
}
