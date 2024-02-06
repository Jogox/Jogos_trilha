using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    int [,] array;
    int playerVez;
   
    
    public static GameController instance; 
 
    
    // Start is called before the first frame update
    void Start()
    {
        array = new int[3, 8];
        

        InitializeBoard();
        // lastpiece = GameObject.Find("RedPlayer");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // void OnMouseDown()
    // {
    //     Debug.Log("campo valido");
    // }

    void InitializeBoard(){
        for(int i = 0;i<8;i++)
        {
            for (int m = 0;m < 3; m++)
            {
                array [m,i] = 0;
            }
        
        }
    }

    public void ValidateMove(int campo, int matriz){
        

        if(array[matriz, campo] == 0){
            Debug.Log("Jogada Valida");
            
        }else{
            Debug.Log("Jogada Invalida..............");
        }
    }

    void MakeMove(int campo, int matriz){
        array[matriz,campo] = playerVez;
        if(playerVez == 1){
            playerVez = 2;
        }else{
            playerVez = 1;
        }
    }
}
