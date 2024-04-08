namespace ReciveShipment
{
    partial class ReciveShipmentCls
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.gridShipments = new Telerik.WinControls.UI.RadGridView();
            this.lblHeader = new Telerik.WinControls.UI.RadLabel();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.btnExit = new Telerik.WinControls.UI.RadButton();
            this.lblOrders = new Telerik.WinControls.UI.RadLabel();
            this.lblSamples = new Telerik.WinControls.UI.RadLabel();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.txtAssutaReq = new Telerik.WinControls.UI.RadTextBox();
            this.btnClean = new Telerik.WinControls.UI.RadButton();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gridShipments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridShipments.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSamples)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAssutaReq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClean)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridShipments
            // 
            this.gridShipments.AllowDrop = true;
            this.gridShipments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridShipments.AutoScroll = true;
            this.gridShipments.AutoSizeRows = true;
            this.gridShipments.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.gridShipments.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.gridShipments.Location = new System.Drawing.Point(40, 117);
            // 
            // 
            // 
            this.gridShipments.MasterTemplate.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom;
            this.gridShipments.MasterTemplate.AllowColumnChooser = false;
            this.gridShipments.MasterTemplate.AllowColumnReorder = false;
            this.gridShipments.MasterTemplate.AllowDragToGroup = false;
            this.gridShipments.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.gridShipments.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridShipments.Name = "gridShipments";
            this.gridShipments.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.gridShipments.RootElement.ControlBounds = new System.Drawing.Rectangle(40, 117, 240, 150);
            this.gridShipments.Size = new System.Drawing.Size(1100, 546);
            this.gridShipments.TabIndex = 0;
            this.gridShipments.Text = "gridShipments";
            this.gridShipments.CreateRow += new Telerik.WinControls.UI.GridViewCreateRowEventHandler(this.gridShipments_CreateRow);
            this.gridShipments.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.gridShipments_CellFormatting);
            this.gridShipments.CellEditorInitialized += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gridShipments_CellEditorInitialized);
            this.gridShipments.CreateRowInfo += new Telerik.WinControls.UI.GridViewCreateRowInfoEventHandler(this.gridShipments_CreateRowInfo);
            this.gridShipments.UserAddedRow += new Telerik.WinControls.UI.GridViewRowEventHandler(this.gridShipments_UserAddedRow);
            this.gridShipments.UserDeletingRow += new Telerik.WinControls.UI.GridViewRowCancelEventHandler(this.gridShipments_UserDeletingRow);
            this.gridShipments.DefaultValuesNeeded += new Telerik.WinControls.UI.GridViewRowEventHandler(this.gridShipments_DefaultValuesNeeded_1);
            this.gridShipments.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gridShipments_CommandCellClick);
            // 
            // lblHeader
            // 
            this.lblHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeader.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Bold);
            this.lblHeader.Location = new System.Drawing.Point(470, 8);
            this.lblHeader.Name = "lblHeader";
            // 
            // 
            // 
            this.lblHeader.RootElement.ControlBounds = new System.Drawing.Rectangle(470, 8, 100, 18);
            this.lblHeader.Size = new System.Drawing.Size(253, 51);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.Text = "קבלת משלוחים";
            this.lblHeader.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.btnSave.Location = new System.Drawing.Point(237, 705);
            this.btnSave.Name = "btnSave";
            // 
            // 
            // 
            this.btnSave.RootElement.ControlBounds = new System.Drawing.Rectangle(237, 705, 110, 24);
            this.btnSave.Size = new System.Drawing.Size(132, 51);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "שמירה";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.btnExit.Location = new System.Drawing.Point(40, 705);
            this.btnExit.Name = "btnExit";
            // 
            // 
            // 
            this.btnExit.RootElement.ControlBounds = new System.Drawing.Rectangle(40, 705, 110, 24);
            this.btnExit.Size = new System.Drawing.Size(132, 51);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "יציאה";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblOrders
            // 
            this.lblOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOrders.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblOrders.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblOrders.Location = new System.Drawing.Point(1012, 684);
            this.lblOrders.Name = "lblOrders";
            // 
            // 
            // 
            this.lblOrders.RootElement.ControlBounds = new System.Drawing.Rectangle(950, 669, 100, 18);
            this.lblOrders.Size = new System.Drawing.Size(128, 31);
            this.lblOrders.TabIndex = 4;
            this.lblOrders.Text = "כמות הפניות";
            this.lblOrders.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSamples
            // 
            this.lblSamples.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSamples.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblSamples.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblSamples.Location = new System.Drawing.Point(1012, 725);
            this.lblSamples.Name = "lblSamples";
            // 
            // 
            // 
            this.lblSamples.RootElement.ControlBounds = new System.Drawing.Rectangle(949, 710, 100, 18);
            this.lblSamples.Size = new System.Drawing.Size(128, 31);
            this.lblSamples.TabIndex = 5;
            this.lblSamples.Text = "כמות צנצנות";
            this.lblSamples.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // radButton1
            // 
            this.radButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radButton1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.radButton1.BackgroundImage = global::ReciveShipment.Properties.Resources._678092_sign_add_1281;
            this.radButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.radButton1.Image = global::ReciveShipment.Properties.Resources._678092_sign_add_1281;
            this.radButton1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radButton1.Location = new System.Drawing.Point(1113, 81);
            this.radButton1.Name = "radButton1";
            // 
            // 
            // 
            this.radButton1.RootElement.ControlBounds = new System.Drawing.Rectangle(1113, 81, 110, 24);
            this.radButton1.Size = new System.Drawing.Size(27, 30);
            this.radButton1.TabIndex = 7;
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // txtAssutaReq
            // 
            this.txtAssutaReq.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.txtAssutaReq.Location = new System.Drawing.Point(40, 66);
            this.txtAssutaReq.Name = "txtAssutaReq";
            this.txtAssutaReq.Size = new System.Drawing.Size(187, 32);
            this.txtAssutaReq.TabIndex = 9;
            this.txtAssutaReq.TextChanged += new System.EventHandler(this.txtAssutaReq_TextChanged);
            this.txtAssutaReq.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAssutaReq_KeyDown);
            this.txtAssutaReq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAssutaReq_KeyPress);
            // 
            // btnClean
            // 
            this.btnClean.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClean.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnClean.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.btnClean.Location = new System.Drawing.Point(811, 705);
            this.btnClean.Name = "btnClean";
            // 
            // 
            // 
            this.btnClean.RootElement.ControlBounds = new System.Drawing.Rectangle(811, 705, 110, 24);
            this.btnClean.Size = new System.Drawing.Size(132, 51);
            this.btnClean.TabIndex = 3;
            this.btnClean.Text = "נקה";
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // radLabel1
            // 
            this.radLabel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.radLabel1.Location = new System.Drawing.Point(237, 66);
            this.radLabel1.Name = "radLabel1";
            // 
            // 
            // 
            this.radLabel1.RootElement.ControlBounds = new System.Drawing.Rectangle(237, 66, 100, 18);
            this.radLabel1.Size = new System.Drawing.Size(118, 31);
            this.radLabel1.TabIndex = 10;
            this.radLabel1.Text = "מס משלוח :";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // ReciveShipmentCls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.txtAssutaReq);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.lblSamples);
            this.Controls.Add(this.lblOrders);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.gridShipments);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ReciveShipmentCls";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1190, 765);
            this.Resize += new System.EventHandler(this.ReciveShipmentCls_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.gridShipments.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridShipments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSamples)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAssutaReq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClean)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gridShipments;
        private Telerik.WinControls.UI.RadLabel lblHeader;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadButton btnExit;
        private Telerik.WinControls.UI.RadLabel lblOrders;
        private Telerik.WinControls.UI.RadLabel lblSamples;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadTextBox txtAssutaReq;
        private Telerik.WinControls.UI.RadButton btnClean;
        private Telerik.WinControls.UI.RadLabel radLabel1;



    }
}
