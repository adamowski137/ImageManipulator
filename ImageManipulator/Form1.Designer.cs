namespace ImageManipulator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.imagePBX = new System.Windows.Forms.PictureBox();
            this.applyBTN = new System.Windows.Forms.Button();
            this.controlGBX = new System.Windows.Forms.GroupBox();
            this.chartsLP = new System.Windows.Forms.FlowLayoutPanel();
            this.filterGBX = new System.Windows.Forms.GroupBox();
            this.customFuncRBTN = new System.Windows.Forms.RadioButton();
            this.contrastRBTN = new System.Windows.Forms.RadioButton();
            this.gammaCorrectionRBTN = new System.Windows.Forms.RadioButton();
            this.changeBrightnessRBTN = new System.Windows.Forms.RadioButton();
            this.negationRBTN = new System.Windows.Forms.RadioButton();
            this.noFilterRBTN = new System.Windows.Forms.RadioButton();
            this.modeCBX = new System.Windows.Forms.ComboBox();
            this.modeLBL = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagePBX)).BeginInit();
            this.filterGBX.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 24);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.imagePBX);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.applyBTN);
            this.splitContainer.Panel2.Controls.Add(this.controlGBX);
            this.splitContainer.Panel2.Controls.Add(this.chartsLP);
            this.splitContainer.Panel2.Controls.Add(this.filterGBX);
            this.splitContainer.Panel2.Controls.Add(this.modeCBX);
            this.splitContainer.Panel2.Controls.Add(this.modeLBL);
            this.splitContainer.Size = new System.Drawing.Size(1260, 640);
            this.splitContainer.SplitterDistance = 799;
            this.splitContainer.TabIndex = 0;
            // 
            // imagePBX
            // 
            this.imagePBX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imagePBX.Location = new System.Drawing.Point(0, 0);
            this.imagePBX.Name = "imagePBX";
            this.imagePBX.Size = new System.Drawing.Size(799, 640);
            this.imagePBX.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imagePBX.TabIndex = 0;
            this.imagePBX.TabStop = false;
            this.imagePBX.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imagePBX_MouseDown);
            this.imagePBX.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imagePBX_MouseMove);
            this.imagePBX.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imagePBX_MouseUp);
            // 
            // applyBTN
            // 
            this.applyBTN.Location = new System.Drawing.Point(22, 532);
            this.applyBTN.Name = "applyBTN";
            this.applyBTN.Size = new System.Drawing.Size(173, 23);
            this.applyBTN.TabIndex = 5;
            this.applyBTN.Text = "Apply";
            this.applyBTN.UseVisualStyleBackColor = true;
            this.applyBTN.Click += new System.EventHandler(this.applyBTN_Click);
            // 
            // controlGBX
            // 
            this.controlGBX.Location = new System.Drawing.Point(22, 288);
            this.controlGBX.Name = "controlGBX";
            this.controlGBX.Size = new System.Drawing.Size(173, 221);
            this.controlGBX.TabIndex = 4;
            this.controlGBX.TabStop = false;
            // 
            // chartsLP
            // 
            this.chartsLP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartsLP.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.chartsLP.Location = new System.Drawing.Point(212, 3);
            this.chartsLP.Name = "chartsLP";
            this.chartsLP.Size = new System.Drawing.Size(242, 637);
            this.chartsLP.TabIndex = 3;
            // 
            // filterGBX
            // 
            this.filterGBX.Controls.Add(this.customFuncRBTN);
            this.filterGBX.Controls.Add(this.contrastRBTN);
            this.filterGBX.Controls.Add(this.gammaCorrectionRBTN);
            this.filterGBX.Controls.Add(this.changeBrightnessRBTN);
            this.filterGBX.Controls.Add(this.negationRBTN);
            this.filterGBX.Controls.Add(this.noFilterRBTN);
            this.filterGBX.Location = new System.Drawing.Point(22, 80);
            this.filterGBX.Name = "filterGBX";
            this.filterGBX.Size = new System.Drawing.Size(136, 175);
            this.filterGBX.TabIndex = 2;
            this.filterGBX.TabStop = false;
            this.filterGBX.Text = "filters";
            // 
            // customFuncRBTN
            // 
            this.customFuncRBTN.AutoSize = true;
            this.customFuncRBTN.Location = new System.Drawing.Point(6, 150);
            this.customFuncRBTN.Name = "customFuncRBTN";
            this.customFuncRBTN.Size = new System.Drawing.Size(117, 19);
            this.customFuncRBTN.TabIndex = 5;
            this.customFuncRBTN.TabStop = true;
            this.customFuncRBTN.Text = "Custom Function";
            this.customFuncRBTN.UseVisualStyleBackColor = true;
            this.customFuncRBTN.CheckedChanged += new System.EventHandler(this.customFuncRBTN_CheckedChanged);
            // 
            // contrastRBTN
            // 
            this.contrastRBTN.AutoSize = true;
            this.contrastRBTN.Location = new System.Drawing.Point(6, 125);
            this.contrastRBTN.Name = "contrastRBTN";
            this.contrastRBTN.Size = new System.Drawing.Size(70, 19);
            this.contrastRBTN.TabIndex = 4;
            this.contrastRBTN.TabStop = true;
            this.contrastRBTN.Text = "Contrast";
            this.contrastRBTN.UseVisualStyleBackColor = true;
            this.contrastRBTN.CheckedChanged += new System.EventHandler(this.contrastRBTN_CheckedChanged);
            // 
            // gammaCorrectionRBTN
            // 
            this.gammaCorrectionRBTN.AutoSize = true;
            this.gammaCorrectionRBTN.Location = new System.Drawing.Point(6, 97);
            this.gammaCorrectionRBTN.Name = "gammaCorrectionRBTN";
            this.gammaCorrectionRBTN.Size = new System.Drawing.Size(126, 19);
            this.gammaCorrectionRBTN.TabIndex = 3;
            this.gammaCorrectionRBTN.TabStop = true;
            this.gammaCorrectionRBTN.Text = "Gamma Correction";
            this.gammaCorrectionRBTN.UseVisualStyleBackColor = true;
            this.gammaCorrectionRBTN.CheckedChanged += new System.EventHandler(this.gammaCorrectionRBTN_CheckedChanged);
            // 
            // changeBrightnessRBTN
            // 
            this.changeBrightnessRBTN.AutoSize = true;
            this.changeBrightnessRBTN.Location = new System.Drawing.Point(6, 72);
            this.changeBrightnessRBTN.Name = "changeBrightnessRBTN";
            this.changeBrightnessRBTN.Size = new System.Drawing.Size(124, 19);
            this.changeBrightnessRBTN.TabIndex = 2;
            this.changeBrightnessRBTN.TabStop = true;
            this.changeBrightnessRBTN.Text = "Change brightness";
            this.changeBrightnessRBTN.UseVisualStyleBackColor = true;
            this.changeBrightnessRBTN.CheckedChanged += new System.EventHandler(this.changeBrightnessRBTN_CheckedChanged);
            // 
            // negationRBTN
            // 
            this.negationRBTN.AutoSize = true;
            this.negationRBTN.Location = new System.Drawing.Point(6, 47);
            this.negationRBTN.Name = "negationRBTN";
            this.negationRBTN.Size = new System.Drawing.Size(74, 19);
            this.negationRBTN.TabIndex = 1;
            this.negationRBTN.TabStop = true;
            this.negationRBTN.Text = "Negation";
            this.negationRBTN.UseVisualStyleBackColor = true;
            this.negationRBTN.CheckedChanged += new System.EventHandler(this.negationRBTN_CheckedChanged);
            // 
            // noFilterRBTN
            // 
            this.noFilterRBTN.AutoSize = true;
            this.noFilterRBTN.Location = new System.Drawing.Point(6, 22);
            this.noFilterRBTN.Name = "noFilterRBTN";
            this.noFilterRBTN.Size = new System.Drawing.Size(68, 19);
            this.noFilterRBTN.TabIndex = 0;
            this.noFilterRBTN.TabStop = true;
            this.noFilterRBTN.Text = "No filter";
            this.noFilterRBTN.UseVisualStyleBackColor = true;
            this.noFilterRBTN.CheckedChanged += new System.EventHandler(this.noFilterRBTN_CheckedChanged);
            // 
            // modeCBX
            // 
            this.modeCBX.FormattingEnabled = true;
            this.modeCBX.Location = new System.Drawing.Point(22, 34);
            this.modeCBX.Name = "modeCBX";
            this.modeCBX.Size = new System.Drawing.Size(136, 23);
            this.modeCBX.TabIndex = 1;
            this.modeCBX.SelectedIndexChanged += new System.EventHandler(this.modeCBX_SelectedIndexChanged);
            // 
            // modeLBL
            // 
            this.modeLBL.AutoSize = true;
            this.modeLBL.Location = new System.Drawing.Point(22, 34);
            this.modeLBL.Name = "modeLBL";
            this.modeLBL.Size = new System.Drawing.Size(0, 15);
            this.modeLBL.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1260, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadImageToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadImageToolStripMenuItem
            // 
            this.loadImageToolStripMenuItem.Name = "loadImageToolStripMenuItem";
            this.loadImageToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.loadImageToolStripMenuItem.Text = "Load Image";
            this.loadImageToolStripMenuItem.Click += new System.EventHandler(this.loadImageToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 664);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imagePBX)).EndInit();
            this.filterGBX.ResumeLayout(false);
            this.filterGBX.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SplitContainer splitContainer;
        private PictureBox imagePBX;
        private ComboBox modeCBX;
        private Label modeLBL;
        private GroupBox filterGBX;
        private RadioButton customFuncRBTN;
        private RadioButton contrastRBTN;
        private RadioButton gammaCorrectionRBTN;
        private RadioButton changeBrightnessRBTN;
        private RadioButton negationRBTN;
        private RadioButton noFilterRBTN;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem loadImageToolStripMenuItem;
        private FlowLayoutPanel chartsLP;
        private GroupBox controlGBX;
        private Button applyBTN;
    }
}