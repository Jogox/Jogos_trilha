using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePiece : MonoBehaviour
    

{
    // Start is called before the first frame update
    public GameObject playerPrefab;
    // Update is called once per frame
   private void Awake()
    {
        // playerPrefab = Resources.Load<GameObject>("player1");
        // Instantiate(playerPrefab,Vector3.zero,Quaternion.identity);
         // Carrega o prefab do jogador da pasta Resources
        playerPrefab = Resources.Load<GameObject>("player1");
        
        // Define a posição desejada para a instância
        Vector3 newPosition = new Vector3(10.91f, -0.28f, 0f); // Defina a posição desejada aqui
        
        // Instancia o jogador na nova posição
        Instantiate(playerPrefab, newPosition, Quaternion.identity);
        
    }
}


    
     
    // using UnityEngine;

// using UnityEngine;

// public class InstantiatePieces : MonoBehaviour
// {
//     public GameObject playerPrefab1; // O prefab da primeira peça
//     public GameObject playerPrefab2; // O prefab da segunda peça
//     public int maxPairs = 9; // O número máximo de pares de peças a serem instanciados
//     public float spacing = 1f; // Espaçamento entre as peças

//     private void Awake()
//     {
//         // Instanciar as peças iniciais
//         InstantiatePairs();
//     }

//     private void InstantiatePairs()
//     {
//         // Verificar se o número atual de pares é menor que o limite máximo
//         if (transform.childCount / 2 < maxPairs)
//         {
//             // Calcula a posição do próximo par com base no número atual de pares e no espaçamento
//             Vector3 newPosition = new Vector3((transform.childCount / 2) * spacing, 0f, 0f);

//             // Instancia um par de peças na nova posição
//             Instantiate(playerPrefab1, newPosition, Quaternion.identity, transform);
//             Instantiate(playerPrefab2, newPosition, Quaternion.identity, transform);
//         }
//     }
// }
// using UnityEngine;

// using UnityEngine;

// using UnityEngine;

// public class InstantiatePiece : MonoBehaviour
// {
//     public GameObject player1PiecePrefab; // Prefab da peça do jogador 1
//     public GameObject player2PiecePrefab; // Prefab da peça do jogador 2
//     public Transform board; // Referência ao tabuleiro onde as peças serão colocadas
//     public int maxPieces = 9; // Número máximo de peças que podem ser colocadas no tabuleiro

//     private bool player1Turn = true; // Variável para controlar de quem é a vez

//     // Função para validar e realizar uma jogada
//     public void MakeMove(int campo, int matriz)
//     {
//         // Verifica se ainda há espaço para mais peças
//         if (board.childCount < maxPieces * 2)
//         {
//             // Escolhe o prefab de peça com base no turno do jogador
//             GameObject piecePrefab = player1Turn ? player1PiecePrefab : player2PiecePrefab;

//             // Instancia a peça do jogador atual no tabuleiro
//             GameObject newPiece = Instantiate(piecePrefab, board);

            

//             // Alterna o turno do jogador
//             player1Turn = !player1Turn;
//         }
//     }
// }