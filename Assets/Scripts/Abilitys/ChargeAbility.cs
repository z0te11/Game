using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeAbility : Ability
{
    public float chargeDelay;
    public float forceChagre;
    protected Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    } 

    private float _chargeTime = float.MinValue;
    public override void Execute()
    {
        if (Time.time < _chargeTime + chargeDelay) return;

        _chargeTime = Time.time;
        Charge();
    }

    private void Charge()
    {
        _rb.AddForce(transform.forward * forceChagre,  ForceMode.Impulse);
    }
}