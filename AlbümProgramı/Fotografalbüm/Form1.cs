using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Media;

namespace Fotografalbüm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        int resimindex = -1;

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {

                listBox1.Items.Clear();
                string[] dosyalar = Directory.GetFiles(fbd.SelectedPath);
                foreach (string dosya in dosyalar)
                {
                    if (dosya.EndsWith(".jpg") || dosya.EndsWith(".jpeg" ))
                        listBox1.Items.Add(dosya);
                    label1.Text = listBox1.Items.Count.ToString();
                    
                }
            }

            listBox1.SelectedIndex = +0;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string resimYolu = listBox1.SelectedItem.ToString();
            pictureBox1.ImageLocation = resimYolu;
          


        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (resimindex == listBox1.Items.Count - 1)
            {
                resimindex = 0;
            }
            else
            {
                resimindex++;
              

            }
            listBox1.SelectedIndex = +resimindex;


        }
        int slaytindex = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                slaytindex++;

                listBox1.SelectedIndex = +slaytindex;
            }
            catch (Exception)
            {
                slaytindex = -1;
            }
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (resimindex == 0)
            {
                resimindex = listBox1.Items.Count - 1;
            }
            else
            {
                resimindex--;
            }
            listBox1.SelectedIndex = +resimindex;

            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            timer1.Start();
        }
        int tiklama = 0;
        private void button5_Click(object sender, EventArgs e)
        {
            tiklama++;

            if (tiklama == 1)
            {
                this.Width = 1509; 
                this.Height = 347; 
            }
            if (tiklama == 2)
            {
                this.Width = 621;  
                this.Height = 347;
                tiklama = 0;
            }
            
            

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap resim = new Bitmap(pictureBox1.Image);
                label3.Text = resim.Width.ToString();
                label2.Text = resim.Height.ToString();
              
                label8.Text = listBox1.SelectedItem.ToString().Split('.')[1];// TÜRÜ (JPG,PNG)
                label9.Text = listBox1.SelectedItem.ToString().Split('.')[0];
                label9.Text = label9.Text.Substring(label9.Text.LastIndexOf(@"\") + 1);
            }
            catch (Exception)
            {

                throw;
            }
            

        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            if (radioButton1.Checked == true)
            {
                SoundPlayer ses = new SoundPlayer();
                string dizin = Application.StartupPath + "\\Triumph.wav";
                ses.SoundLocation = dizin;
                ses.Play();
                label18.Text = radioButton1.Text;
            }
            else if (radioButton2.Checked == true)
            {
                SoundPlayer ses = new SoundPlayer();
                string dizin = Application.StartupPath + "\\Billy_in_the_Lowground.wav";
                ses.SoundLocation = dizin;
                ses.Play();
                label18.Text = radioButton2.Text;
            }
            else if (radioButton3.Checked == true)
            {
                SoundPlayer ses = new SoundPlayer();
                string dizin = Application.StartupPath + "\\Scratch_the_Itch.wav";
                ses.SoundLocation = dizin;
                ses.Play();
                label18.Text = radioButton4.Text;
            }
            else if (radioButton4.Checked == true)
            {
                SoundPlayer ses = new SoundPlayer();
                string dizin = Application.StartupPath + "\\Point_Green_Getdown.wav";
                ses.SoundLocation = dizin;
                ses.Play();
                label18.Text = radioButton4.Text;
            }
            else if (radioButton5.Checked == true)
            {
                SoundPlayer ses = new SoundPlayer();
                string dizin = Application.StartupPath + "\\Kurtlar_Vadisi_Pusu.wav";
                ses.SoundLocation = dizin;
                ses.Play();
                label18.Text = radioButton5.Text;
            }
            else if (radioButton6.Checked == true)
            {
                SoundPlayer ses = new SoundPlayer();
                string dizin = Application.StartupPath + "\\Dirilis_Ertugrul.wav";
                ses.SoundLocation = dizin;
                ses.Play();
                label18.Text = radioButton6.Text;
            }
            
        }
        SoundPlayer ses = new SoundPlayer();

        private void button8_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            ses.Stop();
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            
                label2.Visible = false;
                label3.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                button6.Visible = false;
            label20.Text = "Gizle";
           
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
                label2.Visible = true;
                label3.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
                button6.Visible = true;
            label20.Text = "Göster";
            
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            label19.Text = radioButton9.Text;
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Interval = 2000;
            label19.Text = radioButton10.Text;
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Interval = 3000;
            label19.Text = radioButton11.Text;
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Interval = 4000;
            label19.Text = radioButton12.Text;
        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Interval = 5000;
            label19.Text = radioButton13.Text;
        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Interval = 6000;
            label19.Text = radioButton14.Text;
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            ColorDialog RenkSec = new ColorDialog();
            if (RenkSec.ShowDialog() == DialogResult.OK) 
            {
                groupBox1.ForeColor = RenkSec.Color;
                label1.ForeColor = RenkSec.Color;
                label2.ForeColor = RenkSec.Color;
                label3.ForeColor = RenkSec.Color;
                label7.ForeColor = RenkSec.Color;
                label8.ForeColor = RenkSec.Color;
                label9.ForeColor = RenkSec.Color;
                label10.ForeColor = RenkSec.Color;
                label11.ForeColor = RenkSec.Color;
                label12.ForeColor = RenkSec.Color;
                button1.ForeColor = RenkSec.Color;
                button2.ForeColor = RenkSec.Color;
                button3.ForeColor = RenkSec.Color;
                button4.ForeColor = RenkSec.Color;
                button5.ForeColor = RenkSec.Color;
                button6.ForeColor = RenkSec.Color;
               
                 label22.Text = (RenkSec).ToString().Split('[')[1];  
                 
                

               
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FontDialog FontSec = new FontDialog();
            if (FontSec.ShowDialog() == DialogResult.OK) 
            {
                groupBox1.Font = FontSec.Font;
                label1.Font = FontSec.Font;
                label2.Font = FontSec.Font;
                label3.Font = FontSec.Font;
                label7.Font = FontSec.Font;
                label8.Font = FontSec.Font;
                label9.Font = FontSec.Font;
                label10.Font = FontSec.Font;
                label11.Font = FontSec.Font;
                label12.Font = FontSec.Font;
                button1.Font = FontSec.Font;
                button2.Font = FontSec.Font;
                button3.Font = FontSec.Font;
                button4.Font = FontSec.Font;
                button5.Font = FontSec.Font;
                button6.Font = FontSec.Font;
                
                label23.Text = (FontSec).ToString().Split('[')[1];
              

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            label4.Text = "Ayarlar Config.txt Dosyasından Yüklendi.";
            string[] conf = File.ReadAllLines("Config.txt");

           
            this.label18.Text = conf[0];
            this.label19.Text = conf[1];
            this.label20.Text = conf[2];
            this.label21.Text = conf[3];
            this.label23.Text = conf[4];
            this.label22.Text = conf[5];



        }

        private void button12_Click(object sender, EventArgs e)
        {
            label4.Text = "Ayarlar-> Debug\\Config.txt Dosyasına Kayıt Edildi..";
            string conf = Application.StartupPath + "\\Config.txt";
            FileStream fs = new FileStream(conf, FileMode.Open, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(label18.Text);
            sw.WriteLine(label19.Text);
            sw.WriteLine(label20.Text);
            sw.WriteLine(label21.Text);
            sw.WriteLine(label23.Text);
            sw.WriteLine(label22.Text);
            
            sw.Flush();
            sw.Close();
            fs.Close();
        }

        private void radioButton15_CheckedChanged(object sender, EventArgs e)
        {
            label1.Visible = true;
            label21.Text = "Göster";
        }

        private void radioButton16_CheckedChanged(object sender, EventArgs e)
        {
            label1.Visible = false;
            label21.Text = "Gizle";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 621; //Formun Genişliği 
            this.Height = 347; //Formun Yüksekliği 
            MessageBox.Show("Hocam köyde kısıtlı internet paketi ile araştırma yaptım fakat animasyon olayını yapamadım, bilgilendirmek istedim..", "Bilgilendirme..!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            listBox1.SelectedIndex += 1;
            listBox1.SelectedIndex = (listBox1.Items.Count) - 1;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            
            listBox1.SelectedIndex =+ 0;
        }
    }
}
