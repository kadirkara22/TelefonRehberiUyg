using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Udemy.Entities;

namespace Udemy.TelefonRehberi
{
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        private void btn_yenikayit_Click(object sender, EventArgs e)
        {
            BusinessLogicLayer.BLL BLL = new BusinessLogicLayer.BLL();
          int ReturnValue=BLL.KayitEkle(txt_y_isim.Text,txt_y_soyisim.Text,txt_y_telefonI.Text,txt_y_telefonII.Text,txt_y_telefonIII.Text,txt_y_emailadres.Text, txt_y_website.Text, txt_y_adres.Text, txt_y_aciklama.Text);
            if (ReturnValue>0)
            {
                ListeDoldur();
                MessageBox.Show("Yeni Kayıt Eklendi.","Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
        }

        private void AnaForm_Load(object sender, EventArgs e)
        {
            ListeDoldur();

        }
        
        private void ListeDoldur()
        {
            BusinessLogicLayer.BLL BLL = new BusinessLogicLayer.BLL();
            List<Rehber> RehberListesi = BLL.KayitListe();
            if(RehberListesi!=null && RehberListesi.Count>0)
            {
                lst_liste.DataSource = RehberListesi;
            }
        }
        
        

        private void lst_liste_DoubleClick(object sender, EventArgs e)
        {
            ListBox LST = (ListBox)sender;
          Rehber SecilenKayit= (Rehber)LST.SelectedItem;
           if(SecilenKayit!=null)
            {
                txt_g_isim.Text = SecilenKayit.Isim;
                txt_g_soyisim.Text = SecilenKayit.Soyisim;
                txt_g_telefonI.Text = SecilenKayit.TelefonNumarasiI;
                txt_g_telefonII.Text = SecilenKayit.TelefonNumarasiII;
                txt_g_telefonIII.Text = SecilenKayit.TelefonNumarasiIII;
                txt_g_emailadres.Text = SecilenKayit.EmailAdres;
                txt_g_website.Text = SecilenKayit.WebSite;
                txt_g_adres.Text = SecilenKayit.Adres;
                txt_g_aciklama.Text = SecilenKayit.Aciklama;
            }
        }

        private void btn_düzenle_Click(object sender, EventArgs e)
        {
            Guid ID = ((Rehber)lst_liste.SelectedItem).ID;
            BusinessLogicLayer.BLL BLL = new BusinessLogicLayer.BLL();
          int ReturnValues=  BLL.KayitDüzenle(ID,txt_g_isim.Text, txt_g_soyisim.Text, txt_g_telefonI.Text, txt_g_telefonII.Text, txt_g_telefonIII.Text, txt_g_emailadres.Text, txt_g_website.Text, txt_g_adres.Text, txt_g_aciklama.Text);
            if(ReturnValues>0)
            {
                ListeDoldur();
                MessageBox.Show("Kayıt Güncellendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            Guid ID = ((Rehber)lst_liste.SelectedItem).ID;
            BusinessLogicLayer.BLL BLL = new BusinessLogicLayer.BLL();
            int Returnvalues = BLL.KayitSil(ID);
            if(Returnvalues>0)
            {
                ListeDoldur();
                MessageBox.Show("Kayıt Silindi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }

        }
    }
}
