
namespace Na2so.Views
{
    partial class DuesManageView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlMember = new System.Windows.Forms.Panel();
            this.btnSearchMember = new System.Windows.Forms.Button();
            this.txtSearchWord = new System.Windows.Forms.TextBox();
            this.btnPost = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.pnlStatemet = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.chkSeceInculde = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // pnlMember
            // 
            this.pnlMember.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlMember.Location = new System.Drawing.Point(12, 95);
            this.pnlMember.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlMember.Name = "pnlMember";
            this.pnlMember.Size = new System.Drawing.Size(265, 391);
            this.pnlMember.TabIndex = 0;
            // 
            // btnSearchMember
            // 
            this.btnSearchMember.BackColor = System.Drawing.Color.Black;
            this.btnSearchMember.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchMember.ForeColor = System.Drawing.Color.White;
            this.btnSearchMember.Location = new System.Drawing.Point(119, 12);
            this.btnSearchMember.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSearchMember.Name = "btnSearchMember";
            this.btnSearchMember.Size = new System.Drawing.Size(75, 38);
            this.btnSearchMember.TabIndex = 2;
            this.btnSearchMember.Text = "검색";
            this.btnSearchMember.UseVisualStyleBackColor = false;
            // 
            // txtSearchWord
            // 
            this.txtSearchWord.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.txtSearchWord.Location = new System.Drawing.Point(12, 21);
            this.txtSearchWord.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchWord.Name = "txtSearchWord";
            this.txtSearchWord.Size = new System.Drawing.Size(101, 23);
            this.txtSearchWord.TabIndex = 3;
            // 
            // btnPost
            // 
            this.btnPost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPost.Location = new System.Drawing.Point(601, 21);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(24, 30);
            this.btnPost.TabIndex = 6;
            this.btnPost.Text = "▷";
            this.btnPost.UseVisualStyleBackColor = true;
            // 
            // btnPre
            // 
            this.btnPre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPre.Location = new System.Drawing.Point(351, 21);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(24, 30);
            this.btnPre.TabIndex = 7;
            this.btnPre.Text = "◁";
            this.btnPre.UseVisualStyleBackColor = true;
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(496, 24);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(99, 23);
            this.dtpToDate.TabIndex = 4;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(381, 24);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(99, 23);
            this.dtpFromDate.TabIndex = 5;
            // 
            // pnlStatemet
            // 
            this.pnlStatemet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlStatemet.Location = new System.Drawing.Point(291, 95);
            this.pnlStatemet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlStatemet.Name = "pnlStatemet";
            this.pnlStatemet.Size = new System.Drawing.Size(415, 391);
            this.pnlStatemet.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.Black;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(631, 16);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 38);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "등록";
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // chkSeceInculde
            // 
            this.chkSeceInculde.AutoSize = true;
            this.chkSeceInculde.Location = new System.Drawing.Point(12, 51);
            this.chkSeceInculde.Name = "chkSeceInculde";
            this.chkSeceInculde.Size = new System.Drawing.Size(74, 19);
            this.chkSeceInculde.TabIndex = 8;
            this.chkSeceInculde.Text = "탈퇴포함";
            this.chkSeceInculde.UseVisualStyleBackColor = true;
            // 
            // DuesManageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 499);
            this.Controls.Add(this.chkSeceInculde);
            this.Controls.Add(this.btnPost);
            this.Controls.Add(this.btnPre);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.txtSearchWord);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSearchMember);
            this.Controls.Add(this.pnlStatemet);
            this.Controls.Add(this.pnlMember);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DuesManageView";
            this.Text = "DuesManageView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlMember;
        private System.Windows.Forms.Button btnSearchMember;
        private System.Windows.Forms.TextBox txtSearchWord;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Panel pnlStatemet;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.CheckBox chkSeceInculde;
    }
}