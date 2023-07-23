//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/Features/Global/Services/Inputs/View/Config/Controls.inputactions
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

public partial class @Controls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""GamePlay"",
            ""id"": ""98d3b2ff-9a15-42b1-bc36-b64f77d5f962"",
            ""actions"": [
                {
                    ""name"": ""RangeAttack"",
                    ""type"": ""Button"",
                    ""id"": ""50319b66-920d-45f8-81de-bdf2ca94fb4e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MeleeAttack"",
                    ""type"": ""Button"",
                    ""id"": ""bb9d1598-f11c-4a12-aa33-3d40e312ae3c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""881c0fd0-98ae-42cd-adbe-dbe5ce536693"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Roll"",
                    ""type"": ""Button"",
                    ""id"": ""559581fc-20d1-4f59-8fee-7e59770aac17"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2080924a-dc85-4676-a0fa-6417b6ed8408"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RangeAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ab7fb0d7-2650-42db-81d1-9652f3418d63"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MeleeAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""e7f9f3c2-9a31-46f4-8226-c1c99d373a3c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""394ebc6c-4cb0-4846-9814-e431c6a6fa92"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d860a947-457c-4cb0-8eea-9f31f9e4299d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""408bca3b-d4ac-4c4a-8409-643fb7c59ae3"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""46faee24-39c0-4c6c-a12b-269bf05f53aa"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""273161b4-73b6-4100-bfd8-f9cc2f01b7f5"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Debug"",
            ""id"": ""60e981ee-88bb-4b19-b6b8-0e1b22d00a8a"",
            ""actions"": [
                {
                    ""name"": ""Console"",
                    ""type"": ""Button"",
                    ""id"": ""49b67ce7-c81a-42ad-9d78-62f550fbba04"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""cc478c29-06e8-4102-896e-a9caf6e62102"",
                    ""path"": ""<Keyboard>/backquote"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Console"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GamePlay
        m_GamePlay = asset.FindActionMap("GamePlay", throwIfNotFound: true);
        m_GamePlay_RangeAttack = m_GamePlay.FindAction("RangeAttack", throwIfNotFound: true);
        m_GamePlay_MeleeAttack = m_GamePlay.FindAction("MeleeAttack", throwIfNotFound: true);
        m_GamePlay_Movement = m_GamePlay.FindAction("Movement", throwIfNotFound: true);
        m_GamePlay_Roll = m_GamePlay.FindAction("Roll", throwIfNotFound: true);
        // Debug
        m_Debug = asset.FindActionMap("Debug", throwIfNotFound: true);
        m_Debug_Console = m_Debug.FindAction("Console", throwIfNotFound: true);
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

    // GamePlay
    private readonly InputActionMap m_GamePlay;
    private List<IGamePlayActions> m_GamePlayActionsCallbackInterfaces = new List<IGamePlayActions>();
    private readonly InputAction m_GamePlay_RangeAttack;
    private readonly InputAction m_GamePlay_MeleeAttack;
    private readonly InputAction m_GamePlay_Movement;
    private readonly InputAction m_GamePlay_Roll;
    public struct GamePlayActions
    {
        private @Controls m_Wrapper;
        public GamePlayActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @RangeAttack => m_Wrapper.m_GamePlay_RangeAttack;
        public InputAction @MeleeAttack => m_Wrapper.m_GamePlay_MeleeAttack;
        public InputAction @Movement => m_Wrapper.m_GamePlay_Movement;
        public InputAction @Roll => m_Wrapper.m_GamePlay_Roll;
        public InputActionMap Get() { return m_Wrapper.m_GamePlay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamePlayActions set) { return set.Get(); }
        public void AddCallbacks(IGamePlayActions instance)
        {
            if (instance == null || m_Wrapper.m_GamePlayActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GamePlayActionsCallbackInterfaces.Add(instance);
            @RangeAttack.started += instance.OnRangeAttack;
            @RangeAttack.performed += instance.OnRangeAttack;
            @RangeAttack.canceled += instance.OnRangeAttack;
            @MeleeAttack.started += instance.OnMeleeAttack;
            @MeleeAttack.performed += instance.OnMeleeAttack;
            @MeleeAttack.canceled += instance.OnMeleeAttack;
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Roll.started += instance.OnRoll;
            @Roll.performed += instance.OnRoll;
            @Roll.canceled += instance.OnRoll;
        }

        private void UnregisterCallbacks(IGamePlayActions instance)
        {
            @RangeAttack.started -= instance.OnRangeAttack;
            @RangeAttack.performed -= instance.OnRangeAttack;
            @RangeAttack.canceled -= instance.OnRangeAttack;
            @MeleeAttack.started -= instance.OnMeleeAttack;
            @MeleeAttack.performed -= instance.OnMeleeAttack;
            @MeleeAttack.canceled -= instance.OnMeleeAttack;
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Roll.started -= instance.OnRoll;
            @Roll.performed -= instance.OnRoll;
            @Roll.canceled -= instance.OnRoll;
        }

        public void RemoveCallbacks(IGamePlayActions instance)
        {
            if (m_Wrapper.m_GamePlayActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGamePlayActions instance)
        {
            foreach (var item in m_Wrapper.m_GamePlayActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GamePlayActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GamePlayActions @GamePlay => new GamePlayActions(this);

    // Debug
    private readonly InputActionMap m_Debug;
    private List<IDebugActions> m_DebugActionsCallbackInterfaces = new List<IDebugActions>();
    private readonly InputAction m_Debug_Console;
    public struct DebugActions
    {
        private @Controls m_Wrapper;
        public DebugActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Console => m_Wrapper.m_Debug_Console;
        public InputActionMap Get() { return m_Wrapper.m_Debug; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DebugActions set) { return set.Get(); }
        public void AddCallbacks(IDebugActions instance)
        {
            if (instance == null || m_Wrapper.m_DebugActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_DebugActionsCallbackInterfaces.Add(instance);
            @Console.started += instance.OnConsole;
            @Console.performed += instance.OnConsole;
            @Console.canceled += instance.OnConsole;
        }

        private void UnregisterCallbacks(IDebugActions instance)
        {
            @Console.started -= instance.OnConsole;
            @Console.performed -= instance.OnConsole;
            @Console.canceled -= instance.OnConsole;
        }

        public void RemoveCallbacks(IDebugActions instance)
        {
            if (m_Wrapper.m_DebugActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IDebugActions instance)
        {
            foreach (var item in m_Wrapper.m_DebugActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_DebugActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public DebugActions @Debug => new DebugActions(this);
    public interface IGamePlayActions
    {
        void OnRangeAttack(InputAction.CallbackContext context);
        void OnMeleeAttack(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnRoll(InputAction.CallbackContext context);
    }
    public interface IDebugActions
    {
        void OnConsole(InputAction.CallbackContext context);
    }
}
