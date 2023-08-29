using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinMarker : GameLuckSpin
{
    [SerializeField] protected string Number;
    public string spinMarkerNumber => Number;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        this.Number = other.name;
        Debug.Log(other.name);
    }
}
