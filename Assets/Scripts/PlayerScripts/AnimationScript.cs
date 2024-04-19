using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    [SerializeField]
    private GameObject attackCollider;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private PlayerMoves playerMoves;
    [SerializeField]
    private InputControllers inputControllers;
    public bool walk;
    public bool attack;
    public bool run;
    public bool talk;

    void Start()
    {
        
        animator = GetComponent<Animator>();
        inputControllers = GetComponent<InputControllers>();
        playerMoves = GetComponent<PlayerMoves>();
        attackCollider = GameObject.FindWithTag("AttackCollider");
    }
    void Update()
    {
       
          
        animator.SetFloat("InputX",inputControllers.movimentoHorizontal);
        animator.SetFloat("InputY",inputControllers.movimentoVertical);
        walk = inputControllers.movimentoHorizontal > 0 || inputControllers.movimentoVertical > 0;    
        attack = inputControllers.Attack;
        //animator.SetBool("Attack" , attack);
        if(walk == false && inputControllers.build == true)
        {
             animator.SetBool("Build",true);
        }
        if(walk == false && talk == true)
        {
            animator.SetBool("Talk",true);
        }
        if(walk == true)
        {
             animator.SetBool("Build", false);
             animator.SetBool("Talk", false);
             talk = false;
        }
       

        run = inputControllers.Run;
        animator.SetBool("Run", run);
         
    }   
    public void EnableCollison()
    {
        attackCollider.GetComponent<Collider>().enabled = true;
      
    }
    public void DisableCollison()
    {
        attackCollider.GetComponent<Collider>().enabled = false;
   
    }
    public void TalkAnim()
    {
        talk = true;
    }
}
