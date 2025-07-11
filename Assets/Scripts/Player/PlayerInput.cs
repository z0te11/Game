using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] public Movement moveComp;
    [SerializeField] public Ability mainAbilityComp;
    [SerializeField] public IReload mainAssistAbilityComp;
    [SerializeField] public Ability secondAbilityComp;
    [SerializeField] public PlayerAnimController animController;

    private bool isLocalPlayer;

    private void Start()
    {
        isLocalPlayer = GetComponent<PhotonView>().IsMine;
        mainAssistAbilityComp = GetComponent<IReload>();
    }

    private void Update()
    {
        if (!isLocalPlayer) return;
        if (mainAbilityComp != null && UserInputSystem.mainAbilityInput > 0) mainAbilityComp.Execute();
        if (mainAssistAbilityComp != null && UserInputSystem.mainAssistAbilityInput > 0) mainAssistAbilityComp.Reload();
        if (secondAbilityComp != null && UserInputSystem.secondAbilityInput > 0) secondAbilityComp.Execute();
    }

    private void FixedUpdate()
    {
        if (!isLocalPlayer) return;
        if (moveComp != null)
        {
            moveComp.Move(UserInputSystem.moveInput);
            if (animController != null) animController.MovePlayer(UserInputSystem.moveInput, moveComp.Speed);
        } 
    }
}
