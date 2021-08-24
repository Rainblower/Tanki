using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

public class TankViewController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb = default;
    [SerializeField] private List<BaseWeaponComponent> _weapons = default;
    
    public float baseSpeed = 77.5f;
    public float rotateSpeed = 0.1f;

    [ShowInInspector]
    private BaseWeaponComponent _currentWeapon;
    
    private float _velocity;
    private float _rotation;

    public void Init()
    {
        _currentWeapon = _weapons.FirstOrDefault();
    }
    
    private void Fire()
    {
        _currentWeapon.Attack();
    }

    public void MoveHandler(float velocity)
    {
        _velocity = velocity;
    }

    public void RotateHandler(float rotation)
    {
        _rotation = rotation;
    }

    public void FireHandler()
    {
        Fire();
    }

    public void NextWeaponHandler()
    {
        Debug.Log("next weapon");
    }

    public void PrevWeaponHandler()
    {
        Debug.Log("prev weapon");
    }
    
    private void FixedUpdate()
    {
        _rb.velocity = transform.up *  _velocity * baseSpeed;
        transform.Rotate( -Vector3.forward ,rotateSpeed * _rotation);
    }
}
