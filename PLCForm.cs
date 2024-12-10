using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLCEmulator
{
	public partial class PLCForm : Form
	{
		private SortedSet<int> outputRows = new SortedSet<int>();
		private SortedSet<int> inputRows = new SortedSet<int>();
		private SortedSet<int> addedAnalogInputs = new SortedSet<int>();
		private SortedDictionary<int, TextBox> analogInputTextBoxes = new SortedDictionary<int, TextBox>();
		private SortedDictionary<int, List<DigitalInputOutput>> outputsCopy = new SortedDictionary<int, List<DigitalInputOutput>>();
		private List<Label> analogInputLabels = new List<Label>();
		private SortedDictionary<int, TrackBar> trackBars = new SortedDictionary<int, TrackBar>();
		public PLCForm()
		{
			InitializeComponent();
		}
		private void Form1_Load(object sender, EventArgs e)
		{

		}

		// Make copy of outputs dict to release mutex faster
		private void copyOutputs()
		{
			foreach(var item in IO.outputs)
			{
				var listCopy = new List<DigitalInputOutput>(item.Value.Count);
				foreach(var output in item.Value)
					listCopy.Add((DigitalInputOutput)output.Clone());

				if(!outputsCopy.ContainsKey(item.Key))
				{
					outputsCopy.Add(item.Key, listCopy);
				}
				else
				{
					outputsCopy[item.Key] = listCopy;
				}
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			#region handling outputs
			IO.outputMutex.WaitOne();
			copyOutputs();
			IO.outputMutex.ReleaseMutex();

			foreach(var output in outputsCopy)
			{
				//Create row in table if it doesn't exist
				if(!outputRows.Contains(output.Key))
				{
					int ind = outputGrid.Rows.Add();
					outputGrid.Rows[ind].Cells[Address.Index].Value = output.Key.ToString("000"); // set address cell
					outputGrid.Rows[ind].Cells[Y.Index].Value = "Y"; // set Y cell
					outputRows.Add(output.Key);
				}
			}

			foreach(DataGridViewRow row in outputGrid.Rows)
			{
				int outputKey = Int32.Parse((string)row.Cells[Address.Index].Value);
				if(outputsCopy.ContainsKey(outputKey))
				{
					for(int i = 2; i < row.Cells.Count; i++)
					{
						if(!outputsCopy[outputKey][i - 2].value)
						{
							row.Cells[i].Value = false;
						}
						else if(outputsCopy[outputKey][i - 2].value)
						{
							row.Cells[i].Value = true;
						}
					}
				}
			}
			#endregion

			#region handling inputs

			IO.inputMutex.WaitOne();
			foreach(var input in IO.inputs)
			{
				if(!inputRows.Contains(input.Key))
				{
					int ind = inputGrid.Rows.Add(input);
					inputGrid.Rows[ind].Cells[Address.Index].Value = input.Key.ToString("000");
					inputGrid.Rows[ind].Cells[X.Index].Value = "X"; // set X cell
					inputRows.Add(input.Key);
				}
			}
			IO.inputMutex.ReleaseMutex();

			#endregion

			#region handling analog inputs
			IO.analogInputMutex.WaitOne();
			foreach(var input in IO.analogInputs)
			{
				if(!addedAnalogInputs.Contains(input.Key))
				{
					addedAnalogInputs.Add(input.Key);
					int ind = addedAnalogInputs.Count - 1;

					#region set label properties

					analogInputLabels.Add(new Label());
					analogInputPanel.Controls.Add(analogInputLabels[ind]);
					analogInputLabels[ind].Location = new Point(30, 130 * ind);
					analogInputLabels[ind].Size = new Size(analogInputPanel.Width - 60, 40);
					analogInputLabels[ind].AutoSize = false;
					analogInputLabels[ind].Text = input.Value.name;
					analogInputLabels[ind].Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
					analogInputLabels[ind].ForeColor = SystemColors.ControlLight;
					analogInputLabels[ind].BackColor = Color.Transparent;
					analogInputLabels[ind].Name = "inputLabel" + ind.ToString();
					analogInputLabels[ind].TabIndex = 2*ind;
					analogInputLabels[ind].TextAlign = ContentAlignment.MiddleCenter;

					#endregion

					TextBox box = new TextBox();
					analogInputTextBoxes.Add(input.Key, box);
					analogInputPanel.Controls.Add(box);
					box.BackColor = SystemColors.ControlDarkDark;
					box.BorderStyle = BorderStyle.FixedSingle;
					box.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
					box.ForeColor = SystemColors.Control;
					box.Location = new Point(analogInputPanel.Width - 200, (130 * ind)+5);
					box.Name = "textBox1";
					box.Size = new Size(80, 35);
					box.TabIndex = 10;
					box.Text = "0.000";
					box.TextAlign = HorizontalAlignment.Right;
					box.BringToFront();

					Button setButton = new Button();
					analogInputPanel.Controls.Add(setButton);
					setButton.BackColor = SystemColors.Control;
					setButton.Location = new Point(analogInputPanel.Width - 100, (130 * ind) + 5);
					setButton.Name = "button1";
					setButton.Size = new Size(80, 35);
					setButton.TabIndex = 12;
					setButton.Text = "Set";
					setButton.Tag = input.Key;
					setButton.UseVisualStyleBackColor = false;
					setButton.BringToFront();
					setButton.Click += setButton_Click;

					#region set trackbar properties

					TrackBar trackBar = new TrackBar();
					trackBars.Add(input.Key, trackBar);
					analogInputPanel.Controls.Add(trackBar);
					trackBar.Location = new Point(33, (130 * ind) + 40);
					trackBar.Tag = input.Key;
					trackBar.Size = new Size(648, 70);
					trackBar.TabIndex = 2*ind + 1;
					trackBar.Maximum = 1000;
					trackBar.Minimum = 0;
					trackBar.TickFrequency = 1;
					trackBar.TickStyle = TickStyle.None;
					trackBar.Scroll += trackBar_Scroll;

					#endregion
				}
			}
			IO.analogInputMutex.ReleaseMutex();
			#endregion
		}

		private void setButton_Click(object sender, EventArgs e)
		{
			double value;
			Button button = (Button)sender;
			int channel = (int)button.Tag;
			if(Double.TryParse(analogInputTextBoxes[channel].Text, out value))
			{
				IO.analogInputMutex.WaitOne();
				IO.analogInputs[channel].value = (float)value;
				IO.analogInputMutex.ReleaseMutex();

				trackBars[channel].Value = (int)(value * 100);
			}
		}

		private void trackBar_Scroll(object sender, EventArgs e)
		{
			TrackBar trackBar = (TrackBar)sender;
			int channel = (int)trackBar.Tag;

			IO.analogInputMutex.WaitOne();
			IO.analogInputs[channel].value = (float)trackBar.Value / 100;
			IO.analogInputMutex.ReleaseMutex();

			analogInputTextBoxes[channel].Text = ((double)trackBar.Value / 100).ToString("0.000");
		}

		private void inputGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if(e.RowIndex < 0 || e.ColumnIndex < 2) return;
			int inputNumber = Int32.Parse((string)inputGrid.Rows[e.RowIndex].Cells[Address.Index].Value);

			IO.inputMutex.WaitOne();
			IO.inputs[inputNumber][e.ColumnIndex - 2].value = (bool)inputGrid[e.ColumnIndex, e.RowIndex].Value; // update value of changed input
			IO.inputMutex.ReleaseMutex();
		}

		private void inputGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			if(inputGrid.CurrentCell is DataGridViewCheckBoxCell)
			{
				inputGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
			}
		}

		private void inputGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			int size = 5;
			foreach(DataGridViewColumn col in inputGrid.Columns)
			{
				size += col.Width;
			}
			if(inputGrid.Controls.OfType<VScrollBar>().First().Visible)
			{
				size += SystemInformation.VerticalScrollBarWidth;
			}
			inputPanel.Width = size + inputPanel.Padding.Right + inputPanel.Padding.Left;
		}

		private void outputGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			int size = 5;
			foreach(DataGridViewColumn col in outputGrid.Columns)
			{
				size += col.Width;
			}
			if(outputGrid.Controls.OfType<VScrollBar>().First().Visible)
			{
				size += SystemInformation.VerticalScrollBarWidth;
			}
			outputPanel.Width = size + outputPanel.Padding.Right + outputPanel.Padding.Left;
		}

		private void PLCForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			Communication.closeSocket = true;
			Communication.listener.Close();
		}
	}
}
