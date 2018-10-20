
namespace ChangeRoot
{
    public class Solution
    {
        public static int[] changeRoot(int[] parent, int newRoot)
        {
            int currentNode;
            int parentNode = parent[newRoot];
            int oldParentNode = parent[parentNode];

            parent[parentNode] = newRoot;

            while (parentNode != oldParentNode)
            {
                currentNode = parentNode;
                parentNode = oldParentNode;
                oldParentNode = parent[parentNode];
                parent[parentNode] = currentNode;
            }

            parent[newRoot] = newRoot;

            return parent;
        }
    }
}
