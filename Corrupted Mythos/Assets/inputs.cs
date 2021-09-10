// GENERATED AUTOMATICALLY FROM 'Assets/inputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Inputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Inputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""inputs"",
    ""maps"": [
        {
            ""name"": ""player"",
            ""id"": ""2d3efdc9-dccf-4e20-9127-7d73fc3a891c"",
            ""actions"": [
                {
                    ""name"": ""movement"",
                    ""type"": ""Button"",
                    ""id"": ""0a0ce847-4dbe-4799-aab3-85bcb577dd1e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""attack"",
                    ""type"": ""Button"",
                    ""id"": ""325fb5be-cd10-4c97-8a6e-7dd00f0b3a85"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""jump"",
                    ""type"": ""Button"",
                    ""id"": ""1d6a6b44-d72b-4660-b8c9-96df318b624d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ArtifactOne"",
                    ""type"": ""Button"",
                    ""id"": ""dbdd42e2-46c1-4a08-b656-ca599e51ad4f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ArtifactTwo"",
                    ""type"": ""Button"",
                    ""id"": ""f6869282-d3bd-441a-8eec-ab3632400c32"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ArtifactThree"",
                    ""type"": ""Button"",
                    ""id"": ""9a79d76a-1a80-4cfb-b024-8c5e4c61f23a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""keyboard WASD"",
                    ""id"": ""f86e8b27-e7ac-4dc9-8755-a414706d7878"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e2ce31d6-183b-4a95-ba72-af0c5ff8861d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""controls"",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c2a48862-f322-4d03-bebd-002f7eda226a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""controls"",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ecab535e-032a-4f59-a842-44723e91418f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""controls"",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""49265499-2ff0-42ad-a36f-09aa23c0c7c6"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""controls"",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""controller"",
                    ""id"": ""0c161e4e-0072-4c4c-81c1-62b72953dfaf"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""702a2ff3-9493-4caf-99b3-a7d9b95ed9e1"",
                    ""path"": ""<XInputController>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""controls"",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e9543a30-d577-4f6c-931d-1a26d60f3f73"",
                    ""path"": ""<XInputController>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""controls"",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6f647539-380a-4507-8cbe-a93de7eb6563"",
                    ""path"": ""<XInputController>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""controls"",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d4cc1638-a0fa-4283-8f7d-1e13959c4c34"",
                    ""path"": ""<XInputController>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""controls"",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""keyboard arrows"",
                    ""id"": ""dc6415a4-7523-4d6b-a4e9-286e0b7e371c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8255faca-a458-4ca5-9c00-a502edc0a800"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""controls"",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d8b75338-dd4b-433a-b468-bdcab46944b4"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""controls"",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""54d769f6-48f6-4b36-80a1-faf90b69fef5"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""controls"",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""126c4d40-8fd0-4cf8-9d1b-33c302e0303f"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""controls"",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c7c8846e-19a4-416a-9582-2808ec36f5a7"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9ec4667f-0c26-48a5-b249-ec657993aef1"",
                    ""path"": ""<XInputController>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""44467d8b-2449-415b-a57d-500b9808b2db"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ea85193b-7a9f-4e84-89f1-c53f25197dd0"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ef24a9ec-a6e7-4158-bfee-f511432ee28f"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ArtifactOne"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""90ebf820-b958-44e3-80a4-ff91ba0ac53f"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ArtifactTwo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""492401be-9d99-44e4-9396-49b221555e5d"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ArtifactThree"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""controls"",
            ""bindingGroup"": ""controls"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<XboxOneGampadiOS>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // player
        m_player = asset.FindActionMap("player", throwIfNotFound: true);
        m_player_movement = m_player.FindAction("movement", throwIfNotFound: true);
        m_player_attack = m_player.FindAction("attack", throwIfNotFound: true);
        m_player_jump = m_player.FindAction("jump", throwIfNotFound: true);
        m_player_ArtifactOne = m_player.FindAction("ArtifactOne", throwIfNotFound: true);
        m_player_ArtifactTwo = m_player.FindAction("ArtifactTwo", throwIfNotFound: true);
        m_player_ArtifactThree = m_player.FindAction("ArtifactThree", throwIfNotFound: true);
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

    // player
    private readonly InputActionMap m_player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_player_movement;
    private readonly InputAction m_player_attack;
    private readonly InputAction m_player_jump;
    private readonly InputAction m_player_ArtifactOne;
    private readonly InputAction m_player_ArtifactTwo;
    private readonly InputAction m_player_ArtifactThree;
    public struct PlayerActions
    {
        private @Inputs m_Wrapper;
        public PlayerActions(@Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @movement => m_Wrapper.m_player_movement;
        public InputAction @attack => m_Wrapper.m_player_attack;
        public InputAction @jump => m_Wrapper.m_player_jump;
        public InputAction @ArtifactOne => m_Wrapper.m_player_ArtifactOne;
        public InputAction @ArtifactTwo => m_Wrapper.m_player_ArtifactTwo;
        public InputAction @ArtifactThree => m_Wrapper.m_player_ArtifactThree;
        public InputActionMap Get() { return m_Wrapper.m_player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @attack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @attack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @attack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @ArtifactOne.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnArtifactOne;
                @ArtifactOne.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnArtifactOne;
                @ArtifactOne.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnArtifactOne;
                @ArtifactTwo.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnArtifactTwo;
                @ArtifactTwo.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnArtifactTwo;
                @ArtifactTwo.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnArtifactTwo;
                @ArtifactThree.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnArtifactThree;
                @ArtifactThree.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnArtifactThree;
                @ArtifactThree.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnArtifactThree;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @movement.started += instance.OnMovement;
                @movement.performed += instance.OnMovement;
                @movement.canceled += instance.OnMovement;
                @attack.started += instance.OnAttack;
                @attack.performed += instance.OnAttack;
                @attack.canceled += instance.OnAttack;
                @jump.started += instance.OnJump;
                @jump.performed += instance.OnJump;
                @jump.canceled += instance.OnJump;
                @ArtifactOne.started += instance.OnArtifactOne;
                @ArtifactOne.performed += instance.OnArtifactOne;
                @ArtifactOne.canceled += instance.OnArtifactOne;
                @ArtifactTwo.started += instance.OnArtifactTwo;
                @ArtifactTwo.performed += instance.OnArtifactTwo;
                @ArtifactTwo.canceled += instance.OnArtifactTwo;
                @ArtifactThree.started += instance.OnArtifactThree;
                @ArtifactThree.performed += instance.OnArtifactThree;
                @ArtifactThree.canceled += instance.OnArtifactThree;
            }
        }
    }
    public PlayerActions @player => new PlayerActions(this);
    private int m_controlsSchemeIndex = -1;
    public InputControlScheme controlsScheme
    {
        get
        {
            if (m_controlsSchemeIndex == -1) m_controlsSchemeIndex = asset.FindControlSchemeIndex("controls");
            return asset.controlSchemes[m_controlsSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnArtifactOne(InputAction.CallbackContext context);
        void OnArtifactTwo(InputAction.CallbackContext context);
        void OnArtifactThree(InputAction.CallbackContext context);
    }
}
