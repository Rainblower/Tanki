using System;
using Core;
using UnityEngine;

namespace Controllers
{
    public class InputController: BaseController
    {
        public event Action<float> Move;
        public event Action<float> Rotate;
        public event Action Fire;
        public event Action NextWeapon;
        public event Action PrevWeapon;
        public event Action RestartGame;
        
        public void LocalUpdate()
        {
            Move?.Invoke(Input.GetAxis ("Vertical"));
            Rotate?.Invoke(Input.GetAxis ("Horizontal"));

            if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Space)) Fire?.Invoke();
            if (Input.GetKeyDown(KeyCode.E)) NextWeapon?.Invoke();
            if (Input.GetKeyDown(KeyCode.Q)) PrevWeapon?.Invoke();
            if (Input.GetKeyDown(KeyCode.R)) RestartGame?.Invoke();
        }
    }
}