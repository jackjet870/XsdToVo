namespace Demo
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtboxNameSpace = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtboxBaseXsd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtboxAnalXsd = new System.Windows.Forms.TextBox();
            this.btnBaseXsd = new System.Windows.Forms.Button();
            this.btnAnalXsd = new System.Windows.Forms.Button();
            this.btnOrg = new System.Windows.Forms.Button();
            this.btnNotice = new System.Windows.Forms.Button();
            this.btnCs = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnPath = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "命名空间：";
            // 
            // txtboxNameSpace
            // 
            this.txtboxNameSpace.Location = new System.Drawing.Point(105, 10);
            this.txtboxNameSpace.Name = "txtboxNameSpace";
            this.txtboxNameSpace.Size = new System.Drawing.Size(310, 21);
            this.txtboxNameSpace.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "基础类型XSD：";
            // 
            // txtboxBaseXsd
            // 
            this.txtboxBaseXsd.Location = new System.Drawing.Point(105, 59);
            this.txtboxBaseXsd.Name = "txtboxBaseXsd";
            this.txtboxBaseXsd.ReadOnly = true;
            this.txtboxBaseXsd.Size = new System.Drawing.Size(310, 21);
            this.txtboxBaseXsd.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "要解析的XSD：";
            // 
            // txtboxAnalXsd
            // 
            this.txtboxAnalXsd.Location = new System.Drawing.Point(105, 113);
            this.txtboxAnalXsd.Name = "txtboxAnalXsd";
            this.txtboxAnalXsd.ReadOnly = true;
            this.txtboxAnalXsd.Size = new System.Drawing.Size(310, 21);
            this.txtboxAnalXsd.TabIndex = 5;
            // 
            // btnBaseXsd
            // 
            this.btnBaseXsd.Location = new System.Drawing.Point(449, 57);
            this.btnBaseXsd.Name = "btnBaseXsd";
            this.btnBaseXsd.Size = new System.Drawing.Size(119, 23);
            this.btnBaseXsd.TabIndex = 6;
            this.btnBaseXsd.Text = "导入基础XSD";
            this.btnBaseXsd.UseVisualStyleBackColor = true;
            this.btnBaseXsd.Click += new System.EventHandler(this.btnBaseXsd_Click);
            // 
            // btnAnalXsd
            // 
            this.btnAnalXsd.Location = new System.Drawing.Point(449, 105);
            this.btnAnalXsd.Name = "btnAnalXsd";
            this.btnAnalXsd.Size = new System.Drawing.Size(119, 23);
            this.btnAnalXsd.TabIndex = 6;
            this.btnAnalXsd.Text = "导入解析XSD";
            this.btnAnalXsd.UseVisualStyleBackColor = true;
            this.btnAnalXsd.Click += new System.EventHandler(this.btnAnalXsd_Click);
            // 
            // btnOrg
            // 
            this.btnOrg.Location = new System.Drawing.Point(88, 216);
            this.btnOrg.Name = "btnOrg";
            this.btnOrg.Size = new System.Drawing.Size(75, 23);
            this.btnOrg.TabIndex = 7;
            this.btnOrg.Text = "创建普通VO";
            this.btnOrg.UseVisualStyleBackColor = true;
            this.btnOrg.Click += new System.EventHandler(this.btnCreateVo);
            // 
            // btnNotice
            // 
            this.btnNotice.Location = new System.Drawing.Point(210, 216);
            this.btnNotice.Name = "btnNotice";
            this.btnNotice.Size = new System.Drawing.Size(75, 23);
            this.btnNotice.TabIndex = 7;
            this.btnNotice.Text = "创建通知VO";
            this.btnNotice.UseVisualStyleBackColor = true;
            this.btnNotice.Click += new System.EventHandler(this.btnCreateVo);
            // 
            // btnCs
            // 
            this.btnCs.Location = new System.Drawing.Point(340, 216);
            this.btnCs.Name = "btnCs";
            this.btnCs.Size = new System.Drawing.Size(75, 23);
            this.btnCs.TabIndex = 7;
            this.btnCs.Text = "创建通知类";
            this.btnCs.UseVisualStyleBackColor = true;
            this.btnCs.Click += new System.EventHandler(this.btnCs_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "生成路径：";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(105, 164);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(310, 21);
            this.txtPath.TabIndex = 9;
            // 
            // btnPath
            // 
            this.btnPath.Location = new System.Drawing.Point(449, 162);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(119, 23);
            this.btnPath.TabIndex = 10;
            this.btnPath.Text = "选择生成路径";
            this.btnPath.UseVisualStyleBackColor = true;
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 255);
            this.Controls.Add(this.btnPath);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCs);
            this.Controls.Add(this.btnNotice);
            this.Controls.Add(this.btnOrg);
            this.Controls.Add(this.btnAnalXsd);
            this.Controls.Add(this.btnBaseXsd);
            this.Controls.Add(this.txtboxAnalXsd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtboxBaseXsd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtboxNameSpace);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "XSDToVO";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtboxNameSpace;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtboxBaseXsd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtboxAnalXsd;
        private System.Windows.Forms.Button btnBaseXsd;
        private System.Windows.Forms.Button btnAnalXsd;
        private System.Windows.Forms.Button btnOrg;
        private System.Windows.Forms.Button btnNotice;
        private System.Windows.Forms.Button btnCs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnPath;
    }
}

