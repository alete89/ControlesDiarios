namespace Controles2016.FORMS
{
    partial class CustomMessageBox
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
            this.BT_acepta = new System.Windows.Forms.Button();
            this.BT_cancela = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(355, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "Uno o más de los valores están muy alejados de los valores de referencia.\r\nRevise" +
    " los datos ingresados e intente nuevamente.\r\nSi la diferencia persiste informe a" +
    " Física.\r\nEl reporte no será guardado\r\n";
            // 
            // BT_acepta
            // 
            this.BT_acepta.Location = new System.Drawing.Point(41, 71);
            this.BT_acepta.Name = "BT_acepta";
            this.BT_acepta.Size = new System.Drawing.Size(122, 41);
            this.BT_acepta.TabIndex = 1;
            this.BT_acepta.Text = "Guardar\r\n(sólo Física)";
            this.BT_acepta.UseVisualStyleBackColor = true;
            this.BT_acepta.Click += new System.EventHandler(this.BT_acepta_Click);
            // 
            // BT_cancela
            // 
            this.BT_cancela.Location = new System.Drawing.Point(212, 71);
            this.BT_cancela.Name = "BT_cancela";
            this.BT_cancela.Size = new System.Drawing.Size(117, 41);
            this.BT_cancela.TabIndex = 2;
            this.BT_cancela.Text = "Volver";
            this.BT_cancela.UseVisualStyleBackColor = true;
            this.BT_cancela.Click += new System.EventHandler(this.BT_cancela_Click);
            // 
            // CustomMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 124);
            this.Controls.Add(this.BT_cancela);
            this.Controls.Add(this.BT_acepta);
            this.Controls.Add(this.label1);
            this.Name = "CustomMessageBox";
            this.Text = "Valores Incorrectos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BT_acepta;
        private System.Windows.Forms.Button BT_cancela;
    }
}