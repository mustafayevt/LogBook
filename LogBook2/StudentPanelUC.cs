using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogBook2.Properties;
namespace LogBook2
{
    public partial class StudentPanelUC : UserControl
    {
        public EventHandler<EventArgs> DiamondClick { get; set; }
        public EventHandler<EventArgs> TogleRedGreen { get; set; }
        public bool Togle { get; set; }
        public string studentNumber { get => studentNumLbl.Text; set => studentNumLbl.Text = value; }
        public string studentName { get => StudentNameLbl.Text; set => StudentNameLbl.Text = value; }
        public StudentPanelUC()
        {
            InitializeComponent();
            if(int.TryParse(studentNumber, out int index))
            TogleRedGreen += TogleAll;
            HWCmbx.SelectedIndex = 0;
            CWCmbx.SelectedIndex = 0;
        }
        public bool[] crysState = new bool[3];

        private void TogleAll(object sender, EventArgs e)
        {
            greenRdbtn.Checked = !Togle;
            redRdbtn.Checked = Togle;
        }

        private void crys1_Click(object sender, EventArgs e)
        {
            if (crysState[1] && crysState[2]) return;
            else if (!crysState[0] && LogBookMain.data.TeacherMaxDiamond >= 1)
            {
                crys1.Image = Resources.Diamond_26pxBlue;
                crysState[0] = true;
                LogBookMain.data.TeacherMaxDiamond--;
                LogBookMain.data.studentsDiamond[int.Parse(studentNumber) - 1]++;
                DiamondClick.Invoke(sender, e);
            }
        }

        private void crys2_Click(object sender, EventArgs e)
        {
            if((!crysState[1] && LogBookMain.data.TeacherMaxDiamond >= 2) || (crysState[0]&&LogBookMain.data.TeacherMaxDiamond>=1))
            {
                crys1.Image = Resources.Diamond_26pxBlue;
                crys2.Image = Resources.Diamond_26pxBlue;
                crys1_Click(sender, e);
                crysState[0] = true;
                crysState[1] = true;
                LogBookMain.data.studentsDiamond[int.Parse(studentNumber) - 1]++;
                LogBookMain.data.TeacherMaxDiamond --;
                DiamondClick.Invoke(sender, e);
            }
        }

        private void crys3_Click(object sender, EventArgs e)
        {
            if(!crysState[2] && LogBookMain.data.TeacherMaxDiamond>=3)
            {
                crys1.Image = Resources.Diamond_26pxBlue;
                crys2.Image = Resources.Diamond_26pxBlue;
                crys3.Image = Resources.Diamond_26pxBlue;
                crys1_Click(sender, e);
                crys2_Click(sender, e);
                crysState[0] = true;
                crysState[1] = true;
                crysState[2] = true;
                LogBookMain.data.studentsDiamond[int.Parse(studentNumber) - 1]++;
                LogBookMain.data.TeacherMaxDiamond -- ;
                DiamondClick.Invoke(sender, e);
            }
        }

        private void redRdbtn_CheckedChanged(object sender, EventArgs e)
        {
            EnabledDisabledPanel.Enabled = !redRdbtn.Checked;
            if (redRdbtn.Checked)
            {
                HWCmbx.SelectedIndex = 0;
                CWCmbx.SelectedIndex = 0;
                delCrys_Click(sender, e);
            }
        }
        
        private void delCrys_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < crysState.Length; i++)
            {
                if (crysState[i]) LogBookMain.data.TeacherMaxDiamond++;
            }
            crysState = new bool[3];
            LogBookMain.data.studentsDiamond[int.Parse(studentNumber) - 1] = 0;
            crys1.Image = Resources.Diamond_26px;
            crys2.Image = Resources.Diamond_26px;
            crys3.Image = Resources.Diamond_26px;
            DiamondClick.Invoke(sender, e);
        }

        private void StudentCommentTxtbx_TextChanged(object sender, EventArgs e)
        {
            if(int.TryParse(studentNumber, out int index))
            LogBookMain.data.studentsComment[index - 1] = StudentCommentTxtbx.Text;
        }

        private void comment_Click(object sender, EventArgs e)
        {
            StudentCommentTxtbx.Visible = !StudentCommentTxtbx.Visible;
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            BigSizePic.Visible = !BigSizePic.Visible;
        }
    }
}
