using System;
using System.Collections;
using UnityEngine;
public enum ProductionType { Continuous, Manual }
public class Production : MonoBehaviour
{
    public ProductionType ProductionType;
    public Resource ProducedResource;
    public int TimeToProduce;
    public int ProducedAmount;
    public bool CanProduce = true;
    public bool IsProducing { get; private set; }
    private Action<int, int> onProducing;
    public Action<int, int> OnProducing
    {
        get => onProducing;
        set
        {
            onProducing = value;
            onProducing?.Invoke(timeProducing,TimeToProduce);
        }
    }

    private int timeProducing = 0;
    private void Start()
    {
        if (ProductionType == ProductionType.Continuous)
            StartCoroutine(ProduceCoroutine());
    }

    public void Produce()
    {
        StartCoroutine(ProduceCoroutine());
        OnProducing?.Invoke(timeProducing, TimeToProduce);
    }

    public IEnumerator ProduceCoroutine()
    {
        do
        {
            IsProducing = true;
            timeProducing = 0;
            while (timeProducing < TimeToProduce)
            {
                OnProducing?.Invoke(timeProducing, TimeToProduce);
                yield return new WaitForSeconds(1);
                timeProducing++;
            }
            PlayerStats.Instance.AddResource(ProducedResource, ProducedAmount);
        } while ((CanProduce && ProductionType == ProductionType.Continuous));
        IsProducing = false;
    }
}
