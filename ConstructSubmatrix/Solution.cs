
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConstructSubmatrix
{
    public class Solution
    {
        public static int[][] ConstructSubmatrix(int[][] matrix, int[] rowsToDelete, int[] columnsToDelete)
        {
            Array.Sort(rowsToDelete);
            Array.Sort(columnsToDelete);

            return ShrinkMatrix(matrix, rowsToDelete, columnsToDelete);
        }

        /// <summary>
        /// Given a matrix, return a submatrix that contains all matrix rows and columns 
        /// but no with indexes within rowsToDelete (delete this rows) 
        /// or columnsToDelete (delete items with given indexes from each row that left).
        /// </summary>
        /// <param name="matrix">matrix from which a shrinked one will be created,</param>
        /// <param name="rowsToDelete">sorted (in ascending order) array of indexes of rows to be deleted from the matrix,</param>
        /// <param name="columnsToDelete">sorted (in ascending order) array of indexes of items in given 
        /// matrix row (columns of a i'th matrix row) to be deleted.</param>
        /// <returns>Submatrix of the input matrix.</returns>
        private static int[][] ShrinkMatrix(int[][] matrix, int[] rowsToDelete, int[] columnsToDelete)
        {
            int numberOfRows = matrix.Length;
            int numberOfRowsToBeDeleted = rowsToDelete.Length;
            int numberOfRowsInSubMatrix = numberOfRows - numberOfRowsToBeDeleted;

            int[][] submatrix = new int[numberOfRowsInSubMatrix][];

            int iIdx = 0;
            int iSubIdx = 0;
            int rowIdxToDelete = 0;

            // Until we are OK with all bounderies
            while (iIdx < numberOfRows   //  bounds of matrix rows
                && iSubIdx < numberOfRowsInSubMatrix   // bounds of the submatrix
                && rowIdxToDelete < numberOfRowsToBeDeleted // bounds of the array
            )
            {
                // If given row is not signed to be deleted
                if (iIdx != rowsToDelete[rowIdxToDelete])
                {
                    submatrix[iSubIdx] = RemoveItemsFromMatrixRaw(matrix[iIdx], columnsToDelete);
                    iSubIdx += 1;
                }
                else   // we hit a row to be deleted, we just skip it
                {
                    // and go the the next row (if any) which should be deleted.
                    rowIdxToDelete += 1;
                }
                iIdx += 1;
            }

            while (iSubIdx < numberOfRowsInSubMatrix)
            {
                submatrix[iSubIdx] = RemoveItemsFromMatrixRaw(matrix[iIdx], columnsToDelete);
                iIdx += 1;
                iSubIdx += 1;
            }
            return RemoveEmptyRowsFromMatrix(submatrix);
        }

        /// <summary>
        /// Given an specified i'th row of a matrix, remove from it j'th elements 
        /// where j is an index contained by columnsToDelete array.
        /// </summary>
        /// <param name="matrixRowToShrink">i'th row of a matrix</param>
        /// <param name="columnsToDelete">sorted (in ascending order) array of indexes of items in given 
        /// matrix row (columns of a i'th matrix row) to be deleted.</param>
        /// <returns>New shrinked row of the given matrixRowToShrink.</returns>
        private static int[] RemoveItemsFromMatrixRaw(int[] matrixRowToShrink, int[] columnsToDelete)
        {
            int jIdx = 0;
            int jSubIdx = 0;
            int columnIdxToDelete = 0;

            int numberOfColumns = matrixRowToShrink.Length;
            int numberOfColumnsToBeDeleted = columnsToDelete.Length;
            int numberOfColumnsInSubMatrix = numberOfColumns - numberOfColumnsToBeDeleted;

            int[] subrow = new int[numberOfColumnsInSubMatrix];

            // Until we are OK with all bounderies
            while (jIdx < numberOfColumns   //  bounds of the given row of the full matrix
                && jSubIdx < numberOfColumnsInSubMatrix // bounds of the submatrix
                && columnIdxToDelete < numberOfColumnsToBeDeleted   // bounds of the array
            )
            {
                // If given item of the matrixRowToShrink is NOT signed to be deleted, it should be copied.
                if (jIdx != columnsToDelete[columnIdxToDelete])
                {
                    subrow[jSubIdx] = matrixRowToShrink[jIdx];
                    jSubIdx += 1;
                }
                else   // otherwise skip it (as columnsToDelete is sorted in ascending order and jSubIdx is also increasing).
                {
                    columnIdxToDelete += 1;
                }
                jIdx += 1;
            }

            // Just copy all rows that left.
            while (jSubIdx < numberOfColumnsInSubMatrix)
            {
                subrow[jSubIdx] = matrixRowToShrink[jIdx];
                jIdx += 1;
                jSubIdx += 1;
            }
            return subrow;
        }

        private static int[][] RemoveEmptyRowsFromMatrix(int[][] submatrix)
        {
            IList<int[]> rows = new List<int[]>();
            foreach (var row in submatrix)
            {
                if (row.Length > 0)
                {
                    rows.Add(row);
                }
            }
            return rows.ToArray();
        }
    }
}
