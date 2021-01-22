namespace SoccerManagerEliteUtility
{
    partial class NamePackConverter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NamePackConverter));
            this.btnOpenDataPack = new System.Windows.Forms.Button();
            this.fctbPlayers = new FastColoredTextBoxNS.FastColoredTextBox();
            this.fctbClubs = new FastColoredTextBoxNS.FastColoredTextBox();
            this.btnProcessDataPack = new System.Windows.Forms.Button();
            this.ofdOpenDataPack = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.fctbPlayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fctbClubs)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpenDataPack
            // 
            this.btnOpenDataPack.Location = new System.Drawing.Point(12, 12);
            this.btnOpenDataPack.Name = "btnOpenDataPack";
            this.btnOpenDataPack.Size = new System.Drawing.Size(171, 23);
            this.btnOpenDataPack.TabIndex = 0;
            this.btnOpenDataPack.Text = "Open Data Pack";
            this.btnOpenDataPack.UseVisualStyleBackColor = true;
            this.btnOpenDataPack.Click += new System.EventHandler(this.btnOpenDataPack_Click);
            // 
            // fctbPlayers
            // 
            this.fctbPlayers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.fctbPlayers.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.fctbPlayers.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\n^\\s*(case|default)\\s*[^:]*(" +
    "?<range>:)\\s*(?<range>[^;]+);";
            this.fctbPlayers.AutoScrollMinSize = new System.Drawing.Size(179, 14);
            this.fctbPlayers.BackBrush = null;
            this.fctbPlayers.CharHeight = 14;
            this.fctbPlayers.CharWidth = 8;
            this.fctbPlayers.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctbPlayers.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctbPlayers.IsReplaceMode = false;
            this.fctbPlayers.Location = new System.Drawing.Point(12, 41);
            this.fctbPlayers.Name = "fctbPlayers";
            this.fctbPlayers.Paddings = new System.Windows.Forms.Padding(0);
            this.fctbPlayers.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctbPlayers.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctbPlayers.ServiceColors")));
            this.fctbPlayers.Size = new System.Drawing.Size(324, 397);
            this.fctbPlayers.TabIndex = 1;
            this.fctbPlayers.Text = "fastColoredTextBox1";
            this.fctbPlayers.Zoom = 100;
            // 
            // fctbClubs
            // 
            this.fctbClubs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fctbClubs.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.fctbClubs.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\n^\\s*(case|default)\\s*[^:]*(" +
    "?<range>:)\\s*(?<range>[^;]+);";
            this.fctbClubs.AutoScrollMinSize = new System.Drawing.Size(179, 14);
            this.fctbClubs.BackBrush = null;
            this.fctbClubs.CharHeight = 14;
            this.fctbClubs.CharWidth = 8;
            this.fctbClubs.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctbClubs.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctbClubs.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.fctbClubs.IsReplaceMode = false;
            this.fctbClubs.Location = new System.Drawing.Point(342, 41);
            this.fctbClubs.Name = "fctbClubs";
            this.fctbClubs.Paddings = new System.Windows.Forms.Padding(0);
            this.fctbClubs.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctbClubs.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctbClubs.ServiceColors")));
            this.fctbClubs.Size = new System.Drawing.Size(324, 397);
            this.fctbClubs.TabIndex = 2;
            this.fctbClubs.Text = "fastColoredTextBox1";
            this.fctbClubs.Zoom = 100;
            // 
            // btnProcessDataPack
            // 
            this.btnProcessDataPack.Location = new System.Drawing.Point(189, 12);
            this.btnProcessDataPack.Name = "btnProcessDataPack";
            this.btnProcessDataPack.Size = new System.Drawing.Size(171, 23);
            this.btnProcessDataPack.TabIndex = 3;
            this.btnProcessDataPack.Text = "Process Data Pack";
            this.btnProcessDataPack.UseVisualStyleBackColor = true;
            this.btnProcessDataPack.Click += new System.EventHandler(this.btnProcessDataPack_Click);
            // 
            // ofdOpenDataPack
            // 
            this.ofdOpenDataPack.Filter = "JSON files|*.json";
            // 
            // NamePackConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 450);
            this.Controls.Add(this.btnProcessDataPack);
            this.Controls.Add(this.fctbClubs);
            this.Controls.Add(this.fctbPlayers);
            this.Controls.Add(this.btnOpenDataPack);
            this.Name = "NamePackConverter";
            this.Text = "NamePackConverter";
            this.Load += new System.EventHandler(this.NamePackConverter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fctbPlayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fctbClubs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpenDataPack;
        private FastColoredTextBoxNS.FastColoredTextBox fctbPlayers;
        private FastColoredTextBoxNS.FastColoredTextBox fctbClubs;
        private System.Windows.Forms.Button btnProcessDataPack;
        private System.Windows.Forms.OpenFileDialog ofdOpenDataPack;
    }
}