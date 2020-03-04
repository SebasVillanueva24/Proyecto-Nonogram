using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
   public GameObject mCellPrefab;
   
   [HideInInspector]
   public Cell[,] mAllCells = new Cell[5,150];

   public void Create()
   {
      for (int x = 0; x < 5; x++)
      {
         for (int y = 0; y < 5; y++)
         {
            GameObject newCell = Instantiate(mCellPrefab, transform);

            RectTransform rectTransform = newCell.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2((x*75)+50,(y*75)+50);

            mAllCells[x, y] = newCell.GetComponent<Cell>();
            mAllCells[x,y].Setup(new Vector2Int(x,y), this);
         }
      }

      for (int x = 0; x < 5; x+=2)
      {
         for (int y  = 0; y  < 5; y++)
         {
            //int offset = (y % 2 != 0) ? 0 : 1;
            //int finalX = x + offset;

            mAllCells[x, y].GetComponent<Image>().color = new Color32(230, 220, 187, 255);
         }
      }
   }
}
