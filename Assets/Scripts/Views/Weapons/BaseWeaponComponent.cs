using System.Collections;
using UnityEngine;

public abstract class BaseWeaponComponent : MonoBehaviour
{
    public float Damage;
    public float Countdown;
    public float Speed;

    private bool _canAttack = true;
    private bool _reloading;
    public bool CanAttack => _canAttack;

    private void OnEnable()
    {
        if (_reloading)
        {
            Debug.LogWarning("Reloading...");
            StartCountdown();
        }
        else
        {
            _canAttack = true;
        }
    }

    public abstract void Attack();

    protected void StartCountdown()
    {
        _canAttack = false;
        _reloading = true;
        StartCoroutine(CountdownCoroutine());
    }

    private IEnumerator CountdownCoroutine()
    {
        yield return new WaitForSeconds(Countdown/2);
        
        _reloading = false;
        
        yield return new WaitForSeconds(Countdown/2);
        _canAttack = true;
    }
}
