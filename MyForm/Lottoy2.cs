using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyForm;

namespace MyForm
{
    public partial class Lottoy2 : Form
    {
        public Lottoy2()
        {
            InitializeComponent();
            
        }
        Getnumber getbumber = new Getnumber();
        Pairaward P = new Pairaward();
        IntlistTostring l = new IntlistTostring();
        Sorting sort = new Sorting();
        C獎項 pair獎項 = new C獎項();
        
        Button[] b = new Button[6];
        Button[] sixnum = new Button[6]; //下面的6個按鈕
        int c = 0;
        int co = 0;
        int selected = 6;
        int counter; //電腦組數
        int total_count =0;//總共幾組
        int[][] total列表 =new int[1][];
        int[] win = new int[6];
        string[] total中獎數 = new string[1];
        int[][] total獎項 = new int[1][];
        double total本期總獎金 = 100000000;
        double total本期下注 = 0;
        double total本期中獎獎金 = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            sixnum[0] = c_button1;
            sixnum[1] = c_button2;
            sixnum[2] = c_button3;
            sixnum[3] = c_button4;
            sixnum[4] = c_button5;
            sixnum[5] = c_button6;
            Button btn = (Button)sender;
            selected--;
            for (int i = 0; i < groupBox3.Controls.Count; i++)
            {
                if (co > 5) break;
                if (sixnum[c].Text == "")
                {
                    
                    b[c] = btn;
                    btn.Enabled = false;
                    sixnum[c].Text = btn.Text;
                    sixnum[c].Enabled = true;
                    co++;
                    break;
                }
                else
                    c++;
            }
        }

        private void c_button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            
            btn.Text = "";
            
