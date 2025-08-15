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
        
        //  現在のReloadの入力
        private bool _isReload;
        //  前フレームのReloadの入力
        private bool _isReloadBefore;
        //  ReloadDownの入力用
        private bool _isReloadDown;
        
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
        
        /// <summary>
        /// 読み取り専用 Reloadボタン押下された瞬間にTrueを返す
        /// </summary>
        public bool IsReloadDown => _isReloadDown;

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            _isFireBefore = false;
            _isReloadBefore = false;
        }

        private void Update()
        {
            //  前フレームからTrueに変化した場合ボタンを押下した瞬間を検出
            _isFireDown = (_isFireBefore == false && _isFire == true);
            _isReloadDown = (_isReloadBefore == false && _isReload == true);
        }

        private void LateUpdate()
        {
            //  前フレームの情報を維持
            _isFireBefore = _isFire;
            _isReloadBefore = _isReload;
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
            //  Reload
            _playerInput.actions["Reload"].performed += OnReload;
            _playerInput.actions["Reload"].canceled += OnReload;
            
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
            //  Reload
            _playerInput.actions["Reload"].performed -= OnReload;
            _playerInput.actions["Reload"].canceled -= OnReload;
            
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
        
        private void OnReload(InputAction.CallbackContext obj)
        {
            switch (obj.phase)
            {
                case InputActionPhase.Performed:
                    _isReload = true;
                    break;
                case InputActionPhase.Canceled:
                    _isReload = false;
                    break;
            }
        }
    }
}
