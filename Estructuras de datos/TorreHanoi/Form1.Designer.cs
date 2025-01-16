namespace TorreHanoi
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.t1Tot2 = new System.Windows.Forms.Button();
            this.t2Tot1 = new System.Windows.Forms.Button();
            this.t1Tot3 = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.t2Tot3 = new System.Windows.Forms.Button();
            this.t3Tot2 = new System.Windows.Forms.Button();
            this.t3Tot1 = new System.Windows.Forms.Button();
            this.buttonJugar = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.labelMovimientos = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Ravie", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 22;
            this.listBox1.Location = new System.Drawing.Point(298, 63);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(137, 268);
            this.listBox1.TabIndex = 0;
            // 
            // t1Tot2
            // 
            this.t1Tot2.Location = new System.Drawing.Point(298, 346);
            this.t1Tot2.Name = "t1Tot2";
            this.t1Tot2.Size = new System.Drawing.Size(62, 44);
            this.t1Tot2.TabIndex = 1;
            this.t1Tot2.Text = "A la torre 2";
            this.t1Tot2.UseVisualStyleBackColor = true;
            this.t1Tot2.Click += new System.EventHandler(this.t1Tot2_Click);
            // 
            // t2Tot1
            // 
            this.t2Tot1.Location = new System.Drawing.Point(495, 346);
            this.t2Tot1.Name = "t2Tot1";
            this.t2Tot1.Size = new System.Drawing.Size(62, 44);
            this.t2Tot1.TabIndex = 2;
            this.t2Tot1.Text = "A la torre 1";
            this.t2Tot1.UseVisualStyleBackColor = true;
            this.t2Tot1.Click += new System.EventHandler(this.t2Tot1_Click);
            // 
            // t1Tot3
            // 
            this.t1Tot3.Location = new System.Drawing.Point(373, 346);
            this.t1Tot3.Name = "t1Tot3";
            this.t1Tot3.Size = new System.Drawing.Size(62, 44);
            this.t1Tot3.TabIndex = 3;
            this.t1Tot3.Text = "A la torre 3";
            this.t1Tot3.UseVisualStyleBackColor = true;
            this.t1Tot3.Click += new System.EventHandler(this.t1Tot3_Click);
            // 
            // listBox2
            // 
            this.listBox2.Font = new System.Drawing.Font("Ravie", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 22;
            this.listBox2.Location = new System.Drawing.Point(495, 63);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(137, 268);
            this.listBox2.TabIndex = 4;
            // 
            // listBox3
            // 
            this.listBox3.Font = new System.Drawing.Font("Ravie", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 22;
            this.listBox3.Location = new System.Drawing.Point(698, 63);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(137, 268);
            this.listBox3.TabIndex = 5;
            // 
            // t2Tot3
            // 
            this.t2Tot3.Location = new System.Drawing.Point(570, 346);
            this.t2Tot3.Name = "t2Tot3";
            this.t2Tot3.Size = new System.Drawing.Size(62, 44);
            this.t2Tot3.TabIndex = 6;
            this.t2Tot3.Text = "A la torre 3";
            this.t2Tot3.UseVisualStyleBackColor = true;
            this.t2Tot3.Click += new System.EventHandler(this.t2Tot3_Click);
            // 
            // t3Tot2
            // 
            this.t3Tot2.Location = new System.Drawing.Point(698, 346);
            this.t3Tot2.Name = "t3Tot2";
            this.t3Tot2.Size = new System.Drawing.Size(62, 44);
            this.t3Tot2.TabIndex = 7;
            this.t3Tot2.Text = "A la torre 2";
            this.t3Tot2.UseVisualStyleBackColor = true;
            this.t3Tot2.Click += new System.EventHandler(this.t3Tot2_Click);
            // 
            // t3Tot1
            // 
            this.t3Tot1.Location = new System.Drawing.Point(773, 346);
            this.t3Tot1.Name = "t3Tot1";
            this.t3Tot1.Size = new System.Drawing.Size(62, 44);
            this.t3Tot1.TabIndex = 8;
            this.t3Tot1.Text = "A la torre 1";
            this.t3Tot1.UseVisualStyleBackColor = true;
            this.t3Tot1.Click += new System.EventHandler(this.t3Tot1_Click);
            // 
            // buttonJugar
            // 
            this.buttonJugar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonJugar.Location = new System.Drawing.Point(43, 133);
            this.buttonJugar.Name = "buttonJugar";
            this.buttonJugar.Size = new System.Drawing.Size(181, 39);
            this.buttonJugar.TabIndex = 9;
            this.buttonJugar.Text = "Jugar";
            this.buttonJugar.UseVisualStyleBackColor = true;
            this.buttonJugar.Click += new System.EventHandler(this.buttonJugar_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Location = new System.Drawing.Point(43, 94);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(181, 26);
            this.numericUpDown1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Cantidad de discos";
            // 
            // labelMovimientos
            // 
            this.labelMovimientos.AutoSize = true;
            this.labelMovimientos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMovimientos.Location = new System.Drawing.Point(40, 231);
            this.labelMovimientos.Name = "labelMovimientos";
            this.labelMovimientos.Size = new System.Drawing.Size(13, 20);
            this.labelMovimientos.TabIndex = 12;
            this.labelMovimientos.Text = " ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 450);
            this.Controls.Add(this.labelMovimientos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.buttonJugar);
            this.Controls.Add(this.t3Tot1);
            this.Controls.Add(this.t3Tot2);
            this.Controls.Add(this.t2Tot3);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.t1Tot3);
            this.Controls.Add(this.t2Tot1);
            this.Controls.Add(this.t1Tot2);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button t1Tot2;
        private System.Windows.Forms.Button t2Tot1;
        private System.Windows.Forms.Button t1Tot3;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Button t2Tot3;
        private System.Windows.Forms.Button t3Tot2;
        private System.Windows.Forms.Button t3Tot1;
        private System.Windows.Forms.Button buttonJugar;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelMovimientos;
    }
}

