using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boardcount : MonoBehaviour
{
    public GameObject[] board;
    private int boardnumcount=0;


 public  void prev()
    {
        board[boardnumcount].SetActive(false);
        boardnumcount++;
        board[boardnumcount].SetActive(true);
    }
   public  void back()
    {
        board[boardnumcount].SetActive(false);
        boardnumcount--;
        board[boardnumcount].SetActive(true);
    }
}
