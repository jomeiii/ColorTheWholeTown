﻿using System;
using UnityEngine;

namespace CodeBase.Manager
{
    public class PauseManager : MonoBehaviour
    {
        public static event Action PauseEvent;
        public static event Action ContinueEvent;
        public static bool IsPause;

        public void OnEnable()
        {
            PauseEvent += Pause;
            ContinueEvent += Continue;
        }

        public void OnDisable()
        {
            PauseEvent -= Pause;
            ContinueEvent -= Continue;
        }

        public static void OnPauseEvent() => PauseEvent?.Invoke();

        public static void OnContinueEvent() => ContinueEvent?.Invoke();

        public void Pause()
        {
            Time.timeScale = 0f;
            IsPause = true;

            Debug.Log(
                $"<color=green>[{nameof(PauseManager)}]</color> <color=yellow>{nameof(Pause)}()</color>: Game on pause.");
        }

        public void Continue()
        {
            Time.timeScale = 1f;
            IsPause = false;

            Debug.Log(
                $"<color=green>[{nameof(PauseManager)}]</color> <color=yellow>{nameof(Continue)}()</color>:Game continue.");
        }
    }
}