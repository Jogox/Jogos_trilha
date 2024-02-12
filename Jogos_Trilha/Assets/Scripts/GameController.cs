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
    public Move[] AvailableMoves { get; private set; }

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
    public Game()
        {
            AvailableMoves = CalculateAvailableMoves().ToArray();
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



    private void MakeMove(Move move)
    {
        if (move.From == -1)
        {
            // Coloca uma nova peça no tabuleiro
            gameController.PlacePiece(gameController.GetMatrixIndex(move.To), gameController.GetBoardIndex(move.To), gameController.CurrentPlayer);
        }
        else
        {
            // Move uma peça para uma nova posição no tabuleiro
            gameController.MovePiece(gameController.GetMatrixIndex(move.From), gameController.GetBoardIndex(move.From), gameController.GetMatrixIndex(move.To), gameController.GetBoardIndex(move.To));
        }

        // Verifica se o jogador atual formou um moinho
        if (gameController.HasMill(gameController.GetMatrixIndex(move.To), gameController.GetBoardIndex(move.To)))
        {
            // Se sim, verifica se é possível remover uma peça do oponente
            int opponent = (gameController.CurrentPlayer == 1) ? 2 : 1;
            if (gameController.CanRemove(opponent))
            {
                // Remove uma peça do oponente
                gameController.RemovePiece(gameController.GetRemovedPiece(opponent));
            }
        }

        // Passa a vez para o próximo jogador
        gameController.SwitchPlayer();
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
    if (contadorPecasJogadorAtual < 3){
        Debug.Log("WIN................");
        return true;
    }

    
    

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
    Debug.Log("Moinho : "+moinho);
    return moinho;
}
}
