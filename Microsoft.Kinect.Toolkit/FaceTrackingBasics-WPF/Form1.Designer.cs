namespace FaceTrackingBasics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.labelNome = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelTelefone = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxTelefone = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.textBoxIdRosto = new System.Windows.Forms.TextBox();
            this.labelIdRosto = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProviderNome = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderEmail = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderTelefone = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTipNome = new System.Windows.Forms.ToolTip(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelFormatoRecebido = new System.Windows.Forms.Label();
            this.labelFormato = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonLerNovamente = new System.Windows.Forms.Button();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipEmail = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipTelefone = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderNome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderTelefone)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNome.Location = new System.Drawing.Point(10, 35);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(71, 24);
            this.labelNome.TabIndex = 1;
            this.labelNome.Text = "Nome:";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmail.Location = new System.Drawing.Point(10, 91);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(67, 24);
            this.labelEmail.TabIndex = 3;
            this.labelEmail.Text = "Email:";
            // 
            // labelTelefone
            // 
            this.labelTelefone.AutoSize = true;
            this.labelTelefone.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTelefone.Location = new System.Drawing.Point(9, 66);
            this.labelTelefone.Name = "labelTelefone";
            this.labelTelefone.Size = new System.Drawing.Size(93, 24);
            this.labelTelefone.TabIndex = 4;
            this.labelTelefone.Text = "Telefone:";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.ForeColor = System.Drawing.Color.Black;
            this.textBoxEmail.Location = new System.Drawing.Point(99, 95);
            this.textBoxEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(597, 22);
            this.textBoxEmail.TabIndex = 3;
            this.textBoxEmail.Text = "seuemail@gmail.com";
            this.textBoxEmail.Enter += new System.EventHandler(this.textBoxEmail_Enter);
            this.textBoxEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxEmail_KeyDown);
            this.textBoxEmail.Leave += new System.EventHandler(this.textBoxEmail_Leave);
            // 
            // textBoxTelefone
            // 
            this.textBoxTelefone.ForeColor = System.Drawing.Color.Black;
            this.textBoxTelefone.Location = new System.Drawing.Point(99, 68);
            this.textBoxTelefone.Name = "textBoxTelefone";
            this.textBoxTelefone.Size = new System.Drawing.Size(199, 22);
            this.textBoxTelefone.TabIndex = 2;
            this.textBoxTelefone.Text = "(00)0000-000 ou (00)90000-0000";
            this.textBoxTelefone.Enter += new System.EventHandler(this.textBoxTelefone_Enter);
            this.textBoxTelefone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxTelefone_KeyDown);
            this.textBoxTelefone.Leave += new System.EventHandler(this.textBoxTelefone_Leave);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 307);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(730, 193);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxNome);
            this.panel1.Controls.Add(this.textBoxIdRosto);
            this.panel1.Controls.Add(this.labelIdRosto);
            this.panel1.Controls.Add(this.labelNome);
            this.panel1.Controls.Add(this.textBoxTelefone);
            this.panel1.Controls.Add(this.labelEmail);
            this.panel1.Controls.Add(this.labelTelefone);
            this.panel1.Controls.Add(this.textBoxEmail);
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(3, 172);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(730, 127);
            this.panel1.TabIndex = 11;
            // 
            // textBoxNome
            // 
            this.textBoxNome.ForeColor = System.Drawing.Color.Black;
            this.textBoxNome.Location = new System.Drawing.Point(99, 40);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(199, 22);
            this.textBoxNome.TabIndex = 1;
            this.textBoxNome.Text = "Nome completo";
            this.textBoxNome.Enter += new System.EventHandler(this.textBoxNome_Enter_1);
            this.textBoxNome.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxNome_KeyDown_1);
            this.textBoxNome.Leave += new System.EventHandler(this.textBoxNome_Leave_1);
            // 
            // textBoxIdRosto
            // 
            this.textBoxIdRosto.Location = new System.Drawing.Point(101, 9);
            this.textBoxIdRosto.Name = "textBoxIdRosto";
            this.textBoxIdRosto.Size = new System.Drawing.Size(59, 22);
            this.textBoxIdRosto.TabIndex = 0;
            // 
            // labelIdRosto
            // 
            this.labelIdRosto.AutoSize = true;
            this.labelIdRosto.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIdRosto.ForeColor = System.Drawing.Color.Black;
            this.labelIdRosto.Location = new System.Drawing.Point(9, 9);
            this.labelIdRosto.Name = "labelIdRosto";
            this.labelIdRosto.Size = new System.Drawing.Size(89, 24);
            this.labelIdRosto.TabIndex = 5;
            this.labelIdRosto.Text = "Id Rosto:";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(489, 83);
            this.textBoxSearch.Multiline = true;
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(244, 34);
            this.textBoxSearch.TabIndex = 0;
            this.textBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSearch_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(422, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 24);
            this.label1.TabIndex = 14;
            this.label1.Text = "Busca";
            // 
            // errorProviderNome
            // 
            this.errorProviderNome.ContainerControl = this;
            // 
            // errorProviderEmail
            // 
            this.errorProviderEmail.ContainerControl = this;
            // 
            // errorProviderTelefone
            // 
            this.errorProviderTelefone.ContainerControl = this;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelFormatoRecebido);
            this.panel2.Controls.Add(this.labelFormato);
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(3, 123);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(730, 43);
            this.panel2.TabIndex = 16;
            // 
            // labelFormatoRecebido
            // 
            this.labelFormatoRecebido.AutoSize = true;
            this.labelFormatoRecebido.Font = new System.Drawing.Font("Berlin Sans FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFormatoRecebido.Location = new System.Drawing.Point(238, 9);
            this.labelFormatoRecebido.Name = "labelFormatoRecebido";
            this.labelFormatoRecebido.Size = new System.Drawing.Size(0, 23);
            this.labelFormatoRecebido.TabIndex = 1;
            // 
            // labelFormato
            // 
            this.labelFormato.AutoSize = true;
            this.labelFormato.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFormato.Location = new System.Drawing.Point(7, 9);
            this.labelFormato.Name = "labelFormato";
            this.labelFormato.Size = new System.Drawing.Size(231, 24);
            this.labelFormato.TabIndex = 0;
            this.labelFormato.Text = "O formato do seu rosto é";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pictureBox3);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(736, 62);
            this.panel3.TabIndex = 17;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::FaceTrackingBasics.Properties.Resources.Logo;
            this.pictureBox3.Location = new System.Drawing.Point(12, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(100, 50);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::FaceTrackingBasics.Properties.Resources.sair1;
            this.pictureBox2.Location = new System.Drawing.Point(711, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(22, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.Image = global::FaceTrackingBasics.Properties.Resources.Status;
            this.pictureBox1.Location = new System.Drawing.Point(346, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.buttonLerNovamente);
            this.panel4.Controls.Add(this.pictureBox8);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.pictureBox6);
            this.panel4.Controls.Add(this.textBoxSearch);
            this.panel4.Controls.Add(this.pictureBox5);
            this.panel4.Controls.Add(this.pictureBox4);
            this.panel4.Controls.Add(this.dataGridView1);
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Location = new System.Drawing.Point(1, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(753, 563);
            this.panel4.TabIndex = 18;
            // 
            // buttonLerNovamente
            // 
            this.buttonLerNovamente.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonLerNovamente.FlatAppearance.BorderColor = System.Drawing.Color.Lavender;
            this.buttonLerNovamente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLerNovamente.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLerNovamente.ForeColor = System.Drawing.Color.Black;
            this.buttonLerNovamente.Location = new System.Drawing.Point(3, 506);
            this.buttonLerNovamente.Name = "buttonLerNovamente";
            this.buttonLerNovamente.Size = new System.Drawing.Size(124, 40);
            this.buttonLerNovamente.TabIndex = 23;
            this.buttonLerNovamente.Text = "Novo rosto";
            this.buttonLerNovamente.UseVisualStyleBackColor = false;
            this.buttonLerNovamente.Click += new System.EventHandler(this.buttonLerNovamente_Click);
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::FaceTrackingBasics.Properties.Resources.search;
            this.pictureBox8.Location = new System.Drawing.Point(696, 86);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(36, 30);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 22;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::FaceTrackingBasics.Properties.Resources.delete;
            this.pictureBox6.Location = new System.Drawing.Point(687, 506);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(45, 49);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 20;
            this.pictureBox6.TabStop = false;
            this.toolTip.SetToolTip(this.pictureBox6, "Deletar");
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::FaceTrackingBasics.Properties.Resources.edit;
            this.pictureBox5.Location = new System.Drawing.Point(635, 506);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(46, 49);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 19;
            this.pictureBox5.TabStop = false;
            this.toolTip.SetToolTip(this.pictureBox5, "Editar");
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::FaceTrackingBasics.Properties.Resources.save;
            this.pictureBox4.Location = new System.Drawing.Point(583, 506);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(46, 49);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 18;
            this.pictureBox4.TabStop = false;
            this.toolTip.SetToolTip(this.pictureBox4, "Salvar");
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // toolTipEmail
            // 
            this.toolTipEmail.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Error;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(755, 566);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(100, 100);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Cadastrar Usuário";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderNome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderTelefone)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelTelefone;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxTelefone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBoxIdRosto;
        private System.Windows.Forms.Label labelIdRosto;
        private System.Windows.Forms.ToolTip toolTipNome;
        private System.Windows.Forms.ErrorProvider errorProviderNome;
        private System.Windows.Forms.ErrorProvider errorProviderEmail;
        private System.Windows.Forms.ErrorProvider errorProviderTelefone;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelFormatoRecebido;
        private System.Windows.Forms.Label labelFormato;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Button buttonLerNovamente;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolTip toolTipEmail;
        private System.Windows.Forms.ToolTip toolTipTelefone;
    }
}