using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnDragPurchase : MonoBehaviour
{
    public GameObject ShopCanvas;
    public List<Building> BuildingsToPurchase;
    public List<Button> PurchaseBuildingButtons;
    
    private void OnEnable()
    {
        UpdateShopButtons();
    }

    private void UpdateShopButtons()
    {
        ShopCanvas.gameObject.SetActive(true);
        HidePurchaseButtons();
        for (int i = 0; i < BuildingsToPurchase.Count; i++)
        {
            Building building = BuildingsToPurchase[i];
            PurchaseBuildingButtons[i].gameObject.SetActive(true);
            Text purchaseButtonText = PurchaseBuildingButtons[i].GetComponentInChildren<Text>();
            purchaseButtonText.text = "";
            purchaseButtonText.text += building.Name;
            foreach (Cost buildingCost in building.Costs)
            {
                purchaseButtonText.text += "\n" + buildingCost.Amount + " " + buildingCost.Resource.ToString();
            }
            PurchaseBuildingButtons[i].onClick.RemoveAllListeners();
            PurchaseBuildingButtons[i].onClick.AddListener(() => { Instantiate(building); });
        }
    }

    void OnDisable()
    {
        if (ShopCanvas != null)
            ShopCanvas.gameObject.SetActive(false);
    }

    private void HidePurchaseButtons()
    {
        foreach (Button purchaseBuildingButton in PurchaseBuildingButtons)
        {
            purchaseBuildingButton.gameObject.SetActive(false);
        }
    }
}
