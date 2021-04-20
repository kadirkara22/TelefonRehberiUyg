using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Udemy.TelefonRehberi
{
    public partial class Form1 : Form
    {
        BusinessLogicLayer.BLL bll;
        public Form1()
        {
            InitializeComponent();
            bll = new BusinessLogicLayer.BLL();
        }

        private void btn_giriş_Click(object sender, EventArgs e)
        {
           int Returnvalue = bll.SistemKontrol(txt_kullanici_adi.Text, txt_sifre.Text);
            if(Returnvalue>0)
            {
                AnaForm AF = new AnaForm();
                AF.Show();
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı veya şifre girişi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            KullaniciKayit KK = new KullaniciKayit();
            KK.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SifremiUnuttum SU = new SifremiUnuttum();
            SU.Show();
        }
    }
}
