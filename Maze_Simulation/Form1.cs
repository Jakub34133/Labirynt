using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze_Simulation
{
    public partial class Form1 : Form
    {
        // Rozmiar komórek
        private int cellWidth = 20;
        private int cellHeight = 20;

        // Ilość komórek (dla wyglądu (krawędzi) polecana liczba nieparzysta)
        private int cellRows = 51;
        private int cellColumns = 31;

        // Tablica komórek
        private Cell[,] cells;

        // Punkt początkowy i końcowy
        private Point startPoint;
        private Point endPoint;


        // Kontrolery
        private MazeGenerator mazeGenerator;
        private MazeSolver mazeSolver;

        public Form1()
        {
            InitializeComponent();

            // Zmiana szerokości okna
            this.Width = cellRows * cellWidth + 20;
            this.Height = cellColumns * cellHeight + 80;

            // Ustawienie punktu początkowego w lewym górnym rogu
            startPoint = new Point(1, 1);
            // Ustawienie punktu końcowego w dolnym prawym rogu
            endPoint = new Point(cellRows - 2, cellColumns - 2);

            // Dodanie komórek
            InitializeGrid();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void InitializeGrid()
        {
            // Inicjalizacja tablicy komórek
            cells = new Cell[cellRows, cellColumns];

            // Pętla dodawania komórek
            for(int i = 0; i < cellRows; i++)
            {
                for(int j = 0; j < cellColumns; j++)
                {
                    // Właściwości komórki
                    Label label = new Label();
                    label.Width = cellWidth;
                    label.Height = cellHeight;
                    label.BorderStyle = BorderStyle.FixedSingle;
                    label.Location = new Point(i * cellWidth, j * cellHeight);
                    label.BackColor = Color.Black;

                    // Dodanie komórki
                    gridMaze.Controls.Add(label);
                    cells[i, j] = new Cell(i, j, label);
                }
            } // koniec pętli dodawania komórek
        }

        // Generowanie labiryntu
        private void generateMaze_Click(object sender, EventArgs e)
        {
            // Wyłączenie przycisku rozwiązywania labiryntu
            solveMaze.Enabled = false;

            // Generowanie labiryntu
            mazeGenerator = new MazeGenerator(this.cells, cellRows, cellColumns, this.startPoint);

            generateMazeTimer.Start();
        }

        private void generateMazeTimer_Tick(object sender, EventArgs e)
        {
            if(mazeGenerator.GenerateStep() == false)
            {
                generateMazeTimer.Stop();

                // Ustawienie punktu początkowego oraz końcowego
                cells[startPoint.X, startPoint.Y].Label.BackColor = Color.Yellow;
                cells[endPoint.X, endPoint.Y].Label.BackColor = Color.Red;

                // Włączenie przycisku rozwiązywania labiryntu
                solveMaze.Enabled = true;
            }
        }

        // Rozwiązywanie labiryntu
        private void solveMaze_Click(object sender, EventArgs e)
        {
            // Wyłączenie przycisku generowania labiryntu
            generateMaze.Enabled = false;
            solveMaze.Enabled = false;

            mazeSolver = new MazeSolver(
                this.cellRows,
                this.cellColumns,
                this.cells,
                this.startPoint,
                this.endPoint);

            solveMazeTimer.Start();
        }

        private void solveMazeTimer_Tick(object sender, EventArgs e)
        {
            if(mazeSolver.SolveStep() == false)
            {
                solveMazeTimer.Stop();
                generateMaze.Enabled = true;
            }
        }

        // Czyszczenie planszy
        private void clearButton_Click(object sender, EventArgs e)
        {
            // Zatrzymaj symulacje
            generateMazeTimer.Stop();
            solveMazeTimer.Stop();

            // Wyłączenie przycisku rozwiązywania labiryntu
            solveMaze.Enabled = false;

            // Włączenie przycisku generowania labiryntu
            generateMaze.Enabled = true;

            // Wyczyść plaszę
            mazeGenerator.Clear();
        }
    }
}
