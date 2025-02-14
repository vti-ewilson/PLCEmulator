namespace PLCEmulator
{
	partial class PLCForm
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
			if(disposing && (components != null))
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.outputGrid = new System.Windows.Forms.DataGridView();
			this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.Column4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.Column5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.Column6 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.Column7 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.Column8 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.inputGrid = new System.Windows.Forms.DataGridView();
			this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.dataGridViewCheckBoxColumn3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.dataGridViewCheckBoxColumn4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.dataGridViewCheckBoxColumn5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.dataGridViewCheckBoxColumn6 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.dataGridViewCheckBoxColumn7 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.dataGridViewCheckBoxColumn8 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.label1 = new System.Windows.Forms.Label();
			this.analogInputPanel = new System.Windows.Forms.Panel();
			this.analogInputsLabel = new System.Windows.Forms.Label();
			this.inputPanel = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.folderNameLabel = new System.Windows.Forms.Label();
			this.configSelectButton = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.outputPanel = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.outerAnalogInputPanel = new System.Windows.Forms.Panel();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.outputGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.inputGrid)).BeginInit();
			this.inputPanel.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.outputPanel.SuspendLayout();
			this.outerAnalogInputPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// outputGrid
			// 
			this.outputGrid.AllowUserToAddRows = false;
			this.outputGrid.AllowUserToDeleteRows = false;
			this.outputGrid.AllowUserToResizeColumns = false;
			this.outputGrid.AllowUserToResizeRows = false;
			this.outputGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.outputGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
			this.outputGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.outputGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Y,
            this.Address,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.outputGrid.DefaultCellStyle = dataGridViewCellStyle6;
			this.outputGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.outputGrid.Location = new System.Drawing.Point(30, 80);
			this.outputGrid.Name = "outputGrid";
			this.outputGrid.RowHeadersVisible = false;
			this.outputGrid.RowHeadersWidth = 62;
			this.outputGrid.RowTemplate.Height = 28;
			this.outputGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.outputGrid.Size = new System.Drawing.Size(393, 902);
			this.outputGrid.TabIndex = 2;
			this.outputGrid.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.outputGrid_RowPostPaint);
			// 
			// Y
			// 
			this.Y.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			this.Y.Frozen = true;
			this.Y.HeaderText = " ";
			this.Y.MinimumWidth = 8;
			this.Y.Name = "Y";
			this.Y.ReadOnly = true;
			this.Y.Width = 8;
			// 
			// Address
			// 
			this.Address.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.Address.Frozen = true;
			this.Address.HeaderText = "#";
			this.Address.MinimumWidth = 8;
			this.Address.Name = "Address";
			this.Address.ReadOnly = true;
			this.Address.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.Address.Width = 66;
			// 
			// Column1
			// 
			this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.Column1.HeaderText = "1";
			this.Column1.MinimumWidth = 8;
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.Column1.Width = 36;
			// 
			// Column2
			// 
			this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.Column2.HeaderText = "2";
			this.Column2.MinimumWidth = 8;
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.Column2.Width = 36;
			// 
			// Column3
			// 
			this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.Column3.HeaderText = "3";
			this.Column3.MinimumWidth = 8;
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.Column3.Width = 36;
			// 
			// Column4
			// 
			this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.Column4.HeaderText = "4";
			this.Column4.MinimumWidth = 8;
			this.Column4.Name = "Column4";
			this.Column4.ReadOnly = true;
			this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.Column4.Width = 36;
			// 
			// Column5
			// 
			this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.Column5.HeaderText = "5";
			this.Column5.MinimumWidth = 8;
			this.Column5.Name = "Column5";
			this.Column5.ReadOnly = true;
			this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.Column5.Width = 36;
			// 
			// Column6
			// 
			this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.Column6.HeaderText = "6";
			this.Column6.MinimumWidth = 8;
			this.Column6.Name = "Column6";
			this.Column6.ReadOnly = true;
			this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.Column6.Width = 36;
			// 
			// Column7
			// 
			this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.Column7.HeaderText = "7";
			this.Column7.MinimumWidth = 8;
			this.Column7.Name = "Column7";
			this.Column7.ReadOnly = true;
			this.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.Column7.Width = 36;
			// 
			// Column8
			// 
			this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.Column8.HeaderText = "8";
			this.Column8.MinimumWidth = 8;
			this.Column8.Name = "Column8";
			this.Column8.ReadOnly = true;
			this.Column8.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.Column8.Width = 36;
			// 
			// inputGrid
			// 
			this.inputGrid.AllowUserToAddRows = false;
			this.inputGrid.AllowUserToDeleteRows = false;
			this.inputGrid.AllowUserToResizeColumns = false;
			this.inputGrid.AllowUserToResizeRows = false;
			this.inputGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.inputGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
			this.inputGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.inputGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.X,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewCheckBoxColumn2,
            this.dataGridViewCheckBoxColumn3,
            this.dataGridViewCheckBoxColumn4,
            this.dataGridViewCheckBoxColumn5,
            this.dataGridViewCheckBoxColumn6,
            this.dataGridViewCheckBoxColumn7,
            this.dataGridViewCheckBoxColumn8});
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.inputGrid.DefaultCellStyle = dataGridViewCellStyle8;
			this.inputGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.inputGrid.Location = new System.Drawing.Point(30, 190);
			this.inputGrid.Name = "inputGrid";
			this.inputGrid.RowHeadersVisible = false;
			this.inputGrid.RowHeadersWidth = 62;
			this.inputGrid.RowTemplate.Height = 28;
			this.inputGrid.Size = new System.Drawing.Size(448, 722);
			this.inputGrid.TabIndex = 3;
			this.inputGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.inputGrid_CellValueChanged);
			this.inputGrid.CurrentCellDirtyStateChanged += new System.EventHandler(this.inputGrid_CurrentCellDirtyStateChanged);
			this.inputGrid.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.inputGrid_RowPostPaint);
			// 
			// X
			// 
			this.X.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			this.X.Frozen = true;
			this.X.HeaderText = "";
			this.X.MinimumWidth = 8;
			this.X.Name = "X";
			this.X.ReadOnly = true;
			this.X.Width = 8;
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.dataGridViewTextBoxColumn1.Frozen = true;
			this.dataGridViewTextBoxColumn1.HeaderText = "#";
			this.dataGridViewTextBoxColumn1.MinimumWidth = 8;
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn1.Width = 66;
			// 
			// dataGridViewCheckBoxColumn1
			// 
			this.dataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.dataGridViewCheckBoxColumn1.HeaderText = "1";
			this.dataGridViewCheckBoxColumn1.MinimumWidth = 8;
			this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
			this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewCheckBoxColumn1.Width = 36;
			// 
			// dataGridViewCheckBoxColumn2
			// 
			this.dataGridViewCheckBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.dataGridViewCheckBoxColumn2.HeaderText = "2";
			this.dataGridViewCheckBoxColumn2.MinimumWidth = 8;
			this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
			this.dataGridViewCheckBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewCheckBoxColumn2.Width = 36;
			// 
			// dataGridViewCheckBoxColumn3
			// 
			this.dataGridViewCheckBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.dataGridViewCheckBoxColumn3.HeaderText = "3";
			this.dataGridViewCheckBoxColumn3.MinimumWidth = 8;
			this.dataGridViewCheckBoxColumn3.Name = "dataGridViewCheckBoxColumn3";
			this.dataGridViewCheckBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewCheckBoxColumn3.Width = 36;
			// 
			// dataGridViewCheckBoxColumn4
			// 
			this.dataGridViewCheckBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.dataGridViewCheckBoxColumn4.HeaderText = "4";
			this.dataGridViewCheckBoxColumn4.MinimumWidth = 8;
			this.dataGridViewCheckBoxColumn4.Name = "dataGridViewCheckBoxColumn4";
			this.dataGridViewCheckBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewCheckBoxColumn4.Width = 36;
			// 
			// dataGridViewCheckBoxColumn5
			// 
			this.dataGridViewCheckBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.dataGridViewCheckBoxColumn5.HeaderText = "5";
			this.dataGridViewCheckBoxColumn5.MinimumWidth = 8;
			this.dataGridViewCheckBoxColumn5.Name = "dataGridViewCheckBoxColumn5";
			this.dataGridViewCheckBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewCheckBoxColumn5.Width = 36;
			// 
			// dataGridViewCheckBoxColumn6
			// 
			this.dataGridViewCheckBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.dataGridViewCheckBoxColumn6.HeaderText = "6";
			this.dataGridViewCheckBoxColumn6.MinimumWidth = 8;
			this.dataGridViewCheckBoxColumn6.Name = "dataGridViewCheckBoxColumn6";
			this.dataGridViewCheckBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewCheckBoxColumn6.Width = 36;
			// 
			// dataGridViewCheckBoxColumn7
			// 
			this.dataGridViewCheckBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.dataGridViewCheckBoxColumn7.HeaderText = "7";
			this.dataGridViewCheckBoxColumn7.MinimumWidth = 8;
			this.dataGridViewCheckBoxColumn7.Name = "dataGridViewCheckBoxColumn7";
			this.dataGridViewCheckBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewCheckBoxColumn7.Width = 36;
			// 
			// dataGridViewCheckBoxColumn8
			// 
			this.dataGridViewCheckBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.dataGridViewCheckBoxColumn8.HeaderText = "8";
			this.dataGridViewCheckBoxColumn8.MinimumWidth = 8;
			this.dataGridViewCheckBoxColumn8.Name = "dataGridViewCheckBoxColumn8";
			this.dataGridViewCheckBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewCheckBoxColumn8.Width = 36;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
			this.label1.Location = new System.Drawing.Point(30, 140);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(448, 50);
			this.label1.TabIndex = 4;
			this.label1.Text = "Inputs";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// analogInputPanel
			// 
			this.analogInputPanel.AutoScroll = true;
			this.analogInputPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.analogInputPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.analogInputPanel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.analogInputPanel.Location = new System.Drawing.Point(30, 80);
			this.analogInputPanel.Name = "analogInputPanel";
			this.analogInputPanel.Size = new System.Drawing.Size(710, 902);
			this.analogInputPanel.TabIndex = 7;
			// 
			// analogInputsLabel
			// 
			this.analogInputsLabel.Dock = System.Windows.Forms.DockStyle.Top;
			this.analogInputsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.analogInputsLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
			this.analogInputsLabel.Location = new System.Drawing.Point(30, 30);
			this.analogInputsLabel.Name = "analogInputsLabel";
			this.analogInputsLabel.Size = new System.Drawing.Size(710, 50);
			this.analogInputsLabel.TabIndex = 8;
			this.analogInputsLabel.Text = "Analog Inputs";
			this.analogInputsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// inputPanel
			// 
			this.inputPanel.Controls.Add(this.inputGrid);
			this.inputPanel.Controls.Add(this.label1);
			this.inputPanel.Controls.Add(this.panel3);
			this.inputPanel.Controls.Add(this.panel2);
			this.inputPanel.Controls.Add(this.panel1);
			this.inputPanel.Dock = System.Windows.Forms.DockStyle.Left;
			this.inputPanel.Location = new System.Drawing.Point(0, 0);
			this.inputPanel.Name = "inputPanel";
			this.inputPanel.Padding = new System.Windows.Forms.Padding(30);
			this.inputPanel.Size = new System.Drawing.Size(508, 1012);
			this.inputPanel.TabIndex = 13;
			// 
			// panel3
			// 
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(30, 130);
			this.panel3.Margin = new System.Windows.Forms.Padding(10);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(15);
			this.panel3.Size = new System.Drawing.Size(448, 10);
			this.panel3.TabIndex = 7;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.folderNameLabel);
			this.panel2.Controls.Add(this.configSelectButton);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(30, 912);
			this.panel2.Margin = new System.Windows.Forms.Padding(10);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(15, 30, 15, 0);
			this.panel2.Size = new System.Drawing.Size(448, 70);
			this.panel2.TabIndex = 6;
			// 
			// folderNameLabel
			// 
			this.folderNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.folderNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.folderNameLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.folderNameLabel.Location = new System.Drawing.Point(15, 30);
			this.folderNameLabel.Name = "folderNameLabel";
			this.folderNameLabel.Size = new System.Drawing.Size(285, 40);
			this.folderNameLabel.TabIndex = 1;
			this.folderNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// configSelectButton
			// 
			this.configSelectButton.Dock = System.Windows.Forms.DockStyle.Right;
			this.configSelectButton.Location = new System.Drawing.Point(300, 30);
			this.configSelectButton.Name = "configSelectButton";
			this.configSelectButton.Size = new System.Drawing.Size(133, 40);
			this.configSelectButton.TabIndex = 0;
			this.configSelectButton.Text = "Select Config";
			this.configSelectButton.UseVisualStyleBackColor = true;
			this.configSelectButton.Click += new System.EventHandler(this.configSelectButton_Click);
			// 
			// panel1
			// 
			this.panel1.BackgroundImage = global::PLCEmulator.Properties.Resources.blueoval;
			this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.panel1.Controls.Add(this.label3);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(30, 30);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(448, 100);
			this.panel1.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.SystemColors.Control;
			this.label3.Location = new System.Drawing.Point(0, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(448, 100);
			this.label3.TabIndex = 0;
			this.label3.Text = "PLC Emulator";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// outputPanel
			// 
			this.outputPanel.Controls.Add(this.outputGrid);
			this.outputPanel.Controls.Add(this.label2);
			this.outputPanel.Dock = System.Windows.Forms.DockStyle.Left;
			this.outputPanel.Location = new System.Drawing.Point(508, 0);
			this.outputPanel.Name = "outputPanel";
			this.outputPanel.Padding = new System.Windows.Forms.Padding(30);
			this.outputPanel.Size = new System.Drawing.Size(453, 1012);
			this.outputPanel.TabIndex = 14;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Top;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
			this.label2.Location = new System.Drawing.Point(30, 30);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(393, 50);
			this.label2.TabIndex = 5;
			this.label2.Text = "Outputs";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// outerAnalogInputPanel
			// 
			this.outerAnalogInputPanel.Controls.Add(this.analogInputPanel);
			this.outerAnalogInputPanel.Controls.Add(this.analogInputsLabel);
			this.outerAnalogInputPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.outerAnalogInputPanel.Location = new System.Drawing.Point(961, 0);
			this.outerAnalogInputPanel.Name = "outerAnalogInputPanel";
			this.outerAnalogInputPanel.Padding = new System.Windows.Forms.Padding(30);
			this.outerAnalogInputPanel.Size = new System.Drawing.Size(770, 1012);
			this.outerAnalogInputPanel.TabIndex = 15;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.Filter = "Config files|*.config";
			this.openFileDialog1.FilterIndex = 0;
			// 
			// PLCForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.ClientSize = new System.Drawing.Size(1731, 1012);
			this.Controls.Add(this.outerAnalogInputPanel);
			this.Controls.Add(this.outputPanel);
			this.Controls.Add(this.inputPanel);
			this.Name = "PLCForm";
			this.Text = "PLC Emulator";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PLCForm_FormClosed);
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.outputGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.inputGrid)).EndInit();
			this.inputPanel.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.outputPanel.ResumeLayout(false);
			this.outerAnalogInputPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.DataGridView outputGrid;
		private System.Windows.Forms.DataGridView inputGrid;
		private System.Windows.Forms.DataGridViewTextBoxColumn X;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
		private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
		private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
		private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn4;
		private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn5;
		private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn6;
		private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn7;
		private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn8;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel analogInputPanel;
		private System.Windows.Forms.Label analogInputsLabel;
		private System.Windows.Forms.DataGridViewTextBoxColumn Y;
		private System.Windows.Forms.DataGridViewTextBoxColumn Address;
		private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
		private System.Windows.Forms.DataGridViewCheckBoxColumn Column2;
		private System.Windows.Forms.DataGridViewCheckBoxColumn Column3;
		private System.Windows.Forms.DataGridViewCheckBoxColumn Column4;
		private System.Windows.Forms.DataGridViewCheckBoxColumn Column5;
		private System.Windows.Forms.DataGridViewCheckBoxColumn Column6;
		private System.Windows.Forms.DataGridViewCheckBoxColumn Column7;
		private System.Windows.Forms.DataGridViewCheckBoxColumn Column8;
		private System.Windows.Forms.Panel inputPanel;
		private System.Windows.Forms.Panel outputPanel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel outerAnalogInputPanel;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button configSelectButton;
		private System.Windows.Forms.Label folderNameLabel;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
	}
}

