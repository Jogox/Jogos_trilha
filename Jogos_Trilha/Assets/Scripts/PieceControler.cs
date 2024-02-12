 using UnityEngine;

public class PieceControler : MonoBehaviour
{
    [SerializeField]
    private bool validMove;
    int player;
    int speed;
    public delegate void Move(int pl, int col);
    public static Move OnMove;
    private bool isDragging = false;
    private Vector3 offset;
    private Rigidbody2D rb;
    private Vector3 posInitial;

    void Start()
    {
        speed = 10;
        rb = GetComponent<Rigidbody2D>();
        // Desativar o Rigidbody no início para que o objeto não caia de imediato
        rb.isKinematic = true;
        // inititalPos = transform.position;
        validMove = false;
    }
    private void OnMouseDown()
    {
        if (gameManager.CurrentPlayer != 1 || gameManager.IsGameOver)
            return;

        if (gameManager.MoveState == MoveState.RemoveStone)
        {
            if (gameController.CanRemove(boardPosition))
            {
                gameController.RemoveStone(boardPosition);
                gameController.RemoveStone(boardPosition);
            }
        }
        else if (gameController.MoveState == MoveState.MoveStone)
        {
            if (matrizPosition != -1)
            {
                // Iniciar o arrasto da peça
                StartDragging();
            }
        }
    }

  private void OnMouseUp()
    {
        if (gameManager.MoveState == MoveState.MoveStone)
        {
            if (IsDragging())
            {
                // Solta a peça e tenta colocá-la em uma posição válida no tabuleiro
                DropPiece();
            }
        }
    }

    private void OnMouseDrag()
    {
        if (gameManager.MoveState == MoveState.MoveStone)
        {
            if (IsDragging())
            {
                // Arrasta a peça
                DragPiece();
            }
        }
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, offset.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
            transform.position = curPosition;
        }
    }
    private bool IsDragging()
    {
        // Verifica se a peça está sendo arrastada
        // Por exemplo, verifica se a flag de arrasto está ativada ou se o componente Rigidbody está ativo
        return false; // Altere conforme a implementação
    }

    private void DragPiece()
    {
        // Lógica para arrastar a peça
        // Por exemplo, movimentar a peça na direção do mouse
    }



private void DropPiece()
    {
        // Solta a peça e tenta colocá-la em uma posição válida no tabuleiro
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        (Vector3 location, int boardPos, float dist) nearestPositionInfo = gameController.GetNearestPosition(mousePosition);
        if (nearestPositionInfo.dist < 3.0f && gameManager.Board[nearestPositionInfo.boardPos] == 0)
        {
            // Movimenta a peça para a posição mais próxima válida no tabuleiro
            gameController.MoveStone(boardPosition, nearestPositionInfo.boardPos);
            gameManager.MoveStone(boardPosition, nearestPositionInfo.boardPos);
            boardPosition = nearestPositionInfo.boardPos;
            transform.position = nearestPositionInfo.location;
        }
        else
        {
            // Retorna a peça para a posição original
            transform.position = gameController.GetBoardPosition(boardPosition);
        }
    }
}

