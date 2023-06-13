using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class DinoController : MonoBehaviour, IAtaque, IMovimento
{
    // Rigidbody
    private Rigidbody rb;

    [Header("Movimentação")]
    [Tooltip("Velocidade de movimento.")]
    [SerializeField] private float speed = 2f;
    [Tooltip("Velocidade da corrida.")]
    [SerializeField] private float sprint = 4f;
    [Tooltip("Força do Pulo.")]
    [SerializeField] private float jumpForce = 0f;

    [Header("Ataques")]
    [Tooltip("Dano do ataque fraco.")]
    [SerializeField] private float weakAttack = 0;
    [Tooltip("Dano do ataque forte.")]
    [SerializeField] private float strongAttack = 0;
    [Tooltip("Dano do ataque a distância.")]
    [SerializeField] private float rangedAttack = 0;

    [Header("Rotação")]
    [Tooltip("Velocidade de rotação.")]

    // Variáveis para Layers
    [SerializeField] private LayerMask ground;

    // Variáveis booleanas para verificação
    private bool canJump = false;
    private bool isWalking = false;
    private bool isRunning = false;


    public float rotationSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Variáveis para Input do movimento
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        
        Correr(moveX, moveZ);


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
    public void Andar(float x, float z)
    {
        isWalking = true;
        isRunning = false;
        Vector3 andar = new Vector3(x, rb.velocity.y, z).normalized;
        rb.velocity = andar * speed; // Andando
    }

    public void Correr(float x, float z)
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            isWalking = false;
            isRunning = true;
            Vector3 correr = new Vector3(x, rb.velocity.y, z).normalized;
            rb.velocity = correr * sprint; //Correndo
        }
        else
        {
            Andar(x, z);
        }
    }

    public void Pular()
    {
        if(Input.GetKey(KeyCode.Space) && canJump)
        {
            // Pula usando o jumpForce
            rb.velocity = new Vector3(0f, jumpForce * Time.deltaTime, 0f);
        }
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
