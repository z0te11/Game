using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IType
{
    public AbilityType Type { get; set; }
    [SerializeField] protected OnDieManager onDieManager;
    [SerializeField] protected float _health;
    [SerializeField] protected AnimController animController;

    public virtual float Healths
    {
        get { return _health; }
        set { _health = value; }
    }

    protected virtual void Awake()
    {
        Type = AbilityType.Health;
    }

    public virtual void SetHealth(int health)
    {
        Healths = health;
    }
    public virtual void GetDamage(float damage)
    {
        Healths -= damage;
        Debug.Log("GetDamage" + _health);
        if (animController != null) animController.GetHit();
        if (_health < 0) Die();
    }

    public virtual void GetHeal(float heal)
    {
        Healths += heal;
        Debug.Log("GetHeal" + _health);
    }

    public virtual void Die()
    {
        if (animController != null) animController.Die();
        if (onDieManager != null) onDieManager.Execute();
    }
}
