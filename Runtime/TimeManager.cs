using System;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Utilities
{
    // TODO: Make it readonly struct
    public struct TimeManagerPauseChangedSignal
    {
        public bool IsPaused { get; set; }
    }

    public class TimeManager : ITickable, IInitializable, IDisposable
    {
        public bool GameIsPaused;
        public bool Slowdown;
        public float slowdownFactor = 0.05f;
        private bool slowDownInProgress;
        public float slowdownLength = 2f;
        public float GameSpeed = 1;

        public UnityEvent OnTick = new UnityEvent();

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
            GameIsPaused = true;
            slowDownInProgress = false;
            Slowdown = false;
            Time.timeScale = 0;

            // SignalsHub.DispatchAsync(new TimeManagerPauseChangedSignal { IsPaused = true });
        }

        public void RunGame()
        {
            GameIsPaused = false;
            Time.timeScale = GameSpeed;

            // SignalsHub.DispatchAsync(new TimeManagerPauseChangedSignal { IsPaused = false });
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
}