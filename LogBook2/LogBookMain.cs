using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogBook2
{
    public partial class LogBookMain : MetroFramework.Forms.MetroForm
    {
        public LogBookMain()
        {
            InitializeComponent();
            int i = 8;
            foreach (var item in MainPanel.Controls)
            {
                if (item is StudentPanelUC)
                {
                    (item as StudentPanelUC).DiamondClick += UpdateDiamondLbl;
                    (item as StudentPanelUC).studentName = data.studentsName[--i];
                    (item as StudentPanelUC).studentNumber = (i+1).ToString();
                }
            }
        }
        public static Data data = new Data();
        void UpdateDiamondLbl(object sender, EventArgs e)
        {
            TeacherDiamondLbl.Text = data.TeacherMaxDiamond.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LessonThemeTxtbx.Visible = !LessonThemeTxtbx.Visible;
        }

        private void LessonThemeTxtbx_TextChanged(object sender, EventArgs e)
        {
            MainPanel.Enabled = LessonThemeTxtbx.Text.Length != 0;
            LessonThemeEditLbl.Text = LessonThemeTxtbx.Text;
            data.Lesson = LessonThemeTxtbx.Text;
        }

        private void checkAllChkbx_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var item in MainPanel.Controls)
            {
                if(item is StudentPanelUC)
                {
                    (item as StudentPanelUC).TogleRedGreen.Invoke(sender,e);
                    (item as StudentPanelUC).Togle = checkAllChkbx.Checked;
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Json File|*.json";
            if(save.ShowDialog()==DialogResult.OK)
            {
                var json = JsonConvert.SerializeObject(data);
                File.WriteAllText(save.FileName, json);
            }
        }
    }
}
