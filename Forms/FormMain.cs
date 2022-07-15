using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GraphPhys.Forms
{
	public partial class FormMain : Form
	{
		public FormMain()
		{
			InitializeComponent();
			defaults = new double[7] { 0, 30, 2, 0, 30, 2, 1 };
			chartIsEmpty = true;
			d = double.NaN;
			q1 = double.NaN;
			q2 = double.NaN;
			indexToCreateNewGraph = 0;
			posU = new PointF();
			_maxGraphs = 0;
			_activeGraph = 0;
			showVector = true;
			autoZoom = true;
		}//set defaults
		#region variables
		private double d;//distance between q1(0,0) and q2
		private double q1;
		private double q2;
		private PointF posEsum;//chart based point
		private PointF posU;//chart based point
		//private Point sourceUPoint;//form based point(user point)
		private double[] defaults;//xMin, xMax, xInterval, yMin, yMax, yInterval
		private bool _chartIsEmpty;
		private bool chartIsEmpty
		{
			get
			{
				return _chartIsEmpty;
			}
			set
			{
				_chartIsEmpty = value;
				OnChartStatusChange(value);
			}
		}
		private bool showVector;//draw vector over chart line
		private int _activeGraph;
		private int ActiveGraph
		{
			get
			{
				return _activeGraph;
			}
			set
			{
				_activeGraph = value;
				OnActiveGraphChange(value);
			}
		}
		private bool autoZoom;
		private int _maxGraphs;
		private int MaxGraphs
		{
			get
			{
				return _maxGraphs;
			}
			set
			{
				var tmp = _maxGraphs;
				_maxGraphs = value;
				OnMaxGraphsChange(value,tmp);
			}
		}
		List<PointF[]> activePoints = new List<PointF[]>();
		List<float> esumValues = new List<float>();
		List<float> psumValues = new List<float>();
		int indexToCreateNewGraph;
		private void FormMain_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.I)
			{
				MessageBox.Show("nikasbos@mail.ru", "info");
			}
		}
		#endregion variables

		private void Form1_Load(object sender, EventArgs e)
		{
			MaxGraphs++;
			comboBox_Graphs.SelectedIndex = ActiveGraph;
		}//empty chart

		#region graphics funcs
		private void chart1_Paint(object sender, PaintEventArgs e)
		{
			#region axis
			if (chart1.ChartAreas[0].AxisX.Minimum == 0 && chart1.ChartAreas[0].AxisY.Minimum == 0)
			{
				float chartZeroLocX = (float)Math.Round(chart1.ChartAreas[0].AxisX.ValueToPixelPosition(0), 5);//form based x-coordinate
				float chartZeroLocY = (float)Math.Round(chart1.ChartAreas[0].AxisY.ValueToPixelPosition(0), 5);//form based y-coordinate
				float xMax = (float)Math.Round(chart1.ChartAreas[0].AxisX.ValueToPixelPosition(chart1.ChartAreas[0].AxisX.Maximum), 5);//form based x-coordinate
				float yMax = (float)Math.Round(chart1.ChartAreas[0].AxisY.ValueToPixelPosition(chart1.ChartAreas[0].AxisY.Maximum), 5);//form based y-coordinate
				e.Graphics.DrawLine(new Pen(Color.Black, 4F) { EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor },
					new PointF(chartZeroLocX, chartZeroLocY),
					new PointF(xMax, chartZeroLocY));//X-axis
				e.Graphics.DrawLine(new Pen(Color.Black, 4F) { EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor },
					new PointF(chartZeroLocX, chartZeroLocY),
					new PointF(chartZeroLocX, yMax));//Y-axis
			}//axis
			#endregion axis
			#region q1,q2 circles
			if (!double.IsNaN(d))
			{
				float q1X = (float)Math.Round(chart1.ChartAreas[0].AxisX.ValueToPixelPosition(0), 5);//form based x-coordinate
				float q1Y = (float)Math.Round(chart1.ChartAreas[0].AxisY.ValueToPixelPosition(0), 5);//form based y-coordinate
				float q2X = (float)Math.Round(chart1.ChartAreas[0].AxisX.ValueToPixelPosition(d), 5);//form based x-coordinate
				float q2Y = (float)Math.Round(chart1.ChartAreas[0].AxisY.ValueToPixelPosition(0), 5);//form based y-coordinate
				e.Graphics.FillRectangle(new SolidBrush(Color.Red), q1X - 5, q1Y - 5, 10, 10);//draw circle on q1
				e.Graphics.FillRectangle(new SolidBrush(Color.Red), q2X - 5, q2Y - 5, 10, 10);//draw circle on q2
			}
			#endregion q1,q2 circles
			#region vectors over chart line
			if (!chartIsEmpty && showVector)
			{
				DrawVectors(activePoints, e.Graphics);
			}//drawing vector
			#endregion vectors over chart line
		}//drawing (X- Y- axis lines),(q1,q2 circles), vectors
		private void DrawVectors(List<PointF[]> points,//PointF[0] = start vector point, PointF[1] = end vector point
			Graphics graphics)
		{
			for(int ind=0; ind<points.Count; ind++)
			{
				var arp = points[ind];
				if (arp.Length == 0)
				{
					continue;
				}
				PointF beginning = arp[0];
				PointF end = arp[1];
				float upX = (float)Math.Round(chart1.ChartAreas[0].AxisX.ValueToPixelPosition(beginning.X), 5);//form based x-coordinate(vector start point)
				float upY = (float)Math.Round(chart1.ChartAreas[0].AxisY.ValueToPixelPosition(beginning.Y), 5);//form based y-coordinate(vector start point)
				float esumX = (float)Math.Round(chart1.ChartAreas[0].AxisX.ValueToPixelPosition(end.X), 5);//form based x-coordinate(vector end point)
				float esumY = (float)Math.Round(chart1.ChartAreas[0].AxisY.ValueToPixelPosition(end.Y), 5);//form based y-coordinate(vector end point)
				
				graphics.DrawLine(new Pen(
					(ActiveGraph==ind? Color.FromArgb(255,0,0) : Color.FromArgb(51,153,255)), 6F)
				{ EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor },
					upX, upY,
					esumX, esumY);//draw vector
			}
		}
		private void chart1_MouseMove(object sender, MouseEventArgs e)
		{
			System.Windows.Forms.DataVisualization.Charting.ChartArea tc;
			float xChart = float.NaN, yChart = float.NaN;
			try
			{
				tc = chart1.ChartAreas[0];//just less symbols to type
				xChart = (float)Math.Round(tc.AxisX.PixelPositionToValue(e.X), 2);//chart based mouse coordinates
				yChart = (float)Math.Round(tc.AxisY.PixelPositionToValue(e.Y), 2);//chart based mouse coordinates
				#region moving dot(q2)
					if (!double.IsNaN(d) && e.Button == MouseButtons.Left)
					{
						float xDifference = 2F, yDifference = 2F;//maximum difference between (q2 x- and y- coordinates) and (mouseclick x- and y- coordinates)
						if (
							(xChart >= (d - xDifference) && xChart <= (d + xDifference))//x difference check
							&&
							(yChart >= (0 - yDifference) && yChart <= (0 + yDifference))//y difference check
							&&
							xChart > 0
							)
						{
							d = xChart;
							textBox_d.Text = Math.Round(d, 2).ToString();
							button_Apply.PerformClick();
						}//set new d-value and redraw chart
					}
					#endregion
				if (xChart >= tc.AxisX.Minimum && xChart <= tc.AxisX.Maximum
					&& yChart >= tc.AxisY.Minimum && yChart <= tc.AxisY.Maximum)
				{
					label_x.Text = $"X:{xChart}";
					label_y.Text = $"Y:{yChart}";
				}

			}
			catch
			{
				//if (float.IsNaN(xChart) || float.IsNaN(yChart)) mb_FUT
				//	return;
			}
		}//redraw chart when q2-point is moving, show mouse's x- y- coordinates
		private void chart1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (double.IsNaN(d) || double.IsNaN(q1) || double.IsNaN(q2))
			{
				return;
			}//check1
			if (button_Zoom.Text == "Reset Zoom")
			{
				button_Zoom.PerformClick();
				return;
			}//reset zoom
			//sourceUPoint = new Point(e.X, e.Y);//save user point based on form for further
			posU.X = Convert.ToSingle(chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X));//get chartbased X-position of mouseClickEvent
			posU.Y = Convert.ToSingle(chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Y));//get chartbased Y-position of mouseClickEvent
			if (posU.X <= 0 || posU.Y <= 0)
			{
				return;
			}//check3
			if (MaxGraphs == 0) MaxGraphs++;//initialize pointArray for new chart info if it is first graph
			CalcAddPoints(new PointF[] { posU },ActiveGraph);
			chartIsEmpty = false;
			chart1.Invalidate();
		}//main func
		private void CalcAddPoints(PointF[] pArr, int indexGraph)//calculate posEsum, set values to textboxes, add points to chart1.Series[indexGraph]
		{
			if(pArr.Length <= 0 || pArr[0].IsEmpty)
			{
				return;
			}
			PointF userPoint = pArr[0];
			#region math
			PointF posE1;
			PointF posE2;
			posE1 = Calcs.Find_E1e(userPoint, q1);
			posE2 = Calcs.Find_E2e(userPoint, q2, d);
			posEsum = Calcs.Find_Parallelogram_Corner(userPoint, posE1, posE2);
			#endregion math
			activePoints[indexGraph] = new PointF[] { userPoint, posEsum };//set values to this pointArray
			#region math2
			float Esum = (float)Math.Round(Calcs.Find_r((activePoints[indexGraph])[1], userPoint), 3);
			esumValues.Add(new float());
			float psum = (float)Math.Round(Calcs.Find_p(q1, q2, 1d, new PointF(0, 0), new PointF((float)Math.Round(d, 5), 0), userPoint),3);
			psumValues.Add(new float());//REMOVABLE
			#endregion math2
			esumValues[indexGraph] = Esum;
			psumValues[indexGraph] = psum;
			#region set values to labels E and P
			label_E1.Text = $"E={esumValues[indexGraph]} В/м";
			label_p1.Text = $"φ={psumValues[indexGraph]} В";
			#endregion set values to labels E and P
			#region if autoZoom enabled
			if (autoZoom)
			{
				int standardK = 15;
				double kXY;
				double axisMin;
				double axisLength;
				if (chart1.ChartAreas[0].AxisX.Maximum > chart1.ChartAreas[0].AxisY.Maximum)
				{
					axisMin = chart1.ChartAreas[0].AxisX.Maximum / standardK;
					axisLength = Math.Abs((activePoints[indexGraph])[1].X - (activePoints[indexGraph])[0].X);
				}
				else if (chart1.ChartAreas[0].AxisX.Maximum < chart1.ChartAreas[0].AxisY.Maximum)
				{
					axisMin = chart1.ChartAreas[0].AxisY.Maximum / standardK;
					axisLength = Math.Abs((activePoints[indexGraph])[1].Y - (activePoints[indexGraph])[0].Y);
				}
				else
				{
					axisMin = chart1.ChartAreas[0].AxisX.Maximum / standardK;
					double xLength = Math.Abs((activePoints[indexGraph])[1].X - (activePoints[indexGraph])[0].X);
					double yLength = Math.Abs((activePoints[indexGraph])[1].Y - (activePoints[indexGraph])[0].Y);
					axisLength = xLength > yLength ? yLength : xLength;
				}
				if (Esum < axisMin)
				{
					kXY = Find_kXY(axisLength, axisMin);
					double xLength = (activePoints[indexGraph])[1].X - (activePoints[indexGraph])[0].X;
					double yLength = (activePoints[indexGraph])[1].Y - (activePoints[indexGraph])[0].Y;
					float newX = (float)Math.Round(xLength * kXY, 5);
					float newY = (float)Math.Round(yLength * kXY, 5);
					while(newX>chart1.ChartAreas[0].AxisX.Maximum || newY > chart1.ChartAreas[0].AxisX.Maximum)
					{
						newX/=2;
						newY/=2;
					}
					(activePoints[indexGraph])[1].X += newX;
					(activePoints[indexGraph])[1].Y += newY;
				}
				if((activePoints[indexGraph])[1].X > chart1.ChartAreas[0].AxisX.Maximum)
				{
					float cF = (float)Math.Round(chart1.ChartAreas[0].AxisX.Maximum / activePoints[indexGraph][1].X - 0.1d, 6, MidpointRounding.ToEven);
					activePoints[indexGraph][1].X *= cF;
					activePoints[indexGraph][1].Y *= cF;
				}
			}
			#endregion if autoZoom enabled
			#region set points to Series[](with indexGraph index)
			chart1.Series[indexGraph].Points.Clear();//clear active series to draw new line
			chart1.Series[indexGraph].Points.AddXY((activePoints[indexGraph])[0].X, (activePoints[indexGraph])[0].Y);//start vector point(user point)
			chart1.Series[indexGraph].Points.AddXY((activePoints[indexGraph])[1].X, (activePoints[indexGraph])[1].Y);//end vector point(esum point)
			#endregion set points to Series[](with indexGraph index)
		}
		#endregion graphics funcs

		#region button clicks
		private void button_Apply_Click(object sender, EventArgs e)//set values from textboxes and redraw chart
		{
			try
			{
				q1 = Convert.ToDouble(textBox_q1.Text);
				q2 = Convert.ToDouble(textBox_q2.Text);
				d = Convert.ToDouble(textBox_d.Text);
				button_Apply.Enabled = false;
				chart1.Invalidate();
			}
			catch
			{
				MessageBox.Show("Wrong parametrs!");
				return;
			}
			if (!chartIsEmpty)
			{
				for (int graphInd = 0; graphInd < MaxGraphs; graphInd++)
				{
					CalcAddPoints(activePoints[graphInd], graphInd);
				}
				label_E1.Text = $"E={esumValues[ActiveGraph]} В/м";
				label_p1.Text = $"φ={psumValues[ActiveGraph]} В";
				chart1.Invalidate();
			}
		}
		private void button_Zoom_Click(object sender, EventArgs e)
		{
			if (activePoints[ActiveGraph].Length <= 0) return;
			if (button_Zoom.Text == "Reset Zoom")
			{
				ChartDefault();
				button_Zoom.Text = "Zoom";
				return;
			}//if resettings zoom
			if (!chartIsEmpty)
			{
				#region X-axis
				double xMin;
				double xMax;
				double xInterval;
				double xLength;
				#region identify xMin and xMax values 
				if ((activePoints[ActiveGraph])[0].X > (activePoints[ActiveGraph])[1].X)
				{
					xMin = (activePoints[ActiveGraph])[1].X;
					xMax = (activePoints[ActiveGraph])[0].X;
				}
				else
				{
					xMin = (activePoints[ActiveGraph])[0].X;
					xMax = (activePoints[ActiveGraph])[1].X;
				}
				#endregion identify xMin and xMax values
				#region math
				xLength = Math.Abs((activePoints[ActiveGraph])[0].X - (activePoints[ActiveGraph])[1].X);//get axis projection
				xMin -= xLength;
				xMax += xLength;
				xInterval = xLength / 2;
				if (xLength > 1)
				{
					xMin = Math.Floor(xMin);
					xMax = Math.Ceiling(xMax);
					xInterval = Math.Floor(xInterval);
				}
				#endregion math
				chart1.ChartAreas[0].AxisX.Minimum = xMin;
				chart1.ChartAreas[0].AxisX.Maximum = xMax;
				chart1.ChartAreas[0].AxisX.Interval = xInterval;
				#endregion X-axis

				#region Y-axis
				double yMin;
				double yMax;
				double yInterval;
				double yLength;
				#region identify yMin and yMax values
				if ((activePoints[ActiveGraph])[0].Y > (activePoints[ActiveGraph])[1].Y)
				{
					yMin = (activePoints[ActiveGraph])[1].Y;
					yMax = (activePoints[ActiveGraph])[0].Y;
				}
				else
				{
					yMin = (activePoints[ActiveGraph])[0].Y;
					yMax = (activePoints[ActiveGraph])[1].Y;
				}
				#endregion identify yMin and yMax values
				#region math
				yLength = Math.Abs((activePoints[ActiveGraph])[0].Y - (activePoints[ActiveGraph])[1].Y);
				yMin -= yLength;
				yMax += yLength;
				yInterval = yLength / 2;
				if (yLength > 1)
				{
					yMin = Math.Floor(yMin);
					yMax = Math.Ceiling(yMax);
					yInterval = Math.Floor(yInterval);
				}
				#endregion math
				chart1.ChartAreas[0].AxisY.Minimum = yMin;
				chart1.ChartAreas[0].AxisY.Maximum = yMax;
				chart1.ChartAreas[0].AxisY.Interval = yInterval;
				#endregion Y-axis
				button_Zoom.Text = "Reset Zoom";
			}//if zooming
		}
		private void button_Reset_Click(object sender, EventArgs e)
		{
			MaxGraphs = 0;//zero value cauze there is no graphs ATM
			MaxGraphs++;
			comboBox_Graphs.SelectedItem = ActiveGraph;
		}
		private void button_Settings_Click(object sender, EventArgs e)
		{
			var c = chart1.ChartAreas[0];
			var settings = Forms.FormSettings.ShowDia(c.AxisX.Minimum, c.AxisX.Maximum, c.AxisX.Interval, c.AxisY.Minimum, c.AxisY.Maximum, c.AxisY.Interval, autoZoom);
			if (settings != null)
			{
				//change current values
				c.AxisX.Minimum = settings[0];
				c.AxisX.Maximum = settings[1];
				c.AxisX.Interval = settings[2];
				c.AxisY.Minimum = settings[3];
				c.AxisY.Maximum = settings[4];
				c.AxisY.Interval = settings[5];
				bool autoZoomSettings = (settings[6] == 1);
				if (autoZoom != autoZoomSettings)
				{
					autoZoom = autoZoomSettings;
					if (MaxGraphs > 0)
					{
						for (int graphInd = 0; graphInd < MaxGraphs; graphInd++)
						{
							CalcAddPoints(activePoints[graphInd], graphInd);
						}
						label_E1.Text = $"E={esumValues[ActiveGraph]} В/м";
						label_p1.Text = $"φ={psumValues[ActiveGraph]} В";
					}
					chart1.Invalidate();
				}
				//sourceUPoint.X = (int)Math.Round(chart1.ChartAreas[0].AxisX.ValueToPixelPosition(posU.X), 0);
				for (int i = 0; i < 7; i++)
				{
					defaults[i] = settings[i];
				}//set this values as defaults
			}//apply settings
		}
		private void button_AddGraph_Click(object sender, EventArgs e)
		{
			MaxGraphs++;
			comboBox_Graphs.SelectedIndex = MaxGraphs-1;
		}
		private void button_GraphRemove_Click(object sender, EventArgs e)
		{

			int indexToRemove = chart1.Series.IndexOf($"ca{comboBox_Graphs.SelectedItem}");//find index of removing item from Series[]
			chart1.Series.RemoveAt(indexToRemove);//clear serie with this graph
			activePoints.RemoveAt(indexToRemove);
			esumValues.RemoveAt(indexToRemove);//clear e-value of this graph
			psumValues.RemoveAt(indexToRemove);//clear p-value of this graph
			comboBox_Graphs.Items.RemoveAt(indexToRemove);
			MaxGraphs--;//decrease number to further graph's adding
			if (MaxGraphs == 0) MaxGraphs++;

			comboBox_Graphs.SelectedIndex = 0;//change combobox chose
			ActiveGraph = 0;
		}
		#endregion button clicks

		private void userValues_Changed(object sender, EventArgs e)
		{
			button_Apply.Enabled = true;
		}//invoke this func when q1/q2/d textBoxes changed

		#region property change funcs
		private void OnChartStatusChange(bool empty)
		{
			button_Zoom.Enabled = !empty;//chart !empty => zoom enabled
			button_Reset.Enabled = !empty;//chart !empty => reset enabled
			if (empty)
			{
				ChartDefault();
			}//chart !empty => reset zoom and set CURRENT defaults for chart
		}

		#region multi-graphs funcs
		private void OnMaxGraphsChange(int value, int oldValue)
		{
			if (value == 0)
			{
				if (button_Zoom.Text == "Reset Zoom")
				{
					button_Zoom.PerformClick();
				}//reset zoom
				//d = double.NaN; q1 = double.NaN; q2 = double.NaN;//reset values
				//textBox_d.Clear();
				//textBox_q1.Clear();
				//textBox_q2.Clear();
				label_E1.Text = string.Empty;
				label_p1.Text = string.Empty;
				chart1.Series.Clear();//reset all charts
				chartIsEmpty = true;
				ActiveGraph = 0;
				activePoints.Clear();
				comboBox_Graphs.Items.Clear();
				indexToCreateNewGraph = 0;
				esumValues.Clear();
				psumValues.Clear();
			}
			else if (value == oldValue + 1)//if u add new graph
			{
				activePoints.Add(new PointF[] { });//initialize additional arraw for user point coordinates and Esum coordinates
				esumValues.Add(new float());
				psumValues.Add(new float());

				chart1.Series.Add($"ca{indexToCreateNewGraph}");//add new chart
				chart1.Series[value-1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
				chart1.Series[value-1].Points.AddXY(0, 0);
				comboBox_Graphs.Items.Add(indexToCreateNewGraph);
				indexToCreateNewGraph++;
			}
		}
		private void OnActiveGraphChange(int activeGraph)
		{
			if (MaxGraphs != 0)
			{
				label_E1.Text = $"E={esumValues[activeGraph]} В/м";
				label_p1.Text = $"φ={psumValues[activeGraph]} В";
			}
		}//change activeGraph
		#endregion multi-graphs funcs
		#endregion property change funcs

		private void ChartDefault()
		{
			chart1.ChartAreas[0].AxisX.Minimum = defaults[0];
			chart1.ChartAreas[0].AxisX.Maximum = defaults[1];
			chart1.ChartAreas[0].AxisX.Interval = defaults[2];
			chart1.ChartAreas[0].AxisY.Minimum = defaults[3];
			chart1.ChartAreas[0].AxisY.Maximum = defaults[4];
			chart1.ChartAreas[0].AxisY.Interval = defaults[5];
			autoZoom = (defaults[6] == 1);
		}//X-axis and Y-axis defaults(min,max,interval values)

		private double Find_kXY(double axisLength, double axisStandardLength)
		{
			if (axisLength > axisStandardLength)
				throw new Exception("Bad func usage");
			return axisStandardLength / axisLength;
		}

		private void comboBox_Graphs_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (button_Zoom.Text == "Reset Zoom") button_Zoom.PerformClick();
			int ind = chart1.Series.IndexOf($"ca{comboBox_Graphs.SelectedItem}");
			ActiveGraph = ind;
			button_GraphRemove.Enabled = true;
			chart1.Invalidate();
		}
	}
}
