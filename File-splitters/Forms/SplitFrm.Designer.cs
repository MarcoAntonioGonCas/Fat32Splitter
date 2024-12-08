namespace File_splitters.Forms
{
    partial class SplitFrm
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
            this.BtnSeleccionarArchivo = new System.Windows.Forms.Button();
            this.pgrParticion = new System.Windows.Forms.ProgressBar();
            this.lblInfoProgreso = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTipoParticion = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnParticionar = new System.Windows.Forms.Button();
            this.btnArchivosPesados = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblArchivo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lsvArchivosPesados = new System.Windows.Forms.ListView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnSeleccionarArchivo
            // 
            this.BtnSeleccionarArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSeleccionarArchivo.Location = new System.Drawing.Point(27, 56);
            this.BtnSeleccionarArchivo.Name = "BtnSeleccionarArchivo";
            this.BtnSeleccionarArchivo.Size = new System.Drawing.Size(459, 43);
            this.BtnSeleccionarArchivo.TabIndex = 0;
            this.BtnSeleccionarArchivo.Text = "Seleccionar archivo";
            this.BtnSeleccionarArchivo.UseVisualStyleBackColor = true;
            this.BtnSeleccionarArchivo.Click += new System.EventHandler(this.BtnSeleccionarArchivo_Click);
            // 
            // pgrParticion
            // 
            this.pgrParticion.Location = new System.Drawing.Point(12, 258);
            this.pgrParticion.Name = "pgrParticion";
            this.pgrParticion.Size = new System.Drawing.Size(456, 31);
            this.pgrParticion.TabIndex = 1;
            // 
            // lblInfoProgreso
            // 
            this.lblInfoProgreso.AutoSize = true;
            this.lblInfoProgreso.Location = new System.Drawing.Point(12, 173);
            this.lblInfoProgreso.Name = "lblInfoProgreso";
            this.lblInfoProgreso.Size = new System.Drawing.Size(0, 13);
            this.lblInfoProgreso.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Archivo:";
            // 
            // cmbTipoParticion
            // 
            this.cmbTipoParticion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoParticion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoParticion.FormattingEnabled = true;
            this.cmbTipoParticion.Location = new System.Drawing.Point(27, 144);
            this.cmbTipoParticion.Name = "cmbTipoParticion";
            this.cmbTipoParticion.Size = new System.Drawing.Size(456, 28);
            this.cmbTipoParticion.TabIndex = 4;
            this.cmbTipoParticion.SelectedIndexChanged += new System.EventHandler(this.cmbTipoParticion_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Formato:";
            // 
            // btnParticionar
            // 
            this.btnParticionar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnParticionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParticionar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnParticionar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnParticionar.Location = new System.Drawing.Point(24, 222);
            this.btnParticionar.Name = "btnParticionar";
            this.btnParticionar.Size = new System.Drawing.Size(459, 48);
            this.btnParticionar.TabIndex = 6;
            this.btnParticionar.Text = "Particionar";
            this.btnParticionar.UseVisualStyleBackColor = false;
            this.btnParticionar.Click += new System.EventHandler(this.btnParticionar_Click);
            // 
            // btnArchivosPesados
            // 
            this.btnArchivosPesados.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArchivosPesados.Location = new System.Drawing.Point(12, 10);
            this.btnArchivosPesados.Name = "btnArchivosPesados";
            this.btnArchivosPesados.Size = new System.Drawing.Size(399, 43);
            this.btnArchivosPesados.TabIndex = 8;
            this.btnArchivosPesados.Text = "Buscar archivos mayores a 4GB";
            this.btnArchivosPesados.UseVisualStyleBackColor = true;
            this.btnArchivosPesados.Click += new System.EventHandler(this.btnArchivosPesados_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblInfoProgreso);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.lblArchivo);
            this.panel1.Controls.Add(this.pgrParticion);
            this.panel1.Location = new System.Drawing.Point(12, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(486, 349);
            this.panel1.TabIndex = 9;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Firebrick;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancelar.Location = new System.Drawing.Point(12, 295);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(459, 43);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblArchivo
            // 
            this.lblArchivo.AutoSize = true;
            this.lblArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArchivo.Location = new System.Drawing.Point(90, 11);
            this.lblArchivo.Name = "lblArchivo";
            this.lblArchivo.Size = new System.Drawing.Size(0, 20);
            this.lblArchivo.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.lsvArchivosPesados);
            this.panel2.Controls.Add(this.btnArchivosPesados);
            this.panel2.Location = new System.Drawing.Point(513, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(416, 349);
            this.panel2.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Doble Click para seleccionar";
            // 
            // lsvArchivosPesados
            // 
            this.lsvArchivosPesados.HideSelection = false;
            this.lsvArchivosPesados.Location = new System.Drawing.Point(12, 75);
            this.lsvArchivosPesados.Name = "lsvArchivosPesados";
            this.lsvArchivosPesados.Size = new System.Drawing.Size(388, 230);
            this.lsvArchivosPesados.TabIndex = 9;
            this.lsvArchivosPesados.UseCompatibleStateImageBehavior = false;
            this.lsvArchivosPesados.View = System.Windows.Forms.View.List;
            this.lsvArchivosPesados.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsvArchivosPesados_MouseDoubleClick);
            // 
            // SplitFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 393);
            this.Controls.Add(this.btnParticionar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTipoParticion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnSeleccionarArchivo);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SplitFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Particionador de archivos";
            this.Load += new System.EventHandler(this.SplitFrm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnSeleccionarArchivo;
        private System.Windows.Forms.ProgressBar pgrParticion;
        private System.Windows.Forms.Label lblInfoProgreso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTipoParticion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnParticionar;
        private System.Windows.Forms.Button btnArchivosPesados;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lsvArchivosPesados;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblArchivo;
        private System.Windows.Forms.Button btnCancelar;
    }
}