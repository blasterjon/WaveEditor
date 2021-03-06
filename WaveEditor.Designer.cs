﻿namespace WaveEditor
{
	partial class WaveEditor
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private CommonUtils.GUI.CustomWaveViewer customWaveViewer1;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Label lblFilename;
		private System.Windows.Forms.Label lblZoomIn;
		private System.Windows.Forms.HScrollBar hScrollBar;
		private System.Windows.Forms.Label lblZoomOut;
		private System.Windows.Forms.Label lblZoomSelection;
		private System.Windows.Forms.Label lblZoomInAmplitude;
		private System.Windows.Forms.Label lblZoomOutAmplitude;
		private System.Windows.Forms.Label lblIncreaseSelection;
		private System.Windows.Forms.Label lblDecreaseSelection;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
		private System.Windows.Forms.Label lblBitdepth;
		private System.Windows.Forms.Label lblChannels;
		private System.Windows.Forms.Label lblZoomRatio;
		private System.Windows.Forms.Label lblPlayPosition;
		private System.Windows.Forms.Label lblDuration;
		private System.Windows.Forms.Label lblSelection;
		private System.Windows.Forms.Label lblSamplerate;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem selectionGridLinesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sampleDisplayToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem samplesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem secondsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem timeFormatToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.ToolStripMenuItem snapToZeroCrossingToolStripMenuItem;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaveEditor));
			this.customWaveViewer1 = new CommonUtils.GUI.CustomWaveViewer();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.lblZoomIn = new System.Windows.Forms.Label();
			this.lblZoomOut = new System.Windows.Forms.Label();
			this.lblZoomSelection = new System.Windows.Forms.Label();
			this.lblZoomInAmplitude = new System.Windows.Forms.Label();
			this.lblZoomOutAmplitude = new System.Windows.Forms.Label();
			this.lblIncreaseSelection = new System.Windows.Forms.Label();
			this.lblDecreaseSelection = new System.Windows.Forms.Label();
			this.lblFilename = new System.Windows.Forms.Label();
			this.hScrollBar = new System.Windows.Forms.HScrollBar();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.lblZoomRatio = new System.Windows.Forms.Label();
			this.lblPlayPosition = new System.Windows.Forms.Label();
			this.lblDuration = new System.Windows.Forms.Label();
			this.lblSelection = new System.Windows.Forms.Label();
			this.lblSamplerate = new System.Windows.Forms.Label();
			this.lblChannels = new System.Windows.Forms.Label();
			this.lblBitdepth = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.selectionGridLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sampleDisplayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.samplesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.secondsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.timeFormatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.snapToZeroCrossingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.flowLayoutPanel1.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// customWaveViewer1
			// 
			this.customWaveViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.customWaveViewer1.EndLoopSamplePosition = -1;
			this.customWaveViewer1.EndZoomSamplePosition = 0;
			this.customWaveViewer1.Location = new System.Drawing.Point(0, 44);
			this.customWaveViewer1.Name = "customWaveViewer1";
			this.customWaveViewer1.PreviousStartZoomSamplePosition = 0;
			this.customWaveViewer1.SamplesPerPixel = 128D;
			this.customWaveViewer1.Size = new System.Drawing.Size(654, 213);
			this.customWaveViewer1.SnapToZeroCrossing = false;
			this.customWaveViewer1.StartLoopSamplePosition = 0;
			this.customWaveViewer1.StartZoomSamplePosition = 0;
			this.customWaveViewer1.TabIndex = 0;
			this.customWaveViewer1.TimelineUnit = CommonUtils.MathLib.FFT.TimelineUnit.Time;
			this.customWaveViewer1.WaveformDrawingHeight = 183;
			this.customWaveViewer1.WaveformDrawingWidth = 594;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.lblZoomIn);
			this.flowLayoutPanel1.Controls.Add(this.lblZoomOut);
			this.flowLayoutPanel1.Controls.Add(this.lblZoomSelection);
			this.flowLayoutPanel1.Controls.Add(this.lblZoomInAmplitude);
			this.flowLayoutPanel1.Controls.Add(this.lblZoomOutAmplitude);
			this.flowLayoutPanel1.Controls.Add(this.lblIncreaseSelection);
			this.flowLayoutPanel1.Controls.Add(this.lblDecreaseSelection);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 295);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(654, 20);
			this.flowLayoutPanel1.TabIndex = 10;
			// 
			// lblZoomIn
			// 
			this.lblZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("lblZoomIn.Image")));
			this.lblZoomIn.Location = new System.Drawing.Point(3, 0);
			this.lblZoomIn.Name = "lblZoomIn";
			this.lblZoomIn.Size = new System.Drawing.Size(16, 16);
			this.lblZoomIn.TabIndex = 0;
			this.toolTip1.SetToolTip(this.lblZoomIn, "Zoom In");
			this.lblZoomIn.Click += new System.EventHandler(this.LblZoomInClick);
			// 
			// lblZoomOut
			// 
			this.lblZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("lblZoomOut.Image")));
			this.lblZoomOut.Location = new System.Drawing.Point(25, 0);
			this.lblZoomOut.Name = "lblZoomOut";
			this.lblZoomOut.Size = new System.Drawing.Size(16, 16);
			this.lblZoomOut.TabIndex = 1;
			this.toolTip1.SetToolTip(this.lblZoomOut, "Zoom Out");
			this.lblZoomOut.Click += new System.EventHandler(this.LblZoomOutClick);
			// 
			// lblZoomSelection
			// 
			this.lblZoomSelection.Image = ((System.Drawing.Image)(resources.GetObject("lblZoomSelection.Image")));
			this.lblZoomSelection.Location = new System.Drawing.Point(47, 0);
			this.lblZoomSelection.Name = "lblZoomSelection";
			this.lblZoomSelection.Size = new System.Drawing.Size(16, 16);
			this.lblZoomSelection.TabIndex = 2;
			this.toolTip1.SetToolTip(this.lblZoomSelection, "Zoom Selection");
			this.lblZoomSelection.Click += new System.EventHandler(this.LblZoomSelectionClick);
			// 
			// lblZoomInAmplitude
			// 
			this.lblZoomInAmplitude.Image = ((System.Drawing.Image)(resources.GetObject("lblZoomInAmplitude.Image")));
			this.lblZoomInAmplitude.Location = new System.Drawing.Point(69, 0);
			this.lblZoomInAmplitude.Name = "lblZoomInAmplitude";
			this.lblZoomInAmplitude.Size = new System.Drawing.Size(16, 16);
			this.lblZoomInAmplitude.TabIndex = 3;
			this.toolTip1.SetToolTip(this.lblZoomInAmplitude, "Zoom In Amplitude");
			this.lblZoomInAmplitude.Click += new System.EventHandler(this.LblZoomInAmplitudeClick);
			// 
			// lblZoomOutAmplitude
			// 
			this.lblZoomOutAmplitude.Image = ((System.Drawing.Image)(resources.GetObject("lblZoomOutAmplitude.Image")));
			this.lblZoomOutAmplitude.Location = new System.Drawing.Point(91, 0);
			this.lblZoomOutAmplitude.Name = "lblZoomOutAmplitude";
			this.lblZoomOutAmplitude.Size = new System.Drawing.Size(16, 16);
			this.lblZoomOutAmplitude.TabIndex = 4;
			this.toolTip1.SetToolTip(this.lblZoomOutAmplitude, "Zoom Out Amplitude");
			this.lblZoomOutAmplitude.Click += new System.EventHandler(this.LblZoomOutAmplitudeClick);
			// 
			// lblIncreaseSelection
			// 
			this.lblIncreaseSelection.Image = ((System.Drawing.Image)(resources.GetObject("lblIncreaseSelection.Image")));
			this.lblIncreaseSelection.Location = new System.Drawing.Point(113, 0);
			this.lblIncreaseSelection.Name = "lblIncreaseSelection";
			this.lblIncreaseSelection.Size = new System.Drawing.Size(16, 16);
			this.lblIncreaseSelection.TabIndex = 5;
			this.toolTip1.SetToolTip(this.lblIncreaseSelection, "Increase Selection");
			this.lblIncreaseSelection.Click += new System.EventHandler(this.LblIncreaseSelectionClick);
			// 
			// lblDecreaseSelection
			// 
			this.lblDecreaseSelection.Image = ((System.Drawing.Image)(resources.GetObject("lblDecreaseSelection.Image")));
			this.lblDecreaseSelection.Location = new System.Drawing.Point(135, 0);
			this.lblDecreaseSelection.Name = "lblDecreaseSelection";
			this.lblDecreaseSelection.Size = new System.Drawing.Size(16, 16);
			this.lblDecreaseSelection.TabIndex = 6;
			this.toolTip1.SetToolTip(this.lblDecreaseSelection, "Decrease Selection");
			this.lblDecreaseSelection.Click += new System.EventHandler(this.LblDecreaseSelectionClick);
			// 
			// lblFilename
			// 
			this.lblFilename.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblFilename.Location = new System.Drawing.Point(0, 24);
			this.lblFilename.Name = "lblFilename";
			this.lblFilename.Size = new System.Drawing.Size(654, 17);
			this.lblFilename.TabIndex = 11;
			this.lblFilename.Text = "No Filename";
			this.lblFilename.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// hScrollBar
			// 
			this.hScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.hScrollBar.Location = new System.Drawing.Point(0, 256);
			this.hScrollBar.Name = "hScrollBar";
			this.hScrollBar.Size = new System.Drawing.Size(654, 16);
			this.hScrollBar.TabIndex = 12;
			this.hScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HScrollBarScroll);
			// 
			// flowLayoutPanel2
			// 
			this.flowLayoutPanel2.Controls.Add(this.lblZoomRatio);
			this.flowLayoutPanel2.Controls.Add(this.lblPlayPosition);
			this.flowLayoutPanel2.Controls.Add(this.lblDuration);
			this.flowLayoutPanel2.Controls.Add(this.lblSelection);
			this.flowLayoutPanel2.Controls.Add(this.lblSamplerate);
			this.flowLayoutPanel2.Controls.Add(this.lblChannels);
			this.flowLayoutPanel2.Controls.Add(this.lblBitdepth);
			this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 275);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.flowLayoutPanel2.Size = new System.Drawing.Size(654, 20);
			this.flowLayoutPanel2.TabIndex = 13;
			// 
			// lblZoomRatio
			// 
			this.lblZoomRatio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblZoomRatio.Location = new System.Drawing.Point(595, 0);
			this.lblZoomRatio.Name = "lblZoomRatio";
			this.lblZoomRatio.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblZoomRatio.Size = new System.Drawing.Size(56, 20);
			this.lblZoomRatio.TabIndex = 6;
			this.lblZoomRatio.Text = "Ratio";
			this.toolTip1.SetToolTip(this.lblZoomRatio, "Ratio");
			// 
			// lblPlayPosition
			// 
			this.lblPlayPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblPlayPosition.Location = new System.Drawing.Point(518, 0);
			this.lblPlayPosition.Name = "lblPlayPosition";
			this.lblPlayPosition.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblPlayPosition.Size = new System.Drawing.Size(71, 20);
			this.lblPlayPosition.TabIndex = 5;
			this.lblPlayPosition.Text = "Play Position";
			this.toolTip1.SetToolTip(this.lblPlayPosition, "Position. Click to Toggle Time Mode.");
			this.lblPlayPosition.Click += new System.EventHandler(this.LblPlayPositionClick);
			// 
			// lblDuration
			// 
			this.lblDuration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDuration.Location = new System.Drawing.Point(394, 0);
			this.lblDuration.Name = "lblDuration";
			this.lblDuration.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblDuration.Size = new System.Drawing.Size(118, 20);
			this.lblDuration.TabIndex = 4;
			this.lblDuration.Text = "Duration";
			this.toolTip1.SetToolTip(this.lblDuration, "Duration. Click to Toggle Time Mode.");
			this.lblDuration.Click += new System.EventHandler(this.LblDurationClick);
			// 
			// lblSelection
			// 
			this.lblSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblSelection.Location = new System.Drawing.Point(165, 0);
			this.lblSelection.Name = "lblSelection";
			this.lblSelection.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblSelection.Size = new System.Drawing.Size(223, 20);
			this.lblSelection.TabIndex = 3;
			this.lblSelection.Text = "[Nothing Selected]";
			this.toolTip1.SetToolTip(this.lblSelection, "Selection. Click to Toggle Time Mode.");
			this.lblSelection.Click += new System.EventHandler(this.LblSelectionClick);
			// 
			// lblSamplerate
			// 
			this.lblSamplerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblSamplerate.Location = new System.Drawing.Point(99, 0);
			this.lblSamplerate.Name = "lblSamplerate";
			this.lblSamplerate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblSamplerate.Size = new System.Drawing.Size(60, 20);
			this.lblSamplerate.TabIndex = 2;
			this.lblSamplerate.Text = "Samplerate";
			this.toolTip1.SetToolTip(this.lblSamplerate, "Sample Rate");
			// 
			// lblChannels
			// 
			this.lblChannels.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblChannels.Location = new System.Drawing.Point(48, 0);
			this.lblChannels.Name = "lblChannels";
			this.lblChannels.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblChannels.Size = new System.Drawing.Size(45, 20);
			this.lblChannels.TabIndex = 1;
			this.lblChannels.Text = "Channels";
			this.toolTip1.SetToolTip(this.lblChannels, "Channels");
			// 
			// lblBitdepth
			// 
			this.lblBitdepth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblBitdepth.Location = new System.Drawing.Point(5, 0);
			this.lblBitdepth.Name = "lblBitdepth";
			this.lblBitdepth.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblBitdepth.Size = new System.Drawing.Size(37, 20);
			this.lblBitdepth.TabIndex = 0;
			this.lblBitdepth.Text = "Bitdepth";
			this.toolTip1.SetToolTip(this.lblBitdepth, "Bit Depth");
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.fileToolStripMenuItem,
			this.optionsToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(654, 24);
			this.menuStrip1.TabIndex = 14;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.newToolStripMenuItem,
			this.openToolStripMenuItem,
			this.saveToolStripMenuItem,
			this.saveAsToolStripMenuItem,
			this.toolStripSeparator1,
			this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.newToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.newToolStripMenuItem.Text = "New";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItemClick);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.openToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.openToolStripMenuItem.Text = "Open...";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItemClick);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItemClick);
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.saveAsToolStripMenuItem.Text = "Save As...";
			this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItemClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(152, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.selectionGridLinesToolStripMenuItem,
			this.sampleDisplayToolStripMenuItem,
			this.snapToZeroCrossingToolStripMenuItem});
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
			this.optionsToolStripMenuItem.Text = "Options";
			// 
			// selectionGridLinesToolStripMenuItem
			// 
			this.selectionGridLinesToolStripMenuItem.Name = "selectionGridLinesToolStripMenuItem";
			this.selectionGridLinesToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
			this.selectionGridLinesToolStripMenuItem.Text = "Selection grid lines";
			this.selectionGridLinesToolStripMenuItem.Click += new System.EventHandler(this.SelectionGridLinesToolStripMenuItemClick);
			// 
			// sampleDisplayToolStripMenuItem
			// 
			this.sampleDisplayToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.samplesToolStripMenuItem,
			this.secondsToolStripMenuItem,
			this.timeFormatToolStripMenuItem});
			this.sampleDisplayToolStripMenuItem.Name = "sampleDisplayToolStripMenuItem";
			this.sampleDisplayToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
			this.sampleDisplayToolStripMenuItem.Text = "Sample display";
			// 
			// samplesToolStripMenuItem
			// 
			this.samplesToolStripMenuItem.Name = "samplesToolStripMenuItem";
			this.samplesToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
			this.samplesToolStripMenuItem.Text = "Samples";
			this.samplesToolStripMenuItem.Click += new System.EventHandler(this.SamplesToolStripMenuItemClick);
			// 
			// secondsToolStripMenuItem
			// 
			this.secondsToolStripMenuItem.Name = "secondsToolStripMenuItem";
			this.secondsToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
			this.secondsToolStripMenuItem.Text = "Seconds";
			this.secondsToolStripMenuItem.Click += new System.EventHandler(this.SecondsToolStripMenuItemClick);
			// 
			// timeFormatToolStripMenuItem
			// 
			this.timeFormatToolStripMenuItem.Checked = true;
			this.timeFormatToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.timeFormatToolStripMenuItem.Name = "timeFormatToolStripMenuItem";
			this.timeFormatToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
			this.timeFormatToolStripMenuItem.Text = "Time format";
			this.timeFormatToolStripMenuItem.Click += new System.EventHandler(this.TimeFormatToolStripMenuItemClick);
			// 
			// snapToZeroCrossingToolStripMenuItem
			// 
			this.snapToZeroCrossingToolStripMenuItem.Name = "snapToZeroCrossingToolStripMenuItem";
			this.snapToZeroCrossingToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
			this.snapToZeroCrossingToolStripMenuItem.Text = "Snap to zero crossing";
			this.snapToZeroCrossingToolStripMenuItem.Click += new System.EventHandler(this.SnapToZeroCrossingToolStripMenuItemClick);
			// 
			// WaveEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(654, 315);
			this.Controls.Add(this.flowLayoutPanel2);
			this.Controls.Add(this.hScrollBar);
			this.Controls.Add(this.lblFilename);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Controls.Add(this.customWaveViewer1);
			this.Controls.Add(this.menuStrip1);
			this.KeyPreview = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "WaveEditor";
			this.Text = "Wave Editor";
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel2.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
