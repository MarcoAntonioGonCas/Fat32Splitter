namespace File_splitters.Forms
{
    partial class FrmMain
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
            this.btnParticionar = new System.Windows.Forms.Button();
            this.btnMezclar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnParticionar
            // 
            this.btnParticionar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnParticionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParticionar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnParticionar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnParticionar.Location = new System.Drawing.Point(12, 64);
            this.btnParticionar.Name = "btnParticionar";
            this.btnParticionar.Size = new System.Drawing.Size(381, 70);
            this.btnParticionar.TabIndex = 7;
            this.btnParticionar.Text = "Particionar";
            this.btnParticionar.UseVisualStyleBackColor = false;
            this.btnParticionar.Click += new System.EventHandler(this.btnParticionar_Click);
            // 
            // btnMezclar
            // 
            this.btnMezclar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnMezclar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMezclar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMezclar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMezclar.Location = new System.Drawing.Point(12, 176);
            this.btnMezclar.Name = "btnMezclar";
            this.btnMezclar.Size = new System.Drawing.Size(381, 70);
            this.btnMezclar.TabIndex = 8;
            this.btnMezclar.Text = "Mezclar";
            this.btnMezclar.UseVisualStyleBackColor = false;
            this.btnMezclar.Click += new System.EventHandler(this.btnMezclar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Selecciona una operación:";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 309);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMezclar);
            this.Controls.Add(this.btnParticionar);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnParticionar;
        private System.Windows.Forms.Button btnMezclar;
        private System.Windows.Forms.Label label1;
    }
}