using UnityEngine;

public class PersonagemRPG : MonoBehaviour
{
    string nome;
    int vida;
    float velocidade;
    int nivel;
    bool estaVivo;

    const int VIDA_MAXIMA = 100;
    const float GRAVIDADE = 9.81f;

    void Start()
    {
        nome = "Gregor";
        vida = 100;
        velocidade = 7.5f;
        nivel = 3;
        estaVivo = true;

        Debug.Log($"=== Ficha do Personagem === Nome: {nome} | Nível: {nivel} Vida: {vida}/{VIDA_MAXIMA} | Velocidade: {velocidade} Status: Vivo");

        vida = 50;

        Debug.Log($"=== Ficha do Personagem === Nome: {nome} | Nível: {nivel} Vida: {vida}/{VIDA_MAXIMA} | Velocidade: {velocidade} Status: Vivo");
    }
}
