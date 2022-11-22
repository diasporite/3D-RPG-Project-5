// GENERATED AUTOMATICALLY FROM 'Assets/Input/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""0a2d3b8c-ccf4-4fad-a10a-2b48d53f16f1"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""24ea0ed4-f576-4524-a721-9f773ccef600"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""d4ae4287-0b54-4ba0-bf69-2c1f6de406ef"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dpad"",
                    ""type"": ""Button"",
                    ""id"": ""6a0a12a3-c836-4a97-8b1c-bfb96c5789a6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dodge"",
                    ""type"": ""Button"",
                    ""id"": ""42209cde-da78-4fe3-be07-8e9099b095cb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1df03b51-066d-4766-bec0-cd4b5d2b62af"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""RunCancel"",
                    ""type"": ""Value"",
                    ""id"": ""6ede69d2-bf4a-4830-a1d1-a8066d0561d8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""58227752-7d6b-4de5-b475-ed5681a88a68"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""Guard"",
                    ""type"": ""PassThrough"",
                    ""id"": ""25c5a5c8-0eea-42c3-9a4f-1cbe0ea5d3db"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""GuardCancel"",
                    ""type"": ""Button"",
                    ""id"": ""9c48b2da-632c-4adc-8b42-71b94a6f229f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Action1"",
                    ""type"": ""Button"",
                    ""id"": ""c5c77c76-499b-4687-a5da-0882571e9fab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Action2"",
                    ""type"": ""Button"",
                    ""id"": ""74caffb2-dff2-4149-892e-555f5200c243"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Action3"",
                    ""type"": ""Button"",
                    ""id"": ""e546a64b-9239-48e5-be7c-d6a44ab15b8d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Action4"",
                    ""type"": ""Button"",
                    ""id"": ""e638c746-7831-4e46-bf78-e15ec7569b9d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PauseSelect"",
                    ""type"": ""Button"",
                    ""id"": ""21e0ed53-d59f-4301-814c-8f5c52d78593"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ToggleTarget"",
                    ""type"": ""Button"",
                    ""id"": ""ca0c3f05-97d7-4cea-99f1-3a3721e92a3c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""467eb968-fc57-4556-9e07-4fcae88ff9ea"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""73bea7c1-df83-417b-ad75-a0d9dae3dcd0"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""31f95265-acc9-4075-97e1-25e7d15f01bb"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""73baf02d-90e6-483a-8272-1c50d23e1591"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""cf528287-4475-41b0-b0d3-9b1852f4d386"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""841bb96e-9fc9-46cd-8d38-899e1a52dab7"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e1660505-5f82-40b5-8a97-f754aee76b2f"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b613f858-ffe0-4c50-96e0-0c5388b0a502"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f05287ca-8b45-41d8-be0f-c7ee810b0294"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5314085a-e8b7-4e5a-8fc2-e7089f4113bb"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""6fe8a3d8-25f3-42b5-b7e4-f90afcf11ccd"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8f6bca7e-454c-4e2a-8460-36a292f88ed1"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1506beb8-49b3-4d66-acb8-36810906d2ab"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""533f4cd4-2bce-41f0-9038-5208768a3301"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""64013f58-5e99-49ce-a6cb-e2f4c1177e21"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""a4e7ea5f-c418-4cde-beb5-630428a40cee"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""085846c7-bb71-4aaf-b184-db1ac8654592"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f7c1546c-6f79-4503-b7e2-32812f8c518d"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""21413134-2d45-4b01-938c-7dbf7ee23d13"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d135208e-5f40-4d3b-ac69-2dc6705b32ca"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6870e1b4-fde2-4af2-a849-a42bf3d2a04a"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4da92d69-b0f0-4cdd-9c40-008fd186368b"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""51f2617c-0d2e-41e4-b268-63869d6cdd1d"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""449bf05e-b2f6-47cb-a190-a68a8a28ddea"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b9e22d8b-b3dc-4312-a137-2f87965765ac"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""47fba53b-ec50-4606-869d-f99bbfe986e2"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0f0791dd-a0e6-4e87-ab77-b81f6bb59a50"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Guard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d33794aa-592b-4dae-80f5-42810a5c170c"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Guard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9467e185-a258-4bfc-9dbd-0822fd411c76"",
                    ""path"": ""<Keyboard>/u"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Action1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""20192a07-8a28-48a0-8428-e33c689ec2e7"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Action1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""31ecaa80-037f-456c-a8f1-9e23c27c44bd"",
                    ""path"": ""<Keyboard>/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Action2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3f055dca-f056-494b-97fb-66a4f70ffe19"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Action2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""88852b5b-fcb1-4f5e-a51f-cfe861c6fb47"",
                    ""path"": ""<Keyboard>/o"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Action3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d1363a89-65a2-43ae-bbb6-a0a7b159efc4"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Action3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e3f03dd2-86ad-47ec-88e3-b19c16020f80"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Action4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eeed8f92-3ae2-4da9-901a-a3c60101cffa"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Action4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""290c3add-36c4-46c2-aad6-3a68b9469ab6"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dpad"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""7726d8ec-0906-42a3-8a26-b5fabaf8af5f"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Dpad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8a96af17-a4fe-4af6-a891-e0bc40211835"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Dpad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e3d1f0f9-8d14-481c-b827-9676100f3225"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Dpad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d5128841-7d40-4442-b446-8e1530cadb3a"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Dpad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""846aa1af-0ce2-4c08-b80d-91da8a776936"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dpad"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1a5ec5ad-cdb3-49ef-825e-01df9695adaf"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Dpad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""48a44712-aa83-4d9f-a36e-2ab1593bfaf4"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Dpad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d680490c-fc1e-44db-b418-1800ff37b3b8"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Dpad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""007a4965-81ac-46bd-a0ba-f525836b31a4"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Dpad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""45f90f48-9cf8-4279-8d6d-3d3ed457bc25"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""PauseSelect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f7ecd7ff-5dd8-44ef-a90c-342154efcec1"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""PauseSelect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3b04f066-dc32-4452-b943-383de0652fcc"",
                    ""path"": ""<Keyboard>/h"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ToggleTarget"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4712dad6-f01c-4140-a097-1c0216086f88"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ToggleTarget"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""65dd5e75-4562-437f-9920-2869b7665555"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""RunCancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c044db4b-d44b-4d80-b2b8-65386d28166d"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""RunCancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4e9c7e74-bbe7-408d-87f7-73ee8c574084"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""GuardCancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ae627598-b1fe-4d38-a484-023b7ed295a0"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""GuardCancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MainMenu"",
            ""id"": ""4ca23fef-f17c-41bb-a63a-2bfd0ac82a58"",
            ""actions"": [
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""6fbde449-f4e1-41f1-a357-ab0980beb8d4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Confirm"",
                    ""type"": ""Button"",
                    ""id"": ""7546cad1-a784-48f2-8a5d-b47daf223e99"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Next"",
                    ""type"": ""Button"",
                    ""id"": ""efaeb43e-4f80-447e-88eb-8f8d2ab16414"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Previous"",
                    ""type"": ""Button"",
                    ""id"": ""92e9476a-1161-4d70-9fbf-6af4ffee0082"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8a628a6e-dc96-4048-86a6-1bf85d84fe55"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""da3b53e3-fa6c-4bf7-8f76-f78d759c2f7a"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cfc08acf-98f6-494e-bf50-9ed2f3727ea3"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ac13dc71-ddc0-4542-a06d-3f13aaeb7984"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2525b31a-405d-47a3-93ed-71bed2ea5915"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Next"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""27c9d964-38e5-4c3f-bb28-f5448da4f7bf"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Next"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""77d906f6-b144-4f87-9d08-51024ea8b1a5"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Previous"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4ceb5675-bea7-4063-bad4-bc82267a2b96"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Previous"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Rotate = m_Player.FindAction("Rotate", throwIfNotFound: true);
        m_Player_Dpad = m_Player.FindAction("Dpad", throwIfNotFound: true);
        m_Player_Dodge = m_Player.FindAction("Dodge", throwIfNotFound: true);
        m_Player_Run = m_Player.FindAction("Run", throwIfNotFound: true);
        m_Player_RunCancel = m_Player.FindAction("RunCancel", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Guard = m_Player.FindAction("Guard", throwIfNotFound: true);
        m_Player_GuardCancel = m_Player.FindAction("GuardCancel", throwIfNotFound: true);
        m_Player_Action1 = m_Player.FindAction("Action1", throwIfNotFound: true);
        m_Player_Action2 = m_Player.FindAction("Action2", throwIfNotFound: true);
        m_Player_Action3 = m_Player.FindAction("Action3", throwIfNotFound: true);
        m_Player_Action4 = m_Player.FindAction("Action4", throwIfNotFound: true);
        m_Player_PauseSelect = m_Player.FindAction("PauseSelect", throwIfNotFound: true);
        m_Player_ToggleTarget = m_Player.FindAction("ToggleTarget", throwIfNotFound: true);
        // MainMenu
        m_MainMenu = asset.FindActionMap("MainMenu", throwIfNotFound: true);
        m_MainMenu_Back = m_MainMenu.FindAction("Back", throwIfNotFound: true);
        m_MainMenu_Confirm = m_MainMenu.FindAction("Confirm", throwIfNotFound: true);
        m_MainMenu_Next = m_MainMenu.FindAction("Next", throwIfNotFound: true);
        m_MainMenu_Previous = m_MainMenu.FindAction("Previous", throwIfNotFound: true);
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
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Rotate;
    private readonly InputAction m_Player_Dpad;
    private readonly InputAction m_Player_Dodge;
    private readonly InputAction m_Player_Run;
    private readonly InputAction m_Player_RunCancel;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Guard;
    private readonly InputAction m_Player_GuardCancel;
    private readonly InputAction m_Player_Action1;
    private readonly InputAction m_Player_Action2;
    private readonly InputAction m_Player_Action3;
    private readonly InputAction m_Player_Action4;
    private readonly InputAction m_Player_PauseSelect;
    private readonly InputAction m_Player_ToggleTarget;
    public struct PlayerActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Rotate => m_Wrapper.m_Player_Rotate;
        public InputAction @Dpad => m_Wrapper.m_Player_Dpad;
        public InputAction @Dodge => m_Wrapper.m_Player_Dodge;
        public InputAction @Run => m_Wrapper.m_Player_Run;
        public InputAction @RunCancel => m_Wrapper.m_Player_RunCancel;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Guard => m_Wrapper.m_Player_Guard;
        public InputAction @GuardCancel => m_Wrapper.m_Player_GuardCancel;
        public InputAction @Action1 => m_Wrapper.m_Player_Action1;
        public InputAction @Action2 => m_Wrapper.m_Player_Action2;
        public InputAction @Action3 => m_Wrapper.m_Player_Action3;
        public InputAction @Action4 => m_Wrapper.m_Player_Action4;
        public InputAction @PauseSelect => m_Wrapper.m_Player_PauseSelect;
        public InputAction @ToggleTarget => m_Wrapper.m_Player_ToggleTarget;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Rotate.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotate;
                @Dpad.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDpad;
                @Dpad.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDpad;
                @Dpad.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDpad;
                @Dodge.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDodge;
                @Dodge.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDodge;
                @Dodge.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDodge;
                @Run.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRun;
                @RunCancel.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRunCancel;
                @RunCancel.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRunCancel;
                @RunCancel.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRunCancel;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Guard.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGuard;
                @Guard.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGuard;
                @Guard.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGuard;
                @GuardCancel.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGuardCancel;
                @GuardCancel.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGuardCancel;
                @GuardCancel.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGuardCancel;
                @Action1.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction1;
                @Action1.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction1;
                @Action1.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction1;
                @Action2.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction2;
                @Action2.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction2;
                @Action2.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction2;
                @Action3.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction3;
                @Action3.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction3;
                @Action3.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction3;
                @Action4.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction4;
                @Action4.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction4;
                @Action4.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction4;
                @PauseSelect.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPauseSelect;
                @PauseSelect.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPauseSelect;
                @PauseSelect.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPauseSelect;
                @ToggleTarget.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnToggleTarget;
                @ToggleTarget.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnToggleTarget;
                @ToggleTarget.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnToggleTarget;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @Dpad.started += instance.OnDpad;
                @Dpad.performed += instance.OnDpad;
                @Dpad.canceled += instance.OnDpad;
                @Dodge.started += instance.OnDodge;
                @Dodge.performed += instance.OnDodge;
                @Dodge.canceled += instance.OnDodge;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @RunCancel.started += instance.OnRunCancel;
                @RunCancel.performed += instance.OnRunCancel;
                @RunCancel.canceled += instance.OnRunCancel;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Guard.started += instance.OnGuard;
                @Guard.performed += instance.OnGuard;
                @Guard.canceled += instance.OnGuard;
                @GuardCancel.started += instance.OnGuardCancel;
                @GuardCancel.performed += instance.OnGuardCancel;
                @GuardCancel.canceled += instance.OnGuardCancel;
                @Action1.started += instance.OnAction1;
                @Action1.performed += instance.OnAction1;
                @Action1.canceled += instance.OnAction1;
                @Action2.started += instance.OnAction2;
                @Action2.performed += instance.OnAction2;
                @Action2.canceled += instance.OnAction2;
                @Action3.started += instance.OnAction3;
                @Action3.performed += instance.OnAction3;
                @Action3.canceled += instance.OnAction3;
                @Action4.started += instance.OnAction4;
                @Action4.performed += instance.OnAction4;
                @Action4.canceled += instance.OnAction4;
                @PauseSelect.started += instance.OnPauseSelect;
                @PauseSelect.performed += instance.OnPauseSelect;
                @PauseSelect.canceled += instance.OnPauseSelect;
                @ToggleTarget.started += instance.OnToggleTarget;
                @ToggleTarget.performed += instance.OnToggleTarget;
                @ToggleTarget.canceled += instance.OnToggleTarget;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // MainMenu
    private readonly InputActionMap m_MainMenu;
    private IMainMenuActions m_MainMenuActionsCallbackInterface;
    private readonly InputAction m_MainMenu_Back;
    private readonly InputAction m_MainMenu_Confirm;
    private readonly InputAction m_MainMenu_Next;
    private readonly InputAction m_MainMenu_Previous;
    public struct MainMenuActions
    {
        private @PlayerControls m_Wrapper;
        public MainMenuActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Back => m_Wrapper.m_MainMenu_Back;
        public InputAction @Confirm => m_Wrapper.m_MainMenu_Confirm;
        public InputAction @Next => m_Wrapper.m_MainMenu_Next;
        public InputAction @Previous => m_Wrapper.m_MainMenu_Previous;
        public InputActionMap Get() { return m_Wrapper.m_MainMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainMenuActions set) { return set.Get(); }
        public void SetCallbacks(IMainMenuActions instance)
        {
            if (m_Wrapper.m_MainMenuActionsCallbackInterface != null)
            {
                @Back.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnBack;
                @Confirm.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnConfirm;
                @Confirm.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnConfirm;
                @Confirm.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnConfirm;
                @Next.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnNext;
                @Next.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnNext;
                @Next.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnNext;
                @Previous.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnPrevious;
                @Previous.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnPrevious;
                @Previous.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnPrevious;
            }
            m_Wrapper.m_MainMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
                @Confirm.started += instance.OnConfirm;
                @Confirm.performed += instance.OnConfirm;
                @Confirm.canceled += instance.OnConfirm;
                @Next.started += instance.OnNext;
                @Next.performed += instance.OnNext;
                @Next.canceled += instance.OnNext;
                @Previous.started += instance.OnPrevious;
                @Previous.performed += instance.OnPrevious;
                @Previous.canceled += instance.OnPrevious;
            }
        }
    }
    public MainMenuActions @MainMenu => new MainMenuActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnDpad(InputAction.CallbackContext context);
        void OnDodge(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnRunCancel(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnGuard(InputAction.CallbackContext context);
        void OnGuardCancel(InputAction.CallbackContext context);
        void OnAction1(InputAction.CallbackContext context);
        void OnAction2(InputAction.CallbackContext context);
        void OnAction3(InputAction.CallbackContext context);
        void OnAction4(InputAction.CallbackContext context);
        void OnPauseSelect(InputAction.CallbackContext context);
        void OnToggleTarget(InputAction.CallbackContext context);
    }
    public interface IMainMenuActions
    {
        void OnBack(InputAction.CallbackContext context);
        void OnConfirm(InputAction.CallbackContext context);
        void OnNext(InputAction.CallbackContext context);
        void OnPrevious(InputAction.CallbackContext context);
    }
}
