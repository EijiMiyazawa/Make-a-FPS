using foRCreative.App.MakeAFps.Project.Scripts.Inputs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace foRCreative.App.MakeAFps.Project.Scripts
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private MyInputManager inputManager;
        [SerializeField] private float moveSpeed = 2.0f;
        private Transform _playerTransform;
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //  Transformをキャッシュ
            _playerTransform = transform;
        }

        // Update is called once per frame
        void Update()
        {
            //  入力から移動方向を取得
            Vector3 moveDirection = new Vector3(inputManager.MoveInput.x, 0f, inputManager.MoveInput.y);
            
            //  プレイヤー移動
            _playerTransform.position +=  Time.deltaTime * moveSpeed  * moveDirection;
        }
    }
}
