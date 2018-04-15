using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                textBox1.Enabled = true;
            else
                textBox1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            textBox2.Text = generate();
        }


        private string generate()
        {
            Random rnd = new Random();
            int cityCode = comboBox1.SelectedIndex + 10;
            int genderCode = (radioButton1.Checked == true) ? 1 : 2;
            int count = 1, count2 = 1, checkNum = 0, IdNum = 0;

            //生成一個隨機的7碼流水號
            while (count < 8)
            {
                IdNum += count2 * (rnd.Next(0, 9));
                count2 *= 10;
                count++;
            }

            //加上性別的數字
            IdNum += genderCode * count2;

            //計算檢查碼
            int temp = IdNum;
            for (int i = 1; i < 9; i++)
            {
                checkNum += (temp % 10) * i;
                temp /= 10;
            }

            //檢查碼要加上程式的代號
            int tmp_cityNum = cityCode;
            checkNum += (cityCode % 10) * 9;
            checkNum += cityCode / 10;

            int lastNum = (10 - (checkNum % 10)) % 10;
            char cityNum = (char)(cityCode + 55);
            string ID = cityNum.ToString() + IdNum.ToString() + lastNum.ToString();
            return ID;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }
    }
}
