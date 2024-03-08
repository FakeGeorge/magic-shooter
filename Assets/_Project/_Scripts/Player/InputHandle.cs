using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandle : MonoBehaviour
{
    public static InputHandle Instance;
    private PlayerInputActionAsset playerInputActionAsset;

    #region Player InputAction Reference
    private InputAction moveAction;
    private InputAction lookAction;
    private InputAction jumpAction;
    private InputAction runAction;
    private InputAction crouchAction;
    private InputAction interactionAction;
    #endregion

    #region UI InputAction Reference
    private InputAction pauseAction;
    #endregion


    public Vector2 MoveInput;
    public Vector2 LookInput {  get; private set; }
    public bool RunTriggered { get; private set; }
    public bool JumpTriggered { get; private set; }
    public bool CrouchTriggered { get; private set; }
    public bool InteractionTriggered {  get; private set; }


    private void Awake()
    {
        #region Instance
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        #endregion

        playerInputActionAsset = new PlayerInputActionAsset();

        moveAction = playerInputActionAsset.Player.Move;
        lookAction = playerInputActionAsset.Player.Look;
        jumpAction = playerInputActionAsset.Player.Jump;
        runAction = playerInputActionAsset.Player.Run;
        crouchAction = playerInputActionAsset.Player.Crouch;
        interactionAction = playerInputActionAsset.Player.Interaction;
    }
    private void OnEnable()
    {
        playerInputActionAsset.Enable();

        moveAction.Enable(); 
        lookAction.Enable();
        jumpAction.Enable();
        runAction.Enable();
        crouchAction.Enable();
        interactionAction.Enable();

        SubscribeInputs();
    }
    private void OnDisable()
    {
        playerInputActionAsset.Disable();

        moveAction.Disable();
        lookAction.Disable();
        jumpAction.Disable();
        runAction.Disable();
        crouchAction.Disable();
        interactionAction.Disable();

        UnsubscribeInputs();
    }

    private void SubscribeInputs()
    {
        moveAction.performed += onMove;
        moveAction.canceled += onMoveCanceled;

        lookAction.performed += onLook;
        lookAction.canceled += onLookCanceled;

        jumpAction.performed += onJump;
        jumpAction.canceled += onJumpCanceled;

        runAction.performed += onRun;
        runAction.canceled += onRunCanceled;

        crouchAction.performed += onCrouch;
        crouchAction.canceled += onCrouchCanceled;

        interactionAction.performed += onInteraction;
        //interactionAction.canceled += onInteractionCanceled;
    }
    private void UnsubscribeInputs()
    {
        moveAction.performed -= onMove;
        moveAction.canceled -= onMoveCanceled;

        lookAction.performed -= onLook;
        lookAction.canceled -= onLookCanceled;

        jumpAction.performed -= onJump;
        jumpAction.canceled -= onJumpCanceled;
            
        runAction.performed -= onRun;
        runAction.canceled -= onRunCanceled;

        crouchAction.performed -= onCrouch;
        crouchAction.canceled -= onCrouchCanceled;

        interactionAction.performed -= onInteraction;
    }

    private void onMove(InputAction.CallbackContext ctx)
    {
        MoveInput = ctx.ReadValue<Vector2>();
    }

    private void onMoveCanceled(InputAction.CallbackContext ctx)
    {
        MoveInput = ctx.ReadValue<Vector2>();
    }

    private void onLook(InputAction.CallbackContext ctx)
    {
        LookInput = ctx.ReadValue<Vector2>();
    }

    private void onLookCanceled(InputAction.CallbackContext ctx)
    {
        LookInput = ctx.ReadValue<Vector2>();
    }

    private void onJump(InputAction.CallbackContext ctx)
    {
        JumpTriggered = true;
    }

    private void onJumpCanceled(InputAction.CallbackContext ctx)
    {
        JumpTriggered = false;
    }

    private void onRun(InputAction.CallbackContext ctx)
    {
        Debug.Log("CrouchTrigger");
        RunTriggered = true;
    }

    private void onRunCanceled(InputAction.CallbackContext ctx)
    {
        RunTriggered = false;
    }

    private void onCrouch(InputAction.CallbackContext ctx)
    {
        Debug.Log("CrouchTrigger");
        CrouchTriggered = true;
    }

    private void onCrouchCanceled(InputAction.CallbackContext ctx)
    {
        CrouchTriggered = false;
    }

    private void onInteraction(InputAction.CallbackContext context)
    {
        if (FP_Controller.instance.CanInteract)
        {
            FP_Controller.instance.HandleInteractionInput();
        }
    }

    private void onInteractionCanceled(InputAction.CallbackContext context)
    {

    }
}
