
namespace ChangeRoot
{
    public class Solution
    {
        /// <summary>
        /// The idea is to reverse direction of a tree branch that goes from old root to the new one
        /// and marking a newRoot as a new root (setting it's parent to itself).
        /// Rest of the tree doesn't need any change at all.
        /// </summary>
        /// <param name="parent">array of elements where the value of an i'th element in the array is a number of a parent node to the i'th node,</param>
        /// <param name="newRoot">a new root of the tree (parent of the root is the root inselft - parent[v] = v),</param>
        /// <returns>parent array of a new shifted tree.</returns>
        public static int[] changeRoot(int[] parent, int newRoot)
        {
            int currentNode = newRoot;
            // Parent of a new root
            int currentNodeParent = parent[currentNode];
            // Save index of a parent node of the currentNodeParent before changing it to it's children
            int currentNodeGrandparent = parent[currentNodeParent];

            // Change a parent of the new root's parent to newRoot
            parent[currentNodeParent] = currentNode;

            while (currentNodeParent != currentNodeGrandparent) // untill we reached the old root (parent[v] = v, so parent[parent[v]] = v = parent[v])
            {
                // Save indexes of the current node, it's parent and the parent of it's parent
                currentNode = currentNodeParent;
                currentNodeParent = currentNodeGrandparent;
                currentNodeGrandparent = parent[currentNodeParent];
                // Swap children-parent relation to the next node in the tree.
                parent[currentNodeParent] = currentNode;
            }

            // We reached the old root and changed it's parent, mark newRoot as the new root.
            parent[newRoot] = newRoot;

            return parent;
        }
    }
}