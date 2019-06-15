using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UIResources : MonoBehaviour
{
    public Text GoldText;
    public Text WoodText;
    public Text SteelText;


    private void Start()
    {
        PlayerStats.Instance.OnGoldUpdated += UpdateGold;
        PlayerStats.Instance.OnSteelUpdated += UpdateSteel;
        PlayerStats.Instance.OnWoodUpdated += UpdateWood;
    }


    private void UpdateWood(int woodAvailable)
    {
        WoodText.text = $"[{woodAvailable}]";
    }

    private void UpdateSteel(int steelAvailable)
    {
        SteelText.text = $"[{steelAvailable}]";
    }

    private void UpdateGold(int goldAvailable)
    {
        GoldText.text = $"[{goldAvailable}]";
    }
}
