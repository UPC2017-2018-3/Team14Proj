namespace WindowsFormsApplication11
{
    partial class wdddb
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.slfsqlDataSet1 = new WindowsFormsApplication11.slfsqlDataSet1();
            this.wdddbBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wdddbTableAdapter = new WindowsFormsApplication11.slfsqlDataSet1TableAdapters.wdddbTableAdapter();
            this.姓名DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.身份证号DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.车次DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.出行方式DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.出发地DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.出发时间DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.目的地DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.到达时间DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.价格DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slfsqlDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wdddbBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.姓名DataGridViewTextBoxColumn,
            this.身份证号DataGridViewTextBoxColumn,
            this.车次DataGridViewTextBoxColumn,
            this.出行方式DataGridViewTextBoxColumn,
            this.出发地DataGridViewTextBoxColumn,
            this.出发时间DataGridViewTextBoxColumn,
            this.目的地DataGridViewTextBoxColumn,
            this.到达时间DataGridViewTextBoxColumn,
            this.价格DataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.wdddbBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(13, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(441, 86);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // slfsqlDataSet1
            // 
            this.slfsqlDataSet1.DataSetName = "slfsqlDataSet1";
            this.slfsqlDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // wdddbBindingSource
            // 
            this.wdddbBindingSource.DataMember = "wdddb";
            this.wdddbBindingSource.DataSource = this.slfsqlDataSet1;
            // 
            // wdddbTableAdapter
            // 
            this.wdddbTableAdapter.ClearBeforeFill = true;
            // 
            // 姓名DataGridViewTextBoxColumn
            // 
            this.姓名DataGridViewTextBoxColumn.DataPropertyName = "姓名";
            this.姓名DataGridViewTextBoxColumn.HeaderText = "姓名";
            this.姓名DataGridViewTextBoxColumn.Name = "姓名DataGridViewTextBoxColumn";
            // 
            // 身份证号DataGridViewTextBoxColumn
            // 
            this.身份证号DataGridViewTextBoxColumn.DataPropertyName = "身份证号";
            this.身份证号DataGridViewTextBoxColumn.HeaderText = "身份证号";
            this.身份证号DataGridViewTextBoxColumn.Name = "身份证号DataGridViewTextBoxColumn";
            // 
            // 车次DataGridViewTextBoxColumn
            // 
            this.车次DataGridViewTextBoxColumn.DataPropertyName = "车次";
            this.车次DataGridViewTextBoxColumn.HeaderText = "车次";
            this.车次DataGridViewTextBoxColumn.Name = "车次DataGridViewTextBoxColumn";
            // 
            // 出行方式DataGridViewTextBoxColumn
            // 
            this.出行方式DataGridViewTextBoxColumn.DataPropertyName = "出行方式";
            this.出行方式DataGridViewTextBoxColumn.HeaderText = "出行方式";
            this.出行方式DataGridViewTextBoxColumn.Name = "出行方式DataGridViewTextBoxColumn";
            // 
            // 出发地DataGridViewTextBoxColumn
            // 
            this.出发地DataGridViewTextBoxColumn.DataPropertyName = "出发地";
            this.出发地DataGridViewTextBoxColumn.HeaderText = "出发地";
            this.出发地DataGridViewTextBoxColumn.Name = "出发地DataGridViewTextBoxColumn";
            // 
            // 出发时间DataGridViewTextBoxColumn
            // 
            this.出发时间DataGridViewTextBoxColumn.DataPropertyName = "出发时间";
            this.出发时间DataGridViewTextBoxColumn.HeaderText = "出发时间";
            this.出发时间DataGridViewTextBoxColumn.Name = "出发时间DataGridViewTextBoxColumn";
            // 
            // 目的地DataGridViewTextBoxColumn
            // 
            this.目的地DataGridViewTextBoxColumn.DataPropertyName = "目的地";
            this.目的地DataGridViewTextBoxColumn.HeaderText = "目的地";
            this.目的地DataGridViewTextBoxColumn.Name = "目的地DataGridViewTextBoxColumn";
            // 
            // 到达时间DataGridViewTextBoxColumn
            // 
            this.到达时间DataGridViewTextBoxColumn.DataPropertyName = "到达时间";
            this.到达时间DataGridViewTextBoxColumn.HeaderText = "到达时间";
            this.到达时间DataGridViewTextBoxColumn.Name = "到达时间DataGridViewTextBoxColumn";
            // 
            // 价格DataGridViewTextBoxColumn
            // 
            this.价格DataGridViewTextBoxColumn.DataPropertyName = "价格";
            this.价格DataGridViewTextBoxColumn.HeaderText = "价格";
            this.价格DataGridViewTextBoxColumn.Name = "价格DataGridViewTextBoxColumn";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(140, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "退票";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(379, 115);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "返回上一页";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(13, 115);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(90, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "返回用户中心";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(260, 115);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "刷新";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // wdddb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 178);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "wdddb";
            this.Text = "我的订单";
            this.Load += new System.EventHandler(this.wdddb_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slfsqlDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wdddbBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private slfsqlDataSet1 slfsqlDataSet1;
        private System.Windows.Forms.BindingSource wdddbBindingSource;
        private slfsqlDataSet1TableAdapters.wdddbTableAdapter wdddbTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn 姓名DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 身份证号DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 车次DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 出行方式DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 出发地DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 出发时间DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 目的地DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 到达时间DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 价格DataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}