using UnityEngine;

namespace CodeBase.Manager
{
    public class CursorManager : MonoBehaviour
    {
        private bool _isCursorEnabled = true;

        private void OnEnable()
        {
            PauseManager.PauseEvent += CursorEnable;
            PauseManager.ContinueEvent += CursorOff;
        }

        private void OnDisable()
        {
            PauseManager.PauseEvent -= CursorEnable;
            PauseManager.ContinueEvent -= CursorOff;
        }

        private void Start()
        {
            CursorOff();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                ToggleCursor();
            }
        }

        public void CursorOff()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            _isCursorEnabled = false;
        }

        public void CursorEnable()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            _isCursorEnabled = true;
        }

        private void ToggleCursor()
        {
            if (_isCursorEnabled)
                CursorOff();
            else
                CursorEnable();
        }
    }
}