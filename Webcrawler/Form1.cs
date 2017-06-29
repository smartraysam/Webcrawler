using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using HtmlAgilityPack;
using System.Net;
using System.IO;
using System.Collections.Concurrent;



namespace Webcrawler
{
    public partial class Form1 : Form
    {

        string html_links;

        string playeract;
        public static List<String> htmls_links = new List<String>();
        public static List<String> player_links = new List<String>();
        public static List<String> playerName = new List<string>();
        public List<String> yearActive = new List<String>();
        public List<string> Active = new List<string>();
        public static int numOfPlayers;
        

        public Form1()
        {
            InitializeComponent();
           // actPlay.Checked = false;
            extract.Enabled = false;
       
        }
        private void get_info_Click(object sender, EventArgs e)
        {
            player_list.Items.Clear();
            playerName.Clear();
            player_links.Clear();
            Active.Clear();
            yearActive.Clear();
            htmls_links.Clear();
            numOfPlayers = 0;
         
            var playerIndex = "http://www.baseball-reference.com/players/" + player_initials.Text.ToString().ToLower();


            if (player_initials.Text == "" || player_initials.Text == null)
            {
                MessageBox.Show("Please select player last name initial");
            }
            else
            {
                if (NetworkInterface.GetIsNetworkAvailable() == true)
                {
                    try
                    {
                        get_info.Enabled = false;
                        HtmlWeb webload = new HtmlWeb();
                        HtmlAgilityPack.HtmlDocument doc = webload.Load(playerIndex);
                        //if (actPlay.Checked == true && playeract.Contains("<b>"))
                        //{
                        //    foreach (HtmlNode links in doc.DocumentNode.SelectNodes("//div[@id='div_players_']//p//b//a[@href]"))
                        //    {

                        //        html_links = links.GetAttributeValue("href", string.Empty);
                        //        player_links.Add("http://www.baseball-reference.com" + html_links);
                        //        htmls_links.Add(html_links);

                        //    }
                        //}
                        //else
                        //{
                            foreach (HtmlNode links in doc.DocumentNode.SelectNodes("//div[@id='div_players_']//p//a[@href]"))
                            {

                                html_links = links.GetAttributeValue("href", string.Empty);
                                player_links.Add("http://www.baseball-reference.com" + html_links);
                                htmls_links.Add(html_links);

                            }

                       // }


                        var Player_Names = doc.DocumentNode
                            .SelectNodes("//div[@id='div_players_']//p").ToList();
                        foreach (var item in Player_Names)
                        {

                            numOfPlayers++;
                            playeract = item.InnerHtml.ToString();

                            //if (actPlay.Checked==true && playeract.Contains("<b>")) 
                            //{
                            //    player_list.Items.Add(item.InnerText);
                            //    Active.Add("Yes");
                            //    var ExtVals = item.InnerText.Substring(item.InnerText.IndexOf("("));
                            //    var year_act = getBetween(ExtVals, "(", ")");
                            //    yearActive.Add(year_act);
                              
                            //    var player_name = item.InnerText.Substring(0, (item.InnerText.Length) - ExtVals.Length);
                            //    playerName.Add(player_name);

                            //}
                             if (playeract.Contains("<b>"))
                            {
                                player_list.Items.Add(item.InnerText);
                                Active.Add("Yes");
                                var ExtVals = item.InnerText.Substring(item.InnerText.IndexOf("("));
                                var year_act = getBetween(ExtVals, "(", ")");
                                yearActive.Add(year_act);
                               
                                var player_name = item.InnerText.Substring(0, (item.InnerText.Length) - ExtVals.Length);
                                playerName.Add(player_name);
                                
                            }
                            else
                            {

                                player_list.Items.Add(item.InnerText);
                                Active.Add("No");
                                var ExtVals = item.InnerText.Substring(item.InnerText.IndexOf("("));
                                var year_act = getBetween(ExtVals, "(", ")");
                                yearActive.Add(year_act);
                              
                                var player_name = item.InnerText.Substring(0, (item.InnerText.Length) - ExtVals.Length);
                                playerName.Add(player_name);
                              
                            }


                        }
                        extract.Enabled = true;
                        for (int i = 0; i <= 10; i++)
                        {
                            CopyWithProgress(numOfPlayers);
                        }
                        get_info.Enabled = true;


                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Cannot connect to remote database. Please Retry!!");
                        get_info.Enabled = true;
                    }


                }
                else
                {
                    MessageBox.Show("Check your Internet connection");
                }

            }


        }

        private void CopyWithProgress(int filesizes)
        {
            // Display the ProgressBar control.
            progressBar.Visible = true;
            // Set Minimum to 1 to represent the first file being copied.
            progressBar.Minimum = 1;
            // Set Maximum to the total number of files to copy.
            progressBar.Maximum = filesizes;
            // Set the initial value of the ProgressBar.
            progressBar.Value = 1;
            // Set the Step property to a value of 1 to represent each file being copied.
            progressBar.Step = 1;

            // Loop through all files to copy.
            for (int x = 1; x <= filesizes; x++)
            {
                // Perform the increment on the ProgressBar.
                progressBar.PerformStep();

            }
        }

        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }
     

        private void but_exit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void extract_Click(object sender, EventArgs e)
        {
            this.Hide();
            Player_Extract_Data dataForm = new Player_Extract_Data(htmls_links, player_links, playerName, yearActive, Active, numOfPlayers);
            dataForm.Show();
        }

        private void player_initials_SelectedIndexChanged(object sender, EventArgs e)
        {
            extract.Enabled = false;
        }
    }
}
