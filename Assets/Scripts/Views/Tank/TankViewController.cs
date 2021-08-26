using System.Collections.Generic;
using System.Linq;
using Models;
using Sirenix.OdinInspector;
using UnityEngine;
using Views.Tank;

public class TankViewController : MonoBehaviour, ILivedEntity, ICollisionComponent
{
    [SerializeField] private Rigidbody2D _rb = default;
    [SerializeField] private List<BaseWeaponComponent> _weapons = default;
    
    [ShowInInspector]
    private BaseWeaponComponent _currentWeapon;
    private int _currentWeaponIndex;

    [ShowInInspector]
    private TankModel _tankModel;
    
    private float _velocity;
    private float _rotation;

    public float Health => _tankModel.Health;
    public float Armor => _tankModel.Armor;

    public void Init(TankModel tankModel)
    {
        _tankModel = tankModel;
        _currentWeapon = _weapons.FirstOrDefault();
        _currentWeaponIndex = 0;
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

        if (_currentWeaponIndex == _weapons.Count - 1)
            _currentWeaponIndex = 0;
        else
            _currentWeaponIndex++;
        
        ChangeWeapon();
    }

    public void PrevWeaponHandler()
    {
        Debug.Log("prev weapon");
        
        if (_currentWeaponIndex == 0)
            _currentWeaponIndex = _weapons.Count - 1;
        else
            _currentWeaponIndex--;
        
        ChangeWeapon();
    }

    private void ChangeWeapon()
    {
        _currentWeapon.gameObject.SetActive(false);

        _currentWeapon = _weapons[_currentWeaponIndex];
        _currentWeapon.gameObject.SetActive(true);
    }
    
    private void FixedUpdate()
    {
        _rb.velocity = transform.up *  _velocity * _tankModel.MoveSpeed;
        transform.Rotate( -Vector3.forward ,_tankModel.RotateSpeed * _rotation);
    }
}
