// GENERATED AUTOMATICALLY FROM 'Assets/Scipts/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""GameInput"",
            ""id"": ""0bd5fe04-33de-4f66-9756-c28da21c80cd"",
            ""actions"": [
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""67bebeeb-d4cb-4ce7-9cf4-737c1fe9f919"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Launch"",
                    ""type"": ""Button"",
                    ""id"": ""40f8cdb9-7faa-4431-bc9a-cd9939e336a8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Charge"",
                    ""type"": ""Button"",
                    ""id"": ""f812fc42-ad1c-4bfc-8308-e427563a37af"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""19882145-8526-4ec4-80ad-c621343337b6"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Launch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Axis"",
                    ""id"": ""e50a5ec0-ee2d-4c17-afed-64461d853b8b"",
                    ""path"": ""1DAxis"",
                    ""interactions"": ""Hold,Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""3a0b46ba-174a-46ea-8a45-619c3e1c6861"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""0b9dfedc-17d5-4cde-8977-10b481240d24"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ef662c88-ea75-4edb-9251-c26aabee86f1"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Charge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GameInput
        m_GameInput = asset.FindActionMap("GameInput", throwIfNotFound: true);
        m_GameInput_Rotate = m_GameInput.FindAction("Rotate", throwIfNotFound: true);
        m_GameInput_Launch = m_GameInput.FindAction("Launch", throwIfNotFound: true);
        m_GameInput_Charge = m_GameInput.FindAction("Charge", throwIfNotFound: true);
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

    // GameInput
    private readonly InputActionMap m_GameInput;
    private IGameInputActions m_GameInputActionsCallbackInterface;
    private readonly InputAction m_GameInput_Rotate;
    private readonly InputAction m_GameInput_Launch;
    private readonly InputAction m_GameInput_Charge;
    public struct GameInputActions
    {
        private @PlayerInput m_Wrapper;
        public GameInputActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Rotate => m_Wrapper.m_GameInput_Rotate;
        public InputAction @Launch => m_Wrapper.m_GameInput_Launch;
        public InputAction @Charge => m_Wrapper.m_GameInput_Charge;
        public InputActionMap Get() { return m_Wrapper.m_GameInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameInputActions set) { return set.Get(); }
        public void SetCallbacks(IGameInputActions instance)
        {
            if (m_Wrapper.m_GameInputActionsCallbackInterface != null)
            {
                @Rotate.started -= m_Wrapper.m_GameInputActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_GameInputActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_GameInputActionsCallbackInterface.OnRotate;
                @Launch.started -= m_Wrapper.m_GameInputActionsCallbackInterface.OnLaunch;
                @Launch.performed -= m_Wrapper.m_GameInputActionsCallbackInterface.OnLaunch;
                @Launch.canceled -= m_Wrapper.m_GameInputActionsCallbackInterface.OnLaunch;
                @Charge.started -= m_Wrapper.m_GameInputActionsCallbackInterface.OnCharge;
                @Charge.performed -= m_Wrapper.m_GameInputActionsCallbackInterface.OnCharge;
                @Charge.canceled -= m_Wrapper.m_GameInputActionsCallbackInterface.OnCharge;
            }
            m_Wrapper.m_GameInputActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @Launch.started += instance.OnLaunch;
                @Launch.performed += instance.OnLaunch;
                @Launch.canceled += instance.OnLaunch;
                @Charge.started += instance.OnCharge;
                @Charge.performed += instance.OnCharge;
                @Charge.canceled += instance.OnCharge;
            }
        }
    }
    public GameInputActions @GameInput => new GameInputActions(this);
    public interface IGameInputActions
    {
        void OnRotate(InputAction.CallbackContext context);
        void OnLaunch(InputAction.CallbackContext context);
        void OnCharge(InputAction.CallbackContext context);
    }
}
