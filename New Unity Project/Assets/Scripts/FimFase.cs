using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FimFase : MonoBehaviour
{
    public string nivel = "Nivel0";

    public void MudarNivel()
    {
        SceneManager.LoadScene(nivel);
    }
}
