using System;
using UnityEngine;

namespace CodeBase.Character
{
    [RequireComponent(typeof(CharacterMovement))]
    public class Character : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private CharacterMovement _characterMovement;

        private void Awake()
        {
            if (_characterMovement == null) _characterMovement = GetComponent<CharacterMovement>();
        }

        private void Start()
        {
        }

        private void Update()
        {
            _characterMovement.Movement();
            _characterMovement.Jump();
            _characterMovement.Gravity();
        }
    }
}