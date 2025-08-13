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
        
        //  Lookの入力用
        private Vector2 _lookInput;
        
        //  Fireの入力用
        private bool _isFire; 
        
        //  FireDownの入力用
        private bool _isFireDown;
        //  Fireの前フレームの入力バッファー
        private bool _isFireBefore;
        
        /// <summary>
        /// 読み取り専用 Moveの入力を返す
        /// </summary>
        public Vector2 MoveInput => _moveInput;
        
        /// <summary>
        /// 読み取り専用 Lookの入力を返す
        /// </summary>
        public Vector2 LookInput => _lookInput;
        
        /// <summary>
        /// 読み取り専用 Fireが押されているときにTrueを返す
        /// </summary>
        public bool IsFire => _isFire;
        
        /// <summary>
        /// 読み取り専用 Fireが押された瞬間にTrueを返す
        /// </summary>
        public bool IsFireDown => _isFireDown;

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            _isFireBefore = false;
        }

        private void Update()
        {
            //  Fireの入力がFalseからTrueに変化したときのみIsFireDownをTrueにする
            if (_isFireBefore == false && _isFire == true)
            {
                _isFireDown  = true;
            }
            else
            {
                _isFireDown  = false;
            }
        }

        private void LateUpdate()
        {
            //  前フレームの情報を維持
            _isFireBefore = _isFire;
        }

        private void OnEnable()
        {
            if(_playerInput == null) return;
            //  デリケート登録
            //  Move
            _playerInput.actions["Move"].performed += OnMove;
            _playerInput.actions["Move"].canceled += OnMove;
            //  Look
            _playerInput.actions["Look"].performed += OnLook;
            _playerInput.actions["Look"].canceled += OnLook;
            //  Fire
            _playerInput.actions["Fire"].performed += OnFire;
            _playerInput.actions["Fire"].canceled += OnFire;
            
            //  カーソルロック
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void OnDisable()
        {
            if (_playerInput == null) return;
            //  デリケート登録解除
            //  Move
            _playerInput.actions["Move"].performed -= OnMove;
            _playerInput.actions["Move"].canceled -= OnMove;
            //  Look
            _playerInput.actions["Look"].performed -= OnLook;
            _playerInput.actions["Look"].canceled -= OnLook;
            //  Fire
            _playerInput.actions["Fire"].performed -= OnFire;
            _playerInput.actions["Fire"].canceled -= OnFire;
            
            //  カーソルロック解除
            Cursor.lockState = CursorLockMode.None;
        }
        
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
        
        private void OnLook(InputAction.CallbackContext obj)
        {
            switch (obj.phase)
            {
                case InputActionPhase.Performed:
                    _lookInput = obj.ReadValue<Vector2>();
                    break;
                case InputActionPhase.Canceled:
                    _lookInput = Vector2.zero;
                    break;
            }
        }

        private void OnFire(InputAction.CallbackContext obj)
        {
            switch (obj.phase)
            {
                case InputActionPhase.Performed:
                    _isFire = true;
                    break;
                case InputActionPhase.Canceled:
                    _isFire = false;
                    break;
            }
        }
    }
}
