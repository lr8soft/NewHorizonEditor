﻿namespace NewHorizon
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.originObjectGroup = new System.Windows.Forms.GroupBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.declareTreeView = new System.Windows.Forms.TreeView();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.buttonAddOrigin = new System.Windows.Forms.Button();
            this.buttonDeleteOrigin = new System.Windows.Forms.Button();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.instanceObjectGroup = new System.Windows.Forms.GroupBox();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.InstanceObjectTreeView = new System.Windows.Forms.TreeView();
            this.splitContainer6 = new System.Windows.Forms.SplitContainer();
            this.buttonAddInstance = new System.Windows.Forms.Button();
            this.buttonDeleteInstance = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.撤销ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重做ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.originObjectGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.instanceObjectGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).BeginInit();
            this.splitContainer6.Panel1.SuspendLayout();
            this.splitContainer6.Panel2.SuspendLayout();
            this.splitContainer6.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.instanceObjectGroup);
            this.splitContainer1.Size = new System.Drawing.Size(800, 422);
            this.splitContainer1.SplitterDistance = 258;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.originObjectGroup);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.treeView2);
            this.splitContainer2.Size = new System.Drawing.Size(258, 422);
            this.splitContainer2.SplitterDistance = 286;
            this.splitContainer2.TabIndex = 0;
            // 
            // originObjectGroup
            // 
            this.originObjectGroup.Controls.Add(this.splitContainer3);
            this.originObjectGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.originObjectGroup.Location = new System.Drawing.Point(0, 0);
            this.originObjectGroup.Name = "originObjectGroup";
            this.originObjectGroup.Size = new System.Drawing.Size(258, 286);
            this.originObjectGroup.TabIndex = 0;
            this.originObjectGroup.TabStop = false;
            this.originObjectGroup.Text = "声明物体";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 21);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.declareTreeView);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(252, 262);
            this.splitContainer3.SplitterDistance = 207;
            this.splitContainer3.TabIndex = 0;
            // 
            // declareTreeView
            // 
            this.declareTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.declareTreeView.Location = new System.Drawing.Point(0, 0);
            this.declareTreeView.Name = "declareTreeView";
            this.declareTreeView.Size = new System.Drawing.Size(252, 207);
            this.declareTreeView.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.buttonAddOrigin);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.buttonDeleteOrigin);
            this.splitContainer4.Size = new System.Drawing.Size(252, 51);
            this.splitContainer4.SplitterDistance = 115;
            this.splitContainer4.TabIndex = 0;
            this.splitContainer4.Resize += new System.EventHandler(this.SplitContainerFixedWidth);
            // 
            // buttonAddOrigin
            // 
            this.buttonAddOrigin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddOrigin.Location = new System.Drawing.Point(0, 0);
            this.buttonAddOrigin.Name = "buttonAddOrigin";
            this.buttonAddOrigin.Size = new System.Drawing.Size(115, 51);
            this.buttonAddOrigin.TabIndex = 0;
            this.buttonAddOrigin.Text = "添加声明";
            this.buttonAddOrigin.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteOrigin
            // 
            this.buttonDeleteOrigin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDeleteOrigin.Location = new System.Drawing.Point(0, 0);
            this.buttonDeleteOrigin.Name = "buttonDeleteOrigin";
            this.buttonDeleteOrigin.Size = new System.Drawing.Size(133, 51);
            this.buttonDeleteOrigin.TabIndex = 0;
            this.buttonDeleteOrigin.Text = "删除声明";
            this.buttonDeleteOrigin.UseVisualStyleBackColor = true;
            // 
            // treeView2
            // 
            this.treeView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView2.Location = new System.Drawing.Point(0, 0);
            this.treeView2.Name = "treeView2";
            this.treeView2.Size = new System.Drawing.Size(258, 132);
            this.treeView2.TabIndex = 0;
            // 
            // instanceObjectGroup
            // 
            this.instanceObjectGroup.Controls.Add(this.splitContainer5);
            this.instanceObjectGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.instanceObjectGroup.Location = new System.Drawing.Point(0, 0);
            this.instanceObjectGroup.Name = "instanceObjectGroup";
            this.instanceObjectGroup.Size = new System.Drawing.Size(538, 422);
            this.instanceObjectGroup.TabIndex = 0;
            this.instanceObjectGroup.TabStop = false;
            this.instanceObjectGroup.Text = "实例化物体";
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(3, 21);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.InstanceObjectTreeView);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.splitContainer6);
            this.splitContainer5.Size = new System.Drawing.Size(532, 398);
            this.splitContainer5.SplitterDistance = 325;
            this.splitContainer5.TabIndex = 0;
            // 
            // InstanceObjectTreeView
            // 
            this.InstanceObjectTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InstanceObjectTreeView.Location = new System.Drawing.Point(0, 0);
            this.InstanceObjectTreeView.Name = "InstanceObjectTreeView";
            this.InstanceObjectTreeView.Size = new System.Drawing.Size(532, 325);
            this.InstanceObjectTreeView.TabIndex = 0;
            this.InstanceObjectTreeView.DoubleClick += new System.EventHandler(this.InstanceObjectTreeView_DoubleClick);
            // 
            // splitContainer6
            // 
            this.splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer6.Location = new System.Drawing.Point(0, 0);
            this.splitContainer6.Name = "splitContainer6";
            // 
            // splitContainer6.Panel1
            // 
            this.splitContainer6.Panel1.Controls.Add(this.buttonAddInstance);
            this.splitContainer6.Panel1MinSize = 50;
            // 
            // splitContainer6.Panel2
            // 
            this.splitContainer6.Panel2.Controls.Add(this.buttonDeleteInstance);
            this.splitContainer6.Panel2MinSize = 50;
            this.splitContainer6.Size = new System.Drawing.Size(532, 69);
            this.splitContainer6.SplitterDistance = 263;
            this.splitContainer6.TabIndex = 0;
            this.splitContainer6.Resize += new System.EventHandler(this.SplitContainerFixedWidth);
            // 
            // buttonAddInstance
            // 
            this.buttonAddInstance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddInstance.Location = new System.Drawing.Point(0, 0);
            this.buttonAddInstance.Name = "buttonAddInstance";
            this.buttonAddInstance.Size = new System.Drawing.Size(263, 69);
            this.buttonAddInstance.TabIndex = 0;
            this.buttonAddInstance.Text = "添加实例";
            this.buttonAddInstance.UseVisualStyleBackColor = true;
            this.buttonAddInstance.Click += new System.EventHandler(this.buttonAddInstance_Click);
            // 
            // buttonDeleteInstance
            // 
            this.buttonDeleteInstance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDeleteInstance.Location = new System.Drawing.Point(0, 0);
            this.buttonDeleteInstance.Name = "buttonDeleteInstance";
            this.buttonDeleteInstance.Size = new System.Drawing.Size(265, 69);
            this.buttonDeleteInstance.TabIndex = 0;
            this.buttonDeleteInstance.Text = "删除实例";
            this.buttonDeleteInstance.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem,
            this.编辑EToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开OToolStripMenuItem});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
            this.文件FToolStripMenuItem.Text = "文件(F)";
            // 
            // 打开OToolStripMenuItem
            // 
            this.打开OToolStripMenuItem.Name = "打开OToolStripMenuItem";
            this.打开OToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.打开OToolStripMenuItem.Text = "打开项目(O)";
            this.打开OToolStripMenuItem.Click += new System.EventHandler(this.打开OToolStripMenuItem_Click);
            // 
            // 编辑EToolStripMenuItem
            // 
            this.编辑EToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.撤销ToolStripMenuItem,
            this.重做ToolStripMenuItem});
            this.编辑EToolStripMenuItem.Name = "编辑EToolStripMenuItem";
            this.编辑EToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
            this.编辑EToolStripMenuItem.Text = "编辑(E)";
            // 
            // 撤销ToolStripMenuItem
            // 
            this.撤销ToolStripMenuItem.Name = "撤销ToolStripMenuItem";
            this.撤销ToolStripMenuItem.Size = new System.Drawing.Size(114, 26);
            this.撤销ToolStripMenuItem.Text = "撤销";
            // 
            // 重做ToolStripMenuItem
            // 
            this.重做ToolStripMenuItem.Name = "重做ToolStripMenuItem";
            this.重做ToolStripMenuItem.Size = new System.Drawing.Size(114, 26);
            this.重做ToolStripMenuItem.Text = "重做";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "NewHorizon Editor";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.originObjectGroup.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.instanceObjectGroup.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.splitContainer6.Panel1.ResumeLayout(false);
            this.splitContainer6.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).EndInit();
            this.splitContainer6.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox originObjectGroup;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.GroupBox instanceObjectGroup;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.SplitContainer splitContainer6;
        private System.Windows.Forms.Button buttonAddInstance;
        private System.Windows.Forms.Button buttonDeleteInstance;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Button buttonAddOrigin;
        private System.Windows.Forms.Button buttonDeleteOrigin;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开OToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 撤销ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重做ToolStripMenuItem;
        public System.Windows.Forms.TreeView declareTreeView;
        public System.Windows.Forms.TreeView InstanceObjectTreeView;
        public System.Windows.Forms.TreeView treeView2;
    }
}

