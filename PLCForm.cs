using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
		private SortedDictionary<int, List<DigitalInputOutput>> outputsCopy = new SortedDictionary<int, List<DigitalInputOutput>>();
		private List<Label> analogInputLabels = new List<Label>();
		private List<TrackBar> trackBars = new List<TrackBar>();
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
					analogInputLabels.Add(new Label());
					int ind = analogInputLabels.Count - 1;
					analogInputPanel.Controls.Add(analogInputLabels[ind]);
					#region set label properties
					analogInputLabels[ind].Location = new Point(30, 130 * ind);
					analogInputLabels[ind].Size = new Size(analogInputPanel.Width - 60, 40);
					analogInputLabels[ind].AutoSize = false;
					analogInputLabels[ind].Text = input.Value.name;
					analogInputLabels[ind].Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
					analogInputLabels[ind].ForeColor = SystemColors.ControlLight;
					analogInputLabels[ind].Name = "inputLabel" + ind.ToString();
					analogInputLabels[ind].TabIndex = 2*ind;
					analogInputLabels[ind].TextAlign = ContentAlignment.MiddleCenter;
					#endregion

					trackBars.Add(new TrackBar());
					ind = trackBars.Count - 1;
					analogInputPanel.Controls.Add(trackBars[ind]);
					#region set trackbar properties
					trackBars[ind].Location = new Point(33, (130 * ind) + 40);
					trackBars[ind].Name = input.Key.ToString();
					trackBars[ind].Size = new Size(648, 70);
					trackBars[ind].TabIndex = 2*ind + 1;
					trackBars[ind].Maximum = 1000;
					trackBars[ind].Minimum = 0;
					trackBars[ind].TickFrequency = 1;
					trackBars[ind].TickStyle = TickStyle.None;
					trackBars[ind].Scroll += trackBar_Scroll;
					#endregion
					addedAnalogInputs.Add(input.Key);
				}
			}
			IO.analogInputMutex.ReleaseMutex();
			#endregion
		}

		private void trackBar_Scroll(object sender, EventArgs e)
		{
			TrackBar trackBar = (TrackBar)sender;
			int channel = Int32.Parse(trackBar.Name);

			IO.analogInputMutex.WaitOne();
			IO.analogInputs[channel].value = (float)trackBar.Value / 100;
			IO.analogInputMutex.ReleaseMutex();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Communication.closeSocket = true;
			Thread.Sleep(1000);
			Close();
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
	}
}
