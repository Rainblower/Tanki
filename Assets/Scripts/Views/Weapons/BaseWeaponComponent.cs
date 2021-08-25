using System.Collections;
using UnityEngine;

public abstract class BaseWeaponComponent : MonoBehaviour
{
    public float Damage;
    public float Countdown;
    public float Speed;

    private bool _canAttack = true;
    public bool CanAttack => _canAttack;
    
    public abstract void Attack();

    protected void StartCountdown()
    {
        _canAttack = false;
        StartCoroutine(CountdownCoroutine());
    }

    private IEnumerator CountdownCoroutine()
    {
        yield return new WaitForSeconds(Countdown);
        _canAttack = true;
    }
}
