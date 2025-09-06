using System;
using foRCreative.App.MakeAFps.Project.Scripts.Interfaces;

namespace foRCreative.App.MakeAFps.Project.Scripts
{
    /// <summary>
    /// ステートマシーン
    /// </summary>
    [Serializable]
    public class StateMachine
    {
        /// <summary>
        /// 現在のステート
        /// </summary>
        public IState CurrentState { get; private set; }
        
        /// <summary>
        /// ステートマシーンの初期化
        /// </summary>
        /// <param name="startingState">最初に遷移するステート</param>
        public virtual void Initialize(IState startingState)
        {
            CurrentState = startingState;
            startingState.Enter();
        }
        
        /// <summary>
        /// ステート遷移
        /// </summary>
        /// <param name="nextState">次に遷移するステート</param>
        public virtual void TransitionTo(IState nextState)
        {
            CurrentState.Exit();
            CurrentState = nextState;
            nextState.Enter();
        }
        
        /// <summary>
        /// 現在のステートの処理を実行
        /// </summary>
        public virtual void Execute()
        {
            if (CurrentState != null)
            {
                CurrentState.Update();
            }
        }
    }
}
