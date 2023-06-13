using UnityEngine;

public class Rodando : MonoBehaviour
{
    public float raio = 5f; // O raio do círculo
    public float velocidade = 2f; // A velocidade de rotação da esfera
    private float angulo = 0f; // O ângulo atual da esfera
    private Vector3 posicaoInicial; // A posição inicial da esfera

    private void Start()
    {
        posicaoInicial = transform.position;
    }

    private void Update()
    {
        // Incrementa o ângulo baseado no tempo e velocidade
        angulo += velocidade * Time.deltaTime;

        // Calcula a nova posição da esfera no círculo
        float x = Mathf.Sin(angulo) * raio;
        float y = Mathf.Cos(angulo) * raio;

        // Define a nova posição da esfera, adicionando a posição inicial
        transform.position = posicaoInicial + new Vector3(x, y, 0f);
    }
}
