using System;
using System.Diagnostics;
using foRCreative.App.MakeAFps.Project.Scripts.Inputs;
using foRCreative.App.MakeAFps.Project.Scripts.Weapons;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using Debug = UnityEngine.Debug;

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
        
        private void Start()
        {
            
        }

        // Update is called once per frame
        private void Update()
        {
            if (inputManager.IsWeaponSwitchDown)
            {
                Debug.Log("Switch Down");
            }
            usingWeapon.WeaponUseUpdate(inputManager);
        }

        private void SwitchingWeapons()
        {
            
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
