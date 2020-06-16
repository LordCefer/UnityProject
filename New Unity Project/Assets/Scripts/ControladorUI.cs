using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControladorUI : MonoBehaviour
{
    public TextMeshProUGUI textoMoedas;
    public Jogador jogador;

    // Update is called once per frame
    void Update()
    {
        textoMoedas.text = "x";
        textoMoedas.text += jogador.moedas.ToString();
    }
}