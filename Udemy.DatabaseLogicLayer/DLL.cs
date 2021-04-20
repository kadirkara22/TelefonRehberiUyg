using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Udemy.Entities;

namespace Udemy.DatabaseLogicLayer
{
    public class DLL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;
        int ReturnValues;


        public DLL()
        {
            con = new SqlConnection("Data Source=DESKTOP-ENRTDRV\\SQLEXPRESS;Initial Catalog=TelefonRehberi;Integrated Security=True");
            
            
        }
        public void BaglantiAyarla()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
                
            }
            else
            {
                con.Close();
            }
        }


        public int SistemKontrol(Kulllanici K)
        { 
            try
            {
                cmd = new SqlCommand("select count(*) from Kulllanici where  KullaniciAdi = @KullaniciAdi and Sifre = @Sifre", con);
                cmd.Parameters.Add("@KullaniciAdi", SqlDbType.NVarChar).Value = K.KullaniciAdi;
                cmd.Parameters.Add("@Sifre", SqlDbType.NVarChar).Value = K.Sifre;
                BaglantiAyarla();
                ReturnValues = (int)cmd.ExecuteScalar();    
            }
            catch (Exception ex)
            {


            }
            finally
            {
                BaglantiAyarla();
            }
            return ReturnValues;
        }

        public int KullaniciEkle(Kulllanici YK)
        {
            try
            {
                cmd = new SqlCommand("insert into Kulllanici(KullaniciID, KullaniciAdi, Sifre,Soru,Cevap) values(@KullaniciID, @KullaniciAdi, @Sifre,@soru,@Cevap)", con);
                cmd.Parameters.Add("@KullaniciID", SqlDbType.UniqueIdentifier).Value = YK.KullaniciID;
                cmd.Parameters.Add("@KullaniciAdi", SqlDbType.NVarChar).Value = YK.KullaniciAdi;
                cmd.Parameters.Add("@Sifre", SqlDbType.NVarChar).Value = YK.Sifre;
                cmd.Parameters.Add("@Soru", SqlDbType.NVarChar).Value = YK.Soru;
                cmd.Parameters.Add("@Cevap", SqlDbType.NVarChar).Value = YK.Cevap;
                BaglantiAyarla();
                ReturnValues = (int)cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }
           finally
            {
                BaglantiAyarla();
            }
            return ReturnValues;
        }

               public int KullaniciDüzenle(Kulllanici UK)
        {
            try
            {
                cmd = new SqlCommand(@"update Kulllanici set Sifre=@Sifre
where
KullaniciID=@KullaniciID", con);
                reader = cmd.ExecuteReader();
                cmd.Parameters.Add("@KullaniciID", SqlDbType.UniqueIdentifier).Value = UK.KullaniciID;
                cmd.Parameters.Add("@KullaniciAdi", SqlDbType.NVarChar).Value = UK.KullaniciAdi;
                cmd.Parameters.Add("@Sifre", SqlDbType.NVarChar).Value = UK.Sifre;
                cmd.Parameters.Add("@Soru", SqlDbType.NVarChar).Value = UK.Soru;
                cmd.Parameters.Add("@Cevap", SqlDbType.NVarChar).Value = UK.Cevap;
                BaglantiAyarla();
                ReturnValues = (int)cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                BaglantiAyarla();
            }
            return ReturnValues;
        }
       public int KayitEkle(Rehber R)
        {
            try
            {
                cmd = new SqlCommand("insert into Rehber(ID,Isim,Soyisim,TelefonNumarasiI,TelefonNumarasiII,TelefonNumarasiIII,EmailAdres,WebSite,Adres,Aciklama) values (@ID,@Isim,@Soyisim,@TelefonNumarasiI,@TelefonNumarasiII,@TelefonNumarasiIII,@EmailAdres,@WebSite,@Adres,@Aciklama)",con);
                cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = R.ID;
                cmd.Parameters.Add("@Isim", SqlDbType.NVarChar).Value = R.Isim;
                cmd.Parameters.Add("@Soyisim", SqlDbType.NVarChar).Value = R.Soyisim;
                cmd.Parameters.Add("@TelefonNumarasiI", SqlDbType.NVarChar).Value = R.TelefonNumarasiI;
                cmd.Parameters.Add("@TelefonNumarasiII", SqlDbType.NVarChar).Value = R.TelefonNumarasiII;
                cmd.Parameters.Add("@TelefonNumarasiIII", SqlDbType.NVarChar).Value = R.TelefonNumarasiIII;
                cmd.Parameters.Add("@EmailAdres", SqlDbType.NVarChar).Value = R.EmailAdres;
                cmd.Parameters.Add("@WebSite", SqlDbType.NVarChar).Value = R.WebSite;
                cmd.Parameters.Add("@Adres", SqlDbType.NVarChar).Value = R.Adres;
                cmd.Parameters.Add("@aciklama", SqlDbType.NVarChar).Value = R.Aciklama;
                BaglantiAyarla();
                ReturnValues = cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                BaglantiAyarla();
            }
            return ReturnValues;
        }

        public int Kayitdüzenle(Rehber R)
        {
            try
            {

                cmd = new SqlCommand(@"update Rehber
                 set
                 Isim=  @Isim,
                 Soyisim= @Soyisim,
                 TelefonNumarasiI=@TelefonNumarasiI,
                 TelefonNumarasiII =@TelefonNumarasiII,
                 TelefonNumarasiIII=@TelefonNumarasiIII,
                 Emailadres= @EmailAdres,
                 WebSite= @WebSite,
                 Adres= @Adres,
                 Aciklama= @Aciklama 
                 where 
                 ID=@ID
                    ", con);

                cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = R.ID;
                cmd.Parameters.Add("@Isim", SqlDbType.NVarChar).Value = R.Isim;
                cmd.Parameters.Add("@Soyisim", SqlDbType.NVarChar).Value = R.Soyisim;
                cmd.Parameters.Add("@TelefonNumarasiI", SqlDbType.NVarChar).Value = R.TelefonNumarasiI;
                cmd.Parameters.Add("@TelefonNumarasiII", SqlDbType.NVarChar).Value = R.TelefonNumarasiII;
                cmd.Parameters.Add("@TelefonNumarasiIII", SqlDbType.NVarChar).Value = R.TelefonNumarasiIII;
                cmd.Parameters.Add("@EmailAdres", SqlDbType.NVarChar).Value = R.EmailAdres;
                cmd.Parameters.Add("@WebSite", SqlDbType.NVarChar).Value = R.WebSite;
                cmd.Parameters.Add("@Adres", SqlDbType.NVarChar).Value = R.Adres;
                cmd.Parameters.Add("@aciklama", SqlDbType.NVarChar).Value = R.Aciklama;
                BaglantiAyarla();
                ReturnValues = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                BaglantiAyarla();
            }
            return ReturnValues;
        }


        public int KayitSil(Guid ID)
        {
            try
            {

                cmd = new SqlCommand(@"delete Rehber
                 where 
                 ID=@ID
                    ", con);

                cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = ID;
                BaglantiAyarla();
                ReturnValues = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                BaglantiAyarla();
            }
            return ReturnValues;
        }


        public SqlDataReader KayitListe()
        {
            cmd = new SqlCommand("select *from Rehber", con);
            BaglantiAyarla();
            return cmd.ExecuteReader();
        }
        public SqlDataReader KayitListeID(Guid ID)
        {
            cmd = new SqlCommand("select *from Rehber where ID=@ID", con);
            cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = ID;
            BaglantiAyarla();
            return cmd.ExecuteReader();
        }
    }
}
