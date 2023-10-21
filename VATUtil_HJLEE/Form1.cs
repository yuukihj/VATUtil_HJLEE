using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;


namespace VATUtil_HJLEE
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            this.Text = "VATUtil_HJLEE";
        }


        async void buttonRefresh_Click_1(object sender, EventArgs e)
        {var baseAddress = new Uri("https://avwx.rest/api/");

            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {
                string ICAO = textBox1.Text;
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("authorization", "5vP6TRKBMPihxAdXjoBT3Uo_sjUu9k7twJvntyOZdCM");
                using (var response = await httpClient.GetAsync("metar/" + ICAO + "?options,airport,reporting,format,remove,filter,onfail}"))
                {

                    string responseData = await response.Content.ReadAsStringAsync();
                    JObject obj = JObject.Parse(responseData);
                    string raws = obj["raw"].ToString().Substring(5);
                    string[] raw = raws.Split(new string[] { "RMK" }, StringSplitOptions.None);
                    string icao = obj["station"].ToString();
                    string altimeters = obj["altimeter"]["repr"].ToString();
                    string[] altimeterqs = altimeters.Split(new string[] { "Q" }, StringSplitOptions.None);
                    float altimeterq = float.Parse(altimeterqs[1]);
                    float altimeter = altimeterq * 0.02953f;
                    string altimeterqresult = altimeter.ToString("#.00");
                    
                    string[] row = { icao, raw[0], altimeterqresult};
                    

                   


                    var listViewItem = new ListViewItem(row);
                    listViewItem.Name = textBox1.Text;
                    if (ListView.Items.ContainsKey(row[0]))
                    {
                        ListView.Items.RemoveByKey(ICAO);
                    }
                    else
                    { ListView.Items.Add(listViewItem); }
                    
                }
                
                
            }
        }

        private void ListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://paypal.me/yuukihj");
        }
    }
}
