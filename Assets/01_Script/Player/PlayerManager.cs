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
using savesystem.dto;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace player
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] InputManager inputManager;
        [SerializeField] PlayerLocomotion locomotion;

        [SerializeField] string Name;

        public event Action onEscapePressed;

        private void Awake()
        {
            if (locomotion == null) locomotion = GetComponent<PlayerLocomotion>();
            if (inputManager == null) inputManager = GetComponent<InputManager>();
        }

        private void Start()
        {
            SubscriteToInputs();
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
                inputManager.onSlotOneSelected += () => HandleSlotSelection(0);
                inputManager.onSlotTwoSelected += () => HandleSlotSelection(1);
                inputManager.onSlotThreeSelected += () => HandleSlotSelection(2);
                inputManager.onSpecialPressed += () => HandleSpecial();
            }
            else
            {
                Debug.Log($"<color=red> NO INPUT MANAGER IN PLAYER MANAGER</color>");
            }
        }

        private void OnInteract()
        {
            Debug.Log("Interact");
        }

        private void HandleDash()
        {
            Debug.Log("Dash");
        }

        private void HandleLocomotion(Vector2 motion)
        {
            Debug.Log("Motion ::: " + motion);
            locomotion.Move(motion);
        }

        private void HandleStartAttack()
        {
            Debug.Log("Start Attack");
        }

        private void HandleStopAtatck()
        {
            Debug.Log("Stop Attack");
        }

        private void HandleSlotSelection(int v)
        {
            Debug.Log($"The current slot is {v + 1}");
        }

        private void HandleSpecial()
        {
            Debug.Log("Special");
        }
    }
}

