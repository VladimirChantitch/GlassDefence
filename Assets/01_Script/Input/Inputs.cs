//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/01_Script/Input/Inputs.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Inputs : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Inputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Inputs"",
    ""maps"": [
        {
            ""name"": ""Interaction"",
            ""id"": ""b02a652c-a92f-4ea9-beec-82d834d65e26"",
            ""actions"": [
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""f9312cdc-b746-415c-8558-bc4532246503"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b3edf147-2f03-46df-9848-031d447afe20"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Locomotion"",
            ""id"": ""91c3739d-0284-4775-bdc4-37c5720a59bf"",
            ""actions"": [
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""f6e5bbab-109d-489e-9085-fb667e2abeab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3037abb5-501b-4108-a3a9-c392779a7d26"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""99212ddc-08ae-45ea-81c1-f2bfa3d53af4"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""3e5f2ec0-4658-466d-af4f-c5b240c9961a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8cdaa89d-c8bf-4166-9a93-c059e8b40480"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""656b50a1-a8aa-4004-aaa8-db4d01318364"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""814952b2-379f-4849-a40e-cb71635e4489"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2762e3fb-1a4a-4527-918f-e3f51372e622"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""e63be6bd-5281-404b-9896-ddebe4d1b998"",
            ""actions"": [
                {
                    ""name"": ""PauseMenu"",
                    ""type"": ""Button"",
                    ""id"": ""56c72682-e85e-4f2c-ae73-395fbfd512b6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1044dc37-4c94-48be-9dcc-c4b96a72f458"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Combat"",
            ""id"": ""414cd61f-5a57-4444-b019-c54fd472a279"",
            ""actions"": [
                {
                    ""name"": ""MainAttack"",
                    ""type"": ""Button"",
                    ""id"": ""2892d555-f9ae-46cd-a32a-a19b7110423e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Slot_1"",
                    ""type"": ""Button"",
                    ""id"": ""442f4954-8e6c-419f-88f5-54e879f39f47"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Slot_2"",
                    ""type"": ""Button"",
                    ""id"": ""addddba0-b077-4133-af9f-8879e82a88d2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Slot_3"",
                    ""type"": ""Button"",
                    ""id"": ""568e829b-8436-49a9-9887-d59c93e6df37"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Special"",
                    ""type"": ""Button"",
                    ""id"": ""4ed295da-fdab-48ba-b427-e8bf1ca8979a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""30cbdb4c-00ce-491e-9011-b66d0fa77634"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MainAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b8e4535f-8de7-4ed4-a3ce-5257ddea216b"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Slot_1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0bfd4bf5-e853-464a-aa6a-1e41de346858"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Slot_2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c233e4fb-5a41-4e68-9a36-46f08a1423d5"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Slot_3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e0fdb9a4-fdab-4536-9ce6-fd32c286a0cd"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Special"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Interaction
        m_Interaction = asset.FindActionMap("Interaction", throwIfNotFound: true);
        m_Interaction_Interact = m_Interaction.FindAction("Interact", throwIfNotFound: true);
        // Locomotion
        m_Locomotion = asset.FindActionMap("Locomotion", throwIfNotFound: true);
        m_Locomotion_Dash = m_Locomotion.FindAction("Dash", throwIfNotFound: true);
        m_Locomotion_Move = m_Locomotion.FindAction("Move", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_PauseMenu = m_UI.FindAction("PauseMenu", throwIfNotFound: true);
        // Combat
        m_Combat = asset.FindActionMap("Combat", throwIfNotFound: true);
        m_Combat_MainAttack = m_Combat.FindAction("MainAttack", throwIfNotFound: true);
        m_Combat_Slot_1 = m_Combat.FindAction("Slot_1", throwIfNotFound: true);
        m_Combat_Slot_2 = m_Combat.FindAction("Slot_2", throwIfNotFound: true);
        m_Combat_Slot_3 = m_Combat.FindAction("Slot_3", throwIfNotFound: true);
        m_Combat_Special = m_Combat.FindAction("Special", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Interaction
    private readonly InputActionMap m_Interaction;
    private IInteractionActions m_InteractionActionsCallbackInterface;
    private readonly InputAction m_Interaction_Interact;
    public struct InteractionActions
    {
        private @Inputs m_Wrapper;
        public InteractionActions(@Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Interact => m_Wrapper.m_Interaction_Interact;
        public InputActionMap Get() { return m_Wrapper.m_Interaction; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InteractionActions set) { return set.Get(); }
        public void SetCallbacks(IInteractionActions instance)
        {
            if (m_Wrapper.m_InteractionActionsCallbackInterface != null)
            {
                @Interact.started -= m_Wrapper.m_InteractionActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_InteractionActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_InteractionActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_InteractionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public InteractionActions @Interaction => new InteractionActions(this);

    // Locomotion
    private readonly InputActionMap m_Locomotion;
    private ILocomotionActions m_LocomotionActionsCallbackInterface;
    private readonly InputAction m_Locomotion_Dash;
    private readonly InputAction m_Locomotion_Move;
    public struct LocomotionActions
    {
        private @Inputs m_Wrapper;
        public LocomotionActions(@Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Dash => m_Wrapper.m_Locomotion_Dash;
        public InputAction @Move => m_Wrapper.m_Locomotion_Move;
        public InputActionMap Get() { return m_Wrapper.m_Locomotion; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(LocomotionActions set) { return set.Get(); }
        public void SetCallbacks(ILocomotionActions instance)
        {
            if (m_Wrapper.m_LocomotionActionsCallbackInterface != null)
            {
                @Dash.started -= m_Wrapper.m_LocomotionActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_LocomotionActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_LocomotionActionsCallbackInterface.OnDash;
                @Move.started -= m_Wrapper.m_LocomotionActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_LocomotionActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_LocomotionActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_LocomotionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public LocomotionActions @Locomotion => new LocomotionActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_PauseMenu;
    public struct UIActions
    {
        private @Inputs m_Wrapper;
        public UIActions(@Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @PauseMenu => m_Wrapper.m_UI_PauseMenu;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @PauseMenu.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPauseMenu;
                @PauseMenu.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPauseMenu;
                @PauseMenu.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPauseMenu;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PauseMenu.started += instance.OnPauseMenu;
                @PauseMenu.performed += instance.OnPauseMenu;
                @PauseMenu.canceled += instance.OnPauseMenu;
            }
        }
    }
    public UIActions @UI => new UIActions(this);

    // Combat
    private readonly InputActionMap m_Combat;
    private ICombatActions m_CombatActionsCallbackInterface;
    private readonly InputAction m_Combat_MainAttack;
    private readonly InputAction m_Combat_Slot_1;
    private readonly InputAction m_Combat_Slot_2;
    private readonly InputAction m_Combat_Slot_3;
    private readonly InputAction m_Combat_Special;
    public struct CombatActions
    {
        private @Inputs m_Wrapper;
        public CombatActions(@Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @MainAttack => m_Wrapper.m_Combat_MainAttack;
        public InputAction @Slot_1 => m_Wrapper.m_Combat_Slot_1;
        public InputAction @Slot_2 => m_Wrapper.m_Combat_Slot_2;
        public InputAction @Slot_3 => m_Wrapper.m_Combat_Slot_3;
        public InputAction @Special => m_Wrapper.m_Combat_Special;
        public InputActionMap Get() { return m_Wrapper.m_Combat; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CombatActions set) { return set.Get(); }
        public void SetCallbacks(ICombatActions instance)
        {
            if (m_Wrapper.m_CombatActionsCallbackInterface != null)
            {
                @MainAttack.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnMainAttack;
                @MainAttack.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnMainAttack;
                @MainAttack.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnMainAttack;
                @Slot_1.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnSlot_1;
                @Slot_1.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnSlot_1;
                @Slot_1.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnSlot_1;
                @Slot_2.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnSlot_2;
                @Slot_2.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnSlot_2;
                @Slot_2.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnSlot_2;
                @Slot_3.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnSlot_3;
                @Slot_3.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnSlot_3;
                @Slot_3.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnSlot_3;
                @Special.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnSpecial;
                @Special.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnSpecial;
                @Special.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnSpecial;
            }
            m_Wrapper.m_CombatActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MainAttack.started += instance.OnMainAttack;
                @MainAttack.performed += instance.OnMainAttack;
                @MainAttack.canceled += instance.OnMainAttack;
                @Slot_1.started += instance.OnSlot_1;
                @Slot_1.performed += instance.OnSlot_1;
                @Slot_1.canceled += instance.OnSlot_1;
                @Slot_2.started += instance.OnSlot_2;
                @Slot_2.performed += instance.OnSlot_2;
                @Slot_2.canceled += instance.OnSlot_2;
                @Slot_3.started += instance.OnSlot_3;
                @Slot_3.performed += instance.OnSlot_3;
                @Slot_3.canceled += instance.OnSlot_3;
                @Special.started += instance.OnSpecial;
                @Special.performed += instance.OnSpecial;
                @Special.canceled += instance.OnSpecial;
            }
        }
    }
    public CombatActions @Combat => new CombatActions(this);
    public interface IInteractionActions
    {
        void OnInteract(InputAction.CallbackContext context);
    }
    public interface ILocomotionActions
    {
        void OnDash(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnPauseMenu(InputAction.CallbackContext context);
    }
    public interface ICombatActions
    {
        void OnMainAttack(InputAction.CallbackContext context);
        void OnSlot_1(InputAction.CallbackContext context);
        void OnSlot_2(InputAction.CallbackContext context);
        void OnSlot_3(InputAction.CallbackContext context);
        void OnSpecial(InputAction.CallbackContext context);
    }
}
