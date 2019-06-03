namespace Parcial1_EnmanuelPaulino.UI.Consulta
{
    partial class TotalInventario
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
            this.label1 = new System.Windows.Forms.Label();
            this.TotalTextBox = new System.Windows.Forms.TextBox();
            this.Refrescar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Inventario";
            // 
            // TotalTextBox
            // 
            this.TotalTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalTextBox.Location = new System.Drawing.Point(46, 78);
            this.TotalTextBox.Name = "TotalTextBox";
            this.TotalTextBox.ReadOnly = true;
            this.TotalTextBox.Size = new System.Drawing.Size(178, 38);
            this.TotalTextBox.TabIndex = 1;
            // 
            // Refrescar
            // 
            this.Refrescar.Image = global::Parcial1_EnmanuelPaulino.Properties.Resources.iconfinder_view_refresh_118801;
            this.Refrescar.Location = new System.Drawing.Point(230, 78);
            this.Refrescar.Name = "Refrescar";
            this.Refrescar.Size = new System.Drawing.Size(107, 38);
            this.Refrescar.TabIndex = 2;
            this.Refrescar.Text = "Refrescar";
            this.Refrescar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Refrescar.UseVisualStyleBackColor = true;
            this.Refrescar.Click += new System.EventHandler(this.Refrescar_Click);
            // 
            // TotalInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 191);
            this.Controls.Add(this.Refrescar);
            this.Controls.Add(this.TotalTextBox);
            this.Controls.Add(this.label1);
            this.Name = "TotalInventario";
            this.Text = "Total Inventario";
            this.Load += new System.EventHandler(this.TotalInventario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TotalTextBox;
        private System.Windows.Forms.Button Refrescar;
    }
}