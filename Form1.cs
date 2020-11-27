using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace AtYarisiUygulaması
{
    public partial class FormAtYarisi : Form
    {
        public FormAtYarisi()
        {
            InitializeComponent();
        }
        SoundPlayer player = new SoundPlayer();
        private void btnBasla_Click(object sender, EventArgs e)
        {
            SesEfekti();
            timer2.Enabled = true;
            lblSpiker.Text = "Yarış Başlıyor Sayın Seyirciler...";
            AtlarınDurumDegistir(true);
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AtlarınDurumDegistir(false);

        }
        void AtlarınDurumDegistir(bool durum,PictureBox at)
        {
            atKamil.Enabled = atPoyraz.Enabled = atRuzgar.Enabled = atSahbatur.Enabled = atVeli.Enabled = durum;
            at.Enabled = true;
        }
        void AtlarınDurumDegistir(bool durum)
        {
            atKamil.Enabled = atPoyraz.Enabled = atRuzgar.Enabled = atSahbatur.Enabled = atVeli.Enabled = durum;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            atRuzgar.Left += rnd.Next(1, 8);
            atVeli.Left+= rnd.Next(1, 8);
            atSahbatur.Left+= rnd.Next(1, 8);
            atKamil.Left+= rnd.Next(1, 8);
            atPoyraz.Left+= rnd.Next(1, 8);
            KimOnde(atRuzgar);
            KimOnde(atVeli);
            KimOnde(atSahbatur);
            KimOnde(atPoyraz);
            KimOnde(atKamil);
            SonDzlkKimOnde(atRuzgar);
            SonDzlkKimOnde(atVeli);
            SonDzlkKimOnde(atSahbatur);
            SonDzlkKimOnde(atPoyraz);
            SonDzlkKimOnde(atKamil);
            KimKazandı(atRuzgar);
            KimKazandı(atVeli);
            KimKazandı(atSahbatur);
            KimKazandı(atKamil);
            KimKazandı(atPoyraz);
        }
        void KimKazandı(PictureBox kazanan)
        {
            if (kazanan.Right - 15 >= lblFınısh.Left)
            {
                timer1.Stop();
                AtlarınDurumDegistir(false, kazanan);
                lblSpiker.Text = "Kazanan Atımız:"+" "+kazanan.Name;
            }
            
        }
        void KimOnde(PictureBox kimonde)
        {
            if (kimonde.Right - 10 >= label1.Left)
            {
                lblSpiker.Text = " İlk kulvara Önde Gelen Atımız:" + " " + kimonde.Name;
            }
        }
        void SonDzlkKimOnde(PictureBox sndzlk)
        {
            if (sndzlk.Right - 10 >= lblSonDuzluk.Left)
            {
                lblSpiker.Text = " Son kulvara Önde Gelen Atımız:" + " " + sndzlk.Name;
            }
        }

        private void btnTekrar_Click(object sender, EventArgs e)
        {
            player.Stop();
            AtlarınDurumDegistir(false);
            timer1.Stop();
            timer2.Enabled = false;
            lblSpiker.Text = "";
            atRuzgar.Left = 3;
            atVeli.Left = 3;
            atSahbatur.Left = 3;
            atKamil.Left = 3;
            atPoyraz.Left = 3;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (lblSpiker.ForeColor==Color.White)
            {
                lblSpiker.ForeColor = Color.Black;
            }
            else
            {
                lblSpiker.ForeColor = Color.White;
            }
        }
        public void SesEfekti()
        {
            
            player.SoundLocation = @"C:\Users\EMREPC\source\repos\AtYarisiUygulaması\AtYarisiUygulaması\ses2.wav";
            player.Play();
        }
    }
}
