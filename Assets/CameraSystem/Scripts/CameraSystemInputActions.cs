//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/CameraSystem/Scripts/CameraSystemInputActions.inputactions
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

namespace CameraSystem
{
    public partial class @CameraSystemInputActions : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @CameraSystemInputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""CameraSystemInputActions"",
    ""maps"": [
        {
            ""name"": ""Camera"",
            ""id"": ""10bad493-3fff-42ff-845e-51357d4978a4"",
            ""actions"": [
                {
                    ""name"": ""KeyboardMovement"",
                    ""type"": ""Value"",
                    ""id"": ""256c0ad3-d056-4db9-abbf-0708fadc2926"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""KeyboardRotation"",
                    ""type"": ""Value"",
                    ""id"": ""caa49d8d-4f7c-4b28-ba7c-b3791dade07f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MouseDelta"",
                    ""type"": ""Value"",
                    ""id"": ""12e4b278-1513-4008-95b3-a46b65deb970"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MouseZoom"",
                    ""type"": ""Value"",
                    ""id"": ""bd1ea9b6-24a0-4e51-877b-bc3180d60a58"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""e683b2bf-75fa-48db-a4c2-3bfb2819f1ad"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeyboardMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""16d52956-db05-4ea6-af27-6a7aa453089b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeyboardMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""af37f465-f460-4e33-9c40-f0561c44c86c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeyboardMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""95574efd-b7d5-44ec-bb82-f2b6ec48f57a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeyboardMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a0eb05a8-c0b6-4ddf-a4fe-39f8d16ad0c2"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeyboardMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""f3781cf3-e435-40f7-8838-d7a5aea11182"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeyboardMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b9e7e8b9-dc46-4c4e-a974-600d89c0630c"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeyboardMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8ff70773-71c5-453b-a6b2-34b6d1bd1bbf"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeyboardMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5ff4ba8d-25d4-4e6c-9a7f-4289196f545b"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeyboardMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d473f1e4-b025-4130-955c-c99536634744"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeyboardMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""6cfcee84-19da-45ad-9ede-87340c866a3b"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeyboardMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""51f4b2fe-79fa-41de-9af7-8c4088b3a7fc"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeyboardMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4a711ac2-4cfd-47e0-ae2e-744bd37aee80"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeyboardMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7718feea-55a3-4972-8de3-079ebfaac1ad"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeyboardMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f2a382e9-9a1a-4c10-a1ee-0e0951cdbb82"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeyboardMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""833d0528-20c0-4daa-8001-cec256853447"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseZoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4d90e56c-9893-45bb-947f-28685c06f96c"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""QE"",
                    ""id"": ""eb574eef-fde8-4c01-861b-561663d945dc"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeyboardRotation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Negative"",
                    ""id"": ""f663e9d3-3b2a-450a-b0cb-1564605de302"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeyboardRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Positive"",
                    ""id"": ""92b7ef34-20f2-4ac8-b151-cabc42a0b0ba"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeyboardRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Camera
            m_Camera = asset.FindActionMap("Camera", throwIfNotFound: true);
            m_Camera_KeyboardMovement = m_Camera.FindAction("KeyboardMovement", throwIfNotFound: true);
            m_Camera_KeyboardRotation = m_Camera.FindAction("KeyboardRotation", throwIfNotFound: true);
            m_Camera_MouseDelta = m_Camera.FindAction("MouseDelta", throwIfNotFound: true);
            m_Camera_MouseZoom = m_Camera.FindAction("MouseZoom", throwIfNotFound: true);
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

        // Camera
        private readonly InputActionMap m_Camera;
        private ICameraActions m_CameraActionsCallbackInterface;
        private readonly InputAction m_Camera_KeyboardMovement;
        private readonly InputAction m_Camera_KeyboardRotation;
        private readonly InputAction m_Camera_MouseDelta;
        private readonly InputAction m_Camera_MouseZoom;
        public struct CameraActions
        {
            private @CameraSystemInputActions m_Wrapper;
            public CameraActions(@CameraSystemInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @KeyboardMovement => m_Wrapper.m_Camera_KeyboardMovement;
            public InputAction @KeyboardRotation => m_Wrapper.m_Camera_KeyboardRotation;
            public InputAction @MouseDelta => m_Wrapper.m_Camera_MouseDelta;
            public InputAction @MouseZoom => m_Wrapper.m_Camera_MouseZoom;
            public InputActionMap Get() { return m_Wrapper.m_Camera; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(CameraActions set) { return set.Get(); }
            public void SetCallbacks(ICameraActions instance)
            {
                if (m_Wrapper.m_CameraActionsCallbackInterface != null)
                {
                    @KeyboardMovement.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnKeyboardMovement;
                    @KeyboardMovement.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnKeyboardMovement;
                    @KeyboardMovement.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnKeyboardMovement;
                    @KeyboardRotation.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnKeyboardRotation;
                    @KeyboardRotation.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnKeyboardRotation;
                    @KeyboardRotation.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnKeyboardRotation;
                    @MouseDelta.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnMouseDelta;
                    @MouseDelta.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnMouseDelta;
                    @MouseDelta.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnMouseDelta;
                    @MouseZoom.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnMouseZoom;
                    @MouseZoom.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnMouseZoom;
                    @MouseZoom.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnMouseZoom;
                }
                m_Wrapper.m_CameraActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @KeyboardMovement.started += instance.OnKeyboardMovement;
                    @KeyboardMovement.performed += instance.OnKeyboardMovement;
                    @KeyboardMovement.canceled += instance.OnKeyboardMovement;
                    @KeyboardRotation.started += instance.OnKeyboardRotation;
                    @KeyboardRotation.performed += instance.OnKeyboardRotation;
                    @KeyboardRotation.canceled += instance.OnKeyboardRotation;
                    @MouseDelta.started += instance.OnMouseDelta;
                    @MouseDelta.performed += instance.OnMouseDelta;
                    @MouseDelta.canceled += instance.OnMouseDelta;
                    @MouseZoom.started += instance.OnMouseZoom;
                    @MouseZoom.performed += instance.OnMouseZoom;
                    @MouseZoom.canceled += instance.OnMouseZoom;
                }
            }
        }
        public CameraActions @Camera => new CameraActions(this);
        public interface ICameraActions
        {
            void OnKeyboardMovement(InputAction.CallbackContext context);
            void OnKeyboardRotation(InputAction.CallbackContext context);
            void OnMouseDelta(InputAction.CallbackContext context);
            void OnMouseZoom(InputAction.CallbackContext context);
        }
    }
}
