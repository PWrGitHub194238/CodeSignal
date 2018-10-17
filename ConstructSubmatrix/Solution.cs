
using System;

namespace ConstructSubmatrix
{
    public class Solution
    {
        public static int[][] constructSubmatrix(int[][] matrix, int[] rowsToDelete, int[] columnsToDelete)
        {
            int numberOfRows = matrix.Length;
            int numberOfColumns = matrix[0].Length;
            int numberOfRowsToBeDeleted = rowsToDelete.Length;
            int numberOfColumnsToBeDeleted = columnsToDelete.Length;
            int numberOfRowsInSubMatrix = numberOfRows - numberOfRowsToBeDeleted;
            int numberOfColumnsInSubMatrix = numberOfColumns - numberOfColumnsToBeDeleted;

            int[][] submatrix = new int[numberOfRowsInSubMatrix][];

            Array.Sort(rowsToDelete);
            Array.Sort(columnsToDelete);

            int i = 0;
            int iSubIdx = 0;
            int rowIdxToDelete = 0;

            int j;
            int jSubIdx = 0;
            int columnIdxToDelete;
            int[] tmpCollumn;
            while (i < numberOfRows && rowIdxToDelete < numberOfRowsToBeDeleted && iSubIdx < numberOfRowsInSubMatrix)
            {
                if (i != rowsToDelete[rowIdxToDelete])
                {
                    j = 0;
                    jSubIdx = 0;
                    columnIdxToDelete = 0;
                    tmpCollumn = new int[numberOfColumnsInSubMatrix];
                    while (j < numberOfColumns && columnIdxToDelete < numberOfColumnsToBeDeleted && jSubIdx < numberOfColumnsInSubMatrix)
                    {
                        if (j != columnsToDelete[columnIdxToDelete])
                        {
                            tmpCollumn[jSubIdx] = matrix[i][j];
                            jSubIdx += 1;
                        }
                        else
                        {
                            columnIdxToDelete += 1;
                        }
                        j += 1;
                    }
                    while (jSubIdx < numberOfColumnsInSubMatrix)
                    {
                        tmpCollumn[jSubIdx] = matrix[i][j];
                        j += 1;
                        jSubIdx += 1;
                    }
                    submatrix[iSubIdx] = tmpCollumn;
                    iSubIdx += 1;
                }
                else
                {
                    rowIdxToDelete += 1;
                }
                i += 1;
            }

            while (iSubIdx < numberOfRowsInSubMatrix)
            {
                j = 0;
                jSubIdx = 0;
                columnIdxToDelete = 0;
                tmpCollumn = new int[numberOfColumnsInSubMatrix];
                while (j < numberOfColumns && columnIdxToDelete < numberOfColumnsToBeDeleted && jSubIdx < numberOfColumnsInSubMatrix)
                {
                    if (j != columnsToDelete[columnIdxToDelete])
                    {
                        tmpCollumn[jSubIdx] = matrix[i][j];
                        jSubIdx += 1;
                    }
                    else
                    {
                        columnIdxToDelete += 1;
                    }
                    j += 1;
                }
                while (jSubIdx < numberOfColumnsInSubMatrix)
                {
                    tmpCollumn[jSubIdx] = matrix[i][j];
                    j += 1;
                    jSubIdx += 1;
                }


                submatrix[iSubIdx] = tmpCollumn;
                i += 1;
                iSubIdx += 1;
            }
            return submatrix;
        }
    }
}
