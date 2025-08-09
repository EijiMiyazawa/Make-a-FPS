using foRCreative.App.MakeAFps.Project.Scripts.Inputs;
using foRCreative.App.MakeAFps.Project.Scripts.Weapons;
using UnityEngine;

namespace foRCreative.App.MakeAFps.Project.Scripts
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] MyInputManager  inputManager;
        [SerializeField] private Weapon currentWeapon;
        
        // Update is called once per frame
        void Update()
        {
            currentWeapon.Attack(inputManager.IsFire);
        }
    }
}
