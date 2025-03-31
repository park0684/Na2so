using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Na2so.Helpers;
using Na2so.Presenters;

namespace Na2so.Views
{
    public partial class MemberDetailView : Form, IMemberDetailView
    {

        public MemberDetailView()
        {
            InitializeComponent();
            InitializeComboBox();
            ViewEvent();
            SecessDatePickerSet(cmbStatus, EventArgs.Empty);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            ControlBox = false;
        }

        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;
        private void ViewEvent()
        {
            btnClose.Click += (s, e) => CancelEvent?.Invoke(s, e);
            btnOk.Click += (s, e) => SaveEvent?.Invoke(s, e);
            cmbStatus.SelectedIndexChanged += SecessDatePickerSet;
        }

        private void SecessDatePickerSet(object sender, EventArgs e)
        {
            if (((KeyValuePair<int, string>)cmbStatus.SelectedItem).Key != 2)
            {
                dtpSecessDate.Enabled = false;
            }
            else
            {
                dtpSecessDate.Enabled = true;
            }
        }

        private void InitializeComboBox()
        {
            foreach (var item in MemberHelper.MemStatus)
            {
                cmbStatus.Items.Add(new KeyValuePair<int, string>(item.Key, item.Value));
            }
            cmbStatus.DisplayMember = "Value";
            cmbStatus.ValueMember = "key";
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.SelectedIndex = 0;

            foreach (var item in MemberHelper.MemGender)
            {
                cmbGender.Items.Add(new KeyValuePair<int, string>(item.Key, item.Value));
            }
            cmbGender.DisplayMember = "Value";
            cmbGender.ValueMember = "key";
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGender.SelectedIndex = 1;

            foreach (var item in MemberHelper.MemPosition)
            {
                cmbPosition.Items.Add(new KeyValuePair<int, string>(item.Key, item.Value));
            }
            cmbPosition.DisplayMember = "Value";
            cmbPosition.ValueMember = "key";
            cmbPosition.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPosition.SelectedIndex = 3;
        }
        public void CloseForm()
        {
            this.Close();
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "알림");
        }

        public string MemberName
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }

        public string Birth
        {
            get { return txtBrithYear.Text; }
            set { txtBrithYear.Text = value; }
        }

        public string Memo
        {
            get { return txtMemo.Text; }
            set { txtMemo.Text =value; }
        }

        public int? Status
        {
            get { return ((KeyValuePair<int,string>)cmbStatus.SelectedItem).Key; }
            set 
            {
                if (value.HasValue)
                {
                    int index = cmbStatus.Items.Cast<KeyValuePair<int, string>>().ToList().FindIndex(item => item.Key == value.Value);
                    if (index >= 0)
                    {
                        cmbStatus.SelectedIndex = index;
                    }
                }
            }
        }

        public int? Position
        {
            get { return ((KeyValuePair<int, string>)cmbPosition.SelectedItem).Key; }
            set
            {
                if (value.HasValue)
                {
                    int index = cmbPosition.Items.Cast<KeyValuePair<int, string>>().ToList().FindIndex(item => item.Key == value.Value);
                    if (index >= 0)
                    {
                        cmbPosition.SelectedIndex = index;
                    }
                }
            }
        }

        public int? Gender
        {
            get { return ((KeyValuePair<int, string>)cmbGender.SelectedItem).Key; }
            set
            {
                if (value.HasValue)
                {
                    int index = cmbGender.Items.Cast<KeyValuePair<int, string>>().ToList().FindIndex(item => item.Key == value.Value);
                    if (index >= 0)
                    {
                        cmbGender.SelectedIndex = index;
                    }
                }
            }
        }

        public DateTime? AccessDate
        {
            get { return dtpAccessDate.Value; }
            set { dtpAccessDate.Value = (DateTime)value; }
        }

        public DateTime? SecessDate
        {
            get { return dtpSecessDate.Value; }
            set { dtpSecessDate.Value = (DateTime)value; }
        }


    }
}
