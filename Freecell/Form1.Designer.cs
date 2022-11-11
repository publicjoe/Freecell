namespace Freecell
{
  partial class Form1
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.FreePanel = new System.Windows.Forms.Panel();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.dealToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.newDealToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveDealToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.loadDealToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.FinalPanel = new System.Windows.Forms.Panel();
      this.DealAreaPanel = new System.Windows.Forms.Panel();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // FreePanel
      // 
      this.FreePanel.BackColor = System.Drawing.Color.Green;
      this.FreePanel.Location = new System.Drawing.Point(0, 24);
      this.FreePanel.Name = "FreePanel";
      this.FreePanel.Size = new System.Drawing.Size(300, 100);
      this.FreePanel.TabIndex = 0;
      this.FreePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.FreePanel_Paint);
      this.FreePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FreePanel_MouseDown);
      // 
      // menuStrip1
      // 
      this.menuStrip1.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
      this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dealToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(632, 24);
      this.menuStrip1.TabIndex = 1;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // dealToolStripMenuItem
      // 
      this.dealToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDealToolStripMenuItem,
            this.saveDealToolStripMenuItem,
            this.loadDealToolStripMenuItem,
            this.quitToolStripMenuItem});
      this.dealToolStripMenuItem.Name = "dealToolStripMenuItem";
      this.dealToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
      this.dealToolStripMenuItem.Text = "Deal";
      // 
      // newDealToolStripMenuItem
      // 
      this.newDealToolStripMenuItem.Name = "newDealToolStripMenuItem";
      this.newDealToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
      this.newDealToolStripMenuItem.Text = "New Deal";
      this.newDealToolStripMenuItem.Click += new System.EventHandler(this.newDealToolStripMenuItem_Click);
      // 
      // saveDealToolStripMenuItem
      // 
      this.saveDealToolStripMenuItem.Name = "saveDealToolStripMenuItem";
      this.saveDealToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
      this.saveDealToolStripMenuItem.Text = "Save Deal";
      this.saveDealToolStripMenuItem.Click += new System.EventHandler(this.saveDealToolStripMenuItem_Click);
      // 
      // loadDealToolStripMenuItem
      // 
      this.loadDealToolStripMenuItem.Name = "loadDealToolStripMenuItem";
      this.loadDealToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
      this.loadDealToolStripMenuItem.Text = "Load Deal";
      this.loadDealToolStripMenuItem.Click += new System.EventHandler(this.loadDealToolStripMenuItem_Click);
      // 
      // quitToolStripMenuItem
      // 
      this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
      this.quitToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
      this.quitToolStripMenuItem.Text = "Quit";
      this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
      // 
      // FinalPanel
      // 
      this.FinalPanel.BackColor = System.Drawing.Color.Green;
      this.FinalPanel.Location = new System.Drawing.Point(332, 24);
      this.FinalPanel.Name = "FinalPanel";
      this.FinalPanel.Size = new System.Drawing.Size(300, 100);
      this.FinalPanel.TabIndex = 2;
      this.FinalPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.FinalPanel_Paint);
      this.FinalPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FinalPanel_MouseDown);
      // 
      // DealAreaPanel
      // 
      this.DealAreaPanel.BackColor = System.Drawing.Color.Green;
      this.DealAreaPanel.Location = new System.Drawing.Point(0, 130);
      this.DealAreaPanel.Name = "DealAreaPanel";
      this.DealAreaPanel.Size = new System.Drawing.Size(632, 316);
      this.DealAreaPanel.TabIndex = 3;
      this.DealAreaPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.DealAreaPanel_Paint);
      this.DealAreaPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DealAreaPanel_MouseDown);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Green;
      this.ClientSize = new System.Drawing.Size(632, 446);
      this.Controls.Add(this.DealAreaPanel);
      this.Controls.Add(this.FinalPanel);
      this.Controls.Add(this.FreePanel);
      this.Controls.Add(this.menuStrip1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.menuStrip1;
      this.MaximumSize = new System.Drawing.Size(640, 640);
      this.MinimumSize = new System.Drawing.Size(640, 480);
      this.Name = "Form1";
      this.Text = "Freecell";
      this.Resize += new System.EventHandler(this.Form1_Resize);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel FreePanel;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem dealToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem newDealToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveDealToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem loadDealToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
    private System.Windows.Forms.Panel FinalPanel;
    private System.Windows.Forms.Panel DealAreaPanel;
  }
}

