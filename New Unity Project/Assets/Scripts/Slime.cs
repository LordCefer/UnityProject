using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controlador2D))]
public class Slime : MonoBehaviour
{
    public float alturaPulo = 4f;
    public float tempoParaApicePulo = 0.4f;
    public float intervaloEntrePulos = 2f;
    public float contadorIntervaloEntrePulos;
    private float gravidade;
    private float velocidadePulo;
    private Vector2 velocidade;

    private Controlador2D controlador;

    public int vidaMaxima = 1;
    public int vidaAtual;

    void Start()
    {
        controlador = GetComponent<Controlador2D>();

        gravidade = -(alturaPulo * 2) / Mathf.Pow(tempoParaApicePulo, 2);
        velocidadePulo = Mathf.Abs(gravidade) * tempoParaApicePulo;

        vidaAtual = vidaMaxima;
    }

    void Update()
    {
        if (controlador.colisoes.abaixo || controlador.colisoes.acima)
            velocidade.y = 0f;

        contadorIntervaloEntrePulos -= Time.deltaTime;

        if (contadorIntervaloEntrePulos <= 0f)
        {
            if (controlador.colisoes.abaixo)
            {
                velocidade.y = velocidadePulo;
            }

            contadorIntervaloEntrePulos = intervaloEntrePulos;
        }

        velocidade.y += gravidade * Time.deltaTime;

        controlador.Mover(velocidade * Time.deltaTime);
    }

    public void MudarVida(int valor)
    {
        vidaAtual += valor;

        if (vidaAtual > vidaMaxima)
        {
            vidaAtual = vidaMaxima;
        }

        if (vidaAtual <= 0)
        {
            Morrer();
        }
    }
    
    private void Morrer()
    {
        controlador.mascaraPlataforma = LayerMask.GetMask("Nothing");
        Destroy(this.gameObject, 2);
    }
}