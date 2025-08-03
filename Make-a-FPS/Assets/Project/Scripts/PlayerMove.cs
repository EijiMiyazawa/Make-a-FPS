using foRCreative.App.MakeAFps.Project.Scripts.Inputs;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

namespace foRCreative.App.MakeAFps.Project.Scripts
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private MyInputManager inputManager;
        
        [Header("移動のパラメータ")]
        [SerializeField] private float moveSpeed = 2.0f;
        
        [Header("カメラの回転パラメータ")]
        [SerializeField] private Transform eyeTransform;
        [SerializeField] private float rotateSpeed = 2.0f;
        [Header("クランプ値設定パラメータ")]
        [SerializeField] InputAxis inputAxisYaw;
        [SerializeField] InputAxis inputAxisPitch;
        
        //  PlayerのTransformのキャッシュ
        private Transform _playerTransform;
        
        //  カメラの回転量（x yaw, y pitch）
        private Vector2 _lookAngle;
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //  Transformをキャッシュ
            _playerTransform = transform;
            //  回転値をリセット
            _lookAngle = Vector2.zero;
            inputAxisYaw.Reset();
            inputAxisPitch.Reset();
        }

        // Update is called once per frame
        void Update()
        {
            //  入力からカメラの回転量を決定
            _lookAngle.x += inputManager.LookInput.x * rotateSpeed * Time.deltaTime;
            _lookAngle.y -= inputManager.LookInput.y * rotateSpeed * Time.deltaTime;
            
            //  クランプ後の値に上書き
            _lookAngle.x = inputAxisYaw.ClampValue(_lookAngle.x);
            //  体を横回転
            Quaternion yawRotation = Quaternion.AngleAxis(_lookAngle.x, Vector3.up);
            _playerTransform.rotation = yawRotation;
            
            //  クランプ後の値に上書き
            _lookAngle.y = inputAxisPitch.ClampValue(_lookAngle.y);
            //  eyeを縦回転
            Quaternion pitchRotation = Quaternion.AngleAxis(_lookAngle.y, Vector3.right);
            eyeTransform.localRotation = pitchRotation;
            
            //  入力から移動方向を取得
            Vector3 moveDirection = new Vector3(inputManager.MoveInput.x, 0f, inputManager.MoveInput.y);
            
            //  プレイヤー移動(横回転を踏まえて)
            _playerTransform.position +=  Time.deltaTime * moveSpeed *　(yawRotation * moveDirection);
        }
    }
}
