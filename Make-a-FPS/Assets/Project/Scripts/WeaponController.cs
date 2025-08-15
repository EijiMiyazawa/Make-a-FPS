using System;
using foRCreative.App.MakeAFps.Project.Scripts.Inputs;
using foRCreative.App.MakeAFps.Project.Scripts.Weapons;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace foRCreative.App.MakeAFps.Project.Scripts
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] MyInputManager inputManager;
        [SerializeField] private Weapon currentWeapon;

        [SerializeField] private RigBuilder rigBuilder;
        
        [SerializeField] private Transform leftArmTarget;
        [SerializeField] private Transform rightArmTarget;
        [SerializeField] private TwoBoneIKConstraint  leftArmIKConstraint;
        [SerializeField] private TwoBoneIKConstraint rightArmIKConstraint;
        
        private void Start()
        {
            //  Constraintのデータを取得
            TwoBoneIKConstraintData leftArmData = leftArmIKConstraint.data;
            TwoBoneIKConstraintData rightArmData = rightArmIKConstraint.data;
            
            //  ターゲットを変更
            leftArmData.target = leftArmTarget;
            rightArmData.target = rightArmTarget;
            
            //  変更したターゲットを反映
            leftArmIKConstraint.data = leftArmData;
            rightArmIKConstraint.data = rightArmData;
            
            //  rigBuilderのリビルド
            rigBuilder.Build();
        }

        // Update is called once per frame
        void Update()
        {
            currentWeapon.WeaponUseUpdate(inputManager);
        }
    }
}
