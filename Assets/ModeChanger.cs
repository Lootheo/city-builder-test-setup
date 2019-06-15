using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public enum GameMode { Regular,Build}
public class ModeChanger : MonoBehaviour
{
    public GameMode CurrentGameMode = GameMode.Regular;
    public OnClickShowInfo OnClickShowInfo;
    public OnDragPurchase OnDragPurchase;
    public OnDragMoveBuilding OnDragMoveBuilding;
    public TextMeshProUGUI CurrentModeText;
    public void Start()
    {
        ChangeMode(CurrentGameMode);
    }

    private void ChangeMode(GameMode gameMode)
    {
        CurrentGameMode = gameMode;
        if (gameMode == GameMode.Regular)
        {
            OnClickShowInfo.gameObject.SetActive(true);
            OnDragPurchase.gameObject.SetActive(false);
            OnDragMoveBuilding.gameObject.SetActive(false);
        }
        else
        {
            OnClickShowInfo.gameObject.SetActive(false);
            OnDragPurchase.gameObject.SetActive(true);
            OnDragMoveBuilding.gameObject.SetActive(true);
        }
        CurrentModeText.text = gameMode.ToString();

    }

    public void EnableRegularMode()
    {
        ChangeMode(GameMode.Regular);
    }

    public void EnableBuildMode()
    {
        ChangeMode(GameMode.Build);
    }
}
