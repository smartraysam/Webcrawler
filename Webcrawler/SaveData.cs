using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Web.Script.Serialization;
using System.IO;

namespace Webcrawler
{


    public partial class SaveData : Form
    {


        public SaveData(List<String> player_links, List<String> playerName, List<String> yearActive, List<string> Active, List<string> BAF, List<string> ERAF, int numof_player, List<String> Position, List<int> sorter)
        {
            InitializeComponent();
            position_play = Position;
            playerlinks = player_links;
            numofplayer = numof_player;
            player_Name = playerName;
            year_Active = yearActive;
            ActiveStatus = Active;
            BA = BAF;
            ERA = ERAF;
            sorting = sorter;

            // MessageBox.Show(position_play.Count.ToString() + player_Name.Count.ToString() + year_Active.Count.ToString() + ActiveStatus.Count.ToString());
            start = 0;
            if (numofplayer > 50)
            {
                end = 50;
            }
            else
            {
                end = numofplayer;
            }
           
            Export.Text = "Add " + start.ToString() + " to " + end.ToString() + " of " + numofplayer.ToString();
            playerNO.Text = numofplayer.ToString();
            tabletxt.Hide();
            table2txt.Hide();
            table3txt.Hide();
            Save.Enabled = false;
            process.Hide();
            extract.Enabled = false;
            label5.Text = processing.ToString();
        }
        string table3;
        string table2;
        int numofplayer;
        System.Data.DataTable table = new System.Data.DataTable();
        public List<int> sorting = new List<int>();
        public List<String> playerlinks = new List<String>();
        public static List<String> player_Name = new List<string>();
        public List<string> position_play = new List<string>();
        public List<String> year_Active = new List<String>();
        public List<string> ActiveStatus = new List<string>();
        public List<String> Bats = new List<string>();
        public List<String> Throws = new List<string>();
        public List<String> Team = new List<string>();
        public List<String> ERA = new List<string>();
        public List<String> BA = new List<string>();
        public List<String> SOvsRHB = new List<String>();
        public List<String> SOvsLHB = new List<string>();
        public List<String> SOvsLHP = new List<string>();
        public List<String> SOvsRHP = new List<string>();
        public List<String> H_valvsLHP = new List<String>();
        public List<String> Two_BvsLHP = new List<string>();
        public List<String> Three_BvsLHP = new List<string>();
        public List<String> H_RvsLHP = new List<string>();
        public List<String> B_BvsLHP = new List<String>();
        public List<String> H_valvsRHP = new List<String>();
        public List<String> Two_BvsRHP = new List<string>();
        public List<String> Three_BvsRHP = new List<string>();
        public List<String> H_RvsRHP = new List<string>();
        public List<String> B_BvsRHP = new List<String>();
        string pageHtml; string trimhtml;

        int start, end, last, finish, processing;
        string Bats_play = "";
        string Throws_play = "";
        string Team_play = "";

        string SOvsRHB_play = "";
        string SOvsLHB_play = "";
        string SOvsLHP_play = "";
        string SOvsRHP_play = "";
        string HvarvsRHP = "";
        string twoBvsRHP = "";
        string threeBvsRHP = "";
        string HRvsRHP = "";
        string BBvsRHP = "";
        string HvarvsLHP = "";
        string twoBvsLHP = "";
        string threeBvsLHP = "";
        string HRvsLHP = "";
        string BBvsLHP = "";
        int countso;
        string outText;

        int insertCount;
        DataTable sorted;

        private void extract_Click(object sender, EventArgs e)
        {
            processing = 0;
            sorted = ExportToDataTable();
            sorted.DefaultView.Sort = "SORT";
            sorted = sorted.DefaultView.ToTable();
           // dt.Merge(dt2);
           
            dataGridView1.DataSource = sorted;
            Save.Enabled = true;
        }

