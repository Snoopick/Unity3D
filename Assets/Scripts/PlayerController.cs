using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CharacterState
{
    Idle,
    Move,
    Attack,
    Skill,
    Hit,
    Dead,
}


[RequireComponent(typeof(Animator))]

public class PlayerController : MonoBehaviour
{
    private CharacterState characterState;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject ballPrefab2;
    [SerializeField] private GameObject ballPrefab3;
    [SerializeField] private Transform firePoint;
    [SerializeField] private int skillBallsCount;
    [SerializeField] private float skillAngleBound = 45f;
    [SerializeField] private GameObject SkillEffect;
    private static readonly int AttackTrigger = Animator.StringToHash("Attack");
    private static readonly int SkillTrigger = Animator.StringToHash("Skill");

    public void AttackEvent(int type)
    {
        if (type == 1)
        {
            var obj = Instantiate(ballPrefab, firePoint.transform.position, Quaternion.identity);
            var rig = obj.GetComponent<Rigidbody>();
            
            if (rig)
            {
                rig.AddForce(Vector3.forward * 5f, ForceMode.Impulse);
            }
        }
        else if (type == 2)
        {
            var obj = Instantiate(ballPrefab2, firePoint.transform.position, Quaternion.identity);
            var rig = obj.GetComponent<Rigidbody>();
            
            if (rig)
            {
                rig.AddForce(Vector3.forward * 5f, ForceMode.Impulse);
            }
        } 
        else if (type == 3)
        {
            var obj = Instantiate(ballPrefab3, firePoint.transform.position, Quaternion.identity);
            var rig = obj.GetComponent<Rigidbody>();
            
            if (rig)
            {
                rig.AddForce(Vector3.forward * 5f, ForceMode.Impulse);
            }
        }
    }

    public void SkillEvent()
    {
        var angleStep = skillAngleBound * 2 / (skillBallsCount - 1);
        
        for (int i = 0; i < skillBallsCount; i++)
        {
            var y = skillAngleBound - i * angleStep;
            var rotation = Quaternion.Euler(0f, y, 0f);
            var obj = Instantiate(ballPrefab, firePoint.transform.position, rotation);
            obj.transform.Translate(obj.transform.forward * 0.3f);
            var rig = obj.GetComponent<Rigidbody>();
            
            if (rig)
            {
                rig.AddForce(obj.transform.forward * 5f, ForceMode.Impulse);
            }
            
            SkillEffect.SetActive(false);
        }
    }
    
    private void Reset()
    {
        animator = GetComponent<Animator>();
    }


    // Start is called before the first frame update
    void Start()
    {
        characterState = CharacterState.Move;
        InputController.OnInputAction += OnInputCommand;
//        Move(true);
        StartCoroutine(MovementProccess(5f));
    }

    private IEnumerator MovementProccess(float time)
    {
        animator.SetInteger("Movement", 1);
        var timer = Time.time + time;
        while (Time.time < timer)
        {
            transform.Translate(transform.forward * Time.deltaTime);
            yield return null;
        }

        characterState = CharacterState.Idle;
        animator.SetInteger("Movement", 0);
    }
    
    private void OnDestroy()
    {
        InputController.OnInputAction -= OnInputCommand;
    }

    private void OnInputCommand(InputCommand inputCommand)
    {
        switch (inputCommand)
        {
            case InputCommand.Fire:
                Attack(1);
                break;
            case InputCommand.Fire2:
                Attack(2);
                break;
            case InputCommand.Fire3:
                Attack(3);
                break;
            case InputCommand.Skill:
                Skill();
                break;
        }
    }

    private void Attack(int type)
    {
        if (characterState == CharacterState.Attack || characterState == CharacterState.Skill)
        {
            return;
        }

        switch (type)
        {
            case 1:
                animator.SetTrigger(AttackTrigger);
                break;
            case 2:
                animator.SetTrigger("Attack2");
                break;
            case 3:
                animator.SetTrigger("Attack3");
                break;
        }
        
        
        characterState = CharacterState.Attack;
        DelayRun.Execute(delegate { characterState = CharacterState.Idle; }, 0.5f, gameObject);
    }

    private void Skill()
    {
        if (characterState == CharacterState.Attack || characterState == CharacterState.Skill)
        {
            return;
        }
        
        SkillEffect.SetActive(true);
        animator.SetTrigger(SkillTrigger);
        characterState = CharacterState.Skill;
        DelayRun.Execute(delegate { characterState = CharacterState.Idle; }, 1.29f, gameObject);
    }

    private void Move(bool start)
    {
        
    }

    private void Idle()
    {
        
    }
}
