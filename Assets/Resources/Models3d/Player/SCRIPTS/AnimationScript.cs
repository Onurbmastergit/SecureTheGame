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

    void Start()
    {
        animator = GetComponent<Animator>();
        inputControllers = GetComponent<InputControllers>();
        playerMoves = GetComponent<PlayerMoves>();
        attackCollider = GameObject.FindWithTag("AttackCollider");
    }
    void Update()
    {
        walk = playerMoves.movimentoHorizontal != 0 || playerMoves.movimentoVertical != 0;
        animator.SetBool("Walk", walk);

        attack = inputControllers.Attack;
        animator.SetBool("Attack" , attack);

        run = inputControllers.Run;
        animator.SetBool("Run", run);
         
    }   
    public void EnableCollison()
    {
        attackCollider.GetComponent<Collider>().enabled = true;
        attackCollider.GetComponent<MeshRenderer>().enabled = true;
    }
    public void DisableCollison()
    {
        attackCollider.GetComponent<Collider>().enabled = false;
        attackCollider.GetComponent<MeshRenderer>().enabled = false;
    }
}
