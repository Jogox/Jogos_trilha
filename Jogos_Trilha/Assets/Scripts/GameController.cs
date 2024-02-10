using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    GameObject[,] campos; // Array de campos do tabuleiro
    int[,] array; // Matriz representando o estado do tabuleiro
    int playerVez; // Indica de quem é a vez de jogar
    int movimentosRestantes; // Contador de movimentos restantes

    public static GameController instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        playerVez = 1;
        movimentosRestantes = 24; // Inicialmente, 24 movimentos disponíveis
        array = new int[3, 8];
        campos = new GameObject[3, 8];

        // Preenche o array de campos com os objetos no Unity
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                campos[i, j] = GameObject.Find("Campo_" + i.ToString() + j.ToString());
            }
        }

        InitializeBoard();
    }

    void Update()
    {
        // Lógica de fim de jogo aqui (verificação de vitória ou empate)
    }

    void InitializeBoard()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                array[i, j] = 0;
            }
        }
    }

    public void ValidateMove(int campo, int matriz)
    {
        if (array[matriz, campo] == 0)
        {
            MakeMove(campo, matriz);
        }
        else
        {
            Debug.Log("Jogada Inválida: Campo já ocupado.");
        }
    }

    void MakeMove(int campo, int matriz)
    {
        array[matriz, campo] = playerVez;
        campos[matriz, campo].GetComponent<Renderer>().material.color = (playerVez == 1) ? Color.red : Color.blue; // Muda a cor do campo para indicar a peça do jogador
        movimentosRestantes--;

        if (movimentosRestantes <= 0)
        {
            Debug.Log("Fim do jogo: Empate!");
            return;
        }

        if (CheckForWin(campo, matriz))
        {
            Debug.Log("Fim do jogo: Jogador " + playerVez + " venceu!");
            return;
        }

        playerVez = (playerVez == 1) ? 2 : 1; // Alterna a vez do jogador
        Debug.Log("Vez do Jogador " + playerVez);
    }


    // Método para instanciar uma nova peça
    void InstantiatePiece(int player, int campo, int matriz)
    {
        //   lastPiece =  Instantiate(PiecePrefab[index]);
        // Implemente aqui a lógica de instanciação da peça
    }


 bool CheckForWin(int campo, int matriz)
    {
    int jogadorAtual = playerVez;
    int oponente = (jogadorAtual == 1) ? 2 : 1;

    // Verifica se o jogador atual tem menos de 3 peças, o que significa que o oponente venceu
    int contadorPecasJogadorAtual = 0;
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 8; j++)
        {
            if (array[i, j] == jogadorAtual)
                contadorPecasJogadorAtual++;
        }
    }
    if (contadorPecasJogadorAtual < 3)
        return true;

    // Verifica se o jogador atual formou um moinho na linha ou na coluna do campo recém-colocado
    bool moinho = false;
    // Verifica a linha
    if (array[matriz, (campo + 1) % 8] == jogadorAtual && array[matriz, (campo + 2) % 8] == jogadorAtual)
        moinho = true;
    // Verifica a coluna
    if (array[(matriz + 1) % 3, campo] == jogadorAtual && array[(matriz + 2) % 3, campo] == jogadorAtual)
        moinho = true;

    // Verifica se o jogador atual formou um moinho nas diagonais, se o campo for uma interseção
    if (campo % 2 == 1)
    {
        // Verifica a diagonal principal
        if ((matriz == 0 || matriz == 2) && array[(matriz + 1) % 3, (campo + 1) % 8] == jogadorAtual && array[(matriz + 2) % 3, (campo + 2) % 8] == jogadorAtual)
            moinho = true;
        // Verifica a diagonal secundária
        if ((matriz == 0 || matriz == 2) && array[(matriz + 1) % 3, (campo + 7) % 8] == jogadorAtual && array[(matriz + 2) % 3, (campo + 6) % 8] == jogadorAtual)
            moinho = true;
    }

    return moinho;
}
}
