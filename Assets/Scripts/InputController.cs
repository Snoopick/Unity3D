using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum InputCommand
{
    Fire,
    Fire2,
    Fire3,
    Skill,
}

public class InputController : MonoBehaviour
{
    public static Action<InputCommand> OnInputAction;

    [SerializeField] private Button fireButton;
    [SerializeField] private Button fireButton2;
    [SerializeField] private Button fireButton3;
    [SerializeField] private Button skillButton;
    // Start is called before the first frame update
    void Awake()
    {
        fireButton.onClick.AddListener(OnFireButton);
        fireButton2.onClick.AddListener(OnFireButton2);
        fireButton3.onClick.AddListener(OnFireButton3);
        skillButton.onClick.AddListener(OnSkillButton);
    }

    private void OnFireButton()
    {
        OnInputAction?.Invoke(InputCommand.Fire);
    }
    
    private void OnFireButton2()
    {
        OnInputAction?.Invoke(InputCommand.Fire2);
    }
    
    private void OnFireButton3()
    {
        OnInputAction?.Invoke(InputCommand.Fire3);
    }
    
    private void OnSkillButton()
    {
        OnInputAction?.Invoke(InputCommand.Skill);
    }
}
