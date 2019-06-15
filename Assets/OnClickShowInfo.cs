using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OnClickShowInfo : MonoBehaviour
{
    public TextMeshProUGUI InfoText;
    public GameObject ProduceButton;
    public GameObject ProductionBar;
    public Image ProductionBarForeground;
    public void OnEnable()
    {
        FindObjectOfType<OnClickSelectBuilding>().BuildingClicked += ShowBuildingInfo;
        HideUI();
    }

    private void OnDisable()
    {
        ClearProductionEvents();
        OnClickSelectBuilding onClickSelectBuilding = FindObjectOfType<OnClickSelectBuilding>();
        if (onClickSelectBuilding != null)
        {
            onClickSelectBuilding.BuildingClicked -= ShowBuildingInfo;
        }

        HideUI();
    }

    void HideUI()
    {
        if (InfoText != null)
            InfoText.gameObject.SetActive(false);
        if (ProduceButton != null)
            ProduceButton.SetActive(false);
        if (ProductionBar != null)
            ProductionBar.SetActive(false);
    }

    void ShowBuildingInfo(Building buildingToShow)
    {
        Debug.Log("clicked  ");
        InfoText.gameObject.SetActive(true);
        InfoText.text = buildingToShow.Name;
        Debug.Log(buildingToShow.Name);
        var buildingPosition = buildingToShow.transform.position;
        InfoText.transform.position = new Vector3(buildingPosition.x + 10, buildingPosition.y + 15, buildingPosition.z - 20);
        ShowProductionButton(buildingToShow);
        ShowProductionBar(buildingToShow);
    }

    private void ShowProductionBar(Building buildingToShow)
    {
        Production buildingProduction = buildingToShow.GetComponent<Production>();
        bool canShowProductionBar = buildingProduction != null && buildingProduction.IsProducing;
        if (canShowProductionBar)
        {
            ProductionBar.SetActive(true);
            var buildingPosition = buildingToShow.transform.position;
            ProductionBar.transform.position = new Vector3(buildingPosition.x + 10, buildingPosition.y + 25, buildingPosition.z - 20);
            ClearProductionEvents();
            buildingProduction.OnProducing = OnProducing;
        }
        else
        {
            ProductionBar.SetActive(false);
        }
    }

    private void ClearProductionEvents()
    {
        foreach (Production buildingProduction in FindObjectsOfType<Production>())
        {
            buildingProduction.OnProducing = null;
        }
    }
    private void OnProducing(int timeProducing, int timeToProduce)
    {
        ProductionBarForeground.fillAmount = (float)timeProducing / (float)timeToProduce;
    }

    private void ShowProductionButton(Building buildingToShow)
    {
        Production buildingProduction = buildingToShow.GetComponent<Production>();
        bool canShowProductionButton = buildingProduction != null && buildingProduction.CanProduce &&
                                            buildingProduction.ProductionType == ProductionType.Manual && !buildingProduction.IsProducing;
        if (canShowProductionButton)
        {
            ProduceButton.SetActive(true);
            var buildingPosition = buildingToShow.transform.position;
            ProduceButton.transform.position = new Vector3(buildingPosition.x + 10, buildingPosition.y + 25, buildingPosition.z - 20);
            ProduceButton.GetComponent<Button>().onClick.RemoveAllListeners();
            ProduceButton.GetComponent<Button>().onClick.AddListener(() =>
            {
                ProduceButton.SetActive(false);
                buildingProduction.Produce();
                ShowProductionBar(buildingToShow);
            });
        }
        else
        {
            ProduceButton.SetActive(false);
        }
    }
}
