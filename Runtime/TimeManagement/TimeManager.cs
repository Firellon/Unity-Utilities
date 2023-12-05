using System;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Utilities.TimeManagement
{
    public class TimeManager : ITickable, IInitializable, IDisposable, ITimeManager
    {
        public bool Slowdown;
        public float slowdownFactor = 0.05f;
        private bool slowDownInProgress;
        public float slowdownLength = 2f;
        public float GameSpeed = 1;

        public UnityEvent OnTick { get; } = new();

        public void Initialize()
        {
            Time.timeScale = GameSpeed;
        }

        public void DoSlowdown()
        {
            if (slowDownInProgress)
                return;

            slowDownInProgress = true;
            Time.timeScale = slowdownFactor;
        }

        public void PauseGame()
        {
            slowDownInProgress = false;
            Slowdown = false;
            Time.timeScale = 0;
        }

        public void RunGame()
        {
            Time.timeScale = GameSpeed;
        }

        private void Reset()
        {
            RunGame();
        }

        public void Tick()
        {
            OnTick.Invoke();

            if (Slowdown)
            {
                DoSlowdown();
                Slowdown = false;
            }

            if (slowDownInProgress)
            {
                Time.timeScale += GameSpeed / slowdownLength * Time.unscaledDeltaTime;
                Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, GameSpeed);
                if (Time.timeScale >= GameSpeed)
                    slowDownInProgress = false;
            }
        }

        public void Dispose()
        {
            Reset();
        }
    }

    public interface ITimeManager
    {
        UnityEvent OnTick { get; } 
        
        void RunGame();
        void PauseGame();
        void DoSlowdown();
    }
}