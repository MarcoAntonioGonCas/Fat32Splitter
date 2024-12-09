namespace File_splitters.Forms
{
    partial class MergeFrm
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblArchivo = new System.Windows.Forms.Label();
            this.lblInfoProgreso = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pgrMezcla = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTipoParticion = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lsvArchivosParticionados = new System.Windows.Forms.ListView();
            this.btnBuscarArchivosParticionados = new System.Windows.Forms.Button();
            this.chkEliminarPartesFinalizar = new System.Windows.Forms.CheckBox();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chkEliminarPartesFinalizar);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lblArchivo);
            this.panel2.Controls.Add(this.lblInfoProgreso);
            this.panel2.Controls.Add(this.btnCancelar);
            this.panel2.Controls.Add(this.pgrMezcla);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cmbTipoParticion);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.lsvArchivosParticionados);
            this.panel2.Controls.Add(this.btnBuscarArchivosParticionados);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(421, 499);
            this.panel2.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "Archivo:";
            // 
            // lblArchivo
            // 
            this.lblArchivo.AutoSize = true;
            this.lblArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArchivo.Location = new System.Drawing.Point(89, 10);
            this.lblArchivo.Name = "lblArchivo";
            this.lblArchivo.Size = new System.Drawing.Size(0, 20);
            this.lblArchivo.TabIndex = 17;
            // 
            // lblInfoProgreso
            // 
            this.lblInfoProgreso.AutoSize = true;
            this.lblInfoProgreso.Location = new System.Drawing.Point(12, 394);
            this.lblInfoProgreso.Name = "lblInfoProgreso";
            this.lblInfoProgreso.Size = new System.Drawing.Size(0, 13);
            this.lblInfoProgreso.TabIndex = 16;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Firebrick;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancelar.Location = new System.Drawing.Point(15, 451);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(388, 43);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // pgrMezcla
            // 
            this.pgrMezcla.Location = new System.Drawing.Point(15, 414);
            this.pgrMezcla.Name = "pgrMezcla";
            this.pgrMezcla.Size = new System.Drawing.Size(385, 31);
            this.pgrMezcla.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 77);
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
            this.cmbTipoParticion.Location = new System.Drawing.Point(15, 100);
            this.cmbTipoParticion.Name = "cmbTipoParticion";
            this.cmbTipoParticion.Size = new System.Drawing.Size(388, 28);
            this.cmbTipoParticion.TabIndex = 11;
            this.cmbTipoParticion.SelectedIndexChanged += new System.EventHandler(this.cmbTipoParticion_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Doble Click para seleccionar";
            // 
            // lsvArchivosParticionados
            // 
            this.lsvArchivosParticionados.HideSelection = false;
            this.lsvArchivosParticionados.Location = new System.Drawing.Point(15, 198);
            this.lsvArchivosParticionados.Name = "lsvArchivosParticionados";
            this.lsvArchivosParticionados.Size = new System.Drawing.Size(388, 189);
            this.lsvArchivosParticionados.TabIndex = 9;
            this.lsvArchivosParticionados.UseCompatibleStateImageBehavior = false;
            this.lsvArchivosParticionados.View = System.Windows.Forms.View.List;
            this.lsvArchivosParticionados.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsvArchivosParticionados_MouseDoubleClick);
            // 
            // btnBuscarArchivosParticionados
            // 
            this.btnBuscarArchivosParticionados.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarArchivosParticionados.Location = new System.Drawing.Point(12, 33);
            this.btnBuscarArchivosParticionados.Name = "btnBuscarArchivosParticionados";
            this.btnBuscarArchivosParticionados.Size = new System.Drawing.Size(391, 43);
            this.btnBuscarArchivosParticionados.TabIndex = 8;
            this.btnBuscarArchivosParticionados.Text = "Buscar archivos particionados";
            this.btnBuscarArchivosParticionados.UseVisualStyleBackColor = true;
            this.btnBuscarArchivosParticionados.Click += new System.EventHandler(this.btnBuscarArchivosParticionados_Click);
            // 
            // chkEliminarPartesFinalizar
            // 
            this.chkEliminarPartesFinalizar.AutoSize = true;
            this.chkEliminarPartesFinalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEliminarPartesFinalizar.Location = new System.Drawing.Point(15, 138);
            this.chkEliminarPartesFinalizar.Name = "chkEliminarPartesFinalizar";
            this.chkEliminarPartesFinalizar.Size = new System.Drawing.Size(189, 21);
            this.chkEliminarPartesFinalizar.TabIndex = 19;
            this.chkEliminarPartesFinalizar.Text = "Eliminar partes al finalizar";
            this.chkEliminarPartesFinalizar.UseVisualStyleBackColor = true;
            // 
            // MergeFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 523);
            this.Controls.Add(this.panel2);
            this.Name = "MergeFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mezclar particiones";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lsvArchivosParticionados;
        private System.Windows.Forms.Button btnBuscarArchivosParticionados;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTipoParticion;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ProgressBar pgrMezcla;
        private System.Windows.Forms.Label lblInfoProgreso;
        private System.Windows.Forms.Label lblArchivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkEliminarPartesFinalizar;
    }
}