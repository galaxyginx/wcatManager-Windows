using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace SQLiteManager
{
    public partial class Main : Form
    {
        SQLiteConnection Con = null;
        SQLiteCommand Cmd = null;
        string DBName, RefreshCmd;
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            DBName = "Binds";
            RefreshCmd = "SELECT Bind FROM SpecifiedBindList";
            ConnectDB(@"DataLists\\SpecifiedBindList.db");
            RefreshList();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Con.Close();
        }

        private void ConnectDB(string Path)
        {
            if (System.IO.File.Exists(Path))
            {
                Con = new SQLiteConnection("Data Source="+Path);
                Con.Open();
                Cmd = Con.CreateCommand();
            }
            else
            {
                MessageBox.Show("対象のデータファイルが見つかりません。");
            }
        }

        private void AddRecord()
        {
            switch (DBName)
            {
                case "Binds":
                    Cmd.CommandText = "SELECT COUNT(Bind) FROM SpecifiedBindList WHERE Bind = '" + AdderTextBox.Text + "'";
                    break;
                case "Maps":
                    Cmd.CommandText = "SELECT COUNT(Map) FROM MapList WHERE Map = '" + AdderTextBox.Text + "'";
                    break;
                case "Jobs":
                    Cmd.CommandText = "SELECT COUNT(Job) FROM JobList WHERE Job = '" + AdderTextBox.Text + "'";
                    break;
                case "Types":
                    Cmd.CommandText = "SELECT COUNT(Type) FROM TypeList WHERE Type = '" + AdderTextBox.Text + "'";
                    break;
            }
            long i = (long)Cmd.ExecuteScalar();
            if (i == 0)
            {
                switch (DBName)
                {
                    case "Binds":
                        Cmd.CommandText = "INSERT INTO SpecifiedBindList (Bind) VALUES ('" + AdderTextBox.Text + "')";
                        break;
                    case "Maps":
                        Cmd.CommandText = "INSERT INTO MapList (Difficulty, Map) VALUES ('" + MapDifficulty.Value + "','" + AdderTextBox.Text + "')";
                        break;
                    case "Jobs":
                        Cmd.CommandText = "INSERT INTO JobList (Job) VALUES ('" + AdderTextBox.Text + "')";
                        break;
                    case "Types":
                        Cmd.CommandText = "INSERT INTO TypeList (Type) VALUES ('" + AdderTextBox.Text + "')";
                        break;
                }
                Cmd.ExecuteNonQuery();
                AdderTextBox.Text = "";
                RefreshList();
            }
            else
            {
                MessageBox.Show("既に追加されている要素です。");
            }
        }
        private void RemoveRecord(string obj)
        {
            switch (DBName)
            {
                case "Binds":
                    Cmd.CommandText = "DELETE FROM SpecifiedBindList WHERE Bind = '" + obj + "'";
                    break;
                case "Maps":
                    Cmd.CommandText = "DELETE FROM MapList WHERE Map = '" + obj + "'";
                    break;
                case "Jobs":
                    Cmd.CommandText = "Delete from JobList where Job = '"+ obj +"'";
                    break;
                case "Types":
                    Cmd.CommandText = "Delete from TypeList where Type = '"+obj+"'";
                    break;
            }
            Cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// レコードを取得
        /// </summary>
        private void RefreshList()
        {
            // 全データの取得
            DataList.Rows.Clear();
            Cmd.CommandText = RefreshCmd;
            SQLiteDataReader reader = Cmd.ExecuteReader();
            while (reader.Read())
            {
                switch (DBName)
                {
                    case "Binds":
                        DataList.Rows.Add("",reader["Bind"].ToString());
                        break;
                    case "Maps":
                        DataList.Rows.Add(reader["Difficulty"], reader["Map"].ToString());
                        break;
                    case "Jobs":
                        DataList.Rows.Add("",reader["Job"].ToString());
                        break;
                    case "Types":
                        DataList.Rows.Add("",reader["Type"].ToString());
                        break;
                }
            }
            reader.Close();
        }
        private void ConnectionClose()
        {
            Con.Close();
        }

        private void Adder_Click(object sender, EventArgs e)
        {
            if (AdderTextBox.Text != "")
            {
                AddRecord();
            }
        }

        private void DeleteItem_Click(object sender, EventArgs e)
        {
            int row = 0;
            foreach (DataGridViewRow r in DataList.SelectedRows)
            {
                row = r.Index;
            }
            DialogResult dr = MessageBox.Show(DataList.Rows[(row)].Cells[1].Value.ToString() + "を削除しますか？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                RemoveRecord(DataList.Rows[(row)].Cells[1].Value.ToString());
            }
        }
        private void Binds_Click(object sender, EventArgs e)
        {
            ConnectionClose();
            DBName = "Binds";
            RefreshCmd = "SELECT Bind FROM SpecifiedBindList";
            ConnectDB(@"DataLists\\SpecifiedBindList.db");
            RefreshList();
        }

        private void Jobs_Click(object sender, EventArgs e)
        {
            ConnectionClose();
            DBName = "Jobs";
            RefreshCmd = "SELECT Job FROM JobList";
            ConnectDB(@"DataLists\\JobList.db");
            RefreshList();
        }

        private void Types_Click(object sender, EventArgs e)
        {
            ConnectionClose();
            DBName = "Types";
            RefreshCmd = "SELECT Type FROM TypeList";
            ConnectDB(@"DataLists\\TypeList.db");
            RefreshList();
        }

        private void Maps_Click(object sender, EventArgs e)
        {
            ConnectionClose();
            DBName = "Maps";
            RefreshCmd = "SELECT Difficulty, Map FROM MapList";
            ConnectDB(@"DataLists\\MapList.db");
            RefreshList();
        }
    }
}
