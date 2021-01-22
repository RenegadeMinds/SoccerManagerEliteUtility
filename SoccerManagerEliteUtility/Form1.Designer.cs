namespace SoccerManagerEliteUtility
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
            this.btnGo = new System.Windows.Forms.Button();
            this.cbxRpcs = new System.Windows.Forms.ComboBox();
            this.cbxClubs = new System.Windows.Forms.ComboBox();
            this.cbxPlayers = new System.Windows.Forms.ComboBox();
            this.cbxGameWorlds = new System.Windows.Forms.ComboBox();
            this.ttTips = new System.Windows.Forms.ToolTip(this.components);
            this.cbxUsernames = new System.Windows.Forms.ComboBox();
            this.cbxFixtures = new System.Windows.Forms.ComboBox();
            this.cbxSeasons = new System.Windows.Forms.ComboBox();
            this.cbxLeagues = new System.Windows.Forms.ComboBox();
            this.cbxTurns = new System.Windows.Forms.ComboBox();
            this.lblClubs = new System.Windows.Forms.Label();
            this.lblPlayers = new System.Windows.Forms.Label();
            this.lblFixtures = new System.Windows.Forms.Label();
            this.lblUsers = new System.Windows.Forms.Label();
            this.lblGameWorld = new System.Windows.Forms.Label();
            this.lblSeasons = new System.Windows.Forms.Label();
            this.lblUsersClub = new System.Windows.Forms.Label();
            this.lblLeagues = new System.Windows.Forms.Label();
            this.Turns = new System.Windows.Forms.Label();
            this.nudNum = new System.Windows.Forms.NumericUpDown();
            this.lblNum = new System.Windows.Forms.Label();
            this.pbxClub = new System.Windows.Forms.PictureBox();
            this.pbxPlayer = new System.Windows.Forms.PictureBox();
            this.cbxDataPack = new System.Windows.Forms.ComboBox();
            this.fctbJson = new FastColoredTextBoxNS.FastColoredTextBox();
            this.scPanels = new System.Windows.Forms.SplitContainer();
            this.tabReports = new System.Windows.Forms.TabControl();
            this.tpText = new System.Windows.Forms.TabPage();
            this.scReports = new System.Windows.Forms.SplitContainer();
            this.fctbReportMaster = new FastColoredTextBoxNS.FastColoredTextBox();
            this.ruler = new FastColoredTextBoxNS.Ruler();
            this.fctbReportSlave = new FastColoredTextBoxNS.FastColoredTextBox();
            this.tpGrid = new System.Windows.Forms.TabPage();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.adgvReport = new Zuby.ADGV.AdvancedDataGridView();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.adgvSearch = new Zuby.ADGV.AdvancedDataGridViewSearchToolBar();
            this.pnlSave = new System.Windows.Forms.Panel();
            this.btnExportCsv = new System.Windows.Forms.Button();
            this.bsBinder = new System.Windows.Forms.BindingSource(this.components);
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.miFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miSaveReport = new System.Windows.Forms.ToolStripMenuItem();
            this.miSaveJson = new System.Windows.Forms.ToolStripMenuItem();
            this.cbxSqlReports = new System.Windows.Forms.ComboBox();
            this.btnSqlReport = new System.Windows.Forms.Button();
            this.sfdExportCSV = new System.Windows.Forms.SaveFileDialog();
            this.miHelp1 = new System.Windows.Forms.ToolStripMenuItem();
            this.miHelp2 = new System.Windows.Forms.ToolStripMenuItem();
            this.miAbout = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.nudNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fctbJson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scPanels)).BeginInit();
            this.scPanels.Panel1.SuspendLayout();
            this.scPanels.Panel2.SuspendLayout();
            this.scPanels.SuspendLayout();
            this.tabReports.SuspendLayout();
            this.tpText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scReports)).BeginInit();
            this.scReports.Panel1.SuspendLayout();
            this.scReports.Panel2.SuspendLayout();
            this.scReports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctbReportMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fctbReportSlave)).BeginInit();
            this.tpGrid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgvReport)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlSave.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsBinder)).BeginInit();
            this.msMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            resources.ApplyResources(this.btnGo, "btnGo");
            this.btnGo.Name = "btnGo";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // cbxRpcs
            // 
            this.cbxRpcs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRpcs.FormattingEnabled = true;
            resources.ApplyResources(this.cbxRpcs, "cbxRpcs");
            this.cbxRpcs.Name = "cbxRpcs";
            this.cbxRpcs.SelectedIndexChanged += new System.EventHandler(this.cbxRpcs_SelectedIndexChanged);
            // 
            // cbxClubs
            // 
            this.cbxClubs.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxClubs.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.cbxClubs.FormattingEnabled = true;
            resources.ApplyResources(this.cbxClubs, "cbxClubs");
            this.cbxClubs.Name = "cbxClubs";
            this.ttTips.SetToolTip(this.cbxClubs, resources.GetString("cbxClubs.ToolTip"));
            this.cbxClubs.SelectedIndexChanged += new System.EventHandler(this.cbxClubs_SelectedIndexChanged);
            // 
            // cbxPlayers
            // 
            this.cbxPlayers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxPlayers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxPlayers.FormattingEnabled = true;
            resources.ApplyResources(this.cbxPlayers, "cbxPlayers");
            this.cbxPlayers.Name = "cbxPlayers";
            this.ttTips.SetToolTip(this.cbxPlayers, resources.GetString("cbxPlayers.ToolTip"));
            this.cbxPlayers.SelectedIndexChanged += new System.EventHandler(this.cbxPlayers_SelectedIndexChanged);
            // 
            // cbxGameWorlds
            // 
            this.cbxGameWorlds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxGameWorlds.FormattingEnabled = true;
            resources.ApplyResources(this.cbxGameWorlds, "cbxGameWorlds");
            this.cbxGameWorlds.Name = "cbxGameWorlds";
            this.ttTips.SetToolTip(this.cbxGameWorlds, resources.GetString("cbxGameWorlds.ToolTip"));
            // 
            // cbxUsernames
            // 
            this.cbxUsernames.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxUsernames.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxUsernames.FormattingEnabled = true;
            resources.ApplyResources(this.cbxUsernames, "cbxUsernames");
            this.cbxUsernames.Name = "cbxUsernames";
            this.ttTips.SetToolTip(this.cbxUsernames, resources.GetString("cbxUsernames.ToolTip"));
            this.cbxUsernames.SelectedIndexChanged += new System.EventHandler(this.cbxUsernames_SelectedIndexChanged);
            // 
            // cbxFixtures
            // 
            this.cbxFixtures.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxFixtures.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxFixtures.FormattingEnabled = true;
            resources.ApplyResources(this.cbxFixtures, "cbxFixtures");
            this.cbxFixtures.Name = "cbxFixtures";
            this.ttTips.SetToolTip(this.cbxFixtures, resources.GetString("cbxFixtures.ToolTip"));
            this.cbxFixtures.SelectedIndexChanged += new System.EventHandler(this.cbxFixtures_SelectedIndexChanged);
            // 
            // cbxSeasons
            // 
            this.cbxSeasons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSeasons.FormattingEnabled = true;
            resources.ApplyResources(this.cbxSeasons, "cbxSeasons");
            this.cbxSeasons.Name = "cbxSeasons";
            this.ttTips.SetToolTip(this.cbxSeasons, resources.GetString("cbxSeasons.ToolTip"));
            // 
            // cbxLeagues
            // 
            this.cbxLeagues.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxLeagues.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxLeagues.FormattingEnabled = true;
            resources.ApplyResources(this.cbxLeagues, "cbxLeagues");
            this.cbxLeagues.Name = "cbxLeagues";
            this.ttTips.SetToolTip(this.cbxLeagues, resources.GetString("cbxLeagues.ToolTip"));
            this.cbxLeagues.SelectedIndexChanged += new System.EventHandler(this.cbxLeagues_SelectedIndexChanged);
            // 
            // cbxTurns
            // 
            this.cbxTurns.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxTurns.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxTurns.FormattingEnabled = true;
            resources.ApplyResources(this.cbxTurns, "cbxTurns");
            this.cbxTurns.Name = "cbxTurns";
            this.ttTips.SetToolTip(this.cbxTurns, resources.GetString("cbxTurns.ToolTip"));
            this.cbxTurns.SelectedIndexChanged += new System.EventHandler(this.cbxTurns_SelectedIndexChanged);
            // 
            // lblClubs
            // 
            resources.ApplyResources(this.lblClubs, "lblClubs");
            this.lblClubs.Name = "lblClubs";
            // 
            // lblPlayers
            // 
            resources.ApplyResources(this.lblPlayers, "lblPlayers");
            this.lblPlayers.Name = "lblPlayers";
            // 
            // lblFixtures
            // 
            resources.ApplyResources(this.lblFixtures, "lblFixtures");
            this.lblFixtures.Name = "lblFixtures";
            // 
            // lblUsers
            // 
            resources.ApplyResources(this.lblUsers, "lblUsers");
            this.lblUsers.Name = "lblUsers";
            // 
            // lblGameWorld
            // 
            resources.ApplyResources(this.lblGameWorld, "lblGameWorld");
            this.lblGameWorld.Name = "lblGameWorld";
            // 
            // lblSeasons
            // 
            resources.ApplyResources(this.lblSeasons, "lblSeasons");
            this.lblSeasons.Name = "lblSeasons";
            // 
            // lblUsersClub
            // 
            resources.ApplyResources(this.lblUsersClub, "lblUsersClub");
            this.lblUsersClub.Name = "lblUsersClub";
            // 
            // lblLeagues
            // 
            resources.ApplyResources(this.lblLeagues, "lblLeagues");
            this.lblLeagues.Name = "lblLeagues";
            // 
            // Turns
            // 
            resources.ApplyResources(this.Turns, "Turns");
            this.Turns.Name = "Turns";
            // 
            // nudNum
            // 
            resources.ApplyResources(this.nudNum, "nudNum");
            this.nudNum.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNum.Name = "nudNum";
            this.nudNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblNum
            // 
            resources.ApplyResources(this.lblNum, "lblNum");
            this.lblNum.Name = "lblNum";
            // 
            // pbxClub
            // 
            resources.ApplyResources(this.pbxClub, "pbxClub");
            this.pbxClub.Name = "pbxClub";
            this.pbxClub.TabStop = false;
            this.pbxClub.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbxClub_MouseClick);
            this.pbxClub.MouseEnter += new System.EventHandler(this.pbxClub_MouseEnter);
            this.pbxClub.MouseLeave += new System.EventHandler(this.pbxClub_MouseLeave);
            // 
            // pbxPlayer
            // 
            resources.ApplyResources(this.pbxPlayer, "pbxPlayer");
            this.pbxPlayer.Name = "pbxPlayer";
            this.pbxPlayer.TabStop = false;
            this.pbxPlayer.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbxPlayer_MouseClick);
            this.pbxPlayer.MouseEnter += new System.EventHandler(this.pbxPlayer_MouseEnter);
            this.pbxPlayer.MouseLeave += new System.EventHandler(this.pbxPlayer_MouseLeave);
            // 
            // cbxDataPack
            // 
            this.cbxDataPack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDataPack.FormattingEnabled = true;
            this.cbxDataPack.Items.AddRange(new object[] {
            resources.GetString("cbxDataPack.Items"),
            resources.GetString("cbxDataPack.Items1")});
            resources.ApplyResources(this.cbxDataPack, "cbxDataPack");
            this.cbxDataPack.Name = "cbxDataPack";
            this.cbxDataPack.SelectedIndexChanged += new System.EventHandler(this.cbxDataPack_SelectedIndexChanged);
            // 
            // fctbJson
            // 
            this.fctbJson.AutoCompleteBracketsList = new char[] {
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
            this.fctbJson.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\r\n";
            resources.ApplyResources(this.fctbJson, "fctbJson");
            this.fctbJson.BackBrush = null;
            this.fctbJson.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.fctbJson.CharHeight = 14;
            this.fctbJson.CharWidth = 8;
            this.fctbJson.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctbJson.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctbJson.IsReplaceMode = false;
            this.fctbJson.Language = FastColoredTextBoxNS.Language.JSON;
            this.fctbJson.LeftBracket = '[';
            this.fctbJson.LeftBracket2 = '{';
            this.fctbJson.Name = "fctbJson";
            this.fctbJson.Paddings = new System.Windows.Forms.Padding(0);
            this.fctbJson.RightBracket = ']';
            this.fctbJson.RightBracket2 = '}';
            this.fctbJson.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctbJson.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctbJson.ServiceColors")));
            this.fctbJson.Zoom = 100;
            this.fctbJson.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.fctbJson_TextChanged);
            this.fctbJson.TextChangedDelayed += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.fctbJson_TextChangedDelayed);
            this.fctbJson.AutoIndentNeeded += new System.EventHandler<FastColoredTextBoxNS.AutoIndentEventArgs>(this.fctbJson_AutoIndentNeeded);
            // 
            // scPanels
            // 
            resources.ApplyResources(this.scPanels, "scPanels");
            this.scPanels.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scPanels.Name = "scPanels";
            // 
            // scPanels.Panel1
            // 
            this.scPanels.Panel1.Controls.Add(this.fctbJson);
            // 
            // scPanels.Panel2
            // 
            this.scPanels.Panel2.Controls.Add(this.tabReports);
            // 
            // tabReports
            // 
            this.tabReports.Controls.Add(this.tpText);
            this.tabReports.Controls.Add(this.tpGrid);
            resources.ApplyResources(this.tabReports, "tabReports");
            this.tabReports.Name = "tabReports";
            this.tabReports.SelectedIndex = 0;
            // 
            // tpText
            // 
            this.tpText.Controls.Add(this.scReports);
            resources.ApplyResources(this.tpText, "tpText");
            this.tpText.Name = "tpText";
            this.tpText.UseVisualStyleBackColor = true;
            // 
            // scReports
            // 
            this.scReports.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.scReports, "scReports");
            this.scReports.Name = "scReports";
            // 
            // scReports.Panel1
            // 
            this.scReports.Panel1.Controls.Add(this.fctbReportMaster);
            this.scReports.Panel1.Controls.Add(this.ruler);
            // 
            // scReports.Panel2
            // 
            this.scReports.Panel2.Controls.Add(this.fctbReportSlave);
            // 
            // fctbReportMaster
            // 
            this.fctbReportMaster.AutoCompleteBracketsList = new char[] {
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
            this.fctbReportMaster.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\n^\\s*(case|default)\\s*[^:]*(" +
    "?<range>:)\\s*(?<range>[^;]+);";
            resources.ApplyResources(this.fctbReportMaster, "fctbReportMaster");
            this.fctbReportMaster.BackBrush = null;
            this.fctbReportMaster.CharHeight = 15;
            this.fctbReportMaster.CharWidth = 7;
            this.fctbReportMaster.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctbReportMaster.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctbReportMaster.IsReplaceMode = false;
            this.fctbReportMaster.Name = "fctbReportMaster";
            this.fctbReportMaster.Paddings = new System.Windows.Forms.Padding(0);
            this.fctbReportMaster.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctbReportMaster.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctbReportMaster.ServiceColors")));
            this.fctbReportMaster.Zoom = 100;
            this.fctbReportMaster.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.fctbReport_TextChanged);
            this.fctbReportMaster.TextChangedDelayed += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.fctbReport_TextChangedDelayed);
            this.fctbReportMaster.AutoIndentNeeded += new System.EventHandler<FastColoredTextBoxNS.AutoIndentEventArgs>(this.fctbReport_AutoIndentNeeded);
            // 
            // ruler
            // 
            resources.ApplyResources(this.ruler, "ruler");
            this.ruler.Name = "ruler";
            this.ruler.Target = this.fctbReportMaster;
            // 
            // fctbReportSlave
            // 
            this.fctbReportSlave.AutoCompleteBracketsList = new char[] {
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
            this.fctbReportSlave.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\n^\\s*(case|default)\\s*[^:]*(" +
    "?<range>:)\\s*(?<range>[^;]+);";
            resources.ApplyResources(this.fctbReportSlave, "fctbReportSlave");
            this.fctbReportSlave.BackBrush = null;
            this.fctbReportSlave.CharHeight = 15;
            this.fctbReportSlave.CharWidth = 7;
            this.fctbReportSlave.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctbReportSlave.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctbReportSlave.IsReplaceMode = false;
            this.fctbReportSlave.Name = "fctbReportSlave";
            this.fctbReportSlave.Paddings = new System.Windows.Forms.Padding(0);
            this.fctbReportSlave.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctbReportSlave.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctbReportSlave.ServiceColors")));
            this.fctbReportSlave.SourceTextBox = this.fctbReportMaster;
            this.fctbReportSlave.Zoom = 100;
            this.fctbReportSlave.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.fctbReport_TextChanged);
            this.fctbReportSlave.TextChangedDelayed += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.fctbReport_TextChangedDelayed);
            this.fctbReportSlave.AutoIndentNeeded += new System.EventHandler<FastColoredTextBoxNS.AutoIndentEventArgs>(this.fctbReport_AutoIndentNeeded);
            // 
            // tpGrid
            // 
            this.tpGrid.Controls.Add(this.pnlBottom);
            this.tpGrid.Controls.Add(this.pnlTop);
            resources.ApplyResources(this.tpGrid, "tpGrid");
            this.tpGrid.Name = "tpGrid";
            this.tpGrid.UseVisualStyleBackColor = true;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.adgvReport);
            resources.ApplyResources(this.pnlBottom, "pnlBottom");
            this.pnlBottom.Name = "pnlBottom";
            // 
            // adgvReport
            // 
            this.adgvReport.AllowUserToAddRows = false;
            this.adgvReport.AllowUserToDeleteRows = false;
            this.adgvReport.AllowUserToOrderColumns = true;
            this.adgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.adgvReport, "adgvReport");
            this.adgvReport.FilterAndSortEnabled = true;
            this.adgvReport.Name = "adgvReport";
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.pnlSearch);
            this.pnlTop.Controls.Add(this.pnlSave);
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.Name = "pnlTop";
            // 
            // pnlSearch
            // 
            resources.ApplyResources(this.pnlSearch, "pnlSearch");
            this.pnlSearch.Controls.Add(this.adgvSearch);
            this.pnlSearch.Name = "pnlSearch";
            // 
            // adgvSearch
            // 
            this.adgvSearch.AllowMerge = false;
            resources.ApplyResources(this.adgvSearch, "adgvSearch");
            this.adgvSearch.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.adgvSearch.Name = "adgvSearch";
            this.adgvSearch.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.adgvSearch.Search += new Zuby.ADGV.AdvancedDataGridViewSearchToolBarSearchEventHandler(this.adgvSearch_Search);
            // 
            // pnlSave
            // 
            resources.ApplyResources(this.pnlSave, "pnlSave");
            this.pnlSave.Controls.Add(this.btnExportCsv);
            this.pnlSave.Name = "pnlSave";
            // 
            // btnExportCsv
            // 
            resources.ApplyResources(this.btnExportCsv, "btnExportCsv");
            this.btnExportCsv.Name = "btnExportCsv";
            this.btnExportCsv.UseVisualStyleBackColor = true;
            this.btnExportCsv.Click += new System.EventHandler(this.btnExportCsv_Click);
            // 
            // msMenu
            // 
            this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile,
            this.miHelp1});
            resources.ApplyResources(this.msMenu, "msMenu");
            this.msMenu.Name = "msMenu";
            // 
            // miFile
            // 
            this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miSaveReport,
            this.miSaveJson});
            this.miFile.Name = "miFile";
            resources.ApplyResources(this.miFile, "miFile");
            // 
            // miSaveReport
            // 
            this.miSaveReport.Name = "miSaveReport";
            resources.ApplyResources(this.miSaveReport, "miSaveReport");
            this.miSaveReport.Click += new System.EventHandler(this.miSaveReport_Click);
            // 
            // miSaveJson
            // 
            this.miSaveJson.Name = "miSaveJson";
            resources.ApplyResources(this.miSaveJson, "miSaveJson");
            this.miSaveJson.Click += new System.EventHandler(this.miSaveJson_Click);
            // 
            // cbxSqlReports
            // 
            this.cbxSqlReports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSqlReports.FormattingEnabled = true;
            this.cbxSqlReports.Items.AddRange(new object[] {
            resources.GetString("cbxSqlReports.Items"),
            resources.GetString("cbxSqlReports.Items1"),
            resources.GetString("cbxSqlReports.Items2"),
            resources.GetString("cbxSqlReports.Items3")});
            resources.ApplyResources(this.cbxSqlReports, "cbxSqlReports");
            this.cbxSqlReports.Name = "cbxSqlReports";
            // 
            // btnSqlReport
            // 
            resources.ApplyResources(this.btnSqlReport, "btnSqlReport");
            this.btnSqlReport.Name = "btnSqlReport";
            this.btnSqlReport.UseVisualStyleBackColor = true;
            this.btnSqlReport.Click += new System.EventHandler(this.btnSqlReport_Click);
            // 
            // sfdExportCSV
            // 
            this.sfdExportCSV.DefaultExt = "csv";
            resources.ApplyResources(this.sfdExportCSV, "sfdExportCSV");
            this.sfdExportCSV.SupportMultiDottedExtensions = true;
            // 
            // miHelp1
            // 
            this.miHelp1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miHelp2,
            this.miAbout});
            this.miHelp1.Name = "miHelp1";
            resources.ApplyResources(this.miHelp1, "miHelp1");
            // 
            // miHelp2
            // 
            this.miHelp2.Name = "miHelp2";
            resources.ApplyResources(this.miHelp2, "miHelp2");
            this.miHelp2.Click += new System.EventHandler(this.miHelp2_Click);
            // 
            // miAbout
            // 
            this.miAbout.Name = "miAbout";
            resources.ApplyResources(this.miAbout, "miAbout");
            this.miAbout.Click += new System.EventHandler(this.miAbout_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSqlReport);
            this.Controls.Add(this.cbxSqlReports);
            this.Controls.Add(this.scPanels);
            this.Controls.Add(this.cbxDataPack);
            this.Controls.Add(this.pbxPlayer);
            this.Controls.Add(this.pbxClub);
            this.Controls.Add(this.lblNum);
            this.Controls.Add(this.nudNum);
            this.Controls.Add(this.Turns);
            this.Controls.Add(this.cbxTurns);
            this.Controls.Add(this.lblLeagues);
            this.Controls.Add(this.cbxLeagues);
            this.Controls.Add(this.lblUsersClub);
            this.Controls.Add(this.lblSeasons);
            this.Controls.Add(this.lblGameWorld);
            this.Controls.Add(this.lblUsers);
            this.Controls.Add(this.lblFixtures);
            this.Controls.Add(this.lblPlayers);
            this.Controls.Add(this.lblClubs);
            this.Controls.Add(this.cbxSeasons);
            this.Controls.Add(this.cbxFixtures);
            this.Controls.Add(this.cbxUsernames);
            this.Controls.Add(this.cbxGameWorlds);
            this.Controls.Add(this.cbxPlayers);
            this.Controls.Add(this.cbxClubs);
            this.Controls.Add(this.cbxRpcs);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.msMenu);
            this.MainMenuStrip = this.msMenu;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fctbJson)).EndInit();
            this.scPanels.Panel1.ResumeLayout(false);
            this.scPanels.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scPanels)).EndInit();
            this.scPanels.ResumeLayout(false);
            this.tabReports.ResumeLayout(false);
            this.tpText.ResumeLayout(false);
            this.scReports.Panel1.ResumeLayout(false);
            this.scReports.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scReports)).EndInit();
            this.scReports.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fctbReportMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fctbReportSlave)).EndInit();
            this.tpGrid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.adgvReport)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlSave.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsBinder)).EndInit();
            this.msMenu.ResumeLayout(false);
            this.msMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.ComboBox cbxRpcs;
        private System.Windows.Forms.ComboBox cbxClubs;
        private System.Windows.Forms.ComboBox cbxPlayers;
        private System.Windows.Forms.ToolTip ttTips;
        private System.Windows.Forms.ComboBox cbxGameWorlds;
        private System.Windows.Forms.ComboBox cbxUsernames;
        private System.Windows.Forms.ComboBox cbxFixtures;
        private System.Windows.Forms.ComboBox cbxSeasons;
        private System.Windows.Forms.Label lblClubs;
        private System.Windows.Forms.Label lblPlayers;
        private System.Windows.Forms.Label lblFixtures;
        private System.Windows.Forms.Label lblUsers;
        private System.Windows.Forms.Label lblGameWorld;
        private System.Windows.Forms.Label lblSeasons;
        private System.Windows.Forms.Label lblUsersClub;
        private System.Windows.Forms.ComboBox cbxLeagues;
        private System.Windows.Forms.Label lblLeagues;
        private System.Windows.Forms.ComboBox cbxTurns;
        private System.Windows.Forms.Label Turns;
        private System.Windows.Forms.NumericUpDown nudNum;
        private System.Windows.Forms.Label lblNum;
        private System.Windows.Forms.PictureBox pbxClub;
        private System.Windows.Forms.PictureBox pbxPlayer;
        private System.Windows.Forms.ComboBox cbxDataPack;
        private FastColoredTextBoxNS.FastColoredTextBox fctbJson;
        private System.Windows.Forms.SplitContainer scPanels;
        private FastColoredTextBoxNS.FastColoredTextBox fctbReportMaster;
        private System.Windows.Forms.SplitContainer scReports;
        private FastColoredTextBoxNS.FastColoredTextBox fctbReportSlave;
        private FastColoredTextBoxNS.Ruler ruler;
        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.ToolStripMenuItem miFile;
        private System.Windows.Forms.ToolStripMenuItem miSaveReport;
        private System.Windows.Forms.ToolStripMenuItem miSaveJson;
        private System.Windows.Forms.ComboBox cbxSqlReports;
        private System.Windows.Forms.Button btnSqlReport;
        private System.Windows.Forms.TabControl tabReports;
        private System.Windows.Forms.TabPage tpText;
        private System.Windows.Forms.TabPage tpGrid;
        private System.Windows.Forms.Panel pnlBottom;
        private Zuby.ADGV.AdvancedDataGridView adgvReport;
        private System.Windows.Forms.BindingSource bsBinder;
        private System.Windows.Forms.Panel pnlTop;
        private Zuby.ADGV.AdvancedDataGridViewSearchToolBar adgvSearch;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Panel pnlSave;
        private System.Windows.Forms.Button btnExportCsv;
        private System.Windows.Forms.SaveFileDialog sfdExportCSV;
        private System.Windows.Forms.ToolStripMenuItem miHelp1;
        private System.Windows.Forms.ToolStripMenuItem miHelp2;
        private System.Windows.Forms.ToolStripMenuItem miAbout;
    }
}

