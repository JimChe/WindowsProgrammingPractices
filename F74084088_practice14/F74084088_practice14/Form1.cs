using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace F74084088_practice14
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			// TODO: 這行程式碼會將資料載入 '_practiceDB__1_DataSet.內容簡介' 資料表。您可以視需要進行移動或移除。
			this.內容簡介TableAdapter.Fill(this._practiceDB__1_DataSet.內容簡介);
			// TODO: 這行程式碼會將資料載入 '_practiceDB__1_DataSet.書目' 資料表。您可以視需要進行移動或移除。
			this.書目TableAdapter.Fill(this._practiceDB__1_DataSet.書目);
			// TODO: 這行程式碼會將資料載入 '_practiceDB__1_DataSet.出版者' 資料表。您可以視需要進行移動或移除。
			this.出版者TableAdapter.Fill(this._practiceDB__1_DataSet.出版者);

		}
	}
}
