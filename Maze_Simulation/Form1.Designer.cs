namespace Maze_Simulation
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.solveMaze = new System.Windows.Forms.Button();
            this.generateMaze = new System.Windows.Forms.Button();
            this.gridMaze = new System.Windows.Forms.Label();
            this.generateMazeTimer = new System.Windows.Forms.Timer(this.components);
            this.solveMazeTimer = new System.Windows.Forms.Timer(this.components);
            this.clearButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gridMaze, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel1.Controls.Add(this.solveMaze);
            this.flowLayoutPanel1.Controls.Add(this.generateMaze);
            this.flowLayoutPanel1.Controls.Add(this.clearButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(794, 44);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // solveMaze
            // 
            this.solveMaze.AutoSize = true;
            this.solveMaze.Enabled = false;
            this.solveMaze.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.solveMaze.Location = new System.Drawing.Point(622, 3);
            this.solveMaze.Name = "solveMaze";
            this.solveMaze.Size = new System.Drawing.Size(169, 35);
            this.solveMaze.TabIndex = 0;
            this.solveMaze.Text = "Rozwiąż Labirynt";
            this.solveMaze.UseVisualStyleBackColor = true;
            this.solveMaze.Click += new System.EventHandler(this.solveMaze_Click);
            // 
            // generateMaze
            // 
            this.generateMaze.AutoSize = true;
            this.generateMaze.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.generateMaze.Location = new System.Drawing.Point(451, 3);
            this.generateMaze.Name = "generateMaze";
            this.generateMaze.Size = new System.Drawing.Size(165, 35);
            this.generateMaze.TabIndex = 1;
            this.generateMaze.Text = "Generuj Labirynt";
            this.generateMaze.UseVisualStyleBackColor = true;
            this.generateMaze.Click += new System.EventHandler(this.generateMaze_Click);
            // 
            // gridMaze
            // 
            this.gridMaze.AutoSize = true;
            this.gridMaze.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMaze.Location = new System.Drawing.Point(3, 50);
            this.gridMaze.Name = "gridMaze";
            this.gridMaze.Size = new System.Drawing.Size(794, 400);
            this.gridMaze.TabIndex = 1;
            // 
            // generateMazeTimer
            // 
            this.generateMazeTimer.Interval = 10;
            this.generateMazeTimer.Tick += new System.EventHandler(this.generateMazeTimer_Tick);
            // 
            // solveMazeTimer
            // 
            this.solveMazeTimer.Interval = 10;
            this.solveMazeTimer.Tick += new System.EventHandler(this.solveMazeTimer_Tick);
            // 
            // clearButton
            // 
            this.clearButton.AutoSize = true;
            this.clearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.clearButton.Location = new System.Drawing.Point(280, 3);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(165, 35);
            this.clearButton.TabIndex = 2;
            this.clearButton.Text = "Wyczyść";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Labirynt";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button solveMaze;
        private System.Windows.Forms.Button generateMaze;
        private System.Windows.Forms.Label gridMaze;
        private System.Windows.Forms.Timer generateMazeTimer;
        private System.Windows.Forms.Timer solveMazeTimer;
        private System.Windows.Forms.Button clearButton;
    }
}

