
namespace foRCreative.App.MakeAFps.Project.Scripts.Interfaces
{
    public interface IState
    {
        /// <summary>
        /// この状態に遷移したときに実行
        /// </summary>
        public void Enter();
        
        /// <summary>
        /// フレーム単位ロジック、別の状態の遷移条件を含む
        /// </summary>
        public void Update();
        
        /// <summary>
        /// この状態を抜けるときに実行
        /// </summary>
        public void Exit();
    }
}
