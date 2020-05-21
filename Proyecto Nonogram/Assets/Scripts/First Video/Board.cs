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
    public Cell[,] mAllCells;

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

   public void Create(string readPath)
   {
        
        ReadFile(readPath);

        char[] separator = {',',' '};
        String[] size = textArray[0].Split(separator);

        int rows = Int32.Parse(size[0].ToString());
        int columns = Int32.Parse(size[2].ToString());

        mAllCells = new Cell[rows, columns];

        int fila = 0;
        int columna = 0;

        for (int y = rows-1; y >= 0; y--)
        {
            columna = 0;
            for (int x = 0; x < columns; x++)
            {
                
                GameObject newCell = Instantiate(mCellPrefab, transform);

                RectTransform rectTransform = newCell.GetComponent<RectTransform>();

                if (rows > 11)
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

                mAllCells[fila, columna] = newCell.GetComponent<Cell>();
                mAllCells[fila, columna].Setup(new Vector2Int(x, y), this);
                columna++;
            }
            fila++;
        }

        int offset = 50;
        int contadorTextoFilas = 1 + rows;

        for (int x = 0; x < rows; x++)
        {
            GameObject newCell2 = Instantiate(mClueCellPrefab, transform);
            RectTransform newCellR = newCell2.GetComponent<RectTransform>();
            newCellR.sizeDelta = new Vector2(200, 75);
            newCellR.anchoredPosition = new Vector2((mAllCells[0, 0].MRectTransform.anchoredPosition.x) - 137, offset);
            newCell2.GetComponentInChildren<Text>().text = textArray[contadorTextoFilas];
            contadorTextoFilas--;
            offset = offset + 75;
        }

        //print(contadorTextoFilas);

        float offsetColumnas = mAllCells[0, 0].MRectTransform.anchoredPosition.x;
        int contadorTextoColumnas = contadorTextoFilas + rows + 2;

        for (int y = 0; y < columns; y++)
        {
            GameObject newCell2 = Instantiate(mClueCellPrefab2, transform);
            RectTransform newCellR = newCell2.GetComponent<RectTransform>();
            newCellR.sizeDelta = new Vector2(75, 200);
            newCellR.anchoredPosition = new Vector2(offsetColumnas, (mAllCells[0, 0].MRectTransform.anchoredPosition.y) + 150);
            newCell2.GetComponentInChildren<Text>().text = textArray[contadorTextoColumnas];
            contadorTextoColumnas++;
            offsetColumnas = offsetColumnas + 75f;
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
