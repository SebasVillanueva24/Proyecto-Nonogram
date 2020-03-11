using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class Board : MonoBehaviour
{
   public GameObject mCellPrefab;
   public GameObject mClueCellPrefab;
   public GameObject mClueCellPrefab2;
   public GameObject mParentCanvas;
   public string filePath;

   private static int rows;
   private static int columns;
   public static List<string> textArray = new List<string>();
   
   [HideInInspector]
   public string readPath;
   
   void ReadFile(string FilePath)
   {
      StreamReader sReader = new StreamReader(FilePath);

      while (!sReader.EndOfStream)
      {
         string line = sReader.ReadLine();
         textArray.Add(line);
      }
      
      sReader.Close();
   }

   public void Create()
   {
      readPath = Application.dataPath + "/2x3.txt";
      ReadFile(readPath);

      char[] separator = {',',' '};
      String[] separator2 = {"FILAS", "COLUMNAS"};
      String[] size = textArray[0].Split(separator);
      
      
      int rows = 11;
      int columns = 11;
      
      Cell[,] mAllCells = new Cell[columns, rows];

      String[] text = textArray.ToArray();
      
      Type t = textArray[0].GetType();

      Type a1 = typeof(String[]);

      for (int x = 0; x < columns; x++)
      {
         for (int y = 0; y < rows; y++)
         {
            
            GameObject newCell = Instantiate(mCellPrefab, transform);

            RectTransform rectTransform = newCell.GetComponent<RectTransform>();

            if (rows > 10)
            {
               if (rows > 15)
               {
                  rectTransform.sizeDelta = new Vector2(40, 40);
                  rectTransform.anchoredPosition = new Vector2((x * 40) + 300, (y * 40) + 50);
               }
               else
               {
                  rectTransform.sizeDelta = new Vector2(50, 50);
                  rectTransform.anchoredPosition = new Vector2((x * 50) + 300, (y * 50) + 50);
               }

            }
            else
            {
               rectTransform.sizeDelta = new Vector2(75, 75);
               rectTransform.anchoredPosition = new Vector2((x * 75) + 300, (y * 75) + 50);
            }

            mAllCells[x, y] = newCell.GetComponent<Cell>();
            mAllCells[x, y].Setup(new Vector2Int(x, y), this);
         }
      }

      int offset = 50;
      
      for (int x = 0; x < rows; x++)
      {
         mClueCellPrefab.GetComponent<RectTransform>().sizeDelta = new Vector2(200,50);
         GameObject newCell2 = Instantiate(mClueCellPrefab, transform);
         RectTransform newCellR = newCell2.GetComponent<RectTransform>();
         newCellR.sizeDelta = new Vector2(200,50);
         newCellR.anchoredPosition = new Vector2((mAllCells[0, 0].MRectTransform.anchoredPosition.x)-137,offset);
         offset = offset + 50;
      }
      
      int offsetColumnas = 300;
      
      for (int x = 0; x < columns; x++)
      {
         GameObject newCell2 = Instantiate(mClueCellPrefab2, transform);
         RectTransform newCellR = newCell2.GetComponent<RectTransform>();
         newCellR.sizeDelta = new Vector2(50,200);
         newCellR.anchoredPosition = new Vector2(offsetColumnas,(mAllCells[0, columns-1].MRectTransform.anchoredPosition.y)+150);
         offsetColumnas = offsetColumnas + 50;
      }

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
