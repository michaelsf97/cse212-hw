public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {

        // 1. Handle Duplicate Case: If the value is already in the tree, do nothing!
        if (value == Data)
        {
            return;
        }

        // TODO Start Problem 1

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {

        // Base Case 1: We found the value!
        if (value == Data)
        {
            return true;
        }

        // TODO Start Problem 2
        // If the target value is smaller, search the left subtree
        if (value < Data)
        {
            // If there's nothing on the left, the value doesn't exist in the tree
            if (Left is null)
            {
                return false;
            }
            // Otherwise, recursively ask the left child
            return Left.Contains(value);
    }
    // If the target value is larger, search the right subtree
    else // value < Data
        {
            // If there's nothing on the right, the value doesn't exist in the tree
            if (Right is null)
            {
                return false;
            }
            // Otherwise, recursively ask the right child
            return Right.Contains(value);
        }
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        // 1. If a child exists, ask it for its height. If it's null, its height branch value is 0.
        int leftHeight = (Left is null) ? 0 : Left.GetHeight();
        int rightHeight = (Right is null) ? 0 : Right.GetHeight();

        // 2. The height of the current node is 1 + whichever side is taller
        return 1 + Math.Max(leftHeight, rightHeight); // Replace this line with the correct return statement(s)
    }
}