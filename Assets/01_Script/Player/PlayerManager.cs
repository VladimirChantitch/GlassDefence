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
using UnityEngine.PlayerLoop;

namespace player
{
    public class PlayerManager : MonoBehaviour
    {
        [Header("Interactions")]
        [SerializeField] InputManager inputManager;
        [SerializeField] PlayerLocomotion locomotion;
        [SerializeField] MouseBehavior mouseBehavior;
        [SerializeField] PlayerStats playerStats;

        [Header("Rotation")]
        [SerializeField] PlayerHeadRotation headRotation;
        [SerializeField] PlayerBodyRotation bodyRotation;
        [SerializeField] bool isFacingLeft = false;
        [SerializeField] bool isKnockedBack = false;
        [SerializeField] Camera camera;

        [Header("Attack")]
        [SerializeField] PlayerAttack attack;
        [SerializeField] PlayerAttackSlot dashSlot;
        [SerializeField] float furyReward = 5;

        public event Action onEscapePressed;

        private void Awake()
        {
            if (locomotion == null) locomotion = GetComponent<PlayerLocomotion>();
            if (inputManager == null) inputManager = GetComponent<InputManager>();
            if (mouseBehavior == null) mouseBehavior = FindObjectOfType<MouseBehavior>();
            if (headRotation == null) headRotation = GetComponentInChildren<PlayerHeadRotation>();
            if (bodyRotation == null) bodyRotation = GetComponentInChildren<PlayerBodyRotation>();
            if (attack == null) attack = GetComponentInChildren<PlayerAttack>();
            if (playerStats == null) playerStats = GetComponent<PlayerStats>();
        }

        private void Start()
        {
            SubscriteToInputs();
            SubscribeToMouseBehavior();
            SubscribeToBodyRotation();
            SubscribeToAttack();
            SubscribeToLocomotion();
            SubscribeToPlayerStats();
            dashSlot = ResourcesManager.Instance.GetAttack(AttackType.Dash);
        }

        private void SubscribeToPlayerStats()
        {
            if (playerStats != null)
            {
                playerStats.onPlayerDied += () => HandlePlayerDeath();
                playerStats.onFuryDecayFinished += () => HandleFuryDecayFinished();
            }
        }

        private void SubscribeToAttack()
        {
            attack.onAttackReset += () => HandleStartAttack();
            attack.onSpecialAttackStarted += (decayRate) => HandleSpecialAttackStarted(decayRate);
            attack.onVulnerabilityDestroyed += () => HandleVulnerabilityDestroyed();
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
        [Header("dash")]
        [SerializeField] bool isDashing;
        private void HandleDash()
        {
            if (!isDashing)
            {
                if (playerStats.TryConsumeFury(dashSlot.FuryCost))
                {
                    locomotion.StartDash();
                }
            }
        }

        private void HandleDashStarted()
        {
            attack.StartDashAttack();
            isDashing = true;
        }

        private void HandleDashStopped()
        {
            attack.StopDashAttack();
            isDashing = false;
        }
        #endregion

        private void HandleLocomotion(Vector2 motion)
        {
            locomotion.Move(motion);
        }

        #region HANDLE ATTACK
        private void HandleStartAttack()
        {
            attack.StartAttack(mouseBehavior.transform);
        }

        private void HandleStopAtatck()
        {
            attack.StopAttack();
        }

        private void HandleSpecialAttackStarted(float decayRate)
        {
            playerStats.StartDecayFury(decayRate);
            locomotion.StartKnocBack();
            isKnockedBack = true;
        }

        private void HandleFuryDecayFinished()
        {
            attack.StopSpecialAttack();
            locomotion.StopKnocBack();
            isKnockedBack = false;
        }
        #endregion

        private void HandleSlotSelection(AttackType attackType)
        {
            if (attackType == AttackType.Special)
            {
                if (playerStats.IsFuryMaxed())
                {
                    attack.ChangeAttackType(attackType);
                }
                else
                {
                    return;
                }
            }
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

        private void HandlePlayerDeath()
        {
            Debug.Log("player Died");
        }

        private void HandleVulnerabilityDestroyed()
        {
            playerStats.GenerateFury(furyReward);
        }

        private void FixedUpdate()
        {
            if (isKnockedBack)
            {
                locomotion.UpdateKnocBack(bodyRotation.transform.forward);
            }
        }
    }
}

