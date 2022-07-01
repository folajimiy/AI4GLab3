using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{

    public static HashSet<Node> closedList;

    /// Calculate the final path in the path finding
    private static ArrayList CalculatePath(Node node)
    {
        ArrayList list = new ArrayList();
        while (node != null)
        {
            list.Add(node);
            node = node.parent;
        }
        list.Reverse();
        return list;
    }

  
    // Calculate the estimated Heuristic cost to the goal
    private static float HeuristicEstimateCost(Node curNode, Node goalNode)
    {
        Vector3 vecCost = curNode.position - goalNode.position;
        return vecCost.magnitude;
    }


    public static ArrayList BFS(Node start, Node goal)
    {
        //Start Finding the path
        Queue openList = new Queue();
        openList.Enqueue(start);  

        closedList = new HashSet<Node>();

        Node node = null;

        while (openList.Count != 0)
        {
            node = (Node)openList.Dequeue();

            if (node.position == goal.position)
            {
                return CalculatePath(node);
            }

            ArrayList neighbours = new ArrayList();
            GridManager.instance.GetNeighbours(node, neighbours);

            #region CheckNeighbours

            //Get the Neighbours
            for (int i = 0; i < neighbours.Count; i++)
            {
                Node neighbourNode = (Node)neighbours[i];

                if (!closedList.Contains(neighbourNode))
                {                    
                    neighbourNode.parent = node;
                    
                    //Add the neighbour node to the list if not already existed in the list
                    if (!openList.Contains(neighbourNode))
                    {
                        openList.Enqueue(neighbourNode);
                    }
                }
            }

            #endregion

            closedList.Add(node);
            //openList.Dequeue(node);
        }

        //If finished looping and cannot find the goal then return null
        if (node.position != goal.position)
        {
            Debug.LogError("Goal Not Found");
            return null;
        }

        //Calculate the path based on the final node
        return CalculatePath(node);
    }



    public static ArrayList DFS(Node start, Node goal)
    {
        // your DFS implementation here

        return null;
    }


    // Find the path between start node and goal node using AStar Algorithm
    public static ArrayList AStar(Node start, Node goal)
    {


        // your AStar implementation here
        // Hint: 
        // call HeuristicEstimateCost to return the cost between the two nodes
        // call  CalculatePath method with the current node parameter 
        //  to return a path array from the start node to the target node

        return null;

    }


    
}
