namespace ABD_Monitoreo_MongoDB
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lbxColecciones = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblColecciones = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.txbId = new System.Windows.Forms.TextBox();
            this.txb2 = new System.Windows.Forms.TextBox();
            this.txb3 = new System.Windows.Forms.TextBox();
            this.txb4 = new System.Windows.Forms.TextBox();
            this.panelSeparador = new System.Windows.Forms.Panel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTitulo.Location = new System.Drawing.Point(2, 7);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(137, 20);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "(Base de datos)";
            // 
            // lbxColecciones
            // 
            this.lbxColecciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbxColecciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbxColecciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxColecciones.FormattingEnabled = true;
            this.lbxColecciones.ItemHeight = 15;
            this.lbxColecciones.Location = new System.Drawing.Point(0, 31);
            this.lbxColecciones.Name = "lbxColecciones";
            this.lbxColecciones.Size = new System.Drawing.Size(139, 495);
            this.lbxColecciones.TabIndex = 2;
            this.lbxColecciones.Tag = "Bases de datos";
            this.lbxColecciones.SelectedIndexChanged += new System.EventHandler(this.lbxBasesDatos_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Location = new System.Drawing.Point(0, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(139, 34);
            this.panel1.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.GridColor = System.Drawing.Color.Lavender;
            this.dataGridView1.Location = new System.Drawing.Point(155, 89);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(657, 406);
            this.dataGridView1.TabIndex = 4;
            // 
            // lblColecciones
            // 
            this.lblColecciones.AutoSize = true;
            this.lblColecciones.Font = new System.Drawing.Font("Lato", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColecciones.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblColecciones.Location = new System.Drawing.Point(151, 53);
            this.lblColecciones.Name = "lblColecciones";
            this.lblColecciones.Size = new System.Drawing.Size(116, 23);
            this.lblColecciones.TabIndex = 5;
            this.lblColecciones.Text = "Documentos:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Location = new System.Drawing.Point(138, -2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1100, 34);
            this.panel2.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lato", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(874, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descripcion del producto";
            // 
            // btnInsertar
            // 
            this.btnInsertar.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnInsertar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInsertar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsertar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnInsertar.Location = new System.Drawing.Point(878, 426);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(222, 27);
            this.btnInsertar.TabIndex = 7;
            this.btnInsertar.Tag = "";
            this.btnInsertar.Text = "Insertar";
            this.btnInsertar.UseVisualStyleBackColor = false;
            // 
            // txbId
            // 
            this.txbId.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbId.Location = new System.Drawing.Point(878, 128);
            this.txbId.Name = "txbId";
            this.txbId.ReadOnly = true;
            this.txbId.Size = new System.Drawing.Size(222, 29);
            this.txbId.TabIndex = 8;
            this.txbId.Tag = "Object id";
            this.txbId.Text = "Id";
            // 
            // txb2
            // 
            this.txb2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb2.Location = new System.Drawing.Point(878, 187);
            this.txb2.Name = "txb2";
            this.txb2.Size = new System.Drawing.Size(222, 29);
            this.txb2.TabIndex = 9;
            // 
            // txb3
            // 
            this.txb3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb3.Location = new System.Drawing.Point(878, 245);
            this.txb3.Name = "txb3";
            this.txb3.Size = new System.Drawing.Size(222, 29);
            this.txb3.TabIndex = 10;
            // 
            // txb4
            // 
            this.txb4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb4.Location = new System.Drawing.Point(878, 304);
            this.txb4.Name = "txb4";
            this.txb4.Size = new System.Drawing.Size(222, 29);
            this.txb4.TabIndex = 11;
            // 
            // panelSeparador
            // 
            this.panelSeparador.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panelSeparador.Location = new System.Drawing.Point(844, 102);
            this.panelSeparador.Name = "panelSeparador";
            this.panelSeparador.Size = new System.Drawing.Size(1, 384);
            this.panelSeparador.TabIndex = 12;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUpdate.Location = new System.Drawing.Point(1002, 384);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(98, 27);
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.Tag = "";
            this.btnUpdate.Text = "Actualizar";
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEliminar.Location = new System.Drawing.Point(878, 384);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(98, 27);
            this.btnEliminar.TabIndex = 14;
            this.btnEliminar.Tag = "";
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 529);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.panelSeparador);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txb4);
            this.Controls.Add(this.txb3);
            this.Controls.Add(this.txb2);
            this.Controls.Add(this.txbId);
            this.Controls.Add(this.btnInsertar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblColecciones);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbxColecciones);
            this.Name = "Form1";
            this.Text = "MonitoringApp";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ListBox lbxColecciones;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblColecciones;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.TextBox txbId;
        private System.Windows.Forms.TextBox txb2;
        private System.Windows.Forms.TextBox txb3;
        private System.Windows.Forms.TextBox txb4;
        private System.Windows.Forms.Panel panelSeparador;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnEliminar;
    }
}

