using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class Board : MonoBehaviour
{
   public GameObject mCellPrefab;
   public static List<string> textArray;
   public GameObject mParentCanvas;

   [HideInInspector]
   private static int size = 5;
   [HideInInspector]
   public Cell[,] mAllCells = new Cell[size,size];
   [HideInInspector]
   public RectTransform parentRT;
   
   public void Create()
   {
      
      for (int x = 0; x < size; x++)
      {
         for (int y = 0; y < size; y++)
         {
            GameObject newCell = Instantiate(mCellPrefab, transform);

            RectTransform rectTransform = newCell.GetComponent<RectTransform>();

            if (size > 10)
            {
               if (size > 15)
               {
                  rectTransform.sizeDelta = new Vector2(40,40);
                  print(rectTransform.rect.height);
                  print(rectTransform.rect.width);
                  rectTransform.anchoredPosition = new Vector2((x * 40) + 50, (y * 40) + 50);
               }
               else
               {
                  rectTransform.sizeDelta = new Vector2(50,50);
                  print(rectTransform.rect.height);
                  print(rectTransform.rect.width);
                  rectTransform.anchoredPosition = new Vector2((x * 50) + 50, (y * 50) + 50);
               }
               
            }
            else
            {
               rectTransform.sizeDelta = new Vector2(75,75);
               print(rectTransform.rect.height);
               print(rectTransform.rect.width);
               rectTransform.anchoredPosition = new Vector2((x * 75) + 50, (y * 75) + 50);
            }

            mAllCells[x, y] = newCell.GetComponent<Cell>();
            mAllCells[x, y].Setup(new Vector2Int(x, y), this);
         }
      }

      //this.transform.localScale(100f, 100f, 100f);
      /*for (int x = 0; x < 5; x+=2)
      {
         for (int y  = 0; y  < 5; y++)
         {
            //int offset = (y % 2 != 0) ? 0 : 1;
            //int finalX = x + offset;

            mAllCells[x, y].GetComponent<Image>().color = new Color32(230, 220, 187, 255);
         }
      }*/
   }
}
