using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace foRCreative.App.MakeAFps.Project.Scripts.Inputs
{
    [RequireComponent(typeof(PlayerInput))]
    public class MyInputManager : MonoBehaviour
    {
        private PlayerInput _playerInput;
        
        //  Fireの前フレームの入力バッファー
        private bool _isFireBefore;
        
        //  現在のReloadの入力--------
        private bool _isReload;
        //  前フレームのReloadの入力
        private bool _isReloadBefore;

        //  現在のWeaponSwitchの入力-------
        private bool _isWeaponSwitch;
        //  前フレームのSwitchWeaponの入力
        private bool _isWeaponSwitchBefore;
        
        /// <summary>
        /// 読み取り専用 Moveの入力を返す
        /// </summary>
        public Vector2 MoveInput { get; private set; }

        /// <summary>
        /// 読み取り専用 Lookの入力を返す
        /// </summary>
        public Vector2 LookInput { get; private set; }

        /// <summary>
        /// 読み取り専用 Fireが押されているときにTrueを返す
        /// </summary>
        public bool IsFire { get; private set; }

        /// <summary>
        /// 読み取り専用 Fireが押された瞬間にTrueを返す
        /// </summary>
        public bool IsFireDown { get; private set; }

        /// <summary>
        /// 読み取り専用 Reloadボタン押下された瞬間にTrueを返す
        /// </summary>
        public bool IsReloadDown { get; private set; }
        
        public bool IsWeaponSwitchDown { get; private set; }

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            _isFireBefore = false;
            _isReloadBefore = false;
            _isWeaponSwitchBefore = false;
        }

        private void Update()
        {
            //  前フレームからTrueに変化した場合ボタンを押下した瞬間を検出
            IsFireDown = (_isFireBefore == false && IsFire == true);
            IsReloadDown = (_isReloadBefore == false && _isReload == true);
            IsWeaponSwitchDown = (_isWeaponSwitchBefore == false && _isWeaponSwitch == true);
        }

        private void LateUpdate()
        {
            //  前フレームの情報を維持
            _isFireBefore = IsFire;
            _isReloadBefore = _isReload;
            _isWeaponSwitchBefore = _isWeaponSwitch;
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
            //  WeaponSwitch
            _playerInput.actions["WeaponSwitch"].performed += OnWeaponSwitch;
            _playerInput.actions["WeaponSwitch"].canceled += OnWeaponSwitch;
            
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
            //  WeaponSwitch
            _playerInput.actions["WeaponSwitch"].performed -= OnWeaponSwitch;
            _playerInput.actions["WeaponSwitch"].canceled -= OnWeaponSwitch;
            
            //  カーソルロック解除
            Cursor.lockState = CursorLockMode.None;
        }
        
        private void OnMove(InputAction.CallbackContext obj)
        {
            switch (obj.phase)
            {
                case InputActionPhase.Performed:
                    MoveInput = obj.ReadValue<Vector2>();
                    break;
                case InputActionPhase.Canceled:
                    MoveInput = Vector2.zero;
                    break;
            }
        }
        
        private void OnLook(InputAction.CallbackContext obj)
        {
            switch (obj.phase)
            {
                case InputActionPhase.Performed:
                    LookInput = obj.ReadValue<Vector2>();
                    break;
                case InputActionPhase.Canceled:
                    LookInput = Vector2.zero;
                    break;
            }
        }

        private void OnFire(InputAction.CallbackContext obj)
        {
            switch (obj.phase)
            {
                case InputActionPhase.Performed:
                    IsFire = true;
                    break;
                case InputActionPhase.Canceled:
                    IsFire = false;
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

        private void OnWeaponSwitch(InputAction.CallbackContext obj)
        {
            _isWeaponSwitch = (obj.phase == InputActionPhase.Performed);
        }
    }
}
