using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace wcatCharaDBEditer
{
    public partial class Main : Form
    {
        SQLiteConnection Con = null;
        SQLiteCommand Cmd = null;
        int id;
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            ConnectDB(@"DataLists\\CharacterList.db");
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
                Con = new SQLiteConnection("Data Source=" + Path);
                Con.Open();
                Cmd = Con.CreateCommand();
                Cmd.CommandText = "select count(*) from sqlite_master where name = 'CharacterList' and sql like '%Attribute%'";
                if ((long)Cmd.ExecuteScalar() == 0)
                {
                    Cmd.CommandText = "alter table CharacterList add Attribute varchar";
                    Cmd.ExecuteNonQuery();
                }
            }
            else
            {
                Con = new SQLiteConnection("Data Source=" + Path);
                Con.Open();
                Cmd = Con.CreateCommand();
                Cmd.CommandText = "CREATE TABLE CharacterList (id integer primary key, Rarity int,Name varchar,Job varchar,Type varchar,RareType varchar, Attribute varchar)";
                Cmd.ExecuteNonQuery();
            }
        }

        private void AddRecord()
        {
            Cmd.CommandText = "INSERT INTO CharacterList (Rarity,Name,Job,Type,RareType, Attribute) VALUES ('" + RarityBox.Value + "','" + NameBox.Text + "','" + JobBox.Text + "','" + TypeBox.Text + "','" + RareTypeBox.Text + "','" + AttributeBox.Text + "')";
            Cmd.ExecuteNonQuery();
            NameBox.Clear();
            JobBox.Text = null;
            TypeBox.Text = null;
            RareTypeBox.Text = null;
            AttributeBox.Text = null;
            RefreshList();
        }
        private void RemoveRecord(int obj)
        {
            Cmd.CommandText = "DELETE FROM CharacterList WHERE id = '" + obj + "'";
            Cmd.ExecuteNonQuery();
            RefreshList();
        }
        private void RefreshList()
        {
            CharacterList.Rows.Clear();
            Cmd.CommandText = "SELECT id, Rarity,Name,Job,Type,RareType,Attribute FROM CharacterList order by Rarity desc,Job asc";
            SQLiteDataReader reader = Cmd.ExecuteReader();
            while (reader.Read())
            {
                CharacterList.Rows.Add(reader["id"], "☆" + reader["Rarity"].ToString(), reader["Name"].ToString(), reader["Job"].ToString(), reader["Type"].ToString(), reader["RareType"].ToString(), reader["Attribute"].ToString());
            }
            reader.Close();
        }

        private void Adder_Click(object sender, EventArgs e)
        {
            if (NameBox.Text != "" && JobBox.Text != "" && TypeBox.Text != "" && RareTypeBox.Text != "")
            {
                AddRecord();
            }
            else
            {
                MessageBox.Show("一部の情報が不足しています");
            }
        }

        private void CharacterList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            //"Button"列ならば、ボタンがクリックされた
            if (dgv.Columns[e.ColumnIndex].Name == "Edit")
            {
                Cmd.CommandText = "SELECT Rarity,Name,Job,Type,RareType,Attribute FROM CharacterList where id=" + int.Parse(CharacterList.Rows[e.RowIndex].Cells[0].Value.ToString());
                SQLiteDataReader reader = Cmd.ExecuteReader();
                while (reader.Read())
                {
                    NameBox.Text = reader["Name"].ToString();
                    JobBox.Text = reader["Job"].ToString();
                    RarityBox.Value = (int)reader["Rarity"];
                    TypeBox.Text = reader["Type"].ToString();
                    RareTypeBox.Text = reader["RareType"].ToString();
                    AttributeBox.Text = reader["Attribute"].ToString();
                }
                reader.Close();
                id = int.Parse(CharacterList.Rows[e.RowIndex].Cells[0].Value.ToString());
                Apply.Enabled = true;
                Add.Enabled = false;
            }
            if (dgv.Columns[e.ColumnIndex].Name == "Delete")
            {
                DialogResult dr;
                dr = MessageBox.Show(CharacterList.Rows[e.RowIndex].Cells[2].Value.ToString() + "を削除しますか？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    RemoveRecord(int.Parse(CharacterList.Rows[e.RowIndex].Cells[0].Value.ToString()));
                }
            }
        }

        private void Apply_Click(object sender, EventArgs e)
        {
            Cmd.CommandText = "update CharacterList set Name='" + NameBox.Text + "',Job='" + JobBox.Text + "',Rarity=" + RarityBox.Value + ",Type='" + TypeBox.Text + "',RareType='" + RareTypeBox.Text + "',Attribute = '" + AttributeBox.Text + "' where id=" + id;
            Cmd.ExecuteNonQuery();
            RefreshList();
            NameBox.Clear();
            JobBox.Text = null;
            TypeBox.Text = null;
            RareTypeBox.Text = null;
            AttributeBox.Text = null;
            id = 0;
            Apply.Enabled = false;
            Add.Enabled = true;
        }
    }
}