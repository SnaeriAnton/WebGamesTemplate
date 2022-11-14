using System;
using UnityEngine;

public class FinishGA : MonoBehaviour
{
    private void Start() => Debug.Log("Stub");

    public event Action Victoryed;
    public event Action Losed;
}
