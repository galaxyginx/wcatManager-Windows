using System;
using System.Collections;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace wcatManager
{
    public partial class Main : Form
    {
        public int i, Players, Timer4cnt, LoadCnt;
        public string str, rarity, type, job, raretype, attribute, result, sql, File, TeamDBPath = "Data Source=" + System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\\GalaxySoftware\\wcatManager\\DataLists\\PlayerList.db", CustomDBPath = "Data Source=" + System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\\GalaxySoftware\\wcatManager\\DataLists\\CustomList.db";
        public Timer Timerfor4, DesidePlace, Timer4Custom;
        public Random random = new Random();
        public Boolean Error;
        public ArrayList JobList = new ArrayList(), TypeList = new ArrayList(), RareList = new ArrayList(), AttributeList = new ArrayList(), MapList = new ArrayList(), CustomList = new ArrayList(), PlayerList = new ArrayList(), RareTypeList = new ArrayList(), SortList = new ArrayList(), TeamA = new ArrayList(), TeamB = new ArrayList(), TeamC = new ArrayList(), TeamD = new ArrayList(), RemoveList = new ArrayList();
        public ResultWindow ResultObj = new ResultWindow();
        SQLiteConnection JobCon = null, TypeCon = null, MapCon = null, TeamCon = null, CustomCon = null, BindCon = null, CharaCon = null;
        public SQLiteCommand JobCmd = null, TypeCmd = null, MapCmd = null, TeamCmd = null, CustomCmd = null, BindCmd = null, CharaCmd = null;
        public SQLiteDataReader reader;
        public Label One, Two, Three, Four;
        Settings settings = new Settings();
        XmlSerializer serializer;
        StreamWriter sw;
        StreamReader sr;

        public Main()
        {
            // フォルダ (ディレクトリ) が存在しているかどうか確認する
            if (!System.IO.Directory.Exists(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\\GalaxySoftware\\wcatManager\\DataLists"))
            {
                // フォルダ (ディレクトリ) を作成する
                System.IO.Directory.CreateDirectory(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\\GalaxySoftware\\wcatManager\\DataLists");
            }
            InitializeComponent();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(@"DataLists\\CharacterList.db"))
            {
                EnableAccuracyMenu.Enabled = true;
            }
            if (System.IO.File.Exists(@"wcatBasicEditer.exe"))
            {
                DefaultDataMenuItem.Enabled = true;
            }
            if (System.IO.File.Exists(@"wcatCharaDBEditer.exe"))
            {
                wcatCharaMenuItem.Enabled = true;
            }
            if (!System.IO.File.Exists(@"DataLists\\SpecifiedBindList.db") || !System.IO.File.Exists(@"DataLists\\JobList.db") || !System.IO.File.Exists(@"DataLists\\TypeList.db") || !System.IO.File.Exists(@"DataLists\\MapList.db"))
            {
                MessageBox.Show("SpecifiedBindList.db、JobList.db、TypeList.db、MapListのいずれかが見つかりませんでした。", "", MessageBoxButtons.OK);
                Application.Exit();
            }
            serializer = new XmlSerializer(typeof(Settings));
            if (System.IO.File.Exists(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\\GalaxySoftware\\wcatManager\\DataLists\\Settings.xml"))
            {
                sr = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\\GalaxySoftware\\wcatManager\\DataLists\\Settings.xml");
                settings = (Settings)serializer.Deserialize(sr);
                sr.Close();
                EnableAccuracyMenu.Checked = settings._AccuracyEnabled;
                ResultOnNewWindow.Checked = settings._ResultOnNewWindow;
            }
            else
            {

                sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\\GalaxySoftware\\wcatManager\\DataLists\\Settings.xml");
                settings.Save(EnableAccuracyMenu.Checked, ResultOnNewWindow.Checked);
                serializer.Serialize(sw, settings);
                sw.Close();
            }
            Timerfor4 = new Timer();
            Timerfor4.Tick += new EventHandler(timerfor4);
            DesidePlace = new Timer();
            DesidePlace.Tick += new EventHandler(place);
            Timer4Custom = new Timer();
            Timer4Custom.Tick += new EventHandler(custom);
            ConnectDB();
            LoadDefaultList(JobCmd, "SELECT Job FROM JobList", JobListBox, "Job", JobCon);
            LoadDefaultList(TypeCmd, "SELECT Type FROM TypeList", TypeListBox, "Type", TypeCon);
            LoadDefaultList(BindCmd, "SELECT Bind FROM SpecifiedBindList", SpecifiedListBox, "Bind", BindCon);
            RefreshMapList();
            RefreshCustomList();
            RefreshTeamList();
            for (int cnt = 0; cnt < JobListBox.Items.Count; cnt++)
            {
                JobListBox.SetItemChecked(cnt, true);
            }
            for (int cnt = 0; cnt < TypeListBox.Items.Count; cnt++)
            {
                TypeListBox.SetItemChecked(cnt, true);
            }
            for (int cnt = 0; cnt < RarityListBox.Items.Count; cnt++)
            {
                RarityListBox.SetItemChecked(cnt, true);
            }
            for (int cnt = 0; cnt < RareTypeListBox.Items.Count; cnt++)
            {
                RareTypeListBox.SetItemChecked(cnt, true);
            }
            for (int cnt = 0; cnt < AttributeListBox.Items.Count; cnt++)
            {
                AttributeListBox.SetItemChecked(cnt, true);
            }
            for (int cnt = 0; cnt < SortListBox.Items.Count; cnt++)
            {
                SortListBox.SetItemChecked(cnt, true);
            }
            for (int cnt = 0; cnt < SpecifiedListBox.Items.Count; cnt++)
            {
                SpecifiedListBox.SetItemChecked(cnt, true);
            }
        }
        private void wcatmanager_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConnectionClose();
        }
        //接続
        private void ConnectDB()
        {
            if (System.IO.File.Exists(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\\GalaxySoftware\\wcatManager\\DataLists\\PlayerList.db"))
            {
                TeamCon = new SQLiteConnection(TeamDBPath);
                TeamCon.Open();
                TeamCmd = TeamCon.CreateCommand();
            }
            else
            {
                TeamCon = new SQLiteConnection(TeamDBPath);
                TeamCon.Open();
                TeamCmd = TeamCon.CreateCommand();
                TeamCmd.CommandText = "CREATE TABLE PlayerList (id integer primary key, Player varchar)";
                TeamCmd.ExecuteNonQuery();
            }
            if (System.IO.File.Exists(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\\GalaxySoftware\\wcatManager\\DataLists\\CustomList.db"))
            {
                CustomCon = new SQLiteConnection(CustomDBPath);
                CustomCon.Open();
                CustomCmd = CustomCon.CreateCommand();
            }
            else
            {
                CustomCon = new SQLiteConnection(CustomDBPath);
                CustomCon.Open();
                CustomCmd = CustomCon.CreateCommand();
                CustomCmd.CommandText = "CREATE TABLE CustomList (id integer primary key, Item varchar)";
                CustomCmd.ExecuteNonQuery();
            }
            BindCon = new SQLiteConnection("Data Source=" + @"DataLists\\SpecifiedBindList.db");
            BindCon.Open();
            BindCmd = BindCon.CreateCommand();
            JobCon = new SQLiteConnection("Data Source=" + @"DataLists\\JobList.db");
            JobCon.Open();
            JobCmd = JobCon.CreateCommand();
            TypeCon = new SQLiteConnection("Data Source=" + @"DataLists\\TypeList.db");
            TypeCon.Open();
            TypeCmd = TypeCon.CreateCommand();
            MapCon = new SQLiteConnection("Data Source=" + @"DataLists\\MapList.db");
            MapCon.Open();
            MapCmd = MapCon.CreateCommand();

        }
        private void LoadDefaultList(SQLiteCommand cmd, string str, ListBox list, string column, SQLiteConnection con)
        {
            cmd.CommandText = str;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Items.Add(reader[column].ToString());
            }
            reader.Close();
            con.Close();
        }
        private void RefreshMapList()
        {
            MapCmd.CommandText = "SELECT Difficulty, Map FROM MapList order by Difficulty desc, id desc";
            reader = MapCmd.ExecuteReader();
            while (reader.Read())
            {
                MapListBox.Items.Add("☆" + reader["Difficulty"].ToString() + " " + reader["Map"].ToString());
            }
            reader.Close();
            MapCon.Close();
        }
        private void RefreshCustomList()
        {
            CustomListBox.Items.Clear();
            CustomCmd.CommandText = "SELECT Item FROM CustomList";
            reader = CustomCmd.ExecuteReader();
            while (reader.Read())
            {
                CustomListBox.Items.Add(reader["Item"].ToString());
            }
            reader.Close();
        }
        private void RefreshTeamList()
        {
            PlayerListBox.Items.Clear();
            TeamCmd.CommandText = "SELECT Player FROM PlayerList";
            reader = TeamCmd.ExecuteReader();
            while (reader.Read())
            {
                PlayerListBox.Items.Add(reader["Player"].ToString());
            }
            reader.Close();
        }
        private void ConnectionClose()
        {
            CustomCon.Close();
            TeamCon.Close();
        }
        private void AddTeamRecord(string obj)
        {
            TeamCmd.CommandText = "SELECT COUNT(Player) FROM PlayerList WHERE Player = '" + obj + "'";
            long i = (long)TeamCmd.ExecuteScalar();
            if (i == 0)
            {
                TeamCmd.CommandText = "INSERT INTO PlayerList (Player) VALUES ('" + obj + "')";
                TeamCmd.ExecuteNonQuery();
                PlayerListBox.Items.Add(AdderTextBox.Text);
                AdderTextBox.Text = "";
            }
            else
            {
                MessageBox.Show("既に追加されているプレイヤーです。");
            }
        }
        private void RemoveTeamRecord(string obj)
        {
            TeamCmd.CommandText = "DELETE FROM PlayerList WHERE Player = '" + obj + "'";
            TeamCmd.ExecuteNonQuery();
            RefreshTeamList();
        }
        private void AddCustomRecord(string obj)
        {
            CustomCmd.CommandText = "SELECT COUNT(Item) FROM CustomList WHERE Item = '" + obj + "'";
            long i = (long)CustomCmd.ExecuteScalar();
            if (i == 0)
            {
                CustomCmd.CommandText = "INSERT INTO CustomList (Item) VALUES ('" + obj + "')";
                CustomCmd.ExecuteNonQuery();
                CustomListBox.Items.Add(CustomAdderText.Text);
                CustomAdderText.Text = "";
            }
            else
            {
                MessageBox.Show("既に追加されている要素です。");
            }
        }
        private void RemoveCustomRecord(string obj)
        {
            CustomCmd.CommandText = "DELETE FROM CustomList WHERE Item = '" + obj + "'";
            CustomCmd.ExecuteNonQuery();
            RefreshCustomList();
        }
        public void set_back(Label person, string job)
        {
            switch (job)
            {
                case "剣士":
                    person.ForeColor = Color.Red;
                    break;
                case "ランサー":
                    person.ForeColor = Color.Lime;
                    break;
                case "ウォリアー":
                    person.ForeColor = Color.Blue;
                    break;
                case "武道家":
                    person.ForeColor = Color.Orange;
                    break;
                case "アーチャー":
                    person.ForeColor = Color.Chocolate;
                    break;
                case "魔道士":
                    person.ForeColor = Color.Fuchsia;
                    break;
                case "クロスセイバー":
                    person.ForeColor = Color.FromArgb(255, 128, 128);
                    break;
                case "ドラゴンライダー":
                    person.ForeColor = Color.Aqua;
                    break;
                case "ヴァリアント":
                    person.ForeColor = Color.FromArgb(128, 255, 128);
                    break;
            }
        }
        private void Generate4_Click(object sender, EventArgs e)
        {
            FirstPlayer.Text = "";
            SecondPlayer.Text = "";
            ThirdPlayer.Text = "";
            FourthPlayer.Text = "";
            FirstPlayer.ForeColor = Color.Black;
            SecondPlayer.ForeColor = Color.Black;
            ThirdPlayer.ForeColor = Color.Black;
            FourthPlayer.ForeColor = Color.Black;
            Players = (int)this.NumberOfPlayer.Value;
            string ErrorMsg = SetConditions();
            if (!Error)
            {
                if (ResultOnNewWindow.Checked)
                {
                    OtherWindow();
                    Timerfor4.Start();
                    ResultObj.Show(this); // 子ﾌｫｰﾑを表示
                }
                else
                {
                    SettingStatus(false);
                    One = FirstPlayer;
                    Two = SecondPlayer;
                    Three = ThirdPlayer;
                    Four = FourthPlayer;
                    Timerfor4.Start();
                }
            }
            else
            {
                MessageBox.Show(ErrorMsg, "", MessageBoxButtons.OK);
                Error = false;
            }
        }
        public void OtherWindow()
        {
            One = ResultObj.FirstPlayer;
            Two = ResultObj.SecondPlayer;
            Three = ResultObj.ThirdPlayer;
            Four = ResultObj.FourthPlayer;
        }
        public string SetConditions()
        {
            string ErrorMsg = null;
            if (JobEnabled.Checked)
            {
                JobList.Clear();
                for (int i = 0; i <= (JobListBox.Items.Count - 1); i++)
                {
                    if (JobListBox.GetItemChecked(i))
                    {
                        JobList.Add(JobListBox.Items[i].ToString());
                    }
                }
                if (JobList.Count != 0)
                {
                    if (OneJobOnly.Checked)
                    {
                        job = Convert.ToString((string)JobList[random.Next(0, JobList.Count)]);
                    }
                    if (JobList.Count < 4 && JobExistFalse.Checked)
                    {
                        Error = true;
                        ErrorMsg += ("職業を被らせない設定は選択している職業数が4つ以上である必要があります。\n");
                    }
                }
                else
                {
                    Error = true;
                    ErrorMsg += ("職業が選択されていません。\n");
                }
            }
            if (TypeEnabled.Checked)
            {
                TypeList.Clear();
                for (int i = 0; i <= (TypeListBox.Items.Count - 1); i++)
                {
                    if (TypeListBox.GetItemChecked(i))
                    {
                        TypeList.Add(TypeListBox.Items[i].ToString());
                    }
                }
                if (TypeList.Count != 0)
                {
                    if (OneTypeOnly.Checked)
                    {
                        type = Convert.ToString((string)TypeList[random.Next(0, TypeList.Count)]);
                    }
                    if (TypeList.Count < 4 && TypeExistFalse.Checked)
                    {
                        Error = true;
                        ErrorMsg += ("タイプを被らせない設定は選択しているタイプ数が4つ以上である必要があります。\n");
                    }
                }
                else
                {
                    Error = true;
                    ErrorMsg += ("タイプが選択されていません。\n");
                }
            }
            if (RarityEnabled.Checked)
            {
                RareList.Clear();
                if (UseRarity.Checked)
                {
                    for (int i = 0; i <= (RarityListBox.Items.Count - 1); i++)
                    {
                        if (RarityListBox.GetItemChecked(i))
                        {
                            RareList.Add(RarityListBox.Items[i].ToString());
                        }
                    }
                    TRResult.Text = "";
                    if (RareList.Count == 0)
                    {
                        Error = true;
                        ErrorMsg += ("レアリティが選択されていません。\n");
                    }
                }
                if (UseTotalRarity.Checked)
                {
                    TRResult.Text = "レアリティ合計値：" + random.Next((int)TRMinimum.Value, (int)TRMax.Value);
                }
            }
            if (RareTypeEnabled.Checked)
            {
                RareTypeList.Clear();
                for (int i = 0; i <= (RareTypeListBox.Items.Count - 1); i++)
                {
                    if (RareTypeListBox.GetItemChecked(i))
                    {
                        RareTypeList.Add(RareTypeListBox.Items[i].ToString());
                    }
                }
                if (RareTypeList.Count != 0)
                {
                    if (OneRareTypeOnly.Checked)
                    {
                        raretype = Convert.ToString((string)RareTypeList[random.Next(0, RareTypeList.Count)]);
                    }
                }
                else
                {
                    Error = true;
                    ErrorMsg += ("種類が選択されていません。\n");
                }
            }
            if (AttributeEnabled.Checked)
            {
                AttributeList.Clear();
                for (int i = 0; i <= (AttributeListBox.Items.Count - 1); i++)
                {
                    if (AttributeListBox.GetItemChecked(i))
                    {
                        AttributeList.Add(AttributeListBox.Items[i].ToString());
                    }
                }
                if (AttributeList.Count != 0)
                {
                    attribute = Convert.ToString((string)AttributeList[random.Next(0, AttributeList.Count)]);
                }
                else
                {
                    Error = true;
                    ErrorMsg += ("属性が選択されていません。\n");
                }
            }
            if (!JobEnabled.Checked && !TypeEnabled.Checked && !RarityEnabled.Checked && !RareTypeEnabled.Checked && !AttributeEnabled.Checked)
            {
                Error = true;
                ErrorMsg += ("有効になっている条件がありません。");
            }
            return ErrorMsg;
        }
        public void SettingStatus(Boolean status)
        {
            ConditionTab.Enabled = status;
            Generate4.Enabled = status;
        }
        public string ChooseJob()
        {
            if (JobEnabled.Checked)
            {
                if (!OneJobOnly.Checked)
                {
                    job = Convert.ToString((string)JobList[random.Next(0, JobList.Count)]);
                    if (JobExistFalse.Checked && !EnableAccuracyMenu.Checked)
                    {
                        JobList.Remove(job);
                    }
                }
                if (EnableAccuracyMenu.Checked)
                {
                    sql += "Job='" + job + "' ";
                }
            }
            else
            {
                job = "";
            }
            return job;
        }
        public string ChooseType()
        {
            if (TypeEnabled.Checked)
            {
                if (!OneTypeOnly.Checked)
                {
                    type = Convert.ToString((string)TypeList[random.Next(0, TypeList.Count)]);
                    if (TypeExistFalse.Checked && !EnableAccuracyMenu.Checked)
                    {
                        TypeList.Remove(type);
                    }
                }
                if (EnableAccuracyMenu.Checked)
                {
                    if (sql != "")
                    {
                        sql += "and Type='" + type + "' ";
                    }
                    else
                    {
                        sql += "Type='" + type + "' ";
                    }
                }
            }
            else
            {
                type = "";
            }
            return type;
        }
        public string ChooseRarity()
        {
            if (RarityEnabled.Checked)
            {
                if (UseRarity.Checked)
                {
                    rarity = Convert.ToString((string)RareList[random.Next(0, RareList.Count)]);
                    rarity = rarity.Replace("☆", "");
                }
                else
                {
                    rarity = "";
                }
                if (EnableAccuracyMenu.Checked)
                {
                    if (sql != "")
                    {
                        sql += "and Rarity='" + rarity + "' ";
                    }
                    else
                    {
                        sql += "Rarity='" + rarity + "' ";
                    }
                }
            }
            else
            {
                rarity = "";
            }
            return rarity;
        }
        public string ChooseRareType()
        {
            if (RareTypeEnabled.Checked)
            {
                if (!OneRareTypeOnly.Checked)
                {
                    raretype = Convert.ToString((string)RareTypeList[random.Next(0, RareTypeList.Count)]);
                }
                if (EnableAccuracyMenu.Checked)
                {

                    if (sql != "")
                    {
                        sql += "and RareType='" + raretype + "' ";
                    }
                    else
                    {
                        sql += "RareType='" + raretype + "' ";
                    }
                }
            }
            else
            {
                raretype = "";
            }
            return raretype;
        }
        public string ChooseAttribute()
        {
            if (AttributeEnabled.Checked)
            {
                attribute = Convert.ToString((string)AttributeList[random.Next(0, AttributeList.Count)]);
                if (EnableAccuracyMenu.Checked)
                {

                    if (sql != "")
                    {
                        sql += "and Attribute='" + attribute + "' ";
                    }
                    else
                    {
                        sql += "Attribute='" + attribute + "' ";
                    }
                }
            }
            else
            {
                attribute = "";
            }
            return attribute;
        }
        void timerfor4(object sender, EventArgs e)
        {
            Timer4cnt++;
            if (Timer4cnt < 10)
            {
                str += ". ";
                One.Text = str;
                if (Players >= 2)
                {
                    Two.Text = str;
                }
                if (Players >= 3)
                {
                    Three.Text = str;
                }
                if (Players >= 4)
                {
                    Four.Text = str;
                    //Four.Text = Convert.ToString((string)JobList[random.Next(0, JobList.Count)]);
                }
                LoadCnt++;
                if (LoadCnt == 3)
                {
                    str = null;
                    LoadCnt = 0;
                }
            }
            switch (Timer4cnt)
            {
                case 1:
                    Timerfor4.Interval = 100;
                    break;
                case 10:
                    UpdateLabel(One, 1);
                    break;
                case 11:
                    UpdateLabel(Two, 2);
                    break;
                case 12:
                    UpdateLabel(Three, 3);
                    break;
                case 13:
                    UpdateLabel(Four, 4);
                    break;
            }
        }
        public void UpdateLabel(Label JobLabel, int player)
        {
            if (player <= Players)
            {
                int loop = 0, r = 0;
                string Job = null, Type = null, Rarity = null, RareType = null, Attribute = null;
                if (EnableAccuracyMenu.Checked)
                {
                    while (loop < 10000)
                    {
                        Job = ChooseJob(); Type = ChooseType(); Rarity = ChooseRarity(); RareType = ChooseRareType(); Attribute = ChooseAttribute();
                        CharaCmd.CommandText = "SELECT count(Name) FROM CharacterList where " + sql;
                        sql = "";
                        loop++;
                        if ((long)CharaCmd.ExecuteScalar() > 0)
                        {
                            r = 1;
                            break;
                        }
                    }
                    if (r == 1)
                    {
                        if (JobExistFalse.Checked)
                        {
                            JobList.Remove(Job);
                        }
                        if (TypeExistFalse.Checked)
                        {
                            TypeList.Remove(Type);
                        }
                    }
                }
                else
                {
                    r = 1;
                    RareType = ChooseRareType(); Type = ChooseType(); Rarity = ChooseRarity(); Job = ChooseJob(); Attribute = ChooseAttribute();
                }
                if (RarityEnabled.Checked && !UseTotalRarity.Checked)
                {
                    Rarity = Rarity.Insert(0, "☆");
                }
                if (r == 1)
                {
                    JobLabel.Text = RareType + " " + Rarity + Job + "\r\n" + Type + " " + Attribute;
                    set_back(JobLabel, Job);
                } else
                {
                    JobLabel.Text = "生成失敗";
                }
            }
            if (player == Players)
            {
                Timerfor4.Stop();
                Timer4cnt = 0;
                str = null;
                LoadCnt = 0;
                SettingStatus(true);
            }
        }
        private void GenerateSpecified_Click(object sender, EventArgs e)
        {
            if (SortEnabled.Checked)
            {
                if (AddSpecified(SortListBox))
                {
                    string order;
                    if (random.Next(0, 2) == 1)
                    {
                        order = "昇順";
                    }
                    else
                    {
                        order = "降順";
                    }
                    SpecifiedResult.Text = "ソート:" + Convert.ToString((string)SortList[random.Next(0, SortList.Count)]) + " 行:" + random.Next(1, 4) + " 列:" + random.Next(1, 6) + " ページ:" + random.Next(1, 10) + "(ない場合は最後のページ) " + order;
                    SortList.Clear();
                }
            }
            if (UseSpecified.Checked)
            {
                if (AddSpecified(SpecifiedListBox))
                {
                    SpecifiedResult.Text = Convert.ToString((string)SortList[random.Next(0, SortList.Count)]);
                    SortList.Clear();
                }
            }
        }
        public Boolean AddSpecified(CheckedListBox List)
        {
            int cnt = 0;
            for (int i = 0; i <= (List.Items.Count - 1); i++)
            {
                if (List.GetItemChecked(i))
                {
                    cnt = (i + 1);
                }
            }
            if (cnt >= 2)
            {
                for (i = 0; i <= (List.Items.Count - 1); i++)
                {
                    if (List.GetItemChecked(i))
                    {
                        SortList.Add(List.Items[i].ToString());
                    }
                }
                return true;
            }
            else
            {
                MessageBox.Show("2つ以上の選択が必要", "Error");
                return false;
            }
        }
        private void GeneratePlace_Click(object sender, EventArgs e)
        {
            Place.ForeColor = Color.Black;
            int cnt = 0;
            for (int i = 0; i <= (MapListBox.Items.Count - 1); i++)
            {
                if (MapListBox.GetItemChecked(i))
                {
                    cnt = (i + 1);
                }
            }
            if (cnt >= 2)
            {
                for (i = 0; i <= (MapListBox.Items.Count - 1); i++)
                {
                    if (MapListBox.GetItemChecked(i))
                    {
                        MapList.Add(MapListBox.Items[i].ToString());
                    }
                }
                result = Convert.ToString((string)MapList[random.Next(0, MapList.Count)]);
                DesidePlace.Start();
            }
            else
            {
                MessageBox.Show("2つ以上の選択が必要", "Error");
            }
        }
        void Selector(Label Label, ArrayList List, int Val, Timer timer)
        {
            i++;
            Label.Text = Convert.ToString((string)List[random.Next(0, Val)]);
            switch (i)
            {
                case 1:
                    timer.Interval = 50;
                    break;
                case 10:
                    timer.Interval = 300;
                    break;
                case 15:
                    Label.Text = result;
                    Label.ForeColor = Color.Red;
                    break;
                case 16:
                    Label.Text = "";
                    break;
                case 17:
                    Label.Text = result;
                    break;
                case 18:
                    Label.Text = "";
                    break;
                case 19:
                    timer.Stop();
                    Label.Text = result;
                    i = 0;
                    List.Clear();
                    break;
            }
        }
        private void EnableAccuracyMenu_Click(object sender, EventArgs e)
        {
            if (EnableAccuracyMenu.Checked)
            {
                CharaCon = new SQLiteConnection("Data Source=" + @"DataLists\\CharacterList.db");
                CharaCon.Open();
                CharaCmd = CharaCon.CreateCommand();
                UseTotalRarity.Enabled = false;
                UseTotalRarity.Checked = false;
                OneJobOnly.Enabled = false;
                OneJobOnly.Checked = false;
                OneTypeOnly.Enabled = false;
                OneTypeOnly.Checked = false;
                OneRareTypeOnly.Enabled = false;
                OneRareTypeOnly.Checked = false;
            }
            else
            {
                CharaCon.Close();
                UseTotalRarity.Enabled = true;
                OneJobOnly.Enabled = true;
                OneTypeOnly.Enabled = true;
                OneRareTypeOnly.Enabled = true;
            }
            sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\\GalaxySoftware\\wcatManager\\DataLists\\Settings.xml");
            settings.AccuracyEnabled = EnableAccuracyMenu.Checked;
            serializer.Serialize(sw, settings);
            sw.Close();
        }
        private void ResultOnNewWindow_Click(object sender, EventArgs e)
        {
            sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\\GalaxySoftware\\wcatManager\\DataLists\\Settings.xml");
            settings.ResultOnNewWindow = ResultOnNewWindow.Checked;
            serializer.Serialize(sw, settings);
            sw.Close();
        }
        private void GenerateOneMenuItem_Click(object sender, EventArgs e)
        {
            GenerateForAPlayer one = new GenerateForAPlayer();
            one.Show(this);
        }
        private void DefaultDataMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("wcatBasicEditer.exe");
        }

        private void wcatCharaMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("wcatCharaDBEditer.exe");
        }

        private void DataDLEditMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://1drv.ms/f/s!AkKl3pyfM6zdh6k_5CK09JG8Od_xbg");
        }

        private void Job_Exist_False_CheckedChanged(object sender, EventArgs e)
        {
            if (JobExistFalse.Checked)
            {
                OneJobOnly.Checked = false;
            }
        }

        private void OneJobOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (OneJobOnly.Checked)
            {
                JobExistFalse.Checked = false;
            }
        }
        private void TypeExistFalse_CheckedChanged(object sender, EventArgs e)
        {
            if (TypeExistFalse.Checked)
            {
                OneTypeOnly.Checked = false;
            }
        }

        private void OneTypeOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (OneTypeOnly.Checked)
            {
                TypeExistFalse.Checked = false;
            }
        }
        void place(object sender, EventArgs e)
        {
            Selector(Place, MapList, MapList.Count, DesidePlace);
        }
        void Change_Generate_Status()
        {
            if (!JobEnabled.Checked && !TypeEnabled.Checked && !RarityEnabled.Checked && !RareTypeEnabled.Checked)
            {
                Generate4.Enabled = false;
            }
            else
            {
                Generate4.Enabled = true;
            }
        }

        private void JobEnabled_CheckedChanged(object sender, EventArgs e)
        {
            Change_Generate_Status();
            SelectorStatus(JobEnabled, JobTab);
            JobEnabled.Enabled = true;
        }
        private void TypeEnabled_CheckedChanged(object sender, EventArgs e)
        {
            Change_Generate_Status();
            SelectorStatus(TypeEnabled, TypeTab);
        }
        private void SortEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (SortEnabled.Checked)
            {
                JobEnabled.Enabled = false;
                TypeEnabled.Enabled = false;
                RarityEnabled.Enabled = false;
                RareTypeEnabled.Enabled = false;
                JobEnabled.Checked = false;
                TypeEnabled.Checked = false;
                RarityEnabled.Checked = false;
                RareTypeEnabled.Checked = false;
            }
            else
            {
                JobEnabled.Enabled = true;
                TypeEnabled.Enabled = true;
                RarityEnabled.Enabled = true;
                RareTypeEnabled.Enabled = true;
            }
            Change_Generate_Status();
        }
        private void RarityEnabled_CheckedChanged(object sender, EventArgs e)
        {
            Change_Generate_Status();
            SelectorStatus(RarityEnabled, RarityTab);
        }
        private void RareTypeEnabled_CheckedChanged(object sender, EventArgs e)
        {
            Change_Generate_Status();
            SelectorStatus(RareTypeEnabled, RareTypeTab);
        }
        void SelectorStatus(CheckBox box, TabPage Tab)
        {
            if (box.Checked)
            {
                Tab.Enabled = true;
            }
            else
            {
                Tab.Enabled = false;
            }
        }
        private void CustomGenerate_Click(object sender, EventArgs e)
        {
            CustomResault.ForeColor = Color.Black;
            int cnt = 0;
            for (int i = 0; i <= (CustomListBox.Items.Count - 1); i++)
            {
                if (CustomListBox.GetItemChecked(i))
                {
                    cnt = (i + 1);
                }
            }
            if (cnt >= 2)
            {
                for (i = 0; i <= (CustomListBox.Items.Count - 1); i++)
                {
                    if (CustomListBox.GetItemChecked(i))
                    {
                        CustomList.Add(CustomListBox.Items[i].ToString());
                    }
                }
                result = Convert.ToString((string)CustomList[random.Next(0, CustomList.Count)]);
                Timer4Custom.Start();
            }
            else
            {
                MessageBox.Show("2つ以上の登録が必要", "Error");
            }
        }
        void custom(object sender, EventArgs e)
        {
            Selector(CustomResault, CustomList, CustomList.Count, Timer4Custom);
        }
        private void CustomAdder_Click(object sender, EventArgs e)
        {
            if (CustomAdderText.Text != "")
            {
                AddCustomRecord(CustomAdderText.Text);
            }
        }
        private void SeparateStart_Click(object sender, EventArgs e)
        {
            int cnt = 0;
            for (int i = 0; i <= (PlayerListBox.Items.Count - 1); i++)
            {
                if (PlayerListBox.GetItemChecked(i))
                {
                    cnt = (i + 1);
                }
            }
            if (cnt < 5 || cnt > 16)
            {
                MessageBox.Show("5～16人を選択して下さい", "", MessageBoxButtons.OK);
            }
            else
            {
                for (i = 0; i <= (PlayerListBox.Items.Count - 1); i++)
                {
                    if (PlayerListBox.GetItemChecked(i))
                    {
                        PlayerList.Add(PlayerListBox.Items[i].ToString());
                    }
                }
                if (PlayerList.Count % 4 != 0)
                {
                    for (int i = 0; i <= PlayerList.Count % 4; i++)
                    {
                        PlayerList.Add("×");
                    }
                }
                Separator(TeamA, TAMembers);
                Separator(TeamB, TBMembers);
                if (PlayerList.Count != 0)
                {
                    Separator(TeamC, TCMembers);
                }
                if (PlayerList.Count != 0)
                {
                    Separator(TeamD, TDMembers);
                }
            }
        }
        void Separator(ArrayList Team, Label Members)
        {
            for (int i = 0; i <= 3; i++)
            {
                string player = Convert.ToString((string)PlayerList[random.Next(0, PlayerList.Count)]);
                Team.Add(player);
                PlayerList.Remove(player);
            }
            Members.Text = (string)Team[0] + ',' + (string)Team[1] + ',' + (string)Team[2] + ',' + (string)Team[3];
            Team.Clear();
        }
        private void PlayerAddButton_Click(object sender, EventArgs e)
        {
            if (AdderTextBox.Text != "")
            {
                AddTeamRecord(AdderTextBox.Text);
            }
        }
        private void 開発者ページToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/GalaxyDGamer");
        }
        private void ダウンロードページMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://1drv.ms/f/s!AkKl3pyfM6zdkUsuB5YqgBwzblzk");
        }
        private void 説明書ライセンスToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File = @"Readme.txt";
            TextViewer VW = new TextViewer();
            VW.Show(this);
        }
        private void 設定フォルダMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\\GalaxySoftware\\wcatManager\\DataLists");
        }
        private void 終了MenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            /*string s;
            s = "Checked items:\n";
            for (i = 0; i <= (PlayerListBox.Items.Count - 1); i++)
            {
                if (PlayerListBox.GetItemChecked(i))
                {
                    s = s + "Item " + (i + 1).ToString() + " = " + PlayerListBox.Items[i].ToString() + "\n";
                }
            }
            MessageBox.Show(s);*/
        }
        private void DeletePlayer_Click(object sender, EventArgs e)
        {
            for (i = 0; i <= (PlayerListBox.Items.Count - 1); i++)
            {
                if (PlayerListBox.GetItemChecked(i))
                {
                    RemoveTeamRecord(PlayerListBox.Items[i].ToString());
                }
            }
            RefreshTeamList();
        }
        private void SelectAllPlayer_Click(object sender, EventArgs e)
        {
            for (int cnt = 0; cnt < PlayerListBox.Items.Count; cnt++)
            {
                PlayerListBox.SetItemChecked(cnt, true);
            }
        }
        private void UncheckAllPlayer_Click(object sender, EventArgs e)
        {
            for (int cnt = 0; cnt < PlayerListBox.Items.Count; cnt++)
            {
                PlayerListBox.SetItemChecked(cnt, false);
            }
        }
        private void DeleteCustom_Click(object sender, EventArgs e)
        {
            for (i = 0; i <= (CustomListBox.Items.Count - 1); i++)
            {
                if (CustomListBox.GetItemChecked(i))
                {
                    RemoveCustomRecord(CustomListBox.Items[i].ToString());
                }
            }
            RefreshCustomList();
        }
        private void SelectAllCustom_Click(object sender, EventArgs e)
        {
            for (int cnt = 0; cnt < CustomListBox.Items.Count; cnt++)
            {
                CustomListBox.SetItemChecked(cnt, true);
            }
        }
        private void UncheckAllCustom_Click(object sender, EventArgs e)
        {
            for (int cnt = 0; cnt < CustomListBox.Items.Count; cnt++)
            {
                CustomListBox.SetItemChecked(cnt, false);
            }
        }
    }
}