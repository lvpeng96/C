using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        int count;
        int gettime;
        int touchflag;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int i;
           


            for (i = 0; i < 100; i++)
            {
                comboBox1.Items.Add(i.ToString() + "  ");  //此处为 空格秒，为了在后边提取时，
                //若为个位数时，下面的函数 从0位提取，提取两位会提取到汉字 秒，会报错
                // string data = str.Substring(0, 2); 
            }
            label8.Text = "0 时";

            for (i = 0; i < 100; i++)
            {
                comboBox2.Items.Add(i.ToString() + "  ");  //此处为 空格秒，为了在后边提取时，
                //若为个位数时，下面的函数 从0位提取，提取两位会提取到汉字 秒，会报错
                // string data = str.Substring(0, 2); 
            }
            label7.Text = "0 分";

            for (i = 1; i < 100; i++)
            {
                comboBox3.Items.Add(i.ToString() + "  ");  //此处为 空格秒，为了在后边提取时，
                //若为个位数时，下面的函数 从0位提取，提取两位会提取到汉字 秒，会报错
                // string data = str.Substring(0, 2); 
            }
            label3.Text = "0  秒";
            label8.Text = "0  时";
            label7.Text = "0  分";
        }

  

        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;
            
            label8.Text = ((gettime - count) / 3600).ToString() + "时";
            label7.Text = (((gettime - count) /60)%60).ToString() + "分";
            label3.Text = ((gettime - count)%60) .ToString() + "秒";
            progressBar1.Value = count;
            if(count == gettime)
            {
                timer1.Stop();
                System.Media.SystemSounds.Asterisk.Play();  //
                MessageBox.Show("Over", "提示信息");   //放在最后，系统提示时属于中断

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string hourstr = comboBox1.Text;
            string minstr = comboBox2.Text;
            string secstr = comboBox3.Text;

          
            if (touchflag == 0)
            {
                gettime = Convert.ToInt16(hourstr.Substring(0, 2));    //将字符转换成整形    //提取的是字符，汉字也为一个字符字母也是一个字符数字也是一个字符
                gettime = gettime * 60 + Convert.ToInt16(minstr.Substring(0, 2));
                gettime = gettime * 60 + Convert.ToInt16(secstr.Substring(0, 2));
                progressBar1.Maximum = gettime;
                const string V = "暂停计时";
                button1.Text = V;
                touchflag = 1;
                timer1.Start();
            }
            else
            {
                timer1.Stop();
                touchflag = 0;
                const string X = "暂停计时";
                button1.Text = X;
                button1.Text = "开始计时";
            }
           
        }

    }
}
