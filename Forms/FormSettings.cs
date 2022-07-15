using System;
using System.Windows.Forms;

namespace GraphPhys.Forms
{
	public partial class FormSettings : Form
	{
		double[] result = null;
		public FormSettings(double xMin, double xMax, double xInterval, double yMin, double yMax, double yInterval, bool autoZoom)
		{
			InitializeComponent();
			textBox_xMin.Text = xMin.ToString();
			textBox_xMax.Text = xMax.ToString();
			textBox_xInterval.Text = xInterval.ToString();

			textBox_yMin.Text = yMin.ToString();
			textBox_yMax.Text = yMax.ToString();
			textBox_yInterval.Text = yInterval.ToString();

			checkBox_ASV.Checked = autoZoom;
		}

		private void button_Apply_Click(object sender, EventArgs e)
		{
			try
			{
				this.result = new double[7];
				this.result[0] = Convert.ToSingle(textBox_xMin.Text);
				this.result[1] = Convert.ToSingle(textBox_xMax.Text);
				this.result[2] = Convert.ToSingle(textBox_xInterval.Text);
				if (result[1] <= result[0])
					throw new Exception("min value must be lower than max value");

				this.result[3] = Convert.ToSingle(textBox_yMin.Text);
				this.result[4] = Convert.ToSingle(textBox_yMax.Text);
				this.result[5] = Convert.ToSingle(textBox_yInterval.Text);
				if (result[4] <= result[3])
					throw new Exception("min value must be lower than max value");
				if(checkBox_ASV.CheckState == CheckState.Checked)
				{
					this.result[6] = 1;
				}
				else
				{
					this.result[6] = 0;
				}
				this.Close();
			}
			catch
			{
				MessageBox.Show("Wrong parametrs!");
				this.result = null;
				return;
			}
		}

		private void button_Default_Click(object sender, EventArgs e)
		{
			textBox_xMin.Text = (0).ToString();
			textBox_xMax.Text = (30).ToString();
			textBox_xInterval.Text = (2).ToString();

			textBox_yMin.Text = (0).ToString();
			textBox_yMax.Text = (30).ToString();
			textBox_yInterval.Text = (2).ToString();

			checkBox_ASV.Checked = true;
		}//defaults here

		private void button_Cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		internal static double[] ShowDia(double xMin, double xMax, double xInterval, double yMin, double yMax, double yInterval, bool autoZoom)
		{
			double[] result = null;
			var b = new FormSettings(xMin, xMax, xInterval, yMin, yMax, yInterval,autoZoom );
			b.FormClosing += (s, e) => 
			{
				if(b.result != null)
				{
					result = b.result;
				}
			};
			b.ShowDialog();
			return result;
		}

		#region header to move
		private const int WM_NCLBUTTONDOWN = 0xA1;
		private const int HT_CAPTION = 0x2;

		[System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
		private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
		[System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
		private static extern bool ReleaseCapture();

		public static void MakeMovement(IntPtr handleOfForm)
		{
			ReleaseCapture();
			SendMessage(handleOfForm, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
		}
		#endregion

		private void FormSettings_MouseMove(object sender, MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Left)
			{
				MakeMovement(this.Handle);
			}
		}
	}
}
