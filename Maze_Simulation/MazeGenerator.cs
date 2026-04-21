using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze_Simulation
{
    public class MazeGenerator
    {
        // Ilość komórek
        private int cellRows;
        private int cellColumns;

        // Tablica Komórek
        private Cell[,] cells;

        // Ścieżka
        private List<Cell> path;

        // Pozycja
        private Point currentPosition;

        Random random = new Random();

        public MazeGenerator(Cell[,] cells, int rows, int columns, Point startPoint)
        {
            this.cells = cells;
            this.cellRows = rows;
            this.cellColumns = columns;
            this.path = new List<Cell>();
            this.currentPosition = startPoint;
            Clear();
        }

        public void Clear()
        {
            for(int i = 0; i < cellRows; i++)
            {
                for(int j = 0; j < cellColumns; j++)
                {
                    cells[i, j].Label.BackColor = Color.Black;
                }
            }
                
        }

        public bool GenerateStep()
        {
            // Zapobiegnięcie wyjścia poza zakres labiryntu
            int x = currentPosition.X;
            int y = currentPosition.Y;

            if(x < 0 || x >= cellRows ||
                y < 0 || y >= cellColumns)
            {
                return false;
            }

            // Generacja labiryntu

            // (1) Wylosowanie kierunku
            // 0 - góra, 1 - prawo, 2 - dół, 3 - lewo
            bool isPath = true;

            bool isUp = true;
            bool isRight = true;
            bool isDown = true;
            bool isLeft = true;

            do
            {
                int direction = random.Next(0, 4);

                
                if (direction == 0 && isUp == true)
                {
                    // góra
                    if (moveUp() == false)
                        isUp = false;
                    else
                        break;
                }
                else
                if (direction == 1 && isRight == true)
                {
                    // prawo
                    if (moveRight() == false)
                        isRight = false;
                    else
                        break;
                }
                else
                if (direction == 2 && isDown == true)
                {
                    // dół
                    if (moveDown() == false)
                        isDown = false;
                    else
                        break;
                }
                else
                if (direction == 3 && isLeft == true)
                {
                    // lewo
                    if (moveLeft() == false)
                        isLeft = false;
                    else
                        break;
                }

                // Jeśli w żadnym kierunku nie można pójść
                if (!isUp && !isRight && !isDown && !isLeft)
                {
                    isPath = false;
                    break;
                }


            } while(isPath);

            // Nie ma drogi
            if(isPath == false)
            {
                cells[x, y].Label.BackColor = Color.White;

                if(path.Count > 1)
                {
                    // Nie ma drogi - zawróć
                    path.RemoveAt(path.Count - 1); // usuń ostatni element
                    currentPosition.X = path.ElementAt(path.Count - 1).X;
                    currentPosition.Y = path.ElementAt(path.Count - 1).Y;

                }
                else
                {
                    // Nie ma drogi, ani gdzie zawrócić - zakończ
                    return false;
                }

            }

            return true;
        }

        private bool moveUp()
        {
            int x = currentPosition.X;
            int y = currentPosition.Y;

            // Jeśli wyjdzie poza zakres
            // lub jeśli już jest tam ścieżka
            if(y - 2 < 0 || cells[x,y-2].Label.BackColor == Color.White)
            {
                return false;
            }

            // Przejdź w górę
            cells[x, y].Label.BackColor = Color.White;
            cells[x, y-1].Label.BackColor = Color.White;

            path.Add(cells[x, y]);

            currentPosition.Y -= 2;

            return true;
        }

        private bool moveRight()
        {
            int x = currentPosition.X;
            int y = currentPosition.Y;

            // Jeśli wyjdzie poza zakres
            // lub jeśli już jest tam ścieżka
            if (x + 2 >= cellRows || cells[x + 2, y].Label.BackColor == Color.White)
            {
                return false;
            }

            // Przejdź w prawo
            cells[x, y].Label.BackColor = Color.White;
            cells[x + 1, y].Label.BackColor = Color.White;

            path.Add(cells[x, y]);

            currentPosition.X += 2;

            return true;
        }

        private bool moveDown()
        {
            int x = currentPosition.X;
            int y = currentPosition.Y;

            // Jeśli wyjdzie poza zakres
            // lub jeśli już jest tam ścieżka
            if (y + 2 >= cellColumns || cells[x, y + 2].Label.BackColor == Color.White)
            {
                return false;
            }

            // Przejdź w dół
            cells[x, y].Label.BackColor = Color.White;
            cells[x, y + 1].Label.BackColor = Color.White;

            path.Add(cells[x, y]);

            currentPosition.Y += 2;

            return true;
        }

        private bool moveLeft()
        {
            int x = currentPosition.X;
            int y = currentPosition.Y;

            // Jeśli wyjdzie poza zakres
            // lub jeśli już jest tam ścieżka
            if (x - 2 < 0 || cells[x - 2, y].Label.BackColor == Color.White)
            {
                return false;
            }

            // Przejdź w lewo
            cells[x, y].Label.BackColor = Color.White;
            cells[x - 1, y].Label.BackColor = Color.White;

            path.Add(cells[x, y]);

            currentPosition.X -= 2;

            return true;
        }


    }
}
