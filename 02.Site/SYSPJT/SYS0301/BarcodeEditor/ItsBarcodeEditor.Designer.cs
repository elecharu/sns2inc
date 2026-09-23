namespace LabelDesign
{
    partial class ItsBarcodeEditor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItsBarcodeEditor));
            this.contextMenuStrip_Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_AddLine = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_AddRectangle = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_AddCircle = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_AddText = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_AddBarcode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_AddImage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_SendToForward = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_SendToBackward = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_SendToFront = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_SendToBack = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Preview = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip_Menu
            // 
            this.contextMenuStrip_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_AddLine,
            this.toolStripMenuItem_AddRectangle,
            this.toolStripMenuItem_AddCircle,
            this.toolStripMenuItem_AddText,
            this.toolStripMenuItem_AddBarcode,
            this.toolStripMenuItem_AddImage,
            this.toolStripSeparator2,
            this.toolStripMenuItem_Delete,
            this.toolStripSeparator1,
            this.toolStripMenuItem1,
            this.toolStripMenuItem_Preview});
            this.contextMenuStrip_Menu.Name = "contextMenuStrip_Menu";
            this.contextMenuStrip_Menu.Size = new System.Drawing.Size(123, 214);
            // 
            // toolStripMenuItem_AddLine
            // 
            this.toolStripMenuItem_AddLine.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_AddLine.Image")));
            this.toolStripMenuItem_AddLine.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripMenuItem_AddLine.Name = "toolStripMenuItem_AddLine";
            this.toolStripMenuItem_AddLine.Size = new System.Drawing.Size(122, 22);
            this.toolStripMenuItem_AddLine.Text = "라인";
            this.toolStripMenuItem_AddLine.Click += new System.EventHandler(this.toolStripMenuItem_AddLine_Click);
            // 
            // toolStripMenuItem_AddRectangle
            // 
            this.toolStripMenuItem_AddRectangle.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_AddRectangle.Image")));
            this.toolStripMenuItem_AddRectangle.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripMenuItem_AddRectangle.Name = "toolStripMenuItem_AddRectangle";
            this.toolStripMenuItem_AddRectangle.Size = new System.Drawing.Size(122, 22);
            this.toolStripMenuItem_AddRectangle.Text = "사각형";
            this.toolStripMenuItem_AddRectangle.Click += new System.EventHandler(this.toolStripMenuItem_AddRectangle_Click);
            // 
            // toolStripMenuItem_AddCircle
            // 
            this.toolStripMenuItem_AddCircle.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_AddCircle.Image")));
            this.toolStripMenuItem_AddCircle.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripMenuItem_AddCircle.Name = "toolStripMenuItem_AddCircle";
            this.toolStripMenuItem_AddCircle.Size = new System.Drawing.Size(122, 22);
            this.toolStripMenuItem_AddCircle.Text = "원";
            this.toolStripMenuItem_AddCircle.Click += new System.EventHandler(this.toolStripMenuItem_AddCircle_Click);
            // 
            // toolStripMenuItem_AddText
            // 
            this.toolStripMenuItem_AddText.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_AddText.Image")));
            this.toolStripMenuItem_AddText.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripMenuItem_AddText.Name = "toolStripMenuItem_AddText";
            this.toolStripMenuItem_AddText.Size = new System.Drawing.Size(122, 22);
            this.toolStripMenuItem_AddText.Text = "텍스트";
            this.toolStripMenuItem_AddText.Click += new System.EventHandler(this.toolStripMenuItem_AddText_Click);
            // 
            // toolStripMenuItem_AddBarcode
            // 
            this.toolStripMenuItem_AddBarcode.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_AddBarcode.Image")));
            this.toolStripMenuItem_AddBarcode.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripMenuItem_AddBarcode.Name = "toolStripMenuItem_AddBarcode";
            this.toolStripMenuItem_AddBarcode.Size = new System.Drawing.Size(122, 22);
            this.toolStripMenuItem_AddBarcode.Text = "바코드";
            this.toolStripMenuItem_AddBarcode.Click += new System.EventHandler(this.toolStripMenuItem_AddBarcode_Click);
            // 
            // toolStripMenuItem_AddImage
            // 
            this.toolStripMenuItem_AddImage.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_AddImage.Image")));
            this.toolStripMenuItem_AddImage.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripMenuItem_AddImage.Name = "toolStripMenuItem_AddImage";
            this.toolStripMenuItem_AddImage.Size = new System.Drawing.Size(122, 22);
            this.toolStripMenuItem_AddImage.Text = "이미지";
            this.toolStripMenuItem_AddImage.Click += new System.EventHandler(this.toolStripMenuItem_AddImage_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(119, 6);
            // 
            // toolStripMenuItem_Delete
            // 
            this.toolStripMenuItem_Delete.Name = "toolStripMenuItem_Delete";
            this.toolStripMenuItem_Delete.Size = new System.Drawing.Size(122, 22);
            this.toolStripMenuItem_Delete.Text = "삭제";
            this.toolStripMenuItem_Delete.Click += new System.EventHandler(this.toolStripMenuItem_Delete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(119, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_SendToForward,
            this.toolStripMenuItem_SendToBackward,
            this.toolStripMenuItem_SendToFront,
            this.toolStripMenuItem_SendToBack});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.toolStripMenuItem1.Text = "硅摹";
            // 
            // toolStripMenuItem_SendToForward
            // 
            this.toolStripMenuItem_SendToForward.Name = "toolStripMenuItem_SendToForward";
            this.toolStripMenuItem_SendToForward.Size = new System.Drawing.Size(166, 22);
            this.toolStripMenuItem_SendToForward.Text = "위로이동";
            this.toolStripMenuItem_SendToForward.Click += new System.EventHandler(this.toolStripMenuItem_SendToForward_Click);
            // 
            // toolStripMenuItem_SendToBackward
            // 
            this.toolStripMenuItem_SendToBackward.Name = "toolStripMenuItem_SendToBackward";
            this.toolStripMenuItem_SendToBackward.Size = new System.Drawing.Size(166, 22);
            this.toolStripMenuItem_SendToBackward.Text = "아래로이동";
            this.toolStripMenuItem_SendToBackward.Click += new System.EventHandler(this.toolStripMenuItem_SendToBackward_Click);
            // 
            // toolStripMenuItem_SendToFront
            // 
            this.toolStripMenuItem_SendToFront.Name = "toolStripMenuItem_SendToFront";
            this.toolStripMenuItem_SendToFront.Size = new System.Drawing.Size(166, 22);
            this.toolStripMenuItem_SendToFront.Text = "최상위로이동";
            this.toolStripMenuItem_SendToFront.Click += new System.EventHandler(this.toolStripMenuItem_SendToFront_Click);
            // 
            // toolStripMenuItem_SendToBack
            // 
            this.toolStripMenuItem_SendToBack.Name = "toolStripMenuItem_SendToBack";
            this.toolStripMenuItem_SendToBack.Size = new System.Drawing.Size(166, 22);
            this.toolStripMenuItem_SendToBack.Text = "맨아래로이동";
            this.toolStripMenuItem_SendToBack.Click += new System.EventHandler(this.toolStripMenuItem_SendToBack_Click);
            // 
            // toolStripMenuItem_Preview
            // 
            this.toolStripMenuItem_Preview.Name = "toolStripMenuItem_Preview";
            this.toolStripMenuItem_Preview.Size = new System.Drawing.Size(122, 22);
            this.toolStripMenuItem_Preview.Text = "미리보기";
            this.toolStripMenuItem_Preview.Click += new System.EventHandler(this.toolStripMenuItem_Preview_Click);
            this.contextMenuStrip_Menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Menu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_AddLine;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_AddRectangle;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_AddCircle;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_AddBarcode;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_AddImage;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_AddText;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_SendToForward;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_SendToBackward;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_SendToFront;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_SendToBack;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Preview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Delete;
    }
}
