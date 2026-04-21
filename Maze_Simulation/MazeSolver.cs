using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Simulation
{
    public class MazeSolver
    {
        // Ilość komórek
        private int cellRows;
        private int cellColumns;

        // Tablica Komórek
        private Cell[,] cells;

        // Punkt początkowy i końcowy labiryntu
        private Point startPoint;
        private Point endPoint;

        // Zbiór wierzchołków
        private List<Node> nodes;
        private List<Node> currentNodes;

        // Przebyta odległość
        private int distance;

        // Czy znaleziono koniec
        private bool isEndFound;
        private bool isFinished;

        // Wierzchołek wyznaczający właściwą ścieżke
        private Node currentNode;

        // Klasa definiująca Wierzchołki
        public class Node
        {
            List<Node> vertices;

            public Node Root { get; }
            public Cell Value { get; set; }

            public Node(Node root, Cell value)
            {
                this.Root = root;
                this.Value = value;
                this.vertices = new List<Node>();
            }

            public void Add(Node node)
            {
                this.vertices.Add(node);
            }
        }

        public MazeSolver(int cellRows, int cellColumns, Cell[,] cells, Point startPoint, Point endPoint)
        {
            this.cellRows = cellRows;
            this.cellColumns = cellColumns;
            this.cells = cells;
            this.startPoint = startPoint;
            this.endPoint = endPoint;
            this.distance = 0;
            this.isEndFound = false;
            this.isFinished = false;

            // Dodanie wierzchołka początkowego
            this.nodes = new List<Node>();
            Node rootNode = new Node(null, cells[startPoint.X, startPoint.Y]);
            this.nodes.Add(rootNode);

            this.currentNodes = new List<Node>();
            this.currentNodes.Add(rootNode);

        }

        public bool SolveStep()
        {
            if(isEndFound == false)
            {
                // Szukanie trasy metodą wyszukiwania w szerz (Breadth-in-first)
                List<Node> copyCurrentNodes = new List<Node>();
                foreach (Node node in this.currentNodes)
                {
                    copyCurrentNodes.Add(node);
                }

                foreach (Node node in copyCurrentNodes)
                {
                    node.Value.Label.BackColor = Color.Yellow;
                    findNeighbours(node);
                    currentNodes.Remove(node);
                }

                this.distance += 1;
                return true;
            }
            else
            {
                // Wracanie wyznaczoną ścieżką
                currentNode.Value.Label.BackColor = Color.Red;
                currentNode = currentNode.Root;

                // Jeśli wrócił na początek
                if (currentNode.Root == null)
                {
                    currentNode.Value.Label.BackColor = Color.Red;
                    isFinished = true;
                }

                return !isFinished;
            }


        }

        public void findNeighbours(Node node)
        {
            int x = node.Value.X;
            int y = node.Value.Y;

            // Ścieżka w góre
            if(x >= 0 && x < this.cellRows &&
                y - 1 >= 0 && y - 1 < this.cellColumns)
            {
                if(cells[x, y - 1].Label.BackColor == Color.White)
                {
                    Node newNode = new Node(node, cells[x, y - 1]);
                    node.Add(newNode);
                    this.nodes.Add(newNode);
                    this.currentNodes.Add(newNode);
                }
                else
                if(cells[x, y - 1].Label.BackColor == Color.Red)
                {
                    isEndFound = true;
                    currentNode = node;
                    return;
                }
            }

            // Ścieżka w prawo
            if (x + 1>= 0 && x + 1 < this.cellRows &&
                y >= 0 && y < this.cellColumns)
            {
                if (cells[x + 1, y].Label.BackColor == Color.White)
                {
                    Node newNode = new Node(node, cells[x + 1, y]);
                    node.Add(newNode);
                    this.nodes.Add(newNode);
                    this.currentNodes.Add(newNode);
                }
                else
                if (cells[x + 1, y].Label.BackColor == Color.Red)
                {
                    isEndFound = true;
                    currentNode = node;
                    return;
                }
            }

            // Ścieżka w dół
            if (x >= 0 && x < this.cellRows &&
                y + 1 >= 0 && y + 1 < this.cellColumns)
            {
                if (cells[x, y + 1].Label.BackColor == Color.White)
                {
                    Node newNode = new Node(node, cells[x, y + 1]);
                    node.Add(newNode);
                    this.nodes.Add(newNode);
                    this.currentNodes.Add(newNode);
                }
                else
                if (cells[x, y + 1].Label.BackColor == Color.Red)
                {
                    isEndFound = true;
                    currentNode = node;
                    return;
                }
            }

            // Ścieżka w lewo
            if (x - 1 >= 0 && x - 1 < this.cellRows &&
                y >= 0 && y < this.cellColumns)
            {
                if (cells[x - 1, y].Label.BackColor == Color.White)
                {
                    Node newNode = new Node(node, cells[x - 1, y]);
                    node.Add(newNode);
                    this.nodes.Add(newNode);
                    this.currentNodes.Add(newNode);
                }
                else
                if (cells[x - 1, y].Label.BackColor == Color.Red)
                {
                    isEndFound = true;
                    currentNode = node;
                    return;
                }
            }
        }


        
    }
}
