/*   
    GameJam template for unity project
    Copyright (C) 2023  VladimirChantitch-MarmotteQuantique

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
 */

using inputs;
using savesystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace player
{
    public class PlayerManager : MonoBehaviour
    {
        [Header("Interactions")]
        [SerializeField] InputManager inputManager;
        [SerializeField] PlayerLocomotion locomotion;
        [SerializeField] MouseBehavior mouseBehavior;

        [Header("Rotation")]
        [SerializeField] PlayerHeadRotation headRotation;
        [SerializeField] PlayerBodyRotation bodyRotation;
        [SerializeField] bool isFacingLeft = false;
        [SerializeField] Camera camera;

        [Header("Attack")]
        [SerializeField] PlayerAttack attack;

        public event Action onEscapePressed;

        private void Awake()
        {
            if (locomotion == null) locomotion = GetComponent<PlayerLocomotion>();
            if (inputManager == null) inputManager = GetComponent<InputManager>();
            if (mouseBehavior == null) mouseBehavior = FindObjectOfType<MouseBehavior>();
            if (headRotation == null) headRotation = GetComponentInChildren<PlayerHeadRotation>();
            if (bodyRotation == null) bodyRotation = GetComponentInChildren<PlayerBodyRotation>();
            if (attack == null) attack = GetComponentInChildren<PlayerAttack>();
        }

        private void Start()
        {
            SubscriteToInputs();
            SubscribeToMouseBehavior();
            SubscribeToBodyRotation();
            SubscribeToAttack();
            SubscribeToLocomotion();
        }

        private void SubscribeToAttack()
        {
            attack.onAttackReset += () => HandleStartAttack();
        }

        private void SubscribeToBodyRotation()
        {
            bodyRotation.onIsFacingLeft += () => isFacingLeft = true;
            bodyRotation.onIsFacingRight += () => isFacingLeft = false;
        }

        private void SubscribeToMouseBehavior()
        {
            mouseBehavior.CrossAirPositionChanged += position => HandleCrossAirPosition(position);
            mouseBehavior.Init(camera);
        }

        private void SubscriteToInputs()
        {
            if (inputManager != null)
            {
                inputManager.onInteractPressed += () => OnInteract();
                inputManager.onDashPressed += () => HandleDash();
                inputManager.onEscapePressed += () => onEscapePressed?.Invoke();
                inputManager.onMovePressed += (motion) => HandleLocomotion(motion);
                inputManager.onPrimaryPressed += () => HandleStartAttack();
                inputManager.onPrimaryRealesed += () => HandleStopAtatck();
                inputManager.onSlotOneSelected += () => HandleSlotSelection(AttackType.Fire);
                inputManager.onSlotTwoSelected += () => HandleSlotSelection(AttackType.IcePlasma);
                inputManager.onSlotThreeSelected += () => HandleSlotSelection(AttackType.Lightning);
                inputManager.onSpecialPressed += () => HandleSlotSelection(AttackType.Special);
                inputManager.onMousePositionChanged += (position) => HandleNewMousePosition(position);
            }
            else
            {
                Debug.Log($"<color=red> NO INPUT MANAGER IN PLAYER MANAGER</color>");
            }
        }

        private void SubscribeToLocomotion()
        {
            if(locomotion != null)
            {
                locomotion.onDashStarted += () => HandleDashStarted();
                locomotion.onDashStopped += () => HandleDashStopped();
            }
        }

        private void OnInteract()
        {
            Debug.Log("Interact");
        }

        #region HANDLE DASH
        private void HandleDash()
        {
            locomotion.StartDash();
        }

        private void HandleDashStarted()
        {
            attack.StartDashAttack();
        }

        private void HandleDashStopped()
        {
            attack.StopDashAttack();
        }
        #endregion

        private void HandleLocomotion(Vector2 motion)
        {
            locomotion.Move(motion);
        }

        private void HandleStartAttack()
        {
            attack.StartAttack(mouseBehavior.transform);
        }

        private void HandleStopAtatck()
        {
            attack.StopAttack();
        }

        private void HandleSlotSelection(AttackType attackType)
        {
            attack.ChangeAttackType(attackType);
        }

        private void HandleNewMousePosition(Vector2 position)
        {
            float distance = Vector3.Distance(camera.transform.position, transform.position);
            mouseBehavior.UpdateRealMousePosition(position, distance);
        }

        private void HandleCrossAirPosition(Transform transform)
        {
            bodyRotation.RotateBody(transform.position, isFacingLeft);
            headRotation.RotateHeadTowardCrosAir(transform.position);
        }
    }
}

