using UnityEngine;

public class Rodando : MonoBehaviour
{
    public float raio = 5f; // O raio do c�rculo
    public float velocidade = 2f; // A velocidade de rota��o da esfera
    private float angulo = 0f; // O �ngulo atual da esfera
    private Vector3 posicaoInicial; // A posi��o inicial da esfera

    private void Start()
    {
        posicaoInicial = transform.position;
    }

    private void Update()
    {
        // Incrementa o �ngulo baseado no tempo e velocidade
        angulo += velocidade * Time.deltaTime;

        // Calcula a nova posi��o da esfera no c�rculo
        float x = Mathf.Sin(angulo) * raio;
        float y = Mathf.Cos(angulo) * raio;

        // Define a nova posi��o da esfera, adicionando a posi��o inicial
        transform.position = posicaoInicial + new Vector3(x, y, 0f);
    }
}