        private void Save_Click(object sender, EventArgs e)
        {

            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = "JSON File|*.json";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                File_Path.Text = savefile.FileName;

                string json = DataTabletoJSON(sorted);
                string putJson = json.Replace("{\"NAME\"", "\n{\"NAME\"");
                string reSort1 = putJson.Replace(",\"SORT\":1", "");
                string reSort2 = reSort1.Replace(",\"SORT\":2", "");
                File.WriteAllText(File_Path.Text.ToString(), reSort2);
                CopyWithProgress(numofplayer);
                MessageBox.Show("Extration complete");
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

        private void Export_Click(object sender, EventArgs e)
        {
            process.Show();
            process.Text = "processing";
            progressBar.Visible = true;
            progressBar.Minimum = 0;
            progressBar.Maximum = end-start;
            progressBar.Value = 1;
            progressBar.Step = 1;

            for (int i = start; i <= end; i++)
            {

                processing++;
                pageHtml = "";
                trimhtml = "";
                insertCount++;
                countso = 0;
                tabletxt.Text = "";
                table2txt.Text = "";
                table3txt.Text = "";
                progressBar.PerformStep();
                //MessageBox.Show(playerlinks[i]);
                HtmlWeb webload = new HtmlWeb();

                HtmlAgilityPack.HtmlDocument doc;
                try
                {
                    doc = webload.Load(playerlinks[i]);
                    label5.Text = processing.ToString();
                    foreach (HtmlNode item in doc.DocumentNode.SelectNodes("//div[@itemscope='']//p").ToList())
                    {

                        outText = item.InnerText;
                        // MessageBox.Show(outText);
                        if (outText.Contains("Bats:"))
                        {
                            Bats_play = getBetween(outText, "Bats:", "&");
                            // MessageBox.Show(Bats_play);
                            Bats.Add(Bats_play);
                        }
                        if (outText.Contains("Throws:"))
                        {
                            //MessageBox.Show(outText);
                            Throws_play = outText.Substring(outText.LastIndexOf(':') + 1);
                            // MessageBox.Show(Throws_play);
                            Throws.Add(Throws_play);
                        }
                        else if (outText.Contains("Team:"))
                        {
                            Team_play = outText.Replace("Team:", " ");
                            // MessageBox.Show(Team_play);
                            Team.Add(Team_play);
                        }
                    }
                    string ck1 = "vs RHB as RHP";
                    string ck2 = "vs LHB as RHP";
                    string ck3 = "vs RHP as RHB";
                    string ck4 = "vs LHP as RHB";
                    string ck5 = "vs RHB as LHP";
                    string ck6 = "vs LHB as LHP";

                    pageHtml = doc.DocumentNode.OuterHtml;
                    trimhtml = getBetween(pageHtml, "<h2>Platoon Splits</h2>", "<h2>Home or Away</h2>");
                    string htmltable = getBetween(trimhtml, "<tbody>", "</tbody>");
                    tabletxt.Text = htmltable.Replace("<td", "\n<td");
                    if (pageHtml.Contains(ck1) && pageHtml.Contains(ck2))
                    {
                        table2 = getBetween(pageHtml, "vs RHB as RHP", "vs LHB as RHP");
                        table2txt.Text = table2.Replace("<td", "\n<td");
                        table3 = getBetween(pageHtml, "vs LHB as RHP", "<h2>Home or Away</h2>");
                        table3txt.Text = table3.Replace("<td", "\n<td");
                    }
                    else if (pageHtml.Contains(ck3) && pageHtml.Contains(ck4))
                    {
                        table2 = getBetween(pageHtml, ck3, ck4);
                        table2txt.Text = table2.Replace("<td", "\n<td");
                        table3 = getBetween(pageHtml, ck4, "<h2>Home or Away</h2>");
                        table3txt.Text = table3.Replace("<td", "\n<td");
                    }
                    else if (pageHtml.Contains(ck5) && pageHtml.Contains(ck6))
                    {
                        table2 = getBetween(pageHtml, ck5, ck6);
                        table2txt.Text = table2.Replace("<td", "\n<td");
                        table3 = getBetween(pageHtml, ck6, "<h2>Home or Away</h2>");
                        table3txt.Text = table3.Replace("<td", "\n<td");
                    }

                    foreach (string line in table3txt.Lines)
                    {
                        // countm++;
                        // MessageBox.Show(countm.ToString());
                        if (line.Contains("data-stat=\"H\""))
                        {
                            HvarvsLHP = getBetween(line, ">", "<");
                            H_valvsLHP.Add(HvarvsLHP);


                        }
                        if (line.Contains("data-stat=\"2B\""))
                        {
                            twoBvsLHP = getBetween(line, ">", "<");
                            Two_BvsLHP.Add(twoBvsLHP);
                        }
                        if (line.Contains("data-stat=\"3B\""))
                        {
                            threeBvsLHP = getBetween(line, ">", "<");
                            Three_BvsLHP.Add(threeBvsLHP);
                        }
                        if (line.Contains("data-stat=\"HR\""))
                        {
                            HRvsLHP = getBetween(line, ">", "<");
                            H_RvsLHP.Add(HRvsLHP);
                        }
                        if (line.Contains("data-stat=\"BB\""))
                        {
                            BBvsLHP = getBetween(line, ">", "<");
                            B_BvsLHP.Add(BBvsLHP);
                        }

                    }


                    foreach (string line in table2txt.Lines)
                    {
                        // countm++;
                        // MessageBox.Show(countm.ToString());
                        if (line.Contains("data-stat=\"H\""))
                        {
                            HvarvsRHP = getBetween(line, ">", "<");
                            H_valvsRHP.Add(HvarvsRHP);


                        }
                        if (line.Contains("data-stat=\"2B\""))
                        {
                            twoBvsRHP = getBetween(line, ">", "<");
                            Two_BvsRHP.Add(twoBvsRHP);
                        }
                        if (line.Contains("data-stat=\"3B\""))
                        {
                            threeBvsRHP = getBetween(line, ">", "<");
                            Three_BvsRHP.Add(threeBvsRHP);
                        }
                        if (line.Contains("data-stat=\"HR\""))
                        {
                            HRvsRHP = getBetween(line, ">", "<");
                            H_RvsRHP.Add(HRvsRHP);
                        }
                        if (line.Contains("data-stat=\"BB\""))
                        {
                            BBvsRHP = getBetween(line, ">", "<");
                            B_BvsRHP.Add(BBvsRHP);
                        }

                    }

                    foreach (string line in tabletxt.Lines)
                    {
                        // countm++;
                        // MessageBox.Show(countm.ToString());

                        if (line.Contains("data-stat=\"SO\""))
                        {
                            countso++;
                            //MessageBox.Show( countso.ToString());
                            if (countso == 1) { SOvsRHB_play = getBetween(line, ">", "<"); SOvsRHB.Add(SOvsRHB_play); }// MessageBox.Show(SOvsRHB_play + countso.ToString()); }
                            else if (countso == 2) { SOvsLHB_play = getBetween(line, ">", "<"); SOvsLHB.Add(SOvsLHB_play); }// MessageBox.Show(SOvsLHB_play + countso.ToString()); }
                            else if (countso == 3) { SOvsLHP_play = getBetween(line, ">", "<"); SOvsLHP.Add(SOvsLHP_play); }//MessageBox.Show(SOvsLHP_play + countso.ToString()); }
                            else if (countso == 4) { SOvsRHP_play = getBetween(line, ">", "<"); SOvsRHP.Add(SOvsRHP_play); }// MessageBox.Show(SOvsRHP_play + countso.ToString()); }  

                        }
                    }
                }
                catch (Exception)
                {
                   // MessageBox.Show(");
                   extractstatus.AppendText("Cannot read data from " + playerlinks[i]+ Environment.NewLine);
                    Bats.Add("-");
                    Throws.Add("-");
                    Team.Add("-");
                    SOvsLHB.Add("-");
                    SOvsLHP.Add("-");
                    SOvsRHB.Add("-");
                    SOvsRHP.Add("-");
                    Three_BvsRHP.Add("-");
                    Two_BvsRHP.Add("-");
                    H_RvsRHP.Add("-");
                    B_BvsLHP.Add("-");
                    Three_BvsLHP.Add("-");
                    Two_BvsLHP.Add("-");
                    H_RvsLHP.Add("-");
                    B_BvsRHP.Add("-");
                    H_valvsRHP.Add("-");
                    H_valvsLHP.Add("-");
                    continue;
                }
                
              
            }

            while (Team.Count < insertCount)
            {
                Team.Add("-");

            }
            while (SOvsLHB.Count < insertCount)
            {
                SOvsLHB.Add("-");
            }
            while (SOvsLHP.Count < insertCount)
            {
                SOvsLHP.Add("-");
            }
            while (SOvsRHB.Count < insertCount)
            {
                SOvsRHB.Add("-");
            }
            while (SOvsRHP.Count < insertCount)
            {
                SOvsRHP.Add("-");
            }
            while (Three_BvsRHP.Count < insertCount)
            {
                Three_BvsRHP.Add("-");
            }
            while (Two_BvsRHP.Count < insertCount)
            {
                Two_BvsRHP.Add("-");
            }
            while (H_RvsRHP.Count < insertCount)
            {
                H_RvsRHP.Add("-");
            }
            while (B_BvsLHP.Count < insertCount)
            {
                B_BvsLHP.Add("-");
            }
            while (Three_BvsLHP.Count < insertCount)
            {
                Three_BvsLHP.Add("-");
            }
            while (Two_BvsLHP.Count < insertCount)
            {
                Two_BvsLHP.Add("-");
            }
            while (H_RvsLHP.Count < insertCount)
            {
                H_RvsLHP.Add("-");
            }
            while (B_BvsRHP.Count < insertCount)
            {
                B_BvsRHP.Add("-");
            }
            while (H_valvsRHP.Count < insertCount)
            {

                H_valvsRHP.Add("-");
            }
            while (H_valvsLHP.Count < insertCount)
            {
                H_valvsLHP.Add("-");
            }
            while (ERA.Count < insertCount)
            {

                ERA.Add("-");
            }
            while (BA.Count < insertCount)
            {
                BA.Add("-");
            }

            extract.Enabled = true;
            process.Text = "Done";
          
            finish = start;
            last = end;
            extractstatus.AppendText("Extraction of " + finish.ToString() + " to " + last.ToString() + " of " + numofplayer.ToString() + " is complete"+ Environment.NewLine);

            start = last + 1;

            int unProcess = numofplayer - processing;
           

            if (unProcess > 50)
            {

                end = last + 50;
                Export.Text = "Add " + start.ToString() + " to " + end.ToString() + " of " + numofplayer.ToString();
            }
            else if (processing== numofplayer)
            {
                Export.Enabled = false;
                extractstatus.Text="Extractino complete of "+ numofplayer.ToString() + Environment.NewLine;
                Export.Text = processing.ToString() + " of " + numofplayer.ToString()+ " Done";

            }

            else
            {
                end = last + unProcess;
                Export.Text = "Add " + start.ToString() + " to " + numofplayer.ToString() + " of " + numofplayer.ToString() ;
               
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

        /**
        public static DataTable sortTable(DataTable dt, string colName)
        {
            dt.DefaultView.Sort = colName+""+"ASC";
            dt = dt.DefaultView.ToTable();
            return dt;
        }
        **/
        public string DataTabletoJSON(DataTable table)
        {
            JavaScriptSerializer jsSerial = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in table.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in table.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }
            return jsSerial.Serialize(parentRow);
        }
        public System.Data.DataTable ExportToDataTable()
        {
            table.Columns.Add("NAME", typeof(string));
            table.Columns.Add("YEAR ACTIVE", typeof(string));
            table.Columns.Add("ACTIVE STATUS", typeof(string));
            table.Columns.Add("POSITION", typeof(string));
            table.Columns.Add("BATHS", typeof(string));
            table.Columns.Add("THROWS", typeof(string));
            table.Columns.Add("TEAM", typeof(string));
            table.Columns.Add("ERA", typeof(string));
            table.Columns.Add("BA", typeof(string));
            table.Columns.Add("SOvsRHB", typeof(string));
            table.Columns.Add("SOvsLHB", typeof(string));
            table.Columns.Add("SOvsLHP", typeof(string));
            table.Columns.Add("SOvsRHP", typeof(string));
            table.Columns.Add("HvsRHP", typeof(string));
            table.Columns.Add("2BvsRHP/RHB", typeof(string));
            table.Columns.Add("3BvsRHP/RHB", typeof(string));
            table.Columns.Add("HRvsRHP/RHB", typeof(string));
            table.Columns.Add("BBvsRHP/RHB", typeof(string));
            table.Columns.Add("HvsLHP/LHB", typeof(string));
            table.Columns.Add("2BvsLHP/LHB", typeof(string));
            table.Columns.Add("3BvsLHP/LHB", typeof(string));
            table.Columns.Add("HRvsLHP/LHB", typeof(string));
            table.Columns.Add("BBvsLHP/LHB", typeof(string));
            table.Columns.Add("SORT", typeof(int));

            for (int i = 0; i <= last; i++)
            {
                table.Rows.Add(player_Name[i], year_Active[i], ActiveStatus[i], position_play[i], Bats[i], Throws[i], Team[i], ERA[i], BA[i], SOvsRHB[i], SOvsLHB[i], SOvsLHP[i], SOvsRHP[i], H_valvsRHP[i], Two_BvsRHP[i], Three_BvsRHP[i], H_RvsRHP[i], B_BvsRHP[i], H_valvsLHP[i], Two_BvsLHP[i], Three_BvsLHP[i], H_RvsLHP[i], B_BvsLHP[i],sorting[i]);

            }
            return table;
        }
        /**
                void createExcell()
                {
                    Microsoft.Office.Interop.Excel.Application excel;
                    Microsoft.Office.Interop.Excel.Workbook worKbooK;
                    Microsoft.Office.Interop.Excel.Worksheet worKsheeT;
                    Microsoft.Office.Interop.Excel.Range celLrangE;

                    try
                    {
                        excel = new Microsoft.Office.Interop.Excel.Application();
                        excel.Visible = false;
                        excel.DisplayAlerts = false;
                        worKbooK = excel.Workbooks.Add(Type.Missing);


                        worKsheeT = (Microsoft.Office.Interop.Excel.Worksheet)worKbooK.ActiveSheet;

                        worKsheeT.Name = "baseBallplayer";




                        //worKsheeT.Range[worKsheeT.Cells[1, 1], worKsheeT.Cells[1, 8]].Merge();
                        // worKsheeT.Cells[1, 1] = openFileDialog.SafeFileName;
                        // worKsheeT.Cells.Font.Size = 15;


                        int rowcount = 1;

                        foreach (DataRow datarow in ExportToDataTable().Rows)
                        {
                            rowcount += 1;
                            for (int i = 1; i <= ExportToDataTable().Columns.Count; i++)
                            {

                                if (rowcount == 3)
                                {
                                    worKsheeT.Cells[1, i] = ExportToDataTable().Columns[i - 1].ColumnName;
                                    worKsheeT.Cells.Font.Color = System.Drawing.Color.Black;

                                }

                                worKsheeT.Cells[rowcount, i] = datarow[i - 1].ToString();


                                if (rowcount > 3)
                                {
                                    if (i == ExportToDataTable().Columns.Count)
                                    {
                                        if (rowcount % 2 == 0)
                                        {
                                            celLrangE = worKsheeT.Range[worKsheeT.Cells[rowcount, 1], worKsheeT.Cells[rowcount, ExportToDataTable().Columns.Count]];
                                        }

                                    }
                                }

                            }

                        }


                        celLrangE = worKsheeT.Range[worKsheeT.Cells[1, 1], worKsheeT.Cells[rowcount, ExportToDataTable().Columns.Count]];
                        celLrangE.EntireColumn.AutoFit();
                        Microsoft.Office.Interop.Excel.Borders border = celLrangE.Borders;
                        border.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        border.Weight = 2d;


                        celLrangE = worKsheeT.Range[worKsheeT.Cells[1, 1], worKsheeT.Cells[2, ExportToDataTable().Columns.Count]];
                        worKbooK.SaveAs(File_Path.Text.ToString());
                        for (int i = 0; i <= 10; i++)
                        {
                            CopyWithProgress(numofplayer);
                        }

                        worKbooK.Close();
                        excel.Quit();
                        MessageBox.Show("Extraction complete");


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                    finally
                    {
                        worKsheeT = null;
                        celLrangE = null;
                        worKbooK = null;
                    }

                }

                **/
    }
}
