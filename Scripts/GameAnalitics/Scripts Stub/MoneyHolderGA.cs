using System;
using UnityEngine;

public class MoneyHolderGA : MonoBehaviour
{
    private void Start() => Debug.Log("Stub");

    public event Action<int> Changed;
}