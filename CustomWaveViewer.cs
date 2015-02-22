﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using CommonUtils.FFT; // Audio Analyzer
using CommonUtils.Audio;

namespace CommonUtils.GUI
{
	/// <summary>
	/// Control for viewing waveforms
	/// </summary>
	public sealed class CustomWaveViewer : UserControl
	{
		#region Fields
		IWaveformPlayer soundPlayer;
		Bitmap offlineBitmap;

		int progressSample = 0;

		int startLoopSamplePosition = -1;
		int endLoopSamplePosition = -1;

		int startZoomSamplePosition = 0;
		int endZoomSamplePosition = 0;
		int previousStartZoomSamplePosition = 0;

		int amplitude = 1; // 1 = default amplitude
		
		float samplesPerPixel = 128;
		
		const int mouseMoveTolerance = 3;
		bool isMouseDown = false;
		bool isZooming = false;
		Point mouseDownPoint;
		Point currentPoint;

		Rectangle selectRegion = new Rectangle();
		int startSelectXPosition = -1;
		int endSelectXPosition = -1;
		#endregion
		
		#region Event Overrides
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			FitToScreen();
		}
		
		protected override void OnPaint(PaintEventArgs e)
		{
			if (offlineBitmap != null) {
				e.Graphics.DrawImage(offlineBitmap, 0, 0);
			}
			
			/*
			// draw marker
			using (var markerPen = new Pen(Color.Black, 1))
			{
				// what samples are we showing?
				if (progressSample >= startZoomSamplePosition && progressSample <= endZoomSamplePosition) {
					double xLocation = (progressSample - startZoomSamplePosition) / samplesPerPixel;
					e.Graphics.DrawLine(markerPen, (float) xLocation, 0, (float) xLocation, Height);
				}
			}
			
			// draw select region
			using (var loopPen = new Pen(Color.Red, 2))
			{
				if (selectRegion.Height > 0 && selectRegion.Width > 0)  {
					e.Graphics.DrawRectangle(loopPen, startSelectXPosition, 0, selectRegion.Width, selectRegion.Height);
				}
			}
			 */

			// Calling the base class OnPaint
			base.OnPaint(e);
		}
		#endregion
		
		#region Zoom Methods
		public void Zoom(int startZoomSamplePosition, int endZoomSamplePosition)
		{
			if (soundPlayer != null && soundPlayer.WaveformData != null && soundPlayer.WaveformData.Length > 1)
			{
				// make sure the zoom start and zoom end is correct
				if (startZoomSamplePosition < 0)
					startZoomSamplePosition = 0;
				if (endZoomSamplePosition > (soundPlayer.WaveformData.Length))
					endZoomSamplePosition = soundPlayer.WaveformData.Length;
				
				previousStartZoomSamplePosition = startZoomSamplePosition;
				samplesPerPixel = (float) (endZoomSamplePosition - startZoomSamplePosition) / (float) this.Width;

				// remove select region after zooming
				ClearSelectRegion();

				UpdateWaveform();
			}
		}
		
		public void FitToScreen()
		{
			if (soundPlayer != null && soundPlayer.WaveformData != null && soundPlayer.WaveformData.Length > 1)
			{
				int totalNumberOfSamples = soundPlayer.WaveformData.Length;
				samplesPerPixel = (float) totalNumberOfSamples / (float) this.Width;

				previousStartZoomSamplePosition = 0;
				startZoomSamplePosition = 0;
				endZoomSamplePosition = totalNumberOfSamples;
			}

			// remove select region after zooming
			ClearSelectRegion();
			
			// reset amplitude
			amplitude = 1;
			
			UpdateWaveform();
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// Creates a new WaveViewer control
		/// </summary>
		public CustomWaveViewer()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
			              ControlStyles.OptimizedDoubleBuffer, true);
			InitializeComponent();
			this.DoubleBuffered = true;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Register a sound player from which the waveform timeline
		/// can get the necessary playback data.
		/// </summary>
		/// <param name="soundPlayer">A sound player that provides waveform data through the IWaveformPlayer interface methods.</param>
		public void RegisterSoundPlayer(IWaveformPlayer soundPlayer)
		{
			this.soundPlayer = soundPlayer;
			soundPlayer.PropertyChanged += soundPlayer_PropertyChanged;
		}
		#endregion
		