            b[int.Parse(btn.Name.Last().ToString())-1].Enabled = true;
            btn.Enabled = false;
            c = 0;
            selected++;
            co--;
        }

        private void Self_n_Click(object sender, EventArgs e)
        {
            string number = "";
            string once = "";
            int[] self_n = new int[6];
            int self_c = 0;
            int havingnumber = 0;
            if (selected < 0) { }
            if (selected > 0)
            {
                foreach (Button b in groupBox3.Controls)
                {
                    if (b.Text != "")
                    {
                        once += b.Text + " ";
                        havingnumber++;
                    }
                }
                self_n = getbumber.Random_Number((6 - havingnumber), once);
            }
            else
            {
                foreach (Button a in groupBox3.Controls)
                {
                    self_n[self_c] = int.Parse(a.Text);
                    self_c++;
                }
            }
                number += $"{total_count + 1}:";
                Console.WriteLine($"self_n {l.intlistTostring(self_n)}");
                number += l.intlistTostring(sort.sorting(self_n));
                listBox1.Items.Add(number);
                c = 0; co = 0;
                selected = 6;
                total列表[total_count] = sort.sorting(self_n);
                
                total_count++;
                pairstart.Enabled = true;
                Array.Resize(ref total列表, total列表.Length + 1);
            
            for (int i = 0; i < total列表.Length - 1; i++)
            {
                Console.WriteLine($"total列表[{i}] {l.intlistTostring(total列表[i])}");
            }
            foreach (Button a in groupBox3.Controls)
            {
                a.Text = "";
            }
            foreach (Button a in groupBox1.Controls)
            {
                a.Enabled = true;
            }
        }

        private void Com_number(object sender, EventArgs e)
        {
            int[] s = new int[6];
            
            string n;
            try
            {
                if (int.Parse(com.Text) > 0) 
                {

                    counter = int.Parse(com.Text);
                    pairstart.Enabled = true;
                    com_number.Enabled = false;
                }else
                    MessageBox.Show("請輸入正確數字");
            }
            catch (FormatException)
            {
                MessageBox.Show("請輸入正確數字");
                    
            }
            int coun_t = counter + total_count;
            for (int i = total_count; i < coun_t; i++)
            {
                n = "";
                n += $"{total_count + 1}:";
                s = getbumber.Random_Number(6, "");
                s = sort.sorting(s);
                total列表[i] = s;
                listBox1.Items.Add(n + l.intlistTostring(s));
                n = "";
                total_count++;
                Array.Resize(ref total列表, total列表.Length + 1);
            }
        }

        private void pair(object sender, EventArgs e)
        {
            string n = "";
            int win_c = 0;
            win = getbumber.Random_Number(7,"");
            
            int[] a = new int[win.Length - 1];
            int sp = 0;
            int notsp = 0;
            string[] pairnum2;
            for (int i = 0; i < a.Length; i++)
                a[i] = win[i];
            a = sort.sorting(a);
            Array.Resize(ref a, a.Length +1);
            a[6] = win[6];
            n = l.intlistTostring(a);
            foreach (Button b in group開獎號碼.Controls)
            {
                b.Text = a[win_c].ToString();
                win_c++;
            }
            textBox1.Text += $"共下了{total列表.Length - 1}注\r\n";
            for (int i = 0; i < total列表.Length-1; i++)
            {
                total中獎數[i] = P.check(total列表[i], win);
                Array.Resize(ref total中獎數, total中獎數.Length + 1);
            }
            foreach (Button b in groupBox1.Controls)
                b.Enabled = false;
            pairstart.Enabled = false;
            Self_n.Enabled = false;
            total本期下注 = (total列表.Length-1) * 50;
            total本期總獎金 += total本期下注 * 0.56;
            textBox1.Text += $"共花了{total本期下注}\r\n";

            for (int i = 0; i < total列表.Length - 1; i++)
            {
                if (total中獎數[i].Contains("sp"))
                {
                    string s2 = "";
                    string[] sArray = total中獎數[i].Split(new string[] { "sp" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var item in sArray)
                    {
                        s2 += item.Trim() + " ";
                    }
                    pairnum2 = s2.TrimEnd().Split(' ');
                    if (sArray.Length == 1)
                        sp = 1;
                    else if (sArray.Length > 1)
                    {
                        sp = 1;
                        notsp = pairnum2.Length - 1;
                    }
                }
                else
                {
                    pairnum2 = total中獎數[i].TrimEnd().Split(' ');
                    notsp = pairnum2.Length-1;
                }
                int paircount = 0;
                switch (pair獎項.c獎項(notsp, sp))
                {
                    case 8:
                        total本期中獎獎金 += 400;
                        total獎項[paircount] = new int[] { notsp, sp };
                        Array.Resize(ref total獎項, total獎項.Length + 1);
                        textBox1.Text += $"第{i+1}筆中了普獎，獎金400\r\n";
                        paircount++;
                        break;
                    case 7:
                        total本期中獎獎金 += 400;
                        total獎項[paircount] = new int[] { notsp, sp };
                        Array.Resize(ref total獎項, total獎項.Length + 1);
                        textBox1.Text += $"第{i + 1}筆中了七獎，獎金400\r\n";
                        paircount++;
                        break;
                    case 6:
                        total本期中獎獎金 += 1000;
                        total獎項[paircount] = new int[] { notsp, sp };
                        Array.Resize(ref total獎項, total獎項.Length + 1);
                        textBox1.Text += $"第{i + 1}筆中了六獎，獎金1000\r\n";
                        paircount++;
                        break;
                    case 5:
                        total本期中獎獎金 += 2000;
                        total獎項[paircount] = new int[] { notsp, sp };
                        Array.Resize(ref total獎項, total獎項.Length + 1);
                        textBox1.Text += $"第{i + 1}筆中了五獎，獎金2000\r\n";
                        paircount++;
                        break;
                }
                notsp = 0;sp = 0;
                total本期總獎金 -= total本期中獎獎金;
                switch (pair獎項.c獎項(notsp, sp))
                {
                    case 1:
                        textBox1.Text += $"第{i + 1}筆中了頭獎，獎金{total本期中獎獎金*0.82}\r\n";
                        total本期中獎獎金 += total本期中獎獎金 * 0.82;
                        break;
                    case 2:
                        textBox1.Text += $"第{i + 1}筆中了二獎，獎金{total本期中獎獎金 * 0.065}\r\n";
                        total本期中獎獎金 += total本期中獎獎金 * 0.065;
                        break;
                    case 3:
                        textBox1.Text += $"第{i + 1}筆中了三獎，獎金{total本期中獎獎金 * 0.07}\r\n";
                        total本期中獎獎金 += total本期中獎獎金 * 0.07;
                        break;
                    case 4:
                        textBox1.Text += $"第{i + 1}筆中了四獎，獎金{total本期中獎獎金 * 0.045}\r\n";
                        total本期中獎獎金 += total本期中獎獎金 * 0.045;
                        break;
                }
            }
            if (total本期中獎獎金 == 0)
                textBox1.Text += "本期摃龜\r\n";
            else if(total本期中獎獎金>total本期下注)
                textBox1.Text += $"本期中了{total本期中獎獎金}\r\n贏了{total本期中獎獎金-total本期下注}\r\n";
            else
                textBox1.Text += $"本期中了{total本期中獎獎金}\r\n輸了{total本期下注 - total本期中獎獎金}\r\n";
            label3.Text = (int.Parse(label3.Text)+(total本期下注-total本期中獎獎金)).ToString();
        }


        private void listBox1_click(object sender, MouseEventArgs e)
        {
            if (pairstart.Enabled == false)
            {

                if (listBox1.Items.Count > 0 && listBox1.SelectedItem !=null)
                {
                    string curItem = listBox1.SelectedItem.ToString();
                    int index = listBox1.FindString(curItem);
                    
                    
                    foreach (Control ctl in groupBox1.Controls)
                        ctl.BackgroundImage = Properties.Resources.號碼列表;
                    win = getbumber.Random_Number(7,"");
                    win = sort.sorting(win);
                    if (index == -1)
                        MessageBox.Show("Item is not available in ListBox2");
                    else
                    {
                        string[] pairnum;
                        int list_c =0;
                        string s2 ="";
                        for (int i = 0; i < total列表[index].Length; i++)
                        {
                            (groupBox1.Controls[$"btn_number{total列表[index][i].ToString()}"] as Button).BackgroundImage = Properties.Resources.號碼列表有中的;
                        }
                        foreach (Button b in group中獎結果.Controls)
                        {
                            b.Text = total列表[index][list_c].ToString();
                            list_c++;
                            b.BackgroundImage = Properties.Resources.號碼1_6;
                        }
                        if (total中獎數[index].Contains("sp"))
                        {
                            string[] sArray = total中獎數[index].Split(new string[] { "sp" }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (var item in sArray)
                            {
                                s2 += item.Trim() + " ";
                            }
                            pairnum = s2.TrimEnd().Split(' ');
                        }else
                            pairnum = total中獎數[index].Trim().Split(' ');
                        if (pairnum[0] != "")
                            for (int i = 0; i < pairnum.Length; i++)
                            {
                                for (int j = 0; j < total列表[index].Length; j++)
                                    if (total列表[index][j] == int.Parse(pairnum[i]))
                                    {
                                        (group中獎結果.Controls[$"b{j + 1}_中獎結果"] as Button).BackgroundImage = Properties.Resources.選中的號碼;
                                    }
                                (groupBox1.Controls[$"btn_number{pairnum[i].Trim()}"] as Button).BackgroundImage = Properties.Resources.選中的號碼;
                            }
                    }
                }
            }
        }

        private void reset_Click(object sender, EventArgs e)
        {
            com.Text = "";
            listBox1.Items.Clear();
            pairstart.Enabled = false;
            com_number.Enabled = true;
            Self_n.Enabled = true;
            textBox1.Text = "";

            c = 0;
            co = 0;
            selected = 6;
            counter=0; //電腦組數
            total_count = 0;
            total列表 = new int[1][];
            total本期中獎獎金 = 0;


            foreach (Button b in groupBox1.Controls)
                b.Enabled = true;
            for (int i = 1; i < 50; i++)
            {
                (groupBox1.Controls[$"btn_number{i.ToString()}"] as Button).BackgroundImage = Properties.Resources.號碼列表;
            }
            for (int i = 0; i < 6; i++)
            {
                if (sixnum[i] != null)
                {
                    sixnum[i].Text = "";
                    sixnum[i].Enabled = false;
                }               
            }
            for(int i = 0; i < 6; i++) 
            {
                if (b[i] == null)
                    break;
                else
                {
                    b[i].BackColor = Color.LightBlue;
                    b[i].Enabled = true;
                }
            }
            foreach (Button b in group中獎結果.Controls)
            {
                b.BackgroundImage = Properties.Resources.號碼1_6;
                b.Text = "";
            }
            foreach (Button b in group開獎號碼.Controls)
                b.Text = "";
        }
    }
}