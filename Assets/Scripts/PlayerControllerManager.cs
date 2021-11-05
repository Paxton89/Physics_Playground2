// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerControllerManager.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControllerManager : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControllerManager()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControllerManager"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""c1c6c6af-c1e6-4e43-8b44-0626e7caabdc"",
            ""actions"": [
                {
                    ""name"": ""Forward"",
                    ""type"": ""Value"",
                    ""id"": ""5bda2769-14d9-4d05-8aff-81bb50650639"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Button"",
                    ""id"": ""3a9b62dd-ce40-4abb-b375-0219c16023a3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Boost"",
                    ""type"": ""Value"",
                    ""id"": ""752a440f-0006-422e-ab39-0a4d0419121a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FireTorpedo"",
                    ""type"": ""Button"",
                    ""id"": ""32d989c3-d7bb-4dff-95b9-43890bbc5634"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""06748f7d-c9a0-40e5-9e3d-30dccb0d10e3"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""363cc6e8-4a50-4a09-96c1-73e063f3f005"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""34466355-d3ce-452e-b59e-7e69229b4478"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""5d10b283-bd5f-4463-9b2c-787a6c428f97"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d7a08603-7bf5-4338-b329-574c13e6a217"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Boost"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""11b78741-eec7-43ed-8d0f-d3e46ae33365"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FireTorpedo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Forward = m_Player.FindAction("Forward", throwIfNotFound: true);
        m_Player_Rotate = m_Player.FindAction("Rotate", throwIfNotFound: true);
        m_Player_Boost = m_Player.FindAction("Boost", throwIfNotFound: true);
        m_Player_FireTorpedo = m_Player.FindAction("FireTorpedo", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Forward;
    private readonly InputAction m_Player_Rotate;
    private readonly InputAction m_Player_Boost;
    private readonly InputAction m_Player_FireTorpedo;
    public struct PlayerActions
    {
        private @PlayerControllerManager m_Wrapper;
        public PlayerActions(@PlayerControllerManager wrapper) { m_Wrapper = wrapper; }
        public InputAction @Forward => m_Wrapper.m_Player_Forward;
        public InputAction @Rotate => m_Wrapper.m_Player_Rotate;
        public InputAction @Boost => m_Wrapper.m_Player_Boost;
        public InputAction @FireTorpedo => m_Wrapper.m_Player_FireTorpedo;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Forward.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnForward;
                @Forward.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnForward;
                @Forward.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnForward;
                @Rotate.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotate;
                @Boost.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBoost;
                @Boost.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBoost;
                @Boost.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBoost;
                @FireTorpedo.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFireTorpedo;
                @FireTorpedo.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFireTorpedo;
                @FireTorpedo.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFireTorpedo;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Forward.started += instance.OnForward;
                @Forward.performed += instance.OnForward;
                @Forward.canceled += instance.OnForward;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @Boost.started += instance.OnBoost;
                @Boost.performed += instance.OnBoost;
                @Boost.canceled += instance.OnBoost;
                @FireTorpedo.started += instance.OnFireTorpedo;
                @FireTorpedo.performed += instance.OnFireTorpedo;
                @FireTorpedo.canceled += instance.OnFireTorpedo;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnForward(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnBoost(InputAction.CallbackContext context);
        void OnFireTorpedo(InputAction.CallbackContext context);
    }
}