		#region Private Drawing Methods
		private void UpdateWaveform()
		{
			if (soundPlayer == null || soundPlayer.WaveformData == null)
				return;
			
			if (soundPlayer.WaveformData != null && soundPlayer.WaveformData.Length > 1)
			{
				this.offlineBitmap = AudioAnalyzer.DrawWaveform(soundPlayer.WaveformData, new Size(this.Width, this.Height), amplitude, startZoomSamplePosition, endZoomSamplePosition, startLoopSamplePosition, endLoopSamplePosition, progressSample, soundPlayer.SampleRate, soundPlayer.Channels);

				// force redraw
				this.Invalidate();
			}
		}

		private void UpdateProgressIndicator()
		{
			if (soundPlayer != null && soundPlayer.ChannelLength != 0
			    && soundPlayer.WaveformData != null && soundPlayer.WaveformData.Length != 0)
			{
				progressSample = SecondsToSamplePosition(soundPlayer.ChannelPosition, soundPlayer.ChannelLength, soundPlayer.WaveformData.Length / soundPlayer.Channels);
				
				// force redraw
				UpdateWaveform();
			}
		}
		#endregion

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// CustomWaveViewer
			// 
			this.Name = "CustomWaveViewer";
			this.Size = new System.Drawing.Size(600, 200);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CustomWaveViewerMouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CustomWaveViewerMouseMove);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CustomWaveViewerMouseUp);
			this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.CustomWaveViewerMouseWheel);
			this.ResumeLayout(false);
		}
		#endregion
		
		#region MouseAndKeyEvents
		void CustomWaveViewerMouseWheel(object sender, MouseEventArgs e)
		{
			// most of the mouse wheel zoom logic is taken from BlueberryThing Source
			int rangeInSamples;
			int midpoint;
			int delta;
			int oldStartZoomSamplePosition;
			int oldEndZoomSamplePosition;
			int newStartZoomSamplePosition;
			int newEndZoomSamplePosition;
			float hitpointFraction;
			
			oldStartZoomSamplePosition = startZoomSamplePosition;
			oldEndZoomSamplePosition = endZoomSamplePosition;
			
			rangeInSamples = endZoomSamplePosition - startZoomSamplePosition;
			
			// Scroll the display left/right
			if ((Control.ModifierKeys & Keys.Control) == Keys.Control) {
				delta = rangeInSamples / 20;
				
				// If scrolling right (forward in time on the waveform)
				if (e.Delta > 0) {
					delta = MathUtils.LimitInt(delta, 0, (soundPlayer.WaveformData.Length) - endZoomSamplePosition);
					newStartZoomSamplePosition = startZoomSamplePosition + delta;
					newEndZoomSamplePosition = endZoomSamplePosition + delta;
				}
				
				// If scrolling left (backward in time on the waveform)
				else
				{
					delta = MathUtils.LimitInt(delta, 0, startZoomSamplePosition);
					newStartZoomSamplePosition = startZoomSamplePosition - delta;
					newEndZoomSamplePosition = endZoomSamplePosition - delta;
				}
			}

			// change the amplitude up or down
			else if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift) {
				
				// If right (increase the amplitude)
				if (e.Delta > 0) {
					// increase the amplitude
					if (amplitude * 2 < 5000) {
						amplitude*=2;
						UpdateWaveform();
					}
				}
				
				// If left (decrease the amplitude)
				else {
					amplitude/=2;
					if (amplitude < 1) amplitude = 1;
				}
				
				UpdateWaveform();
				return;
			}
			
			// Zoom the display in/out
			else {
				midpoint = startZoomSamplePosition + (rangeInSamples / 2);
				hitpointFraction = (float)e.X / (float)this.Width;
				if (hitpointFraction < 0.0f)
					hitpointFraction = 0.0f;
				if (hitpointFraction > 1.0f)
					hitpointFraction = 1.0f;
				
				if (e.Delta > 0) {
					// Zoom in
					delta = rangeInSamples / 4;
					newStartZoomSamplePosition = (int) (startZoomSamplePosition + (delta * hitpointFraction));
					newEndZoomSamplePosition = (int) (endZoomSamplePosition - (delta * (1.0 - hitpointFraction)));
					
					// only allow zooming if samples are more than 10
					int samplesSelected = newEndZoomSamplePosition - newStartZoomSamplePosition;
					if (samplesSelected <= 10) {
						return;
					}
				} else {
					// Zoom out
					delta = rangeInSamples / 3; // must use a higher delta than zoom in to make sure we can zoom out again
					newStartZoomSamplePosition = (int) (startZoomSamplePosition - (delta * hitpointFraction));
					newEndZoomSamplePosition = (int) (endZoomSamplePosition + (delta * (1.0 - hitpointFraction)));
				}
				
				// Limit the view
				if (newStartZoomSamplePosition < 0)
					newStartZoomSamplePosition = 0;
				if (newStartZoomSamplePosition > midpoint)
					newStartZoomSamplePosition = midpoint;
				if (newEndZoomSamplePosition < midpoint)
					newEndZoomSamplePosition = midpoint;
				if (newEndZoomSamplePosition > (soundPlayer.WaveformData.Length))
					newEndZoomSamplePosition = soundPlayer.WaveformData.Length;
			}
			
			startZoomSamplePosition = newStartZoomSamplePosition;
			endZoomSamplePosition = newEndZoomSamplePosition;
			
			// If there a change in the view, then refresh the display
			if ((startZoomSamplePosition != oldStartZoomSamplePosition)
			    || (endZoomSamplePosition != oldEndZoomSamplePosition))
			{
				Zoom(startZoomSamplePosition, endZoomSamplePosition);
			}
		}
		
		void CustomWaveViewerMouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Left) {
				isMouseDown = true;
				mouseDownPoint = e.Location;
				
				if ((Control.ModifierKeys & Keys.Control) == Keys.Control) {
					// Control key is being pressed
					isZooming = true;
				} else {
					isZooming = false;
				}
			}
			else if (e.Button == MouseButtons.Right) {
				FitToScreen();
			}
		}
		
		void CustomWaveViewerMouseMove(object sender, MouseEventArgs e)
		{
			currentPoint = e.Location;

			if (soundPlayer.WaveformData == null) return;
			
			if (isMouseDown) {
				if (Math.Abs(currentPoint.X - mouseDownPoint.X) > mouseMoveTolerance) {
					startSelectXPosition = Math.Min(mouseDownPoint.X, currentPoint.X);
					endSelectXPosition = Math.Max(mouseDownPoint.X, currentPoint.X);
				} else {
					ClearSelectRegion();
				}
				
				UpdateSelectRegion();
			}
		}
		
		void CustomWaveViewerMouseUp(object sender, MouseEventArgs e)
		{
			if (!isMouseDown || soundPlayer.WaveformData == null)
				return;
			
			isMouseDown = false;

			if (isZooming) {
				startZoomSamplePosition = Math.Max((int)(previousStartZoomSamplePosition + samplesPerPixel * startSelectXPosition), 0);
				endZoomSamplePosition = Math.Min((int)(previousStartZoomSamplePosition + samplesPerPixel * endSelectXPosition), soundPlayer.WaveformData.Length);
				
				// only allow zooming if samples are more than 10
				int samplesSelected = endZoomSamplePosition - startZoomSamplePosition;
				if (samplesSelected > 10) {
					Zoom(startZoomSamplePosition, endZoomSamplePosition);
				}
				return;
			}

			bool doUpdateLoopRegion = false;

			if (Math.Abs(currentPoint.X - mouseDownPoint.X) < mouseMoveTolerance) {
				// if we did not select a new loop range but just clicked
				int curSamplePosition = (int)(previousStartZoomSamplePosition + samplesPerPixel * mouseDownPoint.X);

				if (PointInLoopRegion(curSamplePosition)) {
					soundPlayer.ChannelPosition = SamplePositionToSeconds(curSamplePosition, soundPlayer.WaveformData.Length, soundPlayer.ChannelLength);
				} else {
					soundPlayer.SelectionBegin = TimeSpan.Zero;
					soundPlayer.SelectionEnd = TimeSpan.Zero;
					soundPlayer.ChannelPosition = SamplePositionToSeconds(curSamplePosition, soundPlayer.WaveformData.Length, soundPlayer.ChannelLength);
					
					startLoopSamplePosition = -1;
					endLoopSamplePosition = -1;
					
					doUpdateLoopRegion = true;
				}
			} else {
				startLoopSamplePosition = Math.Max((int)(previousStartZoomSamplePosition + samplesPerPixel * startSelectXPosition), 0);
				endLoopSamplePosition = Math.Min((int)(previousStartZoomSamplePosition + samplesPerPixel * endSelectXPosition), soundPlayer.WaveformData.Length);

				soundPlayer.SelectionBegin = TimeSpan.FromSeconds(SamplePositionToSeconds(startLoopSamplePosition, soundPlayer.WaveformData.Length, soundPlayer.ChannelLength));
				soundPlayer.SelectionEnd = TimeSpan.FromSeconds(SamplePositionToSeconds(endLoopSamplePosition, soundPlayer.WaveformData.Length, soundPlayer.ChannelLength));
				soundPlayer.ChannelPosition = SamplePositionToSeconds(startLoopSamplePosition, soundPlayer.WaveformData.Length, soundPlayer.ChannelLength);
			}
			
			if (doUpdateLoopRegion) {
				startSelectXPosition = 0;
				endSelectXPosition = 0;
				UpdateSelectRegion();
			}
		}
		
		/// <summary>Keys which can generate OnKeyDown event.</summary>
		private static readonly Keys[] InputKeys = new []
		{ Keys.Left, Keys.Up, Keys.Right, Keys.Down, Keys.Oemcomma, Keys.Home, Keys.OemPeriod, Keys.End };

		protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
		{
			if(Array.IndexOf<Keys>(InputKeys, e.KeyCode) != -1)
			{
				e.IsInputKey = true;
			}
			base.OnPreviewKeyDown(e);
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
			
			if (e.KeyCode == Keys.Up) {
				// increase the amplitude
				if (amplitude * 2 < 5000) {
					amplitude*=2;
					UpdateWaveform();
				}
			} else if (e.KeyCode == Keys.Down) {
				// decrease the amplitude
				amplitude/=2;
				if (amplitude < 1) amplitude = 1;
				UpdateWaveform();
			} else if (e.KeyCode == Keys.Right) {
				ScrollTime(true);
			} else if (e.KeyCode == Keys.Left) {
				ScrollTime(false);
			} else if (e.KeyCode == Keys.Oemcomma || e.KeyCode == Keys.Home) {
				soundPlayer.ChannelPosition = 0;
				FitToScreen();
			} else if (e.KeyCode == Keys.OemPeriod || e.KeyCode == Keys.End) {
				soundPlayer.ChannelPosition = soundPlayer.ChannelLength;
				FitToScreen();
			}
		}
		#endregion
		
		#region Private Static Util Methods
		/// <summary>
		/// Convert a sample position to a time in seconds
		/// </summary>
		/// <param name="samplePosition">sample position</param>
		/// <param name="totalSamples">total number of samples</param>
		/// <param name="totalDurationSeconds">total duration in seconds</param>
		/// <returns>Time in seconds</returns>
		private static double SamplePositionToSeconds(int samplePosition, int totalSamples, double totalDurationSeconds) {
			double positionPercent = (double) samplePosition / (double) totalSamples;
			double position = (totalDurationSeconds * positionPercent);
			return Math.Min(totalDurationSeconds, Math.Max(0, position));
		}

		/// <summary>
		/// Convert a time in seconds to sample position
		/// </summary>
		/// <param name="channelPositionSeconds">time in seconds</param>
		/// <param name="totalDurationSeconds">total duration in seconds</param>
		/// <param name="totalSamples">total number of samples</param>
		/// <returns>Sample position</returns>
		private static int SecondsToSamplePosition(double channelPositionSeconds, double totalDurationSeconds, int totalSamples) {
			double progressPercent = channelPositionSeconds / totalDurationSeconds;
			int position = (int) (totalSamples * progressPercent);
			return Math.Min(totalSamples, Math.Max(0, position));
		}
		#endregion
		
		#region Private Methods
		/// <summary>
		/// Check if a given sample position is within the current set loop
		/// </summary>
		/// <param name="samplePosition">sample position to check</param>
		/// <returns>boolean that tells if the given sample position is within the current selection (loop)</returns>
		private bool PointInLoopRegion(int samplePosition) {
			if (soundPlayer.ChannelLength == 0)
				return false;

			double loopStartSamples = (soundPlayer.SelectionBegin.TotalSeconds / soundPlayer.ChannelLength) * soundPlayer.WaveformData.Length / soundPlayer.Channels;
			double loopEndSamples = (soundPlayer.SelectionEnd.TotalSeconds / soundPlayer.ChannelLength) * soundPlayer.WaveformData.Length / soundPlayer.Channels;
			
			return (samplePosition >= loopStartSamples && samplePosition < loopEndSamples);
		}
		
		private void ScrollTime(bool doScrollRight) {

			if (soundPlayer.WaveformData == null) return;

			int range;
			int delta;
			int oldstartZoomSamplePosition;
			int oldendZoomSamplePosition;
			int newstartZoomSamplePosition;
			int newendZoomSamplePosition;

			oldstartZoomSamplePosition = startZoomSamplePosition;
			oldendZoomSamplePosition = endZoomSamplePosition;
			
			range = endZoomSamplePosition - startZoomSamplePosition;
			delta = range / 20;
			
			// If scrolling right (forward in time on the waveform)
			if (doScrollRight) {
				delta = MathUtils.LimitInt(delta, 0, (soundPlayer.WaveformData.Length) - endZoomSamplePosition);
				newstartZoomSamplePosition = startZoomSamplePosition + delta;
				newendZoomSamplePosition = endZoomSamplePosition + delta;
			} else {
				// If scrolling left (backward in time on the waveform)
				delta = MathUtils.LimitInt(delta, 0, startZoomSamplePosition);
				newstartZoomSamplePosition = startZoomSamplePosition - delta;
				newendZoomSamplePosition = endZoomSamplePosition - delta;
			}
			
			startZoomSamplePosition = newstartZoomSamplePosition;
			endZoomSamplePosition = newendZoomSamplePosition;
			
			// If there a change in the view, then refresh the display
			if ((startZoomSamplePosition != oldstartZoomSamplePosition)
			    || (endZoomSamplePosition != oldendZoomSamplePosition))
			{
				Zoom(startZoomSamplePosition, endZoomSamplePosition);
			}
		}
		
		private void UpdateSelectRegion()
		{
			selectRegion.Width = endSelectXPosition - startSelectXPosition;
			selectRegion.Height = this.Height;
			
			// force redraw
			UpdateWaveform();
		}
		
		private void ClearSelectRegion() {
			startSelectXPosition = -1;
			endSelectXPosition = -1;
			selectRegion.Width = 0;
			selectRegion.Height = 0;
		}
		#endregion

		#region Event Handlers
		private void soundPlayer_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			switch (e.PropertyName)
			{
				case "SelectionBegin":
					startLoopSamplePosition = SecondsToSamplePosition(soundPlayer.SelectionBegin.TotalSeconds, soundPlayer.ChannelLength, soundPlayer.WaveformData.Length / soundPlayer.Channels);
					break;
				case "SelectionEnd":
					endLoopSamplePosition = SecondsToSamplePosition(soundPlayer.SelectionEnd.TotalSeconds, soundPlayer.ChannelLength, soundPlayer.WaveformData.Length / soundPlayer.Channels);
					break;
				case "WaveformData":
					FitToScreen();
					break;
				case "ChannelPosition":
					UpdateProgressIndicator();
					break;
				case "ChannelLength":
					startLoopSamplePosition = -1;
					endLoopSamplePosition = -1;
					break;
			}
		}
		#endregion
	}
}