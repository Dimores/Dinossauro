using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    // Pegar a velocidade inicial do player
    private float velocidadeInicial = 0f;

    // Variável para incrementar a velocidade do player
    private float velocidadeAtual = 0f;

    private PlayerController playerController; // Variável de classe

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>(); // Instanciando a classe do dino
        velocidadeInicial = playerController.getSpeed();
    }

    private IEnumerator aumentaSpeed()
    {
        velocidadeAtual = 2 * velocidadeInicial;
        playerController.setSpeed(velocidadeAtual);
        yield return new WaitForSeconds(3);
        velocidadeAtual = velocidadeInicial;
        playerController.setSpeed(velocidadeAtual);
        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Colidiu com player");
            StartCoroutine(aumentaSpeed());
        }
    }
}
