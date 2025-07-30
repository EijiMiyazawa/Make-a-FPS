using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace foRCreative.App.MakeAFps.Project.Scripts.Inputs
{
    [RequireComponent(typeof(PlayerInput))]
    public class MyInputManager : MonoBehaviour
    {
        private PlayerInput _playerInput;
        
        //  Moveの入力用
        private Vector2 _moveInput;
        
        /// <summary>
        /// 読み取り専用 Moveの入力を返す
        /// </summary>
        public Vector2 MoveInput => _moveInput;
        
        private void OnMove(InputAction.CallbackContext obj)
        {
            switch (obj.phase)
            {
                case InputActionPhase.Performed:
                    _moveInput = obj.ReadValue<Vector2>();
                    break;
                case InputActionPhase.Canceled:
                    _moveInput = Vector2.zero;
                    break;
            }
        }

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
        }

        private void OnEnable()
        {
            if(_playerInput == null) return;
            //  デリケート登録
            _playerInput.actions["Move"].performed += OnMove;
            _playerInput.actions["Move"].canceled += OnMove;
        }

        private void OnDisable()
        {
            if (_playerInput == null) return;
            //  デリケート登録解除
            _playerInput.actions["Move"].performed -= OnMove;
            _playerInput.actions["Move"].canceled -= OnMove;
        }
    }
}
