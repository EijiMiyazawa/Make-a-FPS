using foRCreative.App.MakeAFps.Project.Scripts.Inputs;
using foRCreative.App.MakeAFps.Project.Scripts.Weapons;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace foRCreative.App.MakeAFps.Project.Scripts
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] MyInputManager inputManager;

        [SerializeField] private RigBuilder rigBuilder;

        [SerializeField] private TwoBoneIKConstraint leftArmIKConstraint;
        [SerializeField] private TwoBoneIKConstraint rightArmIKConstraint;
        
        [Header("Weapons")]
        [SerializeField] private Weapon[] equippedWeapons;
        [SerializeField] private Weapon usingWeapon;

        private int _index;
        
        private void Start()
        {
            //  配列の最初にある武器を持つ
            _index = 0;
            usingWeapon =  equippedWeapons[_index];
            usingWeapon.gameObject.SetActive(true);
            IKTargeting();
        }

        // Update is called once per frame
        private void Update()
        {
            if (inputManager.IsWeaponSwitchDown)
            {
                SwitchingWeapons();
            }
            usingWeapon.WeaponUseUpdate(inputManager);
        }

        private void SwitchingWeapons()
        {
            //  現在使用しているWeaponを無効化
            usingWeapon.gameObject.SetActive(false);
            
            //  次のWeaponを選択
            _index++;
            if (_index >= equippedWeapons.Length)
            {
                _index = 0;
            }
            
            usingWeapon =  equippedWeapons[_index];
            
            //  選択したWeaponを有効化
            usingWeapon.gameObject.SetActive(true);
            IKTargeting();
        }

        private void IKTargeting()
        {
            //  Constraintのデータを取得
            TwoBoneIKConstraintData leftArmData = leftArmIKConstraint.data;
            TwoBoneIKConstraintData rightArmData = rightArmIKConstraint.data;
            
            //  ターゲットを変更
            leftArmData.target = usingWeapon.leftHandIKTarget;
            rightArmData.target = usingWeapon.rightHandIKTarget;
            
            //  変更したターゲットを反映
            leftArmIKConstraint.data = leftArmData;
            rightArmIKConstraint.data = rightArmData;
            
            //  rigBuilderのリビルド
            rigBuilder.Build();
        }
    }
}
