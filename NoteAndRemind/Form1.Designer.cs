using System.Windows.Forms;

namespace NoteAndRemind
{
    partial class MainProgForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainProgForm));
            this.AddJobButton = new System.Windows.Forms.Button();
            this.DeleteJobsButton = new System.Windows.Forms.Button();
            this.ShowOldOrNewButton = new System.Windows.Forms.Button();
            this.JobPanelForPanels = new System.Windows.Forms.Panel();
            this.Future = new System.Windows.Forms.Panel();
            this.JobsInFutureLabel = new System.Windows.Forms.Label();
            this.AboutBirthdaysLabel = new System.Windows.Forms.Label();
            this.AboutJobsLabel = new System.Windows.Forms.Label();
            this.ControlledDaysAmountUpdown = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.NewJobDescription = new System.Windows.Forms.TextBox();
            this.jobCalendar = new System.Windows.Forms.DateTimePicker();
            this.BirthdayDeleteButton = new System.Windows.Forms.Button();
            this.BirthdayPanelForPanels = new System.Windows.Forms.Panel();
            this.NewBirthdayPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.BDNameLabel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BDYearLabel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BDMonthLabel = new System.Windows.Forms.TextBox();
            this.BDDayLabel = new System.Windows.Forms.TextBox();
            this.AddNewBirthdayButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.MinimizeButton = new System.Windows.Forms.Button();
            this.RemindCheckbox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TopicPanelForPanels = new System.Windows.Forms.Panel();
            this.HeaderPanelForPanels = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.TopicChangeButton = new System.Windows.Forms.Button();
            this.NewNoteButton = new System.Windows.Forms.Button();
            this.SaveNoteButton = new System.Windows.Forms.Button();
            this.DeleteHeaderButton = new System.Windows.Forms.Button();
            this.CurrentNotePanel = new System.Windows.Forms.Panel();
            this.NoteTopicCombobox = new System.Windows.Forms.ComboBox();
            this.NoteTopicLabel = new System.Windows.Forms.Label();
            this.NoteCorrectionDateLabel = new System.Windows.Forms.Label();
            this.NoteTextTextbox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.NoteHeaderTextbox = new System.Windows.Forms.TextBox();
            this.NoteHeaderLabel = new System.Windows.Forms.Label();
            this.NoteAboutCorrectionDateLabel = new System.Windows.Forms.Label();
            this.BasicTabPanel = new System.Windows.Forms.TabControl();
            this.ReminderTab = new System.Windows.Forms.TabPage();
            this.ControlDaysPanel = new System.Windows.Forms.Panel();
            this.NotesTab = new System.Windows.Forms.TabPage();
            this.Future.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ControlledDaysAmountUpdown)).BeginInit();
            this.NewBirthdayPanel.SuspendLayout();
            this.CurrentNotePanel.SuspendLayout();
            this.BasicTabPanel.SuspendLayout();
            this.ReminderTab.SuspendLayout();
            this.ControlDaysPanel.SuspendLayout();
            this.NotesTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddJobButton
            // 
            this.AddJobButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddJobButton.Location = new System.Drawing.Point(5, 562);
            this.AddJobButton.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.AddJobButton.Name = "AddJobButton";
            this.AddJobButton.Size = new System.Drawing.Size(250, 30);
            this.AddJobButton.TabIndex = 8;
            this.AddJobButton.Text = "ДОБАВИТЬ ДЕЛО";
            this.AddJobButton.UseVisualStyleBackColor = true;
            this.AddJobButton.Click += new System.EventHandler(this.addJobButton_Click);
            // 
            // DeleteJobsButton
            // 
            this.DeleteJobsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteJobsButton.Location = new System.Drawing.Point(210, 40);
            this.DeleteJobsButton.Margin = new System.Windows.Forms.Padding(5);
            this.DeleteJobsButton.Name = "DeleteJobsButton";
            this.DeleteJobsButton.Size = new System.Drawing.Size(240, 30);
            this.DeleteJobsButton.TabIndex = 5;
            this.DeleteJobsButton.Text = "УДАЛИТЬ (ВЫДЕЛЕННЫЕ)\r\n";
            this.DeleteJobsButton.UseVisualStyleBackColor = true;
            this.DeleteJobsButton.Click += new System.EventHandler(this.DeleteJobsButton_Click);
            // 
            // ShowOldOrNewButton
            // 
            this.ShowOldOrNewButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowOldOrNewButton.Location = new System.Drawing.Point(5, 40);
            this.ShowOldOrNewButton.Margin = new System.Windows.Forms.Padding(5);
            this.ShowOldOrNewButton.Name = "ShowOldOrNewButton";
            this.ShowOldOrNewButton.Size = new System.Drawing.Size(200, 30);
            this.ShowOldOrNewButton.TabIndex = 4;
            this.ShowOldOrNewButton.Text = "ПОКАЗАТЬ СТАРЫЕ\r\n";
            this.ShowOldOrNewButton.UseVisualStyleBackColor = true;
            this.ShowOldOrNewButton.Click += new System.EventHandler(this.ShowOld_Click);
            // 
            // JobPanelForPanels
            // 
            this.JobPanelForPanels.AutoScroll = true;
            this.JobPanelForPanels.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.JobPanelForPanels.Location = new System.Drawing.Point(5, 75);
            this.JobPanelForPanels.Margin = new System.Windows.Forms.Padding(0);
            this.JobPanelForPanels.Name = "JobPanelForPanels";
            this.JobPanelForPanels.Size = new System.Drawing.Size(690, 483);
            this.JobPanelForPanels.TabIndex = 2;
            // 
            // Future
            // 
            this.Future.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Future.Controls.Add(this.JobsInFutureLabel);
            this.Future.Controls.Add(this.AboutBirthdaysLabel);
            this.Future.Controls.Add(this.AboutJobsLabel);
            this.Future.Location = new System.Drawing.Point(5, 5);
            this.Future.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.Future.Name = "Future";
            this.Future.Size = new System.Drawing.Size(1390, 30);
            this.Future.TabIndex = 4;
            // 
            // JobsInFutureLabel
            // 
            this.JobsInFutureLabel.AutoSize = true;
            this.JobsInFutureLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.JobsInFutureLabel.Location = new System.Drawing.Point(156, 4);
            this.JobsInFutureLabel.Name = "JobsInFutureLabel";
            this.JobsInFutureLabel.Size = new System.Drawing.Size(16, 17);
            this.JobsInFutureLabel.TabIndex = 22;
            this.JobsInFutureLabel.Text = "0";
            // 
            // AboutBirthdaysLabel
            // 
            this.AboutBirthdaysLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AboutBirthdaysLabel.Location = new System.Drawing.Point(705, 5);
            this.AboutBirthdaysLabel.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.AboutBirthdaysLabel.Name = "AboutBirthdaysLabel";
            this.AboutBirthdaysLabel.Size = new System.Drawing.Size(690, 23);
            this.AboutBirthdaysLabel.TabIndex = 22;
            this.AboutBirthdaysLabel.Text = "Дней рождений за следующие семь дней: Х, за следующий месяц: Х";
            // 
            // AboutJobsLabel
            // 
            this.AboutJobsLabel.AutoSize = true;
            this.AboutJobsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AboutJobsLabel.Location = new System.Drawing.Point(0, 4);
            this.AboutJobsLabel.Name = "AboutJobsLabel";
            this.AboutJobsLabel.Size = new System.Drawing.Size(150, 17);
            this.AboutJobsLabel.TabIndex = 22;
            this.AboutJobsLabel.Text = "Всего дел в будущем:";
            // 
            // ControlledDaysAmountUpdown
            // 
            this.ControlledDaysAmountUpdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ControlledDaysAmountUpdown.Location = new System.Drawing.Point(260, 2);
            this.ControlledDaysAmountUpdown.Maximum = new decimal(new int[] {
            14,
            0,
            0,
            0});
            this.ControlledDaysAmountUpdown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ControlledDaysAmountUpdown.Name = "ControlledDaysAmountUpdown";
            this.ControlledDaysAmountUpdown.Size = new System.Drawing.Size(50, 23);
            this.ControlledDaysAmountUpdown.TabIndex = 0;
            this.ControlledDaysAmountUpdown.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.ControlledDaysAmountUpdown.ValueChanged += new System.EventHandler(this.ControlledDaysAmountUpdown_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(5, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(256, 17);
            this.label7.TabIndex = 22;
            this.label7.Text = "Отслеживать дней для напоминания:";
            // 
            // NewJobDescription
            // 
            this.NewJobDescription.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NewJobDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NewJobDescription.Location = new System.Drawing.Point(130, 597);
            this.NewJobDescription.Margin = new System.Windows.Forms.Padding(0);
            this.NewJobDescription.Name = "NewJobDescription";
            this.NewJobDescription.Size = new System.Drawing.Size(565, 23);
            this.NewJobDescription.TabIndex = 7;
            // 
            // jobCalendar
            // 
            this.jobCalendar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jobCalendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.jobCalendar.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.jobCalendar.Location = new System.Drawing.Point(5, 597);
            this.jobCalendar.Margin = new System.Windows.Forms.Padding(0);
            this.jobCalendar.Name = "jobCalendar";
            this.jobCalendar.Size = new System.Drawing.Size(120, 23);
            this.jobCalendar.TabIndex = 6;
            this.jobCalendar.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // BirthdayDeleteButton
            // 
            this.BirthdayDeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BirthdayDeleteButton.Location = new System.Drawing.Point(950, 40);
            this.BirthdayDeleteButton.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.BirthdayDeleteButton.Name = "BirthdayDeleteButton";
            this.BirthdayDeleteButton.Size = new System.Drawing.Size(240, 30);
            this.BirthdayDeleteButton.TabIndex = 9;
            this.BirthdayDeleteButton.Text = "УДАЛИТЬ (ВЫДЕЛЕННЫЕ)";
            this.BirthdayDeleteButton.UseVisualStyleBackColor = true;
            this.BirthdayDeleteButton.Click += new System.EventHandler(this.BirthdayDeleteButton_Click);
            // 
            // BirthdayPanelForPanels
            // 
            this.BirthdayPanelForPanels.AutoScroll = true;
            this.BirthdayPanelForPanels.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BirthdayPanelForPanels.Location = new System.Drawing.Point(705, 75);
            this.BirthdayPanelForPanels.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.BirthdayPanelForPanels.Name = "BirthdayPanelForPanels";
            this.BirthdayPanelForPanels.Size = new System.Drawing.Size(690, 483);
            this.BirthdayPanelForPanels.TabIndex = 1;
            // 
            // NewBirthdayPanel
            // 
            this.NewBirthdayPanel.Controls.Add(this.label3);
            this.NewBirthdayPanel.Controls.Add(this.BDNameLabel);
            this.NewBirthdayPanel.Controls.Add(this.label2);
            this.NewBirthdayPanel.Controls.Add(this.BDYearLabel);
            this.NewBirthdayPanel.Controls.Add(this.label1);
            this.NewBirthdayPanel.Controls.Add(this.BDMonthLabel);
            this.NewBirthdayPanel.Controls.Add(this.BDDayLabel);
            this.NewBirthdayPanel.Location = new System.Drawing.Point(705, 597);
            this.NewBirthdayPanel.Margin = new System.Windows.Forms.Padding(0);
            this.NewBirthdayPanel.Name = "NewBirthdayPanel";
            this.NewBirthdayPanel.Size = new System.Drawing.Size(690, 23);
            this.NewBirthdayPanel.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(130, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 23);
            this.label3.TabIndex = 22;
            this.label3.Text = "ФИО:";
            // 
            // BDNameLabel
            // 
            this.BDNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BDNameLabel.Location = new System.Drawing.Point(180, 0);
            this.BDNameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.BDNameLabel.MaxLength = 0;
            this.BDNameLabel.Name = "BDNameLabel";
            this.BDNameLabel.Size = new System.Drawing.Size(510, 23);
            this.BDNameLabel.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(70, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 23);
            this.label2.TabIndex = 22;
            this.label2.Text = "-";
            // 
            // BDYearLabel
            // 
            this.BDYearLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BDYearLabel.Location = new System.Drawing.Point(80, 0);
            this.BDYearLabel.Margin = new System.Windows.Forms.Padding(5);
            this.BDYearLabel.MaxLength = 4;
            this.BDYearLabel.Name = "BDYearLabel";
            this.BDYearLabel.Size = new System.Drawing.Size(40, 23);
            this.BDYearLabel.TabIndex = 12;
            this.BDYearLabel.Text = "ГГГГ";
            this.BDYearLabel.Enter += new System.EventHandler(this.BDYearLabel_Enter);
            this.BDYearLabel.Leave += new System.EventHandler(this.BDYearLabel_Leave);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(30, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 23);
            this.label1.TabIndex = 22;
            this.label1.Text = "-";
            // 
            // BDMonthLabel
            // 
            this.BDMonthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BDMonthLabel.Location = new System.Drawing.Point(40, 0);
            this.BDMonthLabel.Margin = new System.Windows.Forms.Padding(0);
            this.BDMonthLabel.MaxLength = 2;
            this.BDMonthLabel.Name = "BDMonthLabel";
            this.BDMonthLabel.Size = new System.Drawing.Size(30, 23);
            this.BDMonthLabel.TabIndex = 11;
            this.BDMonthLabel.Text = "ММ";
            this.BDMonthLabel.Enter += new System.EventHandler(this.BDMonthLabel_Enter);
            this.BDMonthLabel.Leave += new System.EventHandler(this.BDMonthLabel_Leave);
            // 
            // BDDayLabel
            // 
            this.BDDayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BDDayLabel.Location = new System.Drawing.Point(0, 0);
            this.BDDayLabel.Margin = new System.Windows.Forms.Padding(0);
            this.BDDayLabel.MaxLength = 2;
            this.BDDayLabel.Name = "BDDayLabel";
            this.BDDayLabel.Size = new System.Drawing.Size(30, 23);
            this.BDDayLabel.TabIndex = 10;
            this.BDDayLabel.Text = "ДД";
            this.BDDayLabel.Enter += new System.EventHandler(this.BDDayLabel_Enter);
            this.BDDayLabel.Leave += new System.EventHandler(this.BDDayLabel_Leave);
            // 
            // AddNewBirthdayButton
            // 
            this.AddNewBirthdayButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddNewBirthdayButton.Location = new System.Drawing.Point(705, 562);
            this.AddNewBirthdayButton.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.AddNewBirthdayButton.Name = "AddNewBirthdayButton";
            this.AddNewBirthdayButton.Size = new System.Drawing.Size(250, 30);
            this.AddNewBirthdayButton.TabIndex = 14;
            this.AddNewBirthdayButton.Text = "ДОБАВИТЬ ДЕНЬ РОЖДЕНИЯ";
            this.AddNewBirthdayButton.UseVisualStyleBackColor = true;
            this.AddNewBirthdayButton.Click += new System.EventHandler(this.AddNewBirthdayButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExitButton.Location = new System.Drawing.Point(1298, 2);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(0);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(100, 30);
            this.ExitButton.TabIndex = 3;
            this.ExitButton.Text = "ВЫХОД";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // MinimizeButton
            // 
            this.MinimizeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MinimizeButton.Location = new System.Drawing.Point(1193, 2);
            this.MinimizeButton.Margin = new System.Windows.Forms.Padding(0);
            this.MinimizeButton.Name = "MinimizeButton";
            this.MinimizeButton.Size = new System.Drawing.Size(100, 30);
            this.MinimizeButton.TabIndex = 2;
            this.MinimizeButton.Text = "СВЕРНУТЬ";
            this.MinimizeButton.UseVisualStyleBackColor = true;
            this.MinimizeButton.Click += new System.EventHandler(this.MinimizeButton_Click);
            // 
            // RemindCheckbox
            // 
            this.RemindCheckbox.AutoSize = true;
            this.RemindCheckbox.Checked = true;
            this.RemindCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RemindCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RemindCheckbox.Location = new System.Drawing.Point(330, 4);
            this.RemindCheckbox.Margin = new System.Windows.Forms.Padding(5);
            this.RemindCheckbox.Name = "RemindCheckbox";
            this.RemindCheckbox.Size = new System.Drawing.Size(125, 21);
            this.RemindCheckbox.TabIndex = 1;
            this.RemindCheckbox.Text = "НАПОМИНАТЬ";
            this.RemindCheckbox.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(5, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 17);
            this.label5.TabIndex = 22;
            this.label5.Text = "Заголовки заметок:";
            // 
            // TopicPanelForPanels
            // 
            this.TopicPanelForPanels.AutoScroll = true;
            this.TopicPanelForPanels.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TopicPanelForPanels.Location = new System.Drawing.Point(705, 25);
            this.TopicPanelForPanels.Margin = new System.Windows.Forms.Padding(0);
            this.TopicPanelForPanels.Name = "TopicPanelForPanels";
            this.TopicPanelForPanels.Size = new System.Drawing.Size(690, 270);
            this.TopicPanelForPanels.TabIndex = 1;
            // 
            // HeaderPanelForPanels
            // 
            this.HeaderPanelForPanels.AutoScroll = true;
            this.HeaderPanelForPanels.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HeaderPanelForPanels.Location = new System.Drawing.Point(5, 25);
            this.HeaderPanelForPanels.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.HeaderPanelForPanels.Name = "HeaderPanelForPanels";
            this.HeaderPanelForPanels.Size = new System.Drawing.Size(690, 594);
            this.HeaderPanelForPanels.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(705, 5);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 17);
            this.label4.TabIndex = 22;
            this.label4.Text = "Разделы заметок:";
            // 
            // TopicChangeButton
            // 
            this.TopicChangeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TopicChangeButton.Location = new System.Drawing.Point(1235, 300);
            this.TopicChangeButton.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.TopicChangeButton.Name = "TopicChangeButton";
            this.TopicChangeButton.Size = new System.Drawing.Size(160, 30);
            this.TopicChangeButton.TabIndex = 21;
            this.TopicChangeButton.Text = "ЗАМЕНА РАЗДЕЛА";
            this.TopicChangeButton.UseVisualStyleBackColor = true;
            this.TopicChangeButton.Click += new System.EventHandler(this.TopicChangeButton_Click);
            // 
            // NewNoteButton
            // 
            this.NewNoteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NewNoteButton.Location = new System.Drawing.Point(1035, 300);
            this.NewNoteButton.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.NewNoteButton.Name = "NewNoteButton";
            this.NewNoteButton.Size = new System.Drawing.Size(160, 30);
            this.NewNoteButton.TabIndex = 16;
            this.NewNoteButton.Text = "НОВАЯ ЗАМЕТКА";
            this.NewNoteButton.UseVisualStyleBackColor = true;
            this.NewNoteButton.Click += new System.EventHandler(this.NewNoteButton_Click);
            // 
            // SaveNoteButton
            // 
            this.SaveNoteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveNoteButton.Location = new System.Drawing.Point(875, 300);
            this.SaveNoteButton.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.SaveNoteButton.Name = "SaveNoteButton";
            this.SaveNoteButton.Size = new System.Drawing.Size(120, 30);
            this.SaveNoteButton.TabIndex = 20;
            this.SaveNoteButton.Text = "СОХРАНИТЬ";
            this.SaveNoteButton.UseVisualStyleBackColor = true;
            this.SaveNoteButton.Click += new System.EventHandler(this.SaveNoteButton_Click);
            // 
            // DeleteHeaderButton
            // 
            this.DeleteHeaderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteHeaderButton.Location = new System.Drawing.Point(705, 300);
            this.DeleteHeaderButton.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.DeleteHeaderButton.Name = "DeleteHeaderButton";
            this.DeleteHeaderButton.Size = new System.Drawing.Size(160, 30);
            this.DeleteHeaderButton.TabIndex = 15;
            this.DeleteHeaderButton.Text = "УДАЛИТЬ ЗАМЕТКИ";
            this.DeleteHeaderButton.UseVisualStyleBackColor = true;
            this.DeleteHeaderButton.Click += new System.EventHandler(this.DeleteHeaderButton_Click);
            // 
            // CurrentNotePanel
            // 
            this.CurrentNotePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CurrentNotePanel.Controls.Add(this.NoteTopicCombobox);
            this.CurrentNotePanel.Controls.Add(this.NoteTopicLabel);
            this.CurrentNotePanel.Controls.Add(this.NoteCorrectionDateLabel);
            this.CurrentNotePanel.Controls.Add(this.NoteTextTextbox);
            this.CurrentNotePanel.Controls.Add(this.label6);
            this.CurrentNotePanel.Controls.Add(this.NoteHeaderTextbox);
            this.CurrentNotePanel.Controls.Add(this.NoteHeaderLabel);
            this.CurrentNotePanel.Controls.Add(this.NoteAboutCorrectionDateLabel);
            this.CurrentNotePanel.Location = new System.Drawing.Point(705, 335);
            this.CurrentNotePanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.CurrentNotePanel.Name = "CurrentNotePanel";
            this.CurrentNotePanel.Size = new System.Drawing.Size(690, 284);
            this.CurrentNotePanel.TabIndex = 8;
            // 
            // NoteTopicCombobox
            // 
            this.NoteTopicCombobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NoteTopicCombobox.FormattingEnabled = true;
            this.NoteTopicCombobox.Location = new System.Drawing.Point(230, 20);
            this.NoteTopicCombobox.Name = "NoteTopicCombobox";
            this.NoteTopicCombobox.Size = new System.Drawing.Size(456, 24);
            this.NoteTopicCombobox.Sorted = true;
            this.NoteTopicCombobox.TabIndex = 0;
            // 
            // NoteTopicLabel
            // 
            this.NoteTopicLabel.AutoSize = true;
            this.NoteTopicLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NoteTopicLabel.Location = new System.Drawing.Point(83, 24);
            this.NoteTopicLabel.Name = "NoteTopicLabel";
            this.NoteTopicLabel.Size = new System.Drawing.Size(118, 17);
            this.NoteTopicLabel.TabIndex = 22;
            this.NoteTopicLabel.Text = "Раздел заметки:";
            this.NoteTopicLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NoteCorrectionDateLabel
            // 
            this.NoteCorrectionDateLabel.AutoSize = true;
            this.NoteCorrectionDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NoteCorrectionDateLabel.Location = new System.Drawing.Point(230, 0);
            this.NoteCorrectionDateLabel.Name = "NoteCorrectionDateLabel";
            this.NoteCorrectionDateLabel.Size = new System.Drawing.Size(13, 17);
            this.NoteCorrectionDateLabel.TabIndex = 22;
            this.NoteCorrectionDateLabel.Text = "-";
            this.NoteCorrectionDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NoteTextTextbox
            // 
            this.NoteTextTextbox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NoteTextTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NoteTextTextbox.Location = new System.Drawing.Point(2, 71);
            this.NoteTextTextbox.Margin = new System.Windows.Forms.Padding(0);
            this.NoteTextTextbox.Multiline = true;
            this.NoteTextTextbox.Name = "NoteTextTextbox";
            this.NoteTextTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.NoteTextTextbox.Size = new System.Drawing.Size(684, 209);
            this.NoteTextTextbox.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(2, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 67);
            this.label6.TabIndex = 22;
            this.label6.Text = "ЗАМЕТКА";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NoteHeaderTextbox
            // 
            this.NoteHeaderTextbox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NoteHeaderTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NoteHeaderTextbox.Location = new System.Drawing.Point(230, 46);
            this.NoteHeaderTextbox.Margin = new System.Windows.Forms.Padding(0);
            this.NoteHeaderTextbox.Name = "NoteHeaderTextbox";
            this.NoteHeaderTextbox.Size = new System.Drawing.Size(456, 23);
            this.NoteHeaderTextbox.TabIndex = 18;
            // 
            // NoteHeaderLabel
            // 
            this.NoteHeaderLabel.AutoSize = true;
            this.NoteHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NoteHeaderLabel.Location = new System.Drawing.Point(83, 48);
            this.NoteHeaderLabel.Name = "NoteHeaderLabel";
            this.NoteHeaderLabel.Size = new System.Drawing.Size(138, 17);
            this.NoteHeaderLabel.TabIndex = 22;
            this.NoteHeaderLabel.Text = "Заголовок заметки:";
            this.NoteHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NoteAboutCorrectionDateLabel
            // 
            this.NoteAboutCorrectionDateLabel.AutoSize = true;
            this.NoteAboutCorrectionDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NoteAboutCorrectionDateLabel.Location = new System.Drawing.Point(83, 0);
            this.NoteAboutCorrectionDateLabel.Name = "NoteAboutCorrectionDateLabel";
            this.NoteAboutCorrectionDateLabel.Size = new System.Drawing.Size(96, 17);
            this.NoteAboutCorrectionDateLabel.TabIndex = 22;
            this.NoteAboutCorrectionDateLabel.Text = "Дата правки:";
            this.NoteAboutCorrectionDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BasicTabPanel
            // 
            this.BasicTabPanel.Controls.Add(this.ReminderTab);
            this.BasicTabPanel.Controls.Add(this.NotesTab);
            this.BasicTabPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BasicTabPanel.ItemSize = new System.Drawing.Size(200, 20);
            this.BasicTabPanel.Location = new System.Drawing.Point(0, 12);
            this.BasicTabPanel.Margin = new System.Windows.Forms.Padding(0);
            this.BasicTabPanel.Name = "BasicTabPanel";
            this.BasicTabPanel.SelectedIndex = 0;
            this.BasicTabPanel.Size = new System.Drawing.Size(1408, 653);
            this.BasicTabPanel.TabIndex = 2;
            // 
            // ReminderTab
            // 
            this.ReminderTab.Controls.Add(this.AddNewBirthdayButton);
            this.ReminderTab.Controls.Add(this.NewBirthdayPanel);
            this.ReminderTab.Controls.Add(this.BirthdayDeleteButton);
            this.ReminderTab.Controls.Add(this.BirthdayPanelForPanels);
            this.ReminderTab.Controls.Add(this.ControlDaysPanel);
            this.ReminderTab.Controls.Add(this.JobPanelForPanels);
            this.ReminderTab.Controls.Add(this.Future);
            this.ReminderTab.Controls.Add(this.AddJobButton);
            this.ReminderTab.Controls.Add(this.NewJobDescription);
            this.ReminderTab.Controls.Add(this.ShowOldOrNewButton);
            this.ReminderTab.Controls.Add(this.jobCalendar);
            this.ReminderTab.Controls.Add(this.DeleteJobsButton);
            this.ReminderTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ReminderTab.Location = new System.Drawing.Point(4, 24);
            this.ReminderTab.Margin = new System.Windows.Forms.Padding(0);
            this.ReminderTab.Name = "ReminderTab";
            this.ReminderTab.Size = new System.Drawing.Size(1400, 625);
            this.ReminderTab.TabIndex = 0;
            this.ReminderTab.Text = "ЗАДАЧИ И ДНИ РОЖДЕНИЯ";
            this.ReminderTab.UseVisualStyleBackColor = true;
            // 
            // ControlDaysPanel
            // 
            this.ControlDaysPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ControlDaysPanel.Controls.Add(this.ControlledDaysAmountUpdown);
            this.ControlDaysPanel.Controls.Add(this.label7);
            this.ControlDaysPanel.Controls.Add(this.RemindCheckbox);
            this.ControlDaysPanel.Location = new System.Drawing.Point(470, 40);
            this.ControlDaysPanel.Name = "ControlDaysPanel";
            this.ControlDaysPanel.Size = new System.Drawing.Size(460, 30);
            this.ControlDaysPanel.TabIndex = 9;
            // 
            // NotesTab
            // 
            this.NotesTab.Controls.Add(this.TopicChangeButton);
            this.NotesTab.Controls.Add(this.NewNoteButton);
            this.NotesTab.Controls.Add(this.DeleteHeaderButton);
            this.NotesTab.Controls.Add(this.HeaderPanelForPanels);
            this.NotesTab.Controls.Add(this.SaveNoteButton);
            this.NotesTab.Controls.Add(this.label5);
            this.NotesTab.Controls.Add(this.TopicPanelForPanels);
            this.NotesTab.Controls.Add(this.label4);
            this.NotesTab.Controls.Add(this.CurrentNotePanel);
            this.NotesTab.Location = new System.Drawing.Point(4, 24);
            this.NotesTab.Margin = new System.Windows.Forms.Padding(0);
            this.NotesTab.Name = "NotesTab";
            this.NotesTab.Size = new System.Drawing.Size(1400, 625);
            this.NotesTab.TabIndex = 1;
            this.NotesTab.Text = "ЗАМЕТКИ";
            this.NotesTab.UseVisualStyleBackColor = true;
            // 
            // MainProgForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1408, 665);
            this.ControlBox = false;
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.MinimizeButton);
            this.Controls.Add(this.BasicTabPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1424, 704);
            this.MinimumSize = new System.Drawing.Size(1424, 704);
            this.Name = "MainProgForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Note And Remind V 1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainProgForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Future.ResumeLayout(false);
            this.Future.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ControlledDaysAmountUpdown)).EndInit();
            this.NewBirthdayPanel.ResumeLayout(false);
            this.NewBirthdayPanel.PerformLayout();
            this.CurrentNotePanel.ResumeLayout(false);
            this.CurrentNotePanel.PerformLayout();
            this.BasicTabPanel.ResumeLayout(false);
            this.ReminderTab.ResumeLayout(false);
            this.ReminderTab.PerformLayout();
            this.ControlDaysPanel.ResumeLayout(false);
            this.ControlDaysPanel.PerformLayout();
            this.NotesTab.ResumeLayout(false);
            this.NotesTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Future;
        private System.Windows.Forms.Label JobsInFutureLabel;
        private System.Windows.Forms.Label AboutJobsLabel;
        private System.Windows.Forms.Button ShowOldOrNewButton;
        private System.Windows.Forms.DateTimePicker jobCalendar;
        private System.Windows.Forms.Button DeleteJobsButton;
        private System.Windows.Forms.TextBox NewJobDescription;
        private System.Windows.Forms.Button AddJobButton;
        private System.Windows.Forms.Button MinimizeButton;
        private System.Windows.Forms.CheckBox RemindCheckbox;
        private System.Windows.Forms.Panel JobPanelForPanels;
        private System.Windows.Forms.Label AboutBirthdaysLabel;
        private System.Windows.Forms.Panel BirthdayPanelForPanels;
        private System.Windows.Forms.Panel NewBirthdayPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox BDYearLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox BDMonthLabel;
        private System.Windows.Forms.TextBox BDDayLabel;
        private System.Windows.Forms.TextBox BDNameLabel;
        private System.Windows.Forms.Button AddNewBirthdayButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BirthdayDeleteButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Panel TopicPanelForPanels;
        private System.Windows.Forms.Panel HeaderPanelForPanels;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel CurrentNotePanel;
        private System.Windows.Forms.Label NoteAboutCorrectionDateLabel;
        private System.Windows.Forms.Label NoteHeaderLabel;
        private System.Windows.Forms.Button DeleteHeaderButton;
        private System.Windows.Forms.Label NoteCorrectionDateLabel;
        private System.Windows.Forms.TextBox NoteTextTextbox;
        private System.Windows.Forms.TextBox NoteHeaderTextbox;
        private System.Windows.Forms.Button SaveNoteButton;
        private System.Windows.Forms.Button NewNoteButton;
        private System.Windows.Forms.Label NoteTopicLabel;
        private System.Windows.Forms.Button TopicChangeButton;
        private Label label7;
        private NumericUpDown ControlledDaysAmountUpdown;
        private ComboBox NoteTopicCombobox;
        private TabControl BasicTabPanel;
        private TabPage ReminderTab;
        private TabPage NotesTab;
        private Panel ControlDaysPanel;
    }
}

