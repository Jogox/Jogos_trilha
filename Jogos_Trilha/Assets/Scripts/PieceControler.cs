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

    void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
        rb.isKinematic = true;
        
    
    }

    void OnMouseUp()
    {
        
        isDragging = false;
        if (validMove){
              rb.isKinematic =false;
        // }else {
        //     Vector3.MoveTowards(transform.position, initialPos, speed*Time.deltaTime);   
        // }
    
      //  GetComponent<Rigidbody>().isKinematic =false;
      

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
}
}

//     void  OnTriggerEnter2D(Collider2D other) {
//         if(other.CompareTag("column")){
//             int colindex = 0;
//             int.TryParse(other.gameObject.name, out colindex);
//             colindex -=1;
//             if(colindex >= 0){
//              OnMove(player, colindex);

//             } 
//         }else if (other.gameObject.name.Equals("AreaValida")){
//             validMove =  true;


//         }
        
//     }
//     void onTriggernExit2D(Collider2D other){
//        if (other.gameObject.name.Equals("AreaValida")){
//             validMove =  false;

//        }
// }

