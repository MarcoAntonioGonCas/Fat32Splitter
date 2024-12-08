namespace File_splitters.Forms
{
    partial class MargeFrm
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTipoParticion = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lsvArchivosPesados = new System.Windows.Forms.ListView();
            this.btnArchivosPesados = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pgrParticion = new System.Windows.Forms.ProgressBar();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCancelar);
            this.panel2.Controls.Add(this.pgrParticion);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cmbTipoParticion);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.lsvArchivosPesados);
            this.panel2.Controls.Add(this.btnArchivosPesados);
            this.panel2.Location = new System.Drawing.Point(12, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(421, 454);
            this.panel2.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Formato:";
            // 
            // cmbTipoParticion
            // 
            this.cmbTipoParticion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoParticion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoParticion.FormattingEnabled = true;
            this.cmbTipoParticion.Location = new System.Drawing.Point(15, 77);
            this.cmbTipoParticion.Name = "cmbTipoParticion";
            this.cmbTipoParticion.Size = new System.Drawing.Size(388, 28);
            this.cmbTipoParticion.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Doble Click para seleccionar";
            // 
            // lsvArchivosPesados
            // 
            this.lsvArchivosPesados.HideSelection = false;
            this.lsvArchivosPesados.Location = new System.Drawing.Point(15, 134);
            this.lsvArchivosPesados.Name = "lsvArchivosPesados";
            this.lsvArchivosPesados.Size = new System.Drawing.Size(388, 230);
            this.lsvArchivosPesados.TabIndex = 9;
            this.lsvArchivosPesados.UseCompatibleStateImageBehavior = false;
            this.lsvArchivosPesados.View = System.Windows.Forms.View.List;
            // 
            // btnArchivosPesados
            // 
            this.btnArchivosPesados.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArchivosPesados.Location = new System.Drawing.Point(12, 10);
            this.btnArchivosPesados.Name = "btnArchivosPesados";
            this.btnArchivosPesados.Size = new System.Drawing.Size(391, 43);
            this.btnArchivosPesados.TabIndex = 8;
            this.btnArchivosPesados.Text = "Buscar archivos particionados";
            this.btnArchivosPesados.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Firebrick;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancelar.Location = new System.Drawing.Point(15, 411);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(388, 43);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Visible = false;
            // 
            // pgrParticion
            // 
            this.pgrParticion.Location = new System.Drawing.Point(15, 374);
            this.pgrParticion.Name = "pgrParticion";
            this.pgrParticion.Size = new System.Drawing.Size(385, 31);
            this.pgrParticion.TabIndex = 13;
            // 
            // MargeFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 493);
            this.Controls.Add(this.panel2);
            this.Name = "MargeFrm";
            this.Text = "Mezclar particiones";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lsvArchivosPesados;
        private System.Windows.Forms.Button btnArchivosPesados;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTipoParticion;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ProgressBar pgrParticion;
    }
}