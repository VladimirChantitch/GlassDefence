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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace inputs
{
    public class InputManager : MonoBehaviour
    {
        Inputs inputs = null;

        /// <summary>
        /// An event triggered when the interact input is pressed
        /// NB : You can also use a unity event if you want to 
        ///     add subscribers directly in the scene, but keep in
        ///     mind that unity event are 100 times slower.
        /// </summary>
        public event Action onInteractPressed;
        public event Action onDashPressed;

        public event Action onSlotOneSelected;
        public event Action onSlotTwoSelected;
        public event Action onSlotThreeSelected;
        public event Action onSpecialPressed;
        public event Action onPrimaryPressed;
        public event Action onPrimaryRealesed;

        public event Action<Vector2> onMovePressed;
        Vector2 motion;

        public event Action<Vector2> onMousePositionChanged;

        public event Action onEscapePressed;

        private void Awake()
        {
            inputs = new Inputs();
        }

        private void OnEnable()
        {
            inputs.Enable();

            BindInputs();
        }

        private void BindInputs()
        {
            inputs.Interaction.Interact.performed += i => onInteractPressed?.Invoke();
            inputs.Locomotion.Dash.performed += i => onDashPressed?.Invoke();
            inputs.Locomotion.Move.performed += i => motion = i.ReadValue<Vector2>();

            inputs.Combat.Slot_1.performed += i => onSlotOneSelected?.Invoke();
            inputs.Combat.Slot_2.performed += i => onSlotTwoSelected?.Invoke();
            inputs.Combat.Slot_3.performed += i => onSlotThreeSelected?.Invoke();
            inputs.Combat.Special.performed += i => onSpecialPressed?.Invoke();

            inputs.Combat.MainAttack.performed += i => onPrimaryPressed?.Invoke();
            inputs.Combat.MainAttack.canceled += i => onPrimaryRealesed?.Invoke();

            inputs.Combat.MousePosition.performed += i => onMousePositionChanged?.Invoke(i.ReadValue<Vector2>());

            inputs.UI.PauseMenu.performed += i => onEscapePressed?.Invoke();
        }

        private void FixedUpdate()
        {
            CheckMotion(motion);
        }

        public void CheckMotion(Vector2 motion)
        {
            //if (motion.x != 0 || motion.y != 0)
            //{
                onMovePressed?.Invoke(motion);
            //}
        }

        private void OnDisable()
        {
            inputs?.Disable();
        }
    }
}

