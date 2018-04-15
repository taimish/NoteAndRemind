using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace NoteAndRemind
{
    public partial class MainProgForm : Form
    {

        //// SOME VARS
        // DATASETS FOR MANAGING DATA
        //private DataSet AllDataSet = null;
        private SQLiteConnection myConnection = new SQLiteConnection("Data Source=NoteAndRemind.db;");

        // NAME OF TOPIC CURRENTLY LISTED
        private string currentListedTopic = "";

        // ID OF NOTE CURRENTLY LISTED
        private int currentDisplayedNote = -1;

        // SOME BOOLS
        private bool actualJobsShowed;

        // ADDITION VARIABLES
        private DateTime beginOfEra = DateTime.Parse("01.01.0001");
        private DateTime previousTick = DateTime.Now.Date;

        // CREATING SYSTEM TRAY ICON
        private NotifyIcon thisFormIcon = new NotifyIcon();

        // CREATING HOUR TIMER
        private Timer remindTimer = new Timer();

        public MainProgForm()
        {
            InitializeComponent();
            
            // FORM STYLING
            //this.BackColor = Color.FromKnownColor(KnownColor.White);

            // INITIALIZING TRAY ICON
            thisFormIcon.Icon = new Icon("NoteAndRemind.ico");
            thisFormIcon.Visible = true;
            thisFormIcon.Text = "Note and Remind V 1";
            thisFormIcon.DoubleClick += new System.EventHandler(this.thisFormIcon_DoubleClick);

            // INITIALIZING TIMER
            remindTimer.Interval = 3600000;
            remindTimer.Enabled = true;
            remindTimer.Tick += new EventHandler(remindTimer_Tick);
        }

        /// <summary>
        /// LOADING MAIN FORM WITH INITIAL LOADING AND SHOWING OF ALL DATA FROM XML FILES
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // COLOR MANAGING
            /*MainHorizontalSplitcontainer.Panel2.BackColor = Color.FromArgb(255, 247, 247);
            LeftVerticalSplitcontainer.Panel1.BackColor = Color.FromArgb(247, 255, 247);
            LeftVerticalSplitcontainer.Panel2.BackColor = Color.FromArgb(247, 247, 255);
            FormControlPanel.BackColor = Color.FromArgb(200, 215, 215);
            ShowOldOrNewButton.BackColor = Color.FromArgb(160, 200, 160);
            DeleteJobsButton.BackColor = Color.FromArgb(160, 200, 160);
            AddJobButton.BackColor = Color.FromArgb(160, 200, 160);
            BirthdayDeleteButton.BackColor = Color.FromArgb(160, 160, 200);
            AddNewBirthdayButton.BackColor = Color.FromArgb(160, 160, 200);
            DeleteHeaderButton.BackColor = Color.FromArgb(200, 160, 160);
            SaveNoteButton.BackColor = Color.FromArgb(200, 160, 160);
            NewNoteButton.BackColor = Color.FromArgb(200, 160, 160);
            TopicChangeButton.BackColor = Color.FromArgb(200, 160, 160);*/

            /// CHECKING IF THE APPLICATION SHOULD START MINIMIZED (NO URGET JOBS OR BIRTHDAYS)
            bool urgentEvents = false;

            // CHECKING URGENCY
            using (NARContext tmpNARContext = new NARContext(myConnection))
            {
                /*
                public int Id { get; set; }
                public DateTime Date { get; set; }
                public string Text { get; set; }
                */
                tmpNARContext.Database.ExecuteSqlCommand("CREATE TABLE IF NOT EXISTS Jobs (`Id` INTEGER PRIMARY KEY AUTOINCREMENT, Date DATETIME , Text TEXT)");
                /*
                public int Id { get; set; }
                public string Name { get; set; }
                public int Year { get; set; }
                public byte Month { get; set; }
                public byte Day { get; set; }
                */
                tmpNARContext.Database.ExecuteSqlCommand("CREATE TABLE IF NOT EXISTS 'Birthdays' (`Id` INTEGER PRIMARY KEY AUTOINCREMENT, 'Name' TEXT, 'Year' INT, 'Month' TINYINT, 'Day' TINYINT)");
                /*
                public int Id { get; set; }
                public string Topic { get; set; }
                public string Header { get; set; }
                public DateTime Date { get; set; }
                public string Text { get; set; }
                */
                tmpNARContext.Database.ExecuteSqlCommand("CREATE TABLE IF NOT EXISTS 'Notes' (`Id` INTEGER PRIMARY KEY AUTOINCREMENT, 'Topic' TEXT, 'Header' TEXT, 'Date' DATETIME , 'Text' TEXT)");
                tmpNARContext.SaveChanges();

                // CHECKING IF THERE ARE URGENT JOBS
                foreach (var Job in tmpNARContext.Jobs)
                {
                    int leftDays = (int)Math.Floor(Job.Date.Subtract(DateTime.Now.Date).TotalDays);
                    if ((leftDays >= 0) && (leftDays <= (int)ControlledDaysAmountUpdown.Value))
                    {
                        urgentEvents = true;
                        break;
                    }
                }

                // CHECKING IF THERE ARE URGENT BIRTHDAYS
                foreach (var Birthday in tmpNARContext.Birthdays)
                {
                    int leftDays = (int)Math.Floor(DateTime.MinValue.AddYears(DateTime.Now.Year - 1).AddMonths(Birthday.Month - 1).AddDays(Birthday.Day - 1).Subtract(DateTime.Now.Date).TotalDays);
                    if (leftDays < 0)
                        leftDays = (int)Math.Floor(DateTime.MinValue.AddYears(DateTime.Now.Year).AddMonths(Birthday.Month - 1).AddDays(Birthday.Day - 1).Subtract(DateTime.Now.Date).TotalDays);
                    if (leftDays <= (int)ControlledDaysAmountUpdown.Value)
                    {
                        urgentEvents = true;
                        break;
                    }
                }

                // INITIAL JOB PRINTING
                ShowActualJobs();

                // INITIAL BIRTHDAY PRINTING
                ShowBirthdays();

                // INITIAL NOTES PRINTING
                ShowTopics();
            }

            // IF FOUND NO URGENT EVENTS - MINIMIZE THE FORM
            if (!urgentEvents)
            {
                HideForm();
            }
        }




        // *****************************************************************************************************************************
        // *****************************************************************************************************************************
        // DATA SORTING AND PRINTING (JOBS, BIRTHDAYS, TOPICS, HEADERS, NOTE)
        // *****************************************************************************************************************************
        // *****************************************************************************************************************************



        /// <summary>
        /// SHOWING ACTUAL JOBS AS PANELS
        /// </summary>
        private void ShowActualJobs()
        {
            //// SHOWING ACTUAL JOBS
            actualJobsShowed = true;
            using (NARContext tmpNARContext = new NARContext(myConnection))
            {
                if (tmpNARContext.Jobs.Count() > 0)
                {
                    // RENAME OF BUTTON AND LABEL
                    AboutJobsLabel.Text = "Всего дел в будущем:";
                    ShowOldOrNewButton.Text = "ПОКАЗАТЬ СТАРЫЕ";
                    // DISPOSING ALL CREATED PANELS
                    JobPanelForPanels.Controls.Clear();

                    // SHOWING ACTUAL JOBS
                    int position = 2;
                    foreach (var Job in tmpNARContext.Jobs.Where(job => job.Date.Year * 366 + job.Date.Month * 31 + job.Date.Day >= DateTime.Now.Year * 366 + DateTime.Now.Month * 31 + DateTime.Now.Day).OrderBy(job => job.Date))
                    {
                        position = AddJobPanel(position, Job.Id, Job.Date, Job.Text);
                    }
                    JobsInFutureLabel.Text = JobPanelForPanels.Controls.Count.ToString();
                }
                else
                {
                    AboutJobsLabel.Text = "Нет записей о делах";
                    JobsInFutureLabel.Text = "";
                }
            }

        }

        

        /// <summary>
        /// SHOWING OLD JOBS AS PANELS
        /// </summary>
        private void ShowOldJobs()
        {
            //// SHOWING OLD JOBS
            actualJobsShowed = false;
            using (NARContext tmpNARContext = new NARContext(myConnection))
            {
                if (tmpNARContext.Jobs.Count() > 0)
                {
                    // RENAME OF BUTTON AND LABEL
                    AboutJobsLabel.Text = "Всего дел в прошлом:";
                    ShowOldOrNewButton.Text = "ПОКАЗАТЬ НОВЫЕ";
                    // DISPOSING ALL CREATED PANELS
                    JobPanelForPanels.Controls.Clear();

                    // SHOWING OLD JOBS
                    int position = 2;
                    foreach (var Job in tmpNARContext.Jobs.Where(job => job.Date.Year * 366 + job.Date.Month * 31 + job.Date.Day < DateTime.Now.Year * 366 + DateTime.Now.Month * 31 + DateTime.Now.Day).OrderByDescending(job => job.Date))
                    {
                        position = AddJobPanel(position, Job.Id, Job.Date, Job.Text);
                    }
                    JobsInFutureLabel.Text = JobPanelForPanels.Controls.Count.ToString();
                }
                else
                {
                    AboutJobsLabel.Text = "Нет записей о делах";
                    JobsInFutureLabel.Text = "";
                }
            }
        }



        /// <summary>
        /// SHOWING ALL BIRTHDAYS
        /// </summary>
        private void ShowBirthdays()
        {
            BirthdayPanelForPanels.Controls.Clear();
            // LOOKING IF THERE ARE BIRTHDAYS IN THE TABLE
            using (NARContext tmpNARContext = new NARContext(myConnection))
            {
                if (tmpNARContext.Birthdays.Count() > 0)
                {
                    //List<DataRow> BirthdaySelectedRows = (from birthday in AllDataSet.Tables["Birthdays"].AsEnumerable() select birthday).OrderBy(data => int.Parse(data["Month"].ToString()) * 32 + int.Parse(data["Day"].ToString())).ThenBy(data => data["Name"].ToString()).ToList();

                    int bdInWeek = 0;
                    int bdInMonth = 0;
                    int position = 2;

                    // PRINTING ALL FUTURE BIRTHDAYS IN THIS YEAR
                    foreach (var Birthday in tmpNARContext.Birthdays.
                        Where(bd => bd.Day + bd.Month * 32 >= DateTime.Now.Day + DateTime.Now.Month * 32).
                        OrderBy(bd => bd.Month * 32 + bd.Day).
                        ThenBy(bd => bd.Name) )
                    {
                        DateTime bdDay = DateTime.Parse(Birthday.Day.ToString() + "." + Birthday.Month.ToString() + "." + DateTime.Now.Year.ToString());

                        // CALCULATING AGE IF YEAR OF BIRTH IS KNOWN
                        int bdAge = -10;
                        if (Birthday.Year != -1)
                            bdAge = DateTime.Now.Year - Birthday.Year;

                        // PRINTING THE BIRTHDAY
                        position = AddBirthdayPanel(position,
                               Birthday.Id,
                               (int)Math.Ceiling(bdDay.Subtract(DateTime.Now).TotalDays),
                               Birthday.Name,
                               bdAge);

                        // CALCULATING BIRTHDAYS IN NEXT WEEK AND MONTH
                        if (bdDay.Subtract(DateTime.Now).Days <= 7)
                            bdInWeek++;
                        if (bdDay.Subtract(DateTime.Now).Days <= 30)
                            bdInMonth++;
                    }

                    // PRINTING FUTURE BIRTHDAY WHICH WILL COME NEXT YEAR ONLY
                    foreach (var Birthday in tmpNARContext.Birthdays.
                        Where(bd => bd.Day + bd.Month * 32 < DateTime.Now.Day + DateTime.Now.Month * 32).
                        OrderBy(bd => bd.Month * 32 + bd.Day).
                        ThenBy(bd => bd.Name))
                    {
                        DateTime bdDay = DateTime.Parse(Birthday.Day.ToString() + "." + Birthday.Month.ToString() + "." + DateTime.Now.Year.ToString());
                        bdDay = bdDay.AddYears(1);

                        // CALCULATING AGE IF YEAR OF BIRTH IS KNOWN
                        int bdAge = -10;
                        if (Birthday.Year != -1)
                            bdAge = DateTime.Now.Year - Birthday.Year + 1;

                        // PRINTING THE BIRTHDAY
                        position = AddBirthdayPanel(position,
                               Birthday.Id,
                               (int)Math.Ceiling(bdDay.Subtract(DateTime.Now).TotalDays),
                               Birthday.Name,
                               bdAge);

                        // CALCULATING BIRTHDAYS IN NEXT WEEK AND MONTH
                        if (bdDay.Subtract(DateTime.Now).Days <= 7)
                            bdInWeek++;
                        if (bdDay.Subtract(DateTime.Now).Days <= 30)
                            bdInMonth++;
                    }

                    AboutBirthdaysLabel.Text = "Дней рождений за следующие семь дней: " + bdInWeek.ToString() + ", за следующий месяц: " + bdInMonth.ToString();
                }
                else
                    AboutBirthdaysLabel.Text = "Нет записей о днях рождения";
            }
        }


        
        /// <summary>
        /// SHOWING ALL NOTE TOPICS
        /// </summary>
        private void ShowTopics()
        {
            //// SHOWING ALL TOPICS
            // DISPOSING ALL CREATED PANELS
            TopicPanelForPanels.Controls.Clear();

            using (NARContext tmpNARContext = new NARContext(myConnection))
            {
                if (tmpNARContext.Notes.Count() > 0)
                {
                    // GENERATING LIST OF TOPICS
                    List<string> topicsList = tmpNARContext.Notes.Select(note => note.Topic).Distinct().OrderBy(topic => topic).ToList();

                    // CLEARING TOPIC COMBOBOX STRING LIST
                    NoteTopicCombobox.Items.Clear();

                    // PRINTING TOPICS FROM GENERATED LIST
                    int position = 2;
                    foreach (var Topic in topicsList)
                    {
                        position = AddTopicPanel(position, topicsList.IndexOf(Topic), Topic);
                        NoteTopicCombobox.Items.Add(Topic);
                    }
                }
            }
        }


        /// <summary>
        /// SHOWING HEADER OF ALL NOTES OF SELECTED TOPIC
        /// </summary>
        private void ShowHeadersOfTopic()
        {
            // DISPOSING ALL CREATED PANELS
            HeaderPanelForPanels.Controls.Clear();
            if (currentListedTopic != "")
            {
                using (NARContext tmpNARContext = new NARContext(myConnection))
                {
                    //// SHOWING HEADERS OF ALL NOTES OF SELECTED TOPIC

                    int position = 2;
                    foreach (var Note in tmpNARContext.Notes.Where(note => note.Topic == currentListedTopic).OrderBy(note => note.Header))
                    {
                        position = AddHeaderPanel(position, Note.Id, Note.Date.ToString().Remove(10), Note.Header);
                    }
                }
            }
        }



        // *****************************************************************************************************************************
        // *****************************************************************************************************************************
        // DYNAMIC ELEMENT CREATION
        // *****************************************************************************************************************************
        // *****************************************************************************************************************************




        /// <summary>
        /// DYNAMICLY CREATING A JOB PANEL WITH A LABEL, A CHECKBOX AND A RICHTEXTBOX INSIDE, CONTAINING THE JOBS INFO
        /// </summary>
        /// <param name="ID">THE ID OF THE JOB DATARECORD FROM THE INITIAL TABLE, NUMBER FOR PANEL NAME</param>
        /// <param name="days">THE DAYS GAP OF THE JOB</param>
        /// <param name="text">THE TEXT OF THE JOB</param>
        private int AddJobPanel(int position, int ID, DateTime date, string text)
        {
            // CREATING NEW PANEL AS A PARENT FOR CHECKBOX, LABEL AND RICHTEXTBOX
            Panel newPNL = new Panel();
            newPNL.Name = ID.ToString();
            newPNL.BorderStyle = BorderStyle.FixedSingle;
            newPNL.AutoSize = false;
            newPNL.Width = 662;
            newPNL.Dock = DockStyle.None;
            //newPNL.Dock = DockStyle.Top;
            JobPanelForPanels.Controls.Add(newPNL);
            //newPNL.Parent = JobPanelForPanels;
            newPNL.Margin = new Padding(0, 0, 0, 0);
            newPNL.Location = new Point(4, position + 2);
            newPNL.TabStop = false;
            newPNL.TabIndex = 23;
            newPNL.BackColor = Color.FromArgb(247, 247, 247);

            // CREATING NEW CHECKBOX
            CheckBox newCHB = new CheckBox();
            newCHB.Text = "";
            newCHB.AutoSize = false;
            newCHB.Height = 42;
            newCHB.Width = 15;
            newCHB.CheckAlign = ContentAlignment.MiddleRight;
            newCHB.Parent = newPNL;
            newCHB.Checked = false;
            newCHB.Margin = new Padding(0, 0, 0, 0);
            newCHB.Location = new Point(4, 0);
            newCHB.Name = "JobsCHB" + ID.ToString();
            newCHB.TabStop = false;
            newCHB.TabIndex = 23;
            newCHB.BackColor = Color.FromArgb(247, 247, 247);

            // CREATING LABEL WITH DAYGAP NUMBER
            Label newLBL = new Label();
            newLBL.Name = "JobsLBL" + ID.ToString();
            newLBL.Location = new Point(19, 0);
            newLBL.Width = 80;
            int days = (int)Math.Ceiling(date.Subtract(DateTime.Now).TotalDays);
            
            // MAKING ANDING FOR LEFT DAY STRING
            string dayEndingStr = "";
            if ((Math.Abs(days) > 9) && (days.ToString().ElementAt(days.ToString().Length - 2) == '1'))
                dayEndingStr = " дней";
            else
                switch (Math.Abs(days%10))
                {
                    case 1:
                        dayEndingStr = " день";
                        break;
                    case 2:
                    case 3:
                    case 4:
                        dayEndingStr = " дня";
                        break;
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 0:
                        dayEndingStr = " дней";
                        break;
                }

            if (days >= 0)
            {
                if (days == 0)
                    newLBL.Text = "Сегодня";
                else
                    newLBL.Text = "Осталось:\n" + days.ToString() + dayEndingStr;

                if (days <= ControlledDaysAmountUpdown.Value)
                    newLBL.ForeColor = Color.FromKnownColor(KnownColor.Red);
                else
                    newLBL.ForeColor = Color.FromKnownColor(KnownColor.Green);
            }
            else
            {
                newLBL.Text = "Прошло:\n" + (-days).ToString() + dayEndingStr;

                newLBL.ForeColor = Color.FromKnownColor(KnownColor.DarkSlateGray);
            }
            newLBL.TextAlign = ContentAlignment.MiddleLeft;
            //newLBL.BackColor = Color.FromKnownColor(KnownColor.WhiteSmoke);
            newLBL.Parent = newPNL;
            newLBL.Margin = new Padding(0, 0, 0, 0);
            newLBL.BorderStyle = BorderStyle.None;
            newLBL.Font = new Font(FontFamily.GenericSansSerif, 10);
            newLBL.TabStop = false;
            newLBL.TabIndex = 23;
            newLBL.BackColor = Color.FromArgb(247, 247, 247);

            // CREATING RICHTEXTBOX
            RichTextBox newRTB = new RichTextBox();
            newRTB.Name = "JobsRTB" + ID.ToString();
            newRTB.Parent = newPNL;
            newRTB.BorderStyle = BorderStyle.None;
            newRTB.Margin = new Padding(0, 0, 0, 0);
            newRTB.Location = new Point(104, 0);
            newRTB.Width = 554;
            newRTB.Height = 42;
            newRTB.ScrollBars = RichTextBoxScrollBars.Vertical;
            newRTB.Font = new Font(FontFamily.GenericSansSerif, 10);
            newRTB.Text = "[" + date.Date.ToShortDateString() + "]   " + text;
            newRTB.ScrollBars = RichTextBoxScrollBars.None;
            newRTB.ReadOnly = true;
            newRTB.TabStop = false;
            newRTB.TabIndex = 23;
            newRTB.BackColor = Color.FromArgb(247, 247, 247);

            // RICH TEXT BOX HEIGHT MANAGEMENT
            if (newRTB.GetLineFromCharIndex(text.Length - 1) > 1)
                newRTB.Height = (newRTB.GetLineFromCharIndex(text.Length - 1) + 1) * newRTB.PreferredHeight;

            newLBL.Height = newRTB.Height;
            newCHB.Height = newRTB.Height;
            newPNL.Height = newRTB.Height + 2;

            return position + newPNL.Height + 4;

        }




        /// <summary>
        /// DYNAMICLY CREATING A BIRTHDAY PANEL WITH A CHECKBOX AND A LABEL INSIDE, CONTAINING THE BIRTHDAY INFO
        /// </summary>
        /// <param name="position">POSITION FOR PANEL</param>
        /// <param name="ID">THE ID OF RECORD - FOR PANEL NAME</param>
        /// <param name="days">NUMBER OF DAYS BEFORE THE BIRTHDAY</param>
        /// <param name="name">NAME OF B-DAY MAN</param>
        /// <param name="age">AGE THAT THE B-DAY MAN WILL BE</param>
        /// <returns></returns>
        private int AddBirthdayPanel(int position, int ID, int days, string name, int age)
        {
            // CREATING NEW PANEL AS A PARENT FOR CHECKBOX, LABEL AND RICHTEXTBOX
            Panel newPNL = new Panel();
            newPNL.Name = ID.ToString();
            newPNL.BorderStyle = BorderStyle.FixedSingle;
            newPNL.AutoSize = false;
            newPNL.Width = 662;
            newPNL.Height = 33;
            newPNL.Dock = DockStyle.None;
            newPNL.Parent = BirthdayPanelForPanels;
            newPNL.Margin = new Padding(0, 0, 0, 0);
            newPNL.Location = new Point(4, position + 2);
            newPNL.TabStop = false;
            newPNL.TabIndex = 23;
            newPNL.BackColor = Color.FromArgb(247, 247, 247);

            // CREATING NEW CHECKBOX
            CheckBox newCHB = new CheckBox();
            newCHB.Text = "";
            newCHB.AutoSize = false;
            newCHB.Height = 33;
            newCHB.Width = 15;
            newCHB.CheckAlign = ContentAlignment.MiddleRight;
            newCHB.Parent = newPNL;
            newCHB.Checked = false;
            newCHB.Margin = new Padding(0, 0, 0, 0);
            newCHB.Location = new Point(4, 0);
            newCHB.Name = "BirthdayCHB" + ID.ToString();
            newCHB.TabStop = false;
            newCHB.TabIndex = 23;
            newCHB.BackColor = Color.FromArgb(247, 247, 247);

            // CREATING LABEL WITH DAYGAP NUMBER
            Label newLBL = new Label();
            newLBL.Name = "BirthdayLBL" + ID.ToString();
            newLBL.Location = new Point(19, 3);
            newLBL.Width = 643;

            if (days == 0)
                newLBL.Text = "Сегодня день рождения: " + name;
            else
            {
                if ((Math.Abs(days) > 9) && (days.ToString().ElementAt(days.ToString().Length - 2) == '1'))
                    newLBL.Text = "Через " + days.ToString() + " дней";
                else
                    switch (Math.Abs(days%10))
                    {
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 0:
                            newLBL.Text = "Через " + days.ToString() + " дней";
                            break;
                        case 1:
                            newLBL.Text = "Через " + days.ToString() + " день";
                            break;
                        case 2:
                        case 3:
                        case 4:
                            newLBL.Text = "Через " + days.ToString() + " дня";
                            break;
                    }

                newLBL.Text += " (" + DateTime.Now.Date.AddDays(days).ToString().Remove(5) + ") будет день рождения: " + name;
            }

            // ADDING AGE INFO IF AVAILABLE
            if (age > 0)
                switch (age%10)
                {
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 0:
                        newLBL.Text += " (" + age.ToString() + " лет)";
                        break;
                    case 1:
                        newLBL.Text += " (" + age.ToString() + " год)";
                        break;
                    case 2:
                    case 3:
                    case 4:
                        newLBL.Text += " (" + age.ToString() + " года)";
                        break;
                }

            // MANAGING COLOR OF THE BD TEXT
            if (days <= ControlledDaysAmountUpdown.Value)
                newLBL.ForeColor = Color.FromKnownColor(KnownColor.Red);
            else
                newLBL.ForeColor = Color.FromKnownColor(KnownColor.Green);
            if (days > 30)
                newLBL.ForeColor = Color.FromKnownColor(KnownColor.DarkSlateGray);

            newLBL.TextAlign = ContentAlignment.MiddleLeft;
            newLBL.Parent = newPNL;
            newLBL.Margin = new Padding(0, 0, 0, 0);
            newLBL.BorderStyle = BorderStyle.None;
            newLBL.Font = new Font(FontFamily.GenericSansSerif, 10);
            newLBL.TabStop = false;
            newLBL.TabIndex = 23;
            newLBL.BackColor = Color.FromArgb(247, 247, 247);

            return position + newPNL.Height + 4;
        }



        /// <summary>
        /// DYNAMICLY CREATING A TOPIC LABEL WITH THE TOPIC
        /// </summary>
        /// <param name="position">INITIAL POSITION INSIDE PARENT PANEL</param>
        /// <param name="ID">ID FOR NAME</param>
        /// <param name="topic">CURRENTLY PRINTED TOPIC</param>
        /// <returns></returns>
        private int AddTopicPanel(int position, int ID, string topic)
        {
            // CREATING NEW LABEL
            Label newLBL = new Label();
            newLBL.Name = ID.ToString();
            newLBL.BorderStyle = BorderStyle.FixedSingle;
            newLBL.Margin = new Padding(0, 0, 0, 0);
            newLBL.Dock = DockStyle.None;
            newLBL.Width = 662;
            newLBL.Height = 24;
            newLBL.Parent = TopicPanelForPanels;
            newLBL.Location = new Point(4, position + 2);
            newLBL.Font = new Font(FontFamily.GenericSansSerif, 10);
            newLBL.AccessibleDescription = topic;
            if (topic.Length > 60)
                topic = topic.Remove(60) + "...";
            newLBL.Text = topic;
            newLBL.TabStop = false;
            newLBL.TabIndex = 23;
            newLBL.BackColor = Color.FromArgb(247, 247, 247);

            newLBL.Click += (sender, e) => NewLbl_Click(newLBL, EventArgs.Empty);

            return position + newLBL.Height + 4;
        }




        /// <summary>
        /// DYNAMICLY CREATING A HEADER LABEL WITH THE HEADER OF A NOTE
        /// </summary>
        /// <param name="position">INITIAL POSITION INSIDE PARENT PANEL</param>
        /// <param name="ID">ID FOR NAME</param>
        /// <param name="data">DATE OF THE NOTE</param>
        /// <param name="header">HEADER OF THE NOTE</param>
        /// <returns></returns>
        private int AddHeaderPanel(int position, int ID, string date, string header)
        {
            // CREATING NEW PANEL AS A PARENT FOR CHECKBOX AND TWO LABELS
            Panel newPNL = new Panel();
            newPNL.Name = ID.ToString();
            newPNL.BorderStyle = BorderStyle.FixedSingle;
            newPNL.AutoSize = false;
            newPNL.Width = 662;
            newPNL.Height = 33;
            newPNL.Dock = DockStyle.None;
            newPNL.Parent = HeaderPanelForPanels;
            newPNL.Margin = new Padding(0, 0, 0, 0);
            newPNL.Location = new Point(4, position + 2);
            newPNL.TabStop = false;
            newPNL.TabIndex = 23;
            newPNL.BackColor = Color.FromArgb(247, 247, 247);

            // CREATING NEW CHECKBOX
            CheckBox newCHB = new CheckBox();
            newCHB.Name = ID.ToString();
            newCHB.Text = "";
            newCHB.AutoSize = false;
            newCHB.Height = 33;
            newCHB.Width = 15;
            newCHB.CheckAlign = ContentAlignment.MiddleRight;
            newCHB.Parent = newPNL;
            newCHB.Checked = false;
            newCHB.Margin = new Padding(0, 0, 0, 0);
            newCHB.Location = new Point(4, 0);
            newCHB.TabStop = false;
            newCHB.TabIndex = 23;
            newCHB.Name = "HeaderCHB" + ID.ToString();

            // CREATING LABEL WITH DATE OF NOTE
            Label newLBL = new Label();
            newLBL.Name = "HeaderDateLBL" + ID.ToString();
            newLBL.Parent = newPNL;
            newLBL.Location = new Point(19, 0);
            newLBL.Width = 80;
            newLBL.Height = 33;
            newLBL.TextAlign = ContentAlignment.MiddleLeft;
            newLBL.Text = date;
            newLBL.ForeColor = Color.FromKnownColor(KnownColor.DarkGray);
            newLBL.Font = new Font(FontFamily.GenericSansSerif, 10);
            newLBL.TabStop = false;
            newLBL.TabIndex = 23;


            // CREATING LABEL WITH HEADER OF NOTE
            Label newLBL2 = new Label();
            newLBL2.Name = "HeaderLBL" + ID.ToString();
            newLBL2.AccessibleDescription = ID.ToString();
            newLBL2.Parent = newPNL;
            newLBL2.Location = new Point(109, 0);
            newLBL2.Width = 553;
            newLBL2.Height = 33;
            newLBL2.TextAlign = ContentAlignment.MiddleLeft;
            if (header.Length > 60)
                header = header.Remove(60) + "...";
            newLBL2.Text = header;
            newLBL2.Font = new Font(FontFamily.GenericSansSerif, 10);
            newLBL2.TabStop = false;
            newLBL2.TabIndex = 23;

            newLBL2.Click += (sender, e) => Header_Click(newLBL2, EventArgs.Empty);

            return position + newPNL.Height + 4;
        }





        // *****************************************************************************************************************************
        // *****************************************************************************************************************************
        // OTHER CALLED FUNCTIONS
        // *****************************************************************************************************************************
        // *****************************************************************************************************************************


        /// <summary>
        /// SAVING CURRENT DATASET TO THE FILE ON HD
        /// </summary>
        private int DateToInt(DateTime inputDate)
        {
            return inputDate.Year * 366 + inputDate.Month * 31 + inputDate.Day;
        }


        /// <summary>
        /// MINIMIZING PROGRAM TO TRAY WITH HIGING FROM ALT+TAB
        /// </summary>
        private void HideForm()
        {
            // MINIMIZING THE FORM
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }



        /// <summary>
        /// RETURNING THE FORM TO THE SCREEN
        /// </summary>
        private void ShowForm()
        {
            // RETURNING THE FORM ON SCREEN
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.Sizable;
        }



        // *****************************************************************************************************************************
        // *****************************************************************************************************************************
        // BUTTON CLICKS (AND OTHER CLICKS)
        // *****************************************************************************************************************************
        // *****************************************************************************************************************************





        /// <summary>
        /// BUTTON CLICK: SHOWING NEW OR OLD JOBS WHEN "SHOW..." BUTTON IS CLICKED ON
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowOld_Click(object sender, EventArgs e)
        {
            if (actualJobsShowed)
            {
                //// SHOWING OLD JOBS
                ShowOldJobs();
            }
            else
            {
                //// SHOWING ACTUAL JOBS
                ShowActualJobs();
            }
        }

        
        
        /// <summary>
        /// CALENDAR CLICK: CHOOSING A DATA FOR THE NEW JOB FROM A CALENDAR (AFTER A CLICK)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }



        /// <summary>
        /// BUTTON CLICK: JOBS DELETE BUTTON - BEHAVE DEPENDING ON NEW OR OLD JOBS ARE SHOWED
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteJobsButton_Click(object sender, EventArgs e)
        {
            //// DELETING JOBS ENTRIES
            using (NARContext tmpNARContext = new NARContext(myConnection))
            {
                // LOOKING THROUHG ALL DYNAMICALY CREATED PANELS FOR CHECKED
                foreach (object obj in JobPanelForPanels.Controls)
                {
                    // FOR EACH PANEL LOOKING FOR ITS CHILD CHECKBOX
                    if (obj.GetType() == typeof(Panel))
                    {
                        Panel panel = (Panel)obj;

                        foreach (var child in panel.Controls)
                        {
                            if (child.GetType() == typeof(CheckBox))
                            {
                                // IF CHECKBOX FOUND - ANALYZING IT
                                CheckBox tmpCHB = (CheckBox)child;
                                if (tmpCHB.Checked == true)
                                {
                                    /// THE REMOVAL SECTION
                                    int currId = int.Parse(panel.Name);
                                    // REMOVING CURRENT ENTRY FROM TABEL
                                    tmpNARContext.Jobs.Remove(tmpNARContext.Jobs.Where(job => job.Id == currId).SingleOrDefault());
                                    // BREACKING SEARCH FOR THE CHECKBOX
                                    break;
                                }
                            }
                        }

                    }
                }
                // SAVING CHANGES
                tmpNARContext.SaveChanges();
            }

            JobsInFutureLabel.Text = JobPanelForPanels.Controls.Count.ToString();
            if (actualJobsShowed)
            {
                //// SHOWING ACTUAL JOBS
                ShowActualJobs();
            }
            else
            {
                //// SHOWING OLD JOBS
                ShowOldJobs();
            }
        }




        /// <summary>
        /// BUTTON CLICK: BIRTHDAYS DELETE BUTTON
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BirthdayDeleteButton_Click(object sender, EventArgs e)
        {
            //// DELETING BIRTHDAYS ENTRIES
            using (NARContext tmpNARContext = new NARContext(myConnection))
            {
                // LOOKING THROUHG ALL DYNAMICALY CREATED PANELS FOR CHECKED
                foreach (object obj in BirthdayPanelForPanels.Controls)
                {
                    // FOR EACH PANEL LOOKING FOR ITS CHILD CHECKBOX
                    if (obj.GetType() == typeof(Panel))
                    {
                        Panel panel = (Panel)obj;

                        foreach (var child in panel.Controls)
                        {
                            if (child.GetType() == typeof(CheckBox))
                            {
                                // IF CHECKBOX FOUND - ANALYZING IT
                                CheckBox tmpCHB = (CheckBox)child;
                                if (tmpCHB.Checked == true)
                                {
                                    /// THE REMOVAL SECTION
                                    int currId = int.Parse(panel.Name);
                                    // REMOVING CURRENT ENTRY FROM TABEL
                                    tmpNARContext.Birthdays.Remove(tmpNARContext.Birthdays.Where(bd => bd.Id == currId).SingleOrDefault());
                                    // BREACKING SEARCH FOR THE CHECKBOX
                                    break;
                                }
                            }
                        }

                    }
                }
                // SAVING DATA CHANGES
                tmpNARContext.SaveChanges();
            }
            // REFRESH BIRTHDAYS
            ShowBirthdays();
        }


        /// <summary>
        /// BUTTON CLICK: DELETE SELECTED HEADERS AND ASSOCIATED NOTES
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteHeaderButton_Click(object sender, EventArgs e)
        {
            //// DELETING SELECTED NOTE ENTRIES
            using (NARContext tmpNARContext = new NARContext(myConnection))
            {
                // LOOKING THROUHG ALL DYNAMICALY CREATED PANELS FOR CHECKED
                foreach (object obj in HeaderPanelForPanels.Controls)
                {
                    // FOR EACH PANEL LOOKING FOR ITS CHILD CHECKBOX
                    if (obj.GetType() == typeof(Panel))
                    {
                        Panel panel = (Panel)obj;

                        foreach (var child in panel.Controls)
                        {
                            if (child.GetType() == typeof(CheckBox))
                            {
                                // IF CHECKBOX FOUND - ANALYZING IT
                                CheckBox tmpCHB = (CheckBox)child;
                                if (tmpCHB.Checked == true)
                                {
                                    /// THE REMOVAL SECTION
                                    int currId = int.Parse(panel.Name);
                                    // REMOVING CURRENT ENTRY FROM TABEL
                                    tmpNARContext.Notes.Remove(tmpNARContext.Notes.Where(note => note.Id == currId).SingleOrDefault());
                                    // CLEARING NOTE AREA IF DISPLAYED NOTE IS DELETED
                                    if (currId == currentDisplayedNote)
                                    {
                                        currentDisplayedNote = -1;
                                        NoteCorrectionDateLabel.Text = "-";
                                        NoteTopicCombobox.Text = "";
                                        NoteHeaderTextbox.Text = "";
                                        NoteTextTextbox.Text = "";
                                    }
                                    // BREACKING SEARCH FOR THE CHECKBOX
                                    break;
                                }
                            }
                        }

                    }
                }
                // SAVING DATA CHANGES
                tmpNARContext.SaveChanges();
            }
            // REFRESHING TOPIC AND HEADER LISTS
            ShowTopics();
            ShowHeadersOfTopic();
            // REFRESHING SELECTION FOR CERTAIN TOPIC AND HEADER PANELS
            if (currentListedTopic != "")
            {
                foreach (Label topicLabel in TopicPanelForPanels.Controls)
                {
                    if (topicLabel.AccessibleDescription == currentListedTopic)
                        topicLabel.BackColor = Color.FromArgb(227, 227, 227);
                }
            }
            if (currentDisplayedNote != -1)
            {
                foreach (Panel headerPanel in HeaderPanelForPanels.Controls)
                {
                    if (headerPanel.Name == currentDisplayedNote.ToString())
                        headerPanel.BackColor = Color.FromArgb(227, 227, 227);
                }
            }
        }


        /// <summary>
        /// BUTTON CLICK: ADD NEW JOB BUTTON CLICK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addJobButton_Click(object sender, EventArgs e)
        {
            using (NARContext tmpNARContext = new NARContext(myConnection))
            {
                Job newJob = new Job();
                newJob.Date = jobCalendar.Value;
                newJob.Text = NewJobDescription.Text;

                tmpNARContext.Jobs.Add(newJob);
                
                // SAVING DATA CHANGE
                tmpNARContext.SaveChanges();
            }

            // IF NEW JOBS ARE SHOWED - RELOADING THEM
            if (actualJobsShowed)
            {
                ShowActualJobs();
            }
            else
            {
                ShowOldJobs();
            }

            NewJobDescription.Text = "";
            jobCalendar.Value = DateTime.Now;
        }



        /// <summary>
        /// BUTTON CLICK: ADD NEW BIRTHDAY CLICK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddNewBirthdayButton_Click(object sender, EventArgs e)
        {
            if ((BDDayLabel.Text != "ДД") && (BDMonthLabel.Text != "ММ") && (BDNameLabel.Text.Length > 0))
            {
                using (NARContext tmpNARContext = new NARContext(myConnection))
                {
                    Birthday newBd = new Birthday();

                    newBd.Name = BDNameLabel.Text;
                    newBd.Month = (byte)int.Parse(BDMonthLabel.Text);
                    newBd.Day = (byte)int.Parse(BDDayLabel.Text);
                    if (BDYearLabel.Text == "ГГГГ")
                        newBd.Year = -1;
                    else
                        newBd.Year = int.Parse(BDYearLabel.Text);

                    tmpNARContext.Birthdays.Add(newBd);

                    // SAVING DATA CHANGE
                    tmpNARContext.SaveChanges();
                }
                // REFRESHING BIRTHDAYS
                ShowBirthdays();
                // REFRESHING BIRTHDAY BOXES
                BDDayLabel.Text = "ДД";
                BDMonthLabel.Text = "ММ";
                BDYearLabel.Text = "ГГГГ";
                BDNameLabel.Text = "";
            }
        }


        /// <summary>
        /// BUTTON CLICK: EXITING PROGRAM
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        /// <summary>
        /// BUTTON CLICK: MINIMIZING PROGRAM INTO TRAY
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            HideForm();
        }


        /// <summary>
        /// BUTTON CLICK: NEW NOTE CREATION
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewNoteButton_Click(object sender, EventArgs e)
        {
            // RECOLORING ALL HEADER LABELS
            currentDisplayedNote = -1;
            foreach (Panel headerPanel in HeaderPanelForPanels.Controls)
            {
                headerPanel.BackColor = Color.FromArgb(247, 247, 247);
            }
            // EMPTING NOTE AREA
            NoteCorrectionDateLabel.Text = DateTime.Now.Date.ToString().Remove(10);
            NoteTopicCombobox.Text = "";
            NoteHeaderTextbox.Text = "";
            NoteTextTextbox.Text = "";
        }


        /// <summary>
        /// BUTTON CLICK: SAVING CURRENT NOTE AREA INFORMATION
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveNoteButton_Click(object sender, EventArgs e)
        {
            using (NARContext tmpNARContext = new NARContext(myConnection))
            {

                if (currentDisplayedNote != -1)
                {
                    // SERCHING FOR CURREN NOTE IN THE TABLE
                    Note currNote = tmpNARContext.Notes.Where(note => note.Id == currentDisplayedNote).SingleOrDefault();

                    NoteCorrectionDateLabel.Text = DateTime.Now.Date.ToString().Remove(10);
                    currNote.Date = DateTime.Now;
                    currNote.Text = NoteTextTextbox.Text;
                    // SAVING DATA CHANGE
                    tmpNARContext.SaveChanges();
                    // LOOKING IF TOPIC IS CHANGED
                    if (currNote.Topic != NoteTopicCombobox.Text)
                    {
                        currNote.Topic = NoteTopicCombobox.Text;
                        // SAVING DATA CHANGE
                        tmpNARContext.SaveChanges();
                        // REFRESHING TOPICS AND MARKING TOPIC WITH CURRENT NEW NOTE
                        currentListedTopic = NoteTopicCombobox.Text;
                        ShowTopics();
                        foreach (Label topicLabel in TopicPanelForPanels.Controls)
                        {
                            if (topicLabel.AccessibleDescription == currentListedTopic)
                                topicLabel.BackColor = Color.FromArgb(227, 227, 227);
                        }
                        // REFRESHING HEADERS AND MARKING HEADER OF CURRENT NEW NOTE
                        ShowHeadersOfTopic();
                        foreach (Panel headerPanel in HeaderPanelForPanels.Controls)
                        {
                            if (headerPanel.Name == currentDisplayedNote.ToString())
                                headerPanel.BackColor = Color.FromArgb(227, 227, 227);
                        }
                    }
                    // LOOKING IF HEADER IS CHANGED
                    if (currNote.Header != NoteHeaderTextbox.Text)
                    {
                        currNote.Header = NoteHeaderTextbox.Text;
                        // SAVING DATA CHANGE
                        tmpNARContext.SaveChanges();
                        // REFRESHING HEADERS AND MARKING HEADER OF CURRENT NEW NOTE
                        ShowHeadersOfTopic();
                        foreach (Panel headerPanel in HeaderPanelForPanels.Controls)
                        {
                            if (headerPanel.Name == currentDisplayedNote.ToString())
                                headerPanel.BackColor = Color.FromArgb(227, 227, 227);
                        }
                    }
                }
                else
                {
                    /// CREATING NEW NOTE
                    Note newNote = new Note();

                    newNote.Topic = NoteTopicCombobox.Text;
                    newNote.Header = NoteHeaderTextbox.Text;
                    newNote.Date = DateTime.Now;
                    newNote.Text = NoteTextTextbox.Text;

                    tmpNARContext.Notes.Add(newNote);
                    // SAVING DATA CHANGE
                    tmpNARContext.SaveChanges();

                    NoteCorrectionDateLabel.Text = DateTime.Now.Date.ToString().Remove(10);

                    // REFRESHING TOPICS AND MARKING TOPIC WITH CURRENT NEW NOTE
                    currentListedTopic = NoteTopicCombobox.Text;
                    ShowTopics();
                    foreach (Label topicLabel in TopicPanelForPanels.Controls)
                    {
                        if (topicLabel.AccessibleDescription == currentListedTopic)
                            topicLabel.BackColor = Color.FromArgb(227, 227, 227);
                    }
                    // REFRESHING HEADERS AND MARKING HEADER OF CURRENT NEW NOTE
                    currentDisplayedNote = newNote.Id;
                    ShowHeadersOfTopic();
                    foreach (Panel headerPanel in HeaderPanelForPanels.Controls)
                    {
                        if (headerPanel.Name == currentDisplayedNote.ToString())
                            headerPanel.BackColor = Color.FromArgb(227, 227, 227);
                    }
                }
            }
        }


        /// <summary>
        /// BUTTON CLICK: CHANGE OF TOPIC IN ALL OF ITS NOTES
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TopicChangeButton_Click(object sender, EventArgs e)
        {
            if (currentListedTopic != "")
            {
                if ((NoteTopicCombobox.Text != currentListedTopic) && (NoteTopicCombobox.Text != ""))
                {
                    // SEARCHING NOTE DATA ROWS WITH CURRENT TOPIC
                    using (NARContext tmpNARContext = new NARContext(myConnection))
                    {
                        foreach (var note in tmpNARContext.Notes.Where(note => note.Topic == currentListedTopic))
                        {
                            note.Topic = NoteTopicCombobox.Text;
                        }

                        // SAVING DATA CHANGE
                        tmpNARContext.SaveChanges();
                    }
                    
                    // REFRESHING TOPICS AND MARKING CURRENT TOPIC
                    currentListedTopic = NoteTopicCombobox.Text;
                    ShowTopics();
                    foreach (Label topicLabel in TopicPanelForPanels.Controls)
                    {
                        if (topicLabel.AccessibleDescription == currentListedTopic)
                            topicLabel.BackColor = Color.FromArgb(227, 227, 227);
                    }
                    // REFRESHING HEADERS WITHOUT MARKING ANY
                    ShowHeadersOfTopic();
                    currentDisplayedNote = -1;
                    NoteCorrectionDateLabel.Text = "-";
                    NoteTopicCombobox.Text = "";
                    NoteHeaderTextbox.Text = "";
                    NoteTextTextbox.Text = "";
                }
            }
        }


        /// <summary>
        /// LABEL CLICK: CLICK ON TOPIC LABEL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewLbl_Click(Label senderLabel, EventArgs e)
        {
            // RECOLORING ALL TOPIC LABELS
            foreach (Label headerLabel in TopicPanelForPanels.Controls)
            {
                headerLabel.BackColor = Color.FromArgb(247, 247, 247);
            }
            // SETTING CURRENT TOPIC
            currentListedTopic = senderLabel.AccessibleDescription;
            // DARKENING SELECTED TOPIC
            senderLabel.BackColor = Color.FromArgb(227, 227, 227);
            ShowHeadersOfTopic();
            // CLEARING NOTE AREA
            NoteCorrectionDateLabel.Text = "-";
            NoteTopicCombobox.Text = currentListedTopic;
            NoteHeaderTextbox.Text = "";
            NoteTextTextbox.Text = "";
            currentDisplayedNote = -1;
        }
        

        /// <summary>
        /// HEADER CLICK: CLICK ON LABEL OF A HEADER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Header_Click(Label sender, EventArgs e)
        {
            currentDisplayedNote = int.Parse(sender.AccessibleDescription);
            using (NARContext tmpNARContext = new NARContext(myConnection))
            {
                Note currNote = tmpNARContext.Notes.Where(note => note.Id == currentDisplayedNote).SingleOrDefault();

                NoteCorrectionDateLabel.Text = currNote.Date.ToShortDateString();
                NoteTopicCombobox.Text = currNote.Topic;
                NoteHeaderTextbox.Text = currNote.Header;
                NoteTextTextbox.Text = currNote.Text;
            }

            foreach (Panel headerPanel in HeaderPanelForPanels.Controls)
            {
                headerPanel.BackColor = Color.FromArgb(247, 247, 247);
            }
            sender.Parent.BackColor = Color.FromArgb(227, 227, 227);
        }


        /// <summary>
        /// DOUBLE CLICK ON FORM ICON IN SYSTEM TRAY FOR BRINGING IT BACK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void thisFormIcon_DoubleClick(object sender, EventArgs e)
        {
            // SHOWING THE FORM
            ShowForm();
        }


        /// <summary>
        /// ONE HOUR REMIND TIMER TICK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void remindTimer_Tick(object sender, EventArgs e)
        {
            // REFRESHING TIMER
            remindTimer.Interval = 3600000;
            remindTimer.Enabled = true;
            // CHECKING IF A NEW DAY HAS COME TO REFRESH THE REMIND CHECKBOX ON THE FORM
            if (DateTime.Now.Date.Subtract(previousTick).TotalDays > 0)
            {
                RemindCheckbox.Checked = true;
                ShowActualJobs();
                ShowBirthdays();
            }
            previousTick = DateTime.Now.Date;
            // CHECKING IF REMIND CHECKBOX IS CHECKED
            if (RemindCheckbox.Checked == true)
            {
                bool urgentEvents = false;
                // CHECKING IF THERE ARE URGENT JOBS
                using (NARContext tmpNARContext = new NARContext(myConnection))
                {
                    foreach (var job in tmpNARContext.Jobs)
                    {
                        int leftDays = (int)Math.Ceiling(job.Date.Subtract(DateTime.Now.Date).TotalDays);
                        if ((leftDays >= 0) && (leftDays <= (int)ControlledDaysAmountUpdown.Value))
                        {
                            urgentEvents = true;
                            break;
                        }
                    }
                    // CHECKING IF THERE ARE URGENT BIRTHDAYS
                    if (!urgentEvents)
                    {
                        foreach (var bd in tmpNARContext.Birthdays)
                        {
                            int leftDays = (int)Math.Ceiling(DateTime.MinValue.AddYears(DateTime.Now.Year - 1).AddMonths(bd.Month - 1).AddDays(bd.Day - 1).Subtract(DateTime.Now.Date).TotalDays);
                            if (leftDays < 0)
                                leftDays = (int)Math.Ceiling(DateTime.MinValue.AddYears(DateTime.Now.Year).AddMonths(bd.Month - 1).AddDays(bd.Day - 1).Subtract(DateTime.Now.Date).TotalDays);
                            if (leftDays <= (int)ControlledDaysAmountUpdown.Value)
                            {
                                urgentEvents = true;
                                break;
                            }
                        }
                    }
                    // IF FOUND URGENT EVENTS - SHOW THE FORM
                    if (urgentEvents)
                    {
                        ShowForm();
                        BasicTabPanel.SelectedTab = ReminderTab;
                    }
                }
            }
        }


        /// <summary>
        /// ON CHANGE OF CONTROL PERIOD LENGTH
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ControlledDaysAmountUpdown_ValueChanged(object sender, EventArgs e)
        {
            if (actualJobsShowed == true)
                ShowActualJobs();
            else
                ShowOldJobs();
            ShowBirthdays();
        }



        /// <summary>
        /// WHEN FORM START CLOSING
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainProgForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            thisFormIcon.Visible = false;
            thisFormIcon.Dispose();
            myConnection.Dispose();
        }



        
        
        // *****************************************************************************************************************************
        // *****************************************************************************************************************************
        // CHECKS
        // *****************************************************************************************************************************
        // *****************************************************************************************************************************





        /// <summary>
        /// EDIT ENTER: ENTERING TO CHANGE DAY OF NEW BIRTHDAY
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BDDayLabel_Enter(object sender, EventArgs e)
        {
            if (BDDayLabel.Text == "ДД")
                BDDayLabel.Text = "";
        }

        /// <summary>
        /// EDIT LEAVE: LEAVING DAY OF NEW BIRTHDAY TEXTBOX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BDDayLabel_Leave(object sender, EventArgs e)
        {
            if (BDDayLabel.Text.Length < 1)
                BDDayLabel.Text = "ДД";
            else if (BDDayLabel.Text.Length == 1)
            {
                if (!"0123456789".Contains(BDDayLabel.Text.ElementAt(0)))
                    BDDayLabel.Text = "ДД";
                else
                    BDDayLabel.Text = "0" + BDDayLabel.Text;
            }
            else
            {
                if ((!"0123".Contains(BDDayLabel.Text.ElementAt(0))) || (!"0123456789".Contains(BDDayLabel.Text.ElementAt(1))))
                    BDDayLabel.Text = "ДД";
                else if ((int.Parse(BDDayLabel.Text) > 31) || (int.Parse(BDDayLabel.Text) < 1))
                    BDDayLabel.Text = "ДД";
            }
        }



        /// <summary>
        /// EDIT ENTER: ENTERING TO CHANGE MONTH OF NEW BIRTHDAY
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BDMonthLabel_Enter(object sender, EventArgs e)
        {
            if (BDMonthLabel.Text == "ММ")
                BDMonthLabel.Text = "";

        }

        /// <summary>
        /// EDIT LEAVE: LEAVING MONTH OF NEW BIRTHDAY TEXTBOX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BDMonthLabel_Leave(object sender, EventArgs e)
        {
            if (BDMonthLabel.Text.Length < 1)
                BDMonthLabel.Text = "ММ";
            else if (BDMonthLabel.Text.Length == 1)
            {
                if (!"0123456789".Contains(BDMonthLabel.Text.ElementAt(0)))
                    BDMonthLabel.Text = "ММ";
                else
                    BDMonthLabel.Text = "0" + BDMonthLabel.Text;
            }
            else
            {
                if ((!"01".Contains(BDMonthLabel.Text.ElementAt(0))) || (!"0123456789".Contains(BDMonthLabel.Text.ElementAt(1))))
                    BDMonthLabel.Text = "ММ";
                else if ((int.Parse(BDMonthLabel.Text) > 12) || (int.Parse(BDMonthLabel.Text) < 1))
                    BDMonthLabel.Text = "ММ";
            }
        }



        /// <summary>
        /// EDIT ENTER: ENTERING TO CHANGE YEAR OF NEW BIRTHDAY
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BDYearLabel_Enter(object sender, EventArgs e)
        {
            if (BDYearLabel.Text == "ГГГГ")
                BDYearLabel.Text = "";
        }

        /// <summary>
        /// EDIT LEAVE: LEAVING MONTH OF NEW BIRTHDAY TEXTBOX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BDYearLabel_Leave(object sender, EventArgs e)
        {
            if ((BDYearLabel.Text.Length < 2) || (BDYearLabel.Text.Length == 3))
                BDYearLabel.Text = "ГГГГ";
            else
            {
                char[] tmpCharArr = BDYearLabel.Text.ToCharArray();
                foreach (var item in tmpCharArr)
                {
                    // CHECKING IF ALL CHARS OF YEAR ARE DIGITS
                    if (!"0123456789".Contains(item))
                    {
                        BDYearLabel.Text = "ГГГГ";
                        break;
                    }
                }
                if (BDYearLabel.Text.Length == 2)
                {
                    // CORRECTING YEAR TO BE YYYY-TYPE
                    if (int.Parse(BDYearLabel.Text) <= int.Parse(DateTime.Now.Year.ToString().Remove(0, 2)))
                        BDYearLabel.Text = "20" + BDYearLabel.Text;
                    else
                        BDYearLabel.Text = "19" + BDYearLabel.Text;
                }
                if ((BDYearLabel.Text.Length == 4) && (int.Parse(BDYearLabel.Text) > DateTime.Now.Year))
                    BDYearLabel.Text = "ГГГГ";
            }
        }

    }






    // *****************************************************************************************************************************
    // *****************************************************************************************************************************
    // MODEL CLASSES
    // *****************************************************************************************************************************
    // *****************************************************************************************************************************




    public class Job
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
    }

    public class Birthday
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public byte Month { get; set; }
        public byte Day { get; set; }
    }

    public class Note
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public string Header { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
    }







    // *****************************************************************************************************************************
    // *****************************************************************************************************************************
    // CONTEXT CLASS
    // *****************************************************************************************************************************
    // *****************************************************************************************************************************





    public class NARContext : DbContext
    {
        public NARContext(SQLiteConnection myConnection) : base (myConnection, false)
        {
            if (!Database.Exists())
            {
                Database.Create();
                Jobs.Create();
                Birthdays.Create();
                Notes.Create();
                SaveChanges();
            }
        }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<Birthday> Birthdays { get; set; }
        public DbSet<Note> Notes { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=NoteAndRemind.db");
        }*/
    }

}


/*
 
    






    */
