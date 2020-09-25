using System.Windows.Forms;

namespace GlobalMetadataEditor.GUI
{
    partial class Editor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.另存文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.letterCase = new System.Windows.Forms.CheckBox();
            this.wholeWord = new System.Windows.Forms.CheckBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.editableListView = new GlobalMetadataEditor.GUI.EditableListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.original = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.replace = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hasModify = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(908, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开文件ToolStripMenuItem,
            this.保存文件ToolStripMenuItem,
            this.另存文件ToolStripMenuItem,
            this.关闭文件ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 打开文件ToolStripMenuItem
            // 
            this.打开文件ToolStripMenuItem.Name = "打开文件ToolStripMenuItem";
            this.打开文件ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.打开文件ToolStripMenuItem.Text = "打开文件";
            this.打开文件ToolStripMenuItem.Click += new System.EventHandler(this.OpenFile);
            // 
            // 保存文件ToolStripMenuItem
            // 
            this.保存文件ToolStripMenuItem.Name = "保存文件ToolStripMenuItem";
            this.保存文件ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.保存文件ToolStripMenuItem.Text = "保存文件";
            this.保存文件ToolStripMenuItem.Click += new System.EventHandler(this.SaveFile);
            // 
            // 另存文件ToolStripMenuItem
            // 
            this.另存文件ToolStripMenuItem.Name = "另存文件ToolStripMenuItem";
            this.另存文件ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.另存文件ToolStripMenuItem.Text = "另存文件";
            this.另存文件ToolStripMenuItem.Click += new System.EventHandler(this.SaveAs);
            // 
            // 关闭文件ToolStripMenuItem
            // 
            this.关闭文件ToolStripMenuItem.Name = "关闭文件ToolStripMenuItem";
            this.关闭文件ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.关闭文件ToolStripMenuItem.Text = "关闭文件";
            this.关闭文件ToolStripMenuItem.Click += new System.EventHandler(this.CloseFile);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(600, 25);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(618, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 2;
            this.button1.Text = "下一个";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnNextButtonClick);
            // 
            // letterCase
            // 
            this.letterCase.AutoSize = true;
            this.letterCase.Location = new System.Drawing.Point(699, 35);
            this.letterCase.Name = "letterCase";
            this.letterCase.Size = new System.Drawing.Size(74, 19);
            this.letterCase.TabIndex = 3;
            this.letterCase.Text = "大小写";
            this.letterCase.UseVisualStyleBackColor = true;
            // 
            // wholeWord
            // 
            this.wholeWord.AutoSize = true;
            this.wholeWord.Location = new System.Drawing.Point(785, 35);
            this.wholeWord.Name = "wholeWord";
            this.wholeWord.Size = new System.Drawing.Size(59, 19);
            this.wholeWord.TabIndex = 4;
            this.wholeWord.Text = "整词";
            this.wholeWord.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "global-metadata.dat";
            this.openFileDialog1.Filter = "global-metadata.dat|global-metadata.dat|所有文件|*.*";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "global-metadata.dat";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 506);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(908, 25);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(84, 20);
            this.toolStripStatusLabel1.Text = "字符串修改";
            // 
            // editableListView
            // 
            this.editableListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.original,
            this.replace,
            this.hasModify});
            this.editableListView.FullRowSelect = true;
            this.editableListView.GridLines = true;
            this.editableListView.HideSelection = false;
            this.editableListView.Location = new System.Drawing.Point(12, 62);
            this.editableListView.MultiSelect = false;
            this.editableListView.Name = "editableListView";
            this.editableListView.Size = new System.Drawing.Size(884, 457);
            this.editableListView.TabIndex = 5;
            this.editableListView.UseCompatibleStateImageBehavior = false;
            this.editableListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "索引";
            this.columnHeader1.Width = 42;
            // 
            // original
            // 
            this.original.Text = "原始字符";
            this.original.Width = 248;
            // 
            // replace
            // 
            this.replace.Text = "替换字符";
            this.replace.Width = 267;
            // 
            // hasModify
            // 
            this.hasModify.Text = "是否修改";
            this.hasModify.Width = 72;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(618, 60);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 25);
            this.button2.TabIndex = 7;
            this.button2.Text = "上一个";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.OnPreButtonClick);
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(908, 531);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.editableListView);
            this.Controls.Add(this.wholeWord);
            this.Controls.Add(this.letterCase);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Editor";
            this.Text = "global-metadata Editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 另存文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox letterCase;
        private System.Windows.Forms.CheckBox wholeWord;
        //private System.Windows.Forms.ListView listView1;
        private EditableListView editableListView;
        private ColumnHeader original;
        private ColumnHeader replace;
        private ColumnHeader hasModify;
        private ColumnHeader columnHeader1;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Button button2;
    }
}