namespace GraphPhys.Forms
{
	partial class FormMain
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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.label_E1 = new System.Windows.Forms.Label();
			this.label_q1 = new System.Windows.Forms.Label();
			this.textBox_q1 = new System.Windows.Forms.TextBox();
			this.textBox_q2 = new System.Windows.Forms.TextBox();
			this.label_q2 = new System.Windows.Forms.Label();
			this.textBox_d = new System.Windows.Forms.TextBox();
			this.label_d = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.button_Settings = new System.Windows.Forms.Button();
			this.button_Apply = new System.Windows.Forms.Button();
			this.button_Zoom = new System.Windows.Forms.Button();
			this.button_Reset = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label_p1 = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.panel6 = new System.Windows.Forms.Panel();
			this.button_GraphRemove = new System.Windows.Forms.Button();
			this.button_AddGraph = new System.Windows.Forms.Button();
			this.comboBox_Graphs = new System.Windows.Forms.ComboBox();
			this.panel5 = new System.Windows.Forms.Panel();
			this.label_y = new System.Windows.Forms.Label();
			this.label_x = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel5.SuspendLayout();
			this.SuspendLayout();
			// 
			// chart1
			// 
			this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.chart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(204)))), ((int)(((byte)(230)))));
			this.chart1.BorderlineColor = System.Drawing.Color.Black;
			chartArea1.Name = "c0";
			this.chart1.ChartAreas.Add(chartArea1);
			this.chart1.Location = new System.Drawing.Point(0, 0);
			this.chart1.Margin = new System.Windows.Forms.Padding(0);
			this.chart1.Name = "chart1";
			this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
			this.chart1.Size = new System.Drawing.Size(984, 641);
			this.chart1.TabIndex = 0;
			this.chart1.TabStop = false;
			this.chart1.Text = "chart1";
			this.chart1.Paint += new System.Windows.Forms.PaintEventHandler(this.chart1_Paint);
			this.chart1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseDoubleClick);
			this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseMove);
			// 
			// label_E1
			// 
			this.label_E1.AutoSize = true;
			this.label_E1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.label_E1.Location = new System.Drawing.Point(3, 4);
			this.label_E1.Name = "label_E1";
			this.label_E1.Size = new System.Drawing.Size(0, 24);
			this.label_E1.TabIndex = 1;
			// 
			// label_q1
			// 
			this.label_q1.AutoSize = true;
			this.label_q1.Location = new System.Drawing.Point(6, 36);
			this.label_q1.Name = "label_q1";
			this.label_q1.Size = new System.Drawing.Size(22, 13);
			this.label_q1.TabIndex = 2;
			this.label_q1.Text = "q1:";
			// 
			// textBox_q1
			// 
			this.textBox_q1.Location = new System.Drawing.Point(26, 33);
			this.textBox_q1.Name = "textBox_q1";
			this.textBox_q1.Size = new System.Drawing.Size(100, 20);
			this.textBox_q1.TabIndex = 3;
			this.textBox_q1.TextChanged += new System.EventHandler(this.userValues_Changed);
			// 
			// textBox_q2
			// 
			this.textBox_q2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_q2.Location = new System.Drawing.Point(184, 33);
			this.textBox_q2.Name = "textBox_q2";
			this.textBox_q2.Size = new System.Drawing.Size(100, 20);
			this.textBox_q2.TabIndex = 5;
			this.textBox_q2.TextChanged += new System.EventHandler(this.userValues_Changed);
			// 
			// label_q2
			// 
			this.label_q2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label_q2.AutoSize = true;
			this.label_q2.Location = new System.Drawing.Point(161, 36);
			this.label_q2.Name = "label_q2";
			this.label_q2.Size = new System.Drawing.Size(22, 13);
			this.label_q2.TabIndex = 4;
			this.label_q2.Text = "q2:";
			// 
			// textBox_d
			// 
			this.textBox_d.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_d.Location = new System.Drawing.Point(184, 78);
			this.textBox_d.Name = "textBox_d";
			this.textBox_d.Size = new System.Drawing.Size(100, 20);
			this.textBox_d.TabIndex = 7;
			this.textBox_d.TextChanged += new System.EventHandler(this.userValues_Changed);
			// 
			// label_d
			// 
			this.label_d.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label_d.AutoSize = true;
			this.label_d.Location = new System.Drawing.Point(167, 81);
			this.label_d.Name = "label_d";
			this.label_d.Size = new System.Drawing.Size(16, 13);
			this.label_d.TabIndex = 6;
			this.label_d.Text = "d:";
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.textBox_q1);
			this.panel1.Controls.Add(this.button_Settings);
			this.panel1.Controls.Add(this.button_Apply);
			this.panel1.Controls.Add(this.textBox_d);
			this.panel1.Controls.Add(this.textBox_q2);
			this.panel1.Controls.Add(this.label_q2);
			this.panel1.Controls.Add(this.label_q1);
			this.panel1.Controls.Add(this.label_d);
			this.panel1.Location = new System.Drawing.Point(668, 641);
			this.panel1.Margin = new System.Windows.Forms.Padding(0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(316, 120);
			this.panel1.TabIndex = 8;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(284, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(26, 13);
			this.label2.TabIndex = 13;
			this.label2.Text = "нКл";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(126, 37);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(26, 13);
			this.label1.TabIndex = 12;
			this.label1.Text = "нКл";
			// 
			// button_Settings
			// 
			this.button_Settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button_Settings.Location = new System.Drawing.Point(18, 70);
			this.button_Settings.Name = "button_Settings";
			this.button_Settings.Size = new System.Drawing.Size(62, 35);
			this.button_Settings.TabIndex = 11;
			this.button_Settings.TabStop = false;
			this.button_Settings.Text = "Settings";
			this.button_Settings.UseVisualStyleBackColor = true;
			this.button_Settings.Click += new System.EventHandler(this.button_Settings_Click);
			// 
			// button_Apply
			// 
			this.button_Apply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button_Apply.Location = new System.Drawing.Point(86, 70);
			this.button_Apply.Name = "button_Apply";
			this.button_Apply.Size = new System.Drawing.Size(68, 35);
			this.button_Apply.TabIndex = 8;
			this.button_Apply.Text = "Apply";
			this.button_Apply.UseVisualStyleBackColor = true;
			this.button_Apply.Click += new System.EventHandler(this.button_Apply_Click);
			// 
			// button_Zoom
			// 
			this.button_Zoom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.button_Zoom.Enabled = false;
			this.button_Zoom.Location = new System.Drawing.Point(14, 11);
			this.button_Zoom.Name = "button_Zoom";
			this.button_Zoom.Size = new System.Drawing.Size(77, 35);
			this.button_Zoom.TabIndex = 9;
			this.button_Zoom.TabStop = false;
			this.button_Zoom.Text = "Zoom";
			this.button_Zoom.UseVisualStyleBackColor = true;
			this.button_Zoom.Click += new System.EventHandler(this.button_Zoom_Click);
			// 
			// button_Reset
			// 
			this.button_Reset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.button_Reset.Enabled = false;
			this.button_Reset.Location = new System.Drawing.Point(14, 52);
			this.button_Reset.Name = "button_Reset";
			this.button_Reset.Size = new System.Drawing.Size(77, 35);
			this.button_Reset.TabIndex = 10;
			this.button_Reset.TabStop = false;
			this.button_Reset.Text = "Reset";
			this.button_Reset.UseVisualStyleBackColor = true;
			this.button_Reset.Click += new System.EventHandler(this.button_Reset_Click);
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.panel2.Controls.Add(this.button_Zoom);
			this.panel2.Controls.Add(this.button_Reset);
			this.panel2.Location = new System.Drawing.Point(566, 663);
			this.panel2.Margin = new System.Windows.Forms.Padding(0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(102, 98);
			this.panel2.TabIndex = 11;
			// 
			// panel3
			// 
			this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel3.Controls.Add(this.label_p1);
			this.panel3.Controls.Add(this.label_E1);
			this.panel3.Location = new System.Drawing.Point(0, 641);
			this.panel3.Margin = new System.Windows.Forms.Padding(0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(434, 120);
			this.panel3.TabIndex = 12;
			// 
			// label_p1
			// 
			this.label_p1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_p1.AutoSize = true;
			this.label_p1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.label_p1.Location = new System.Drawing.Point(3, 87);
			this.label_p1.Name = "label_p1";
			this.label_p1.Size = new System.Drawing.Size(0, 24);
			this.label_p1.TabIndex = 13;
			// 
			// panel4
			// 
			this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.panel4.Controls.Add(this.panel6);
			this.panel4.Location = new System.Drawing.Point(434, 663);
			this.panel4.Margin = new System.Windows.Forms.Padding(0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(132, 98);
			this.panel4.TabIndex = 12;
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.button_GraphRemove);
			this.panel6.Controls.Add(this.button_AddGraph);
			this.panel6.Controls.Add(this.comboBox_Graphs);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel6.Location = new System.Drawing.Point(0, 0);
			this.panel6.Margin = new System.Windows.Forms.Padding(0);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(132, 98);
			this.panel6.TabIndex = 3;
			// 
			// button_GraphRemove
			// 
			this.button_GraphRemove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.button_GraphRemove.Enabled = false;
			this.button_GraphRemove.Location = new System.Drawing.Point(72, 52);
			this.button_GraphRemove.Margin = new System.Windows.Forms.Padding(0);
			this.button_GraphRemove.Name = "button_GraphRemove";
			this.button_GraphRemove.Size = new System.Drawing.Size(55, 35);
			this.button_GraphRemove.TabIndex = 12;
			this.button_GraphRemove.TabStop = false;
			this.button_GraphRemove.Text = "Remove";
			this.button_GraphRemove.UseVisualStyleBackColor = true;
			this.button_GraphRemove.Click += new System.EventHandler(this.button_GraphRemove_Click);
			// 
			// button_AddGraph
			// 
			this.button_AddGraph.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.button_AddGraph.Location = new System.Drawing.Point(5, 52);
			this.button_AddGraph.Margin = new System.Windows.Forms.Padding(0);
			this.button_AddGraph.Name = "button_AddGraph";
			this.button_AddGraph.Size = new System.Drawing.Size(55, 35);
			this.button_AddGraph.TabIndex = 11;
			this.button_AddGraph.TabStop = false;
			this.button_AddGraph.Text = "Add";
			this.button_AddGraph.UseVisualStyleBackColor = true;
			this.button_AddGraph.Click += new System.EventHandler(this.button_AddGraph_Click);
			// 
			// comboBox_Graphs
			// 
			this.comboBox_Graphs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBox_Graphs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_Graphs.FormattingEnabled = true;
			this.comboBox_Graphs.Location = new System.Drawing.Point(5, 11);
			this.comboBox_Graphs.Margin = new System.Windows.Forms.Padding(0);
			this.comboBox_Graphs.MaxDropDownItems = 25;
			this.comboBox_Graphs.Name = "comboBox_Graphs";
			this.comboBox_Graphs.Size = new System.Drawing.Size(122, 21);
			this.comboBox_Graphs.TabIndex = 1;
			this.comboBox_Graphs.TabStop = false;
			this.comboBox_Graphs.SelectedIndexChanged += new System.EventHandler(this.comboBox_Graphs_SelectedIndexChanged);
			// 
			// panel5
			// 
			this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(210)))), ((int)(((byte)(230)))));
			this.panel5.Controls.Add(this.label_y);
			this.panel5.Controls.Add(this.label_x);
			this.panel5.Location = new System.Drawing.Point(434, 641);
			this.panel5.Margin = new System.Windows.Forms.Padding(0);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(234, 22);
			this.panel5.TabIndex = 13;
			// 
			// label_y
			// 
			this.label_y.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.label_y.AutoSize = true;
			this.label_y.Location = new System.Drawing.Point(129, 4);
			this.label_y.Name = "label_y";
			this.label_y.Size = new System.Drawing.Size(17, 13);
			this.label_y.TabIndex = 1;
			this.label_y.Text = "Y:";
			// 
			// label_x
			// 
			this.label_x.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.label_x.AutoSize = true;
			this.label_x.Location = new System.Drawing.Point(3, 4);
			this.label_x.Name = "label_x";
			this.label_x.Size = new System.Drawing.Size(17, 13);
			this.label_x.TabIndex = 0;
			this.label_x.Text = "X:";
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ClientSize = new System.Drawing.Size(984, 761);
			this.Controls.Add(this.panel5);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.chart1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MinimumSize = new System.Drawing.Size(842, 400);
			this.Name = "FormMain";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private System.Windows.Forms.Label label_E1;
		private System.Windows.Forms.Label label_q1;
		private System.Windows.Forms.TextBox textBox_q1;
		private System.Windows.Forms.TextBox textBox_q2;
		private System.Windows.Forms.Label label_q2;
		private System.Windows.Forms.TextBox textBox_d;
		private System.Windows.Forms.Label label_d;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button button_Apply;
		private System.Windows.Forms.Button button_Zoom;
		private System.Windows.Forms.Button button_Reset;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Button button_Settings;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Label label_p1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Label label_y;
		private System.Windows.Forms.Label label_x;
		private System.Windows.Forms.ComboBox comboBox_Graphs;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Button button_GraphRemove;
		private System.Windows.Forms.Button button_AddGraph;
	}
}

