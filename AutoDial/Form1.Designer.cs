namespace AutoDial
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.AutoDialIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showHideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.executeProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // AutoDialIcon
            // 
            this.AutoDialIcon.ContextMenuStrip = this.contextMenuStrip;
            this.AutoDialIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("AutoDialIcon.Icon")));
            this.AutoDialIcon.Text = "AutoDial";
            this.AutoDialIcon.Visible = true;
            this.AutoDialIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.AutoDialIcon_MouseDoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.executeProgramToolStripMenuItem,
            this.showHideToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(164, 92);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // showHideToolStripMenuItem
            // 
            this.showHideToolStripMenuItem.Name = "showHideToolStripMenuItem";
            this.showHideToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.showHideToolStripMenuItem.Text = "Show/Hide";
            this.showHideToolStripMenuItem.Click += new System.EventHandler(this.showHideToolStripMenuItem_Click);
            // 
            // executeProgramToolStripMenuItem
            // 
            this.executeProgramToolStripMenuItem.Name = "executeProgramToolStripMenuItem";
            this.executeProgramToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.executeProgramToolStripMenuItem.Text = "Execute Program";
            this.executeProgramToolStripMenuItem.Click += new System.EventHandler(this.executeProgramToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 300);
            this.ContextMenuStrip = this.contextMenuStrip;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon AutoDialIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showHideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem executeProgramToolStripMenuItem;
    }
}

