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
using System.Text.RegularExpressions;



namespace Webcrawler
{
    public partial class Player_Extract_Data : Form
    {
        public List<string> links = new List<string>();
        public List<string> playerlinks = new List<string>();
        public static List<string> player_Name = new List<string>();
        public List<string> year_Active = new List<string>();
        public List<string> ActiveStatus = new List<string>();
        public List<String> ERA = new List<string>();
        public List<String> BA = new List<string>();
        public List<int> sorter = new List<int>();
        int numofplayer;
        int inistart, start, iniend, end, processed;
     

        string ERA_play = "";
        string BA_play = "";


        public Player_Extract_Data(List<String> html_links, List<String> player_links, List<String> playerName, List<String> yearActive, List<string> Active, int numof_player)
        {
            InitializeComponent();
            links = html_links;
            playerlinks = player_links;
            numofplayer = numof_player;
            player_Name = playerName;
            year_Active = yearActive;
            ActiveStatus = Active;
          
            Next.Enabled = false;
            status.Hide();
            getBAERA.Hide();

            playerNO.Text = numofplayer.ToString();
            start = 0;
            if (numofplayer > 50)
            {
                end = 50;
            }
            else
            {
                end = numofplayer;
            }
           
            getData.Text = "Add " + start.ToString() + " to " + end.ToString() + " of " + numofplayer.ToString();

        }

        public List<string> newLinks = new List<string>();
        public List<String> Position = new List<string>();


        string Position_play = "";
        string chekstring;
        string noSpace;


        private void getData_Click(object sender, EventArgs e)
        {
            status.Show();

            status.Text = "Please wait";

            getData.Enabled = false;
            progressBar.Visible = true;
            progressBar.Minimum = 0;
            progressBar.Maximum = end - start;
            progressBar.Value = 1;
            progressBar.Step = 1;
            Next.Enabled = false;
            for (int i = start; i <= end; i++)
            {

                chekstring = "";
                noSpace = "";
                processed++;
                HtmlWeb webload = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc;
                progressBar.PerformStep();
                string partlink = getBetween(links[i], "players/", ".shtml");
                partlink = partlink.Substring(2);
                try
                {

                    doc = webload.Load(playerlinks[i]);
                    string outText = doc.DocumentNode.SelectSingleNode("//div[@itemscope='']//p").InnerText;

                    chekstring = doc.DocumentNode.SelectSingleNode("//div[@class='stats_pullout']").InnerHtml;

                    noSpace = Regex.Replace(chekstring, @"\s+", string.Empty);
                    getBAERA.Text = noSpace.Replace("<div>", "\n<div>");
                    foreach (string varLine in getBAERA.Lines)
                    {
                        if (varLine.Contains(">ERA</h4>"))
                        {
                            ERA_play = getBetween(varLine, "<p>", "</p>");
                            ERA.Add(ERA_play);
                            //MessageBox.Show(ERA_play);
                            BA.Add("-");

                        }
                        else if (varLine.Contains(">BA</h4>"))
                        {
                            BA_play = getBetween(varLine, "<p>", "</p>");
                            BA.Add(BA_play);
                            // MessageBox.Show(BA_play);
                            ERA.Add("-");

                        }
                    }

                    Position_play = outText.Substring(18);
                    Position.Add(Position_play);
                    // MessageBox.Show(Position_play);
                    playerName.Items.Add(string.Format("{0} | {1}", player_Name[i], Position_play));

                    if (Position_play.Contains("Pitcher"))
                    {
                        newLinks.Add("http://www.baseball-reference.com/players/split.fcgi?id=" + partlink + "&year=Career&t=p");
                        // MessageBox.Show("http://www.baseball-reference.com/players/split.fcgi?id=" + partlink + "&year=Career&t=p");
                        sorter.Add(1);
                    }
                    else
                    {
                        newLinks.Add("http://www.baseball-reference.com/players/split.fcgi?id=" + partlink + "&year=Career&t=b");
                        // MessageBox.Show("http://www.baseball-reference.com/players/split.fcgi?id=" + partlink + "&year=Career&t=b");
                        sorter.Add(2);
                    }
                    prodata.Text = Position.Count.ToString();
                }
                catch (Exception)
                {
                    xDetails.AppendText("Cannot read data from " + playerlinks[i] + Environment.NewLine);

                    continue;
                }
            }

            Next.Enabled = true;
            status.Text = "Done";
            getData.Enabled = true;
            inistart = start;
            iniend = end;
            start = iniend + 1;
            xDetails.AppendText("Extraction of " + inistart.ToString() + " to " + iniend.ToString() + " of " + numofplayer.ToString() + " is complete" + Environment.NewLine);

            int unProcess = numofplayer - processed;

          
            if (unProcess > 50)
            {

                end = iniend + 50;
                getData.Text = "Add " + start.ToString() + " to " + end.ToString() + " of " + numofplayer.ToString();

            }
            else if (processed== numofplayer)
            {
                getData.Enabled = false;
                xDetails.Text=("Extractino complete of " + numofplayer.ToString()+ Environment.NewLine);
                getData.Text = processed.ToString() + " of " + numofplayer.ToString()+ " Done";

            }
            else
            {
                end = iniend + unProcess;
                getData.Text = "Add " + start.ToString() + " to " + numofplayer.ToString() +" of " + numofplayer.ToString();
               
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

        private void Back_Click(object sender, EventArgs e)
        {

            this.Close();
            Form1 backtoform = new Form1();
            backtoform.Show();
        }

        private void Next_Click(object sender, EventArgs e)
        {

            this.Hide();
            SaveData dataForm = new SaveData(newLinks, player_Name, year_Active, ActiveStatus, BA, ERA, numofplayer, Position, sorter);
            processed = 0;
            dataForm.Show();

        }


    }
}
