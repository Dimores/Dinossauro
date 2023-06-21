using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour, IAtaque, IMovimento
{
    // Rigidbody
    private Rigidbody rb;

    [Header("Movimentação")]
    [Tooltip("Velocidade de movimento.")]
    [SerializeField] private float speed = 2f;
    [Tooltip("Força do Pulo.")]
    [SerializeField] private float jumpForce = 0f;
    // Sprint será 1.5 * speed
    private float sprint = 0f;

    [Header("Ataques")]
    [Tooltip("Dano do ataque fraco.")]
    [SerializeField] private float weakAttack = 0;
    [Tooltip("Dano do ataque forte.")]
    [SerializeField] private float strongAttack = 0;
    [Tooltip("Dano do ataque a distância.")]
    [SerializeField] private float rangedAttack = 0;

    [Header("Rotação")]
    [Tooltip("Velocidade de rotação.")]

    // Variáveis booleanas para verificação
    private bool canJump = false;
    private bool isWalking = false;
    private bool isRunning = false;

    // Variaveis para pegar input do movimento
    private float moveX = 0f;
    private float moveZ = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
  
        sprint = 1.5f * speed;

        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");

        Movimento();
        Pular();
    }
 

    // Funções de Ataque
    public void AtaqueFraco()
    {
        // Causa dano usando o weakAttack
        Debug.Log("Usou ataque fraco.");
    }

    public void AtaqueForte()
    {
        // Causa dano usando o strongAttack
        Debug.Log("Usou ataque forte.");
    }

    public void AtaqueDistancia()
    {
        // Causa dano usando o rangedAttack
        Debug.Log("Usou ataque a distancia.");
    }

    // Funções de movimentação
    public void Andar()
    {
        isWalking = true;
        isRunning = false;
        Vector3 andar = new Vector3(this.moveX, 0f, this.moveZ).normalized;

        rb.velocity = new Vector3(andar.x *speed, rb.velocity.y, andar.z*speed) ; // Andando
    }

    public void Correr()
    {
            isWalking = false;
            isRunning = true;
            Vector3 correr = new Vector3(this.moveX, 0f, this.moveZ).normalized;

            rb.velocity = new Vector3(correr.x * sprint, rb.velocity.y, correr.z * sprint); // Correndo
    }

    public void Pular()
    {
        if(Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            // Pula usando o jumpForce
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            canJump = false;
        }
    }

    public void Movimento()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Correr();
        }
        else
        {
            Andar();
        }
    }

    // Funções de Get e Set
    public void setSpeed(float speed)
    {
        this.speed = speed;
    }

    public float getSpeed()
    {
        return this.speed;
    }

    public void setWeakAtk(float weakAttack)
    {
        this.weakAttack = weakAttack;
    }

    public float getWeakAtk()
    {
        return this.weakAttack;
    }

    // Funções pra verificar colisao
    public void OnCollisionEnter(Collision colisor)
    {
        // Verifica se existe colisao com o chao atraves do indice da Layer "Ground"
        if(colisor.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            canJump = true;
            //Debug.Log("Pode pular");
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        canJump = false;
        //Debug.Log("Não pode pular");
    }
}
