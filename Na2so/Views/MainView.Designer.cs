
namespace Na2so.Views
{
    partial class MainView
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
            this.pnlTopMenu = new System.Windows.Forms.Panel();
            this.pnlSideMenu = new System.Windows.Forms.Panel();
            this.btnMemberList = new System.Windows.Forms.Button();
            this.pnlView = new System.Windows.Forms.Panel();
            this.btnGameList = new System.Windows.Forms.Button();
            this.btnDues = new System.Windows.Forms.Button();
            this.pnlSideMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTopMenu
            // 
            this.pnlTopMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(38)))), ((int)(((byte)(58)))));
            this.pnlTopMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlTopMenu.Name = "pnlTopMenu";
            this.pnlTopMenu.Size = new System.Drawing.Size(874, 63);
            this.pnlTopMenu.TabIndex = 0;
            // 
            // pnlSideMenu
            // 
            this.pnlSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.pnlSideMenu.Controls.Add(this.btnDues);
            this.pnlSideMenu.Controls.Add(this.btnGameList);
            this.pnlSideMenu.Controls.Add(this.btnMemberList);
            this.pnlSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSideMenu.Location = new System.Drawing.Point(0, 63);
            this.pnlSideMenu.Name = "pnlSideMenu";
            this.pnlSideMenu.Size = new System.Drawing.Size(140, 538);
            this.pnlSideMenu.TabIndex = 1;
            // 
            // btnMemberList
            // 
            this.btnMemberList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(58)))), ((int)(((byte)(88)))));
            this.btnMemberList.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMemberList.FlatAppearance.BorderSize = 0;
            this.btnMemberList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMemberList.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.btnMemberList.ForeColor = System.Drawing.Color.White;
            this.btnMemberList.Location = new System.Drawing.Point(0, 0);
            this.btnMemberList.Name = "btnMemberList";
            this.btnMemberList.Size = new System.Drawing.Size(140, 40);
            this.btnMemberList.TabIndex = 0;
            this.btnMemberList.Text = "회원관리";
            this.btnMemberList.UseVisualStyleBackColor = false;
            // 
            // pnlView
            // 
            this.pnlView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlView.Location = new System.Drawing.Point(140, 63);
            this.pnlView.Name = "pnlView";
            this.pnlView.Size = new System.Drawing.Size(734, 538);
            this.pnlView.TabIndex = 2;
            // 
            // btnGameList
            // 
            this.btnGameList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(58)))), ((int)(((byte)(88)))));
            this.btnGameList.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGameList.FlatAppearance.BorderSize = 0;
            this.btnGameList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGameList.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.btnGameList.ForeColor = System.Drawing.Color.White;
            this.btnGameList.Location = new System.Drawing.Point(0, 40);
            this.btnGameList.Name = "btnGameList";
            this.btnGameList.Size = new System.Drawing.Size(140, 40);
            this.btnGameList.TabIndex = 1;
            this.btnGameList.Text = "모임목록";
            this.btnGameList.UseVisualStyleBackColor = false;
            // 
            // btnDues
            // 
            this.btnDues.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(58)))), ((int)(((byte)(88)))));
            this.btnDues.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDues.FlatAppearance.BorderSize = 0;
            this.btnDues.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDues.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.btnDues.ForeColor = System.Drawing.Color.White;
            this.btnDues.Location = new System.Drawing.Point(0, 80);
            this.btnDues.Name = "btnDues";
            this.btnDues.Size = new System.Drawing.Size(140, 40);
            this.btnDues.TabIndex = 2;
            this.btnDues.Text = "회비관리";
            this.btnDues.UseVisualStyleBackColor = false;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 601);
            this.Controls.Add(this.pnlView);
            this.Controls.Add(this.pnlSideMenu);
            this.Controls.Add(this.pnlTopMenu);
            this.Name = "MainView";
            this.Text = "MainView";
            this.pnlSideMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTopMenu;
        private System.Windows.Forms.Panel pnlSideMenu;
        private System.Windows.Forms.Panel pnlView;
        private System.Windows.Forms.Button btnMemberList;
        private System.Windows.Forms.Button btnDues;
        private System.Windows.Forms.Button btnGameList;
    }
}