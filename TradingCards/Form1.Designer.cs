namespace TradingCards
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListView listViewPlayers;
        private System.Windows.Forms.ColumnHeader cName;
        private System.Windows.Forms.ColumnHeader cTeam;
        private System.Windows.Forms.Panel panelCard;
        private System.Windows.Forms.PictureBox pictureBoxPlayer;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelTeam;
        private System.Windows.Forms.Label labelPosition;
        private System.Windows.Forms.Label labelPPG;
        private System.Windows.Forms.Label labelAPG;
        private System.Windows.Forms.Label labelRPG;
        private System.Windows.Forms.Label labelFGP;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.listViewPlayers = new System.Windows.Forms.ListView();
            this.cName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cTeam = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelCard = new System.Windows.Forms.Panel();
            this.labelFGP = new System.Windows.Forms.Label();
            this.labelRPG = new System.Windows.Forms.Label();
            this.labelAPG = new System.Windows.Forms.Label();
            this.labelPPG = new System.Windows.Forms.Label();
            this.labelPosition = new System.Windows.Forms.Label();
            this.labelTeam = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.pictureBoxPlayer = new System.Windows.Forms.PictureBox();
            this.panelCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // listViewPlayers
            // 
            this.listViewPlayers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cName,
            this.cTeam});
            this.listViewPlayers.FullRowSelect = true;
            this.listViewPlayers.GridLines = true;
            this.listViewPlayers.HideSelection = false;
            this.listViewPlayers.Location = new System.Drawing.Point(12, 12);
            this.listViewPlayers.Name = "listViewPlayers";
            this.listViewPlayers.Size = new System.Drawing.Size(493, 600);
            this.listViewPlayers.TabIndex = 0;
            this.listViewPlayers.UseCompatibleStateImageBehavior = false;
            this.listViewPlayers.View = System.Windows.Forms.View.Details;
            this.listViewPlayers.SelectedIndexChanged += new System.EventHandler(this.listViewPlayers_SelectedIndexChanged);
            // 
            // cName
            // 
            this.cName.Text = "Name";
            this.cName.Width = 200;
            // 
            // cTeam
            // 
            this.cTeam.Text = "Team";
            this.cTeam.Width = 200;
            // 
            // panelCard
            // 
            this.panelCard.Controls.Add(this.labelFGP);
            this.panelCard.Controls.Add(this.labelRPG);
            this.panelCard.Controls.Add(this.labelAPG);
            this.panelCard.Controls.Add(this.labelPPG);
            this.panelCard.Controls.Add(this.labelPosition);
            this.panelCard.Controls.Add(this.labelTeam);
            this.panelCard.Controls.Add(this.labelName);
            this.panelCard.Controls.Add(this.pictureBoxPlayer);
            this.panelCard.Location = new System.Drawing.Point(528, 12);
            this.panelCard.Name = "panelCard";
            this.panelCard.Size = new System.Drawing.Size(350, 600);
            this.panelCard.TabIndex = 1;
            // 
            // labelFGP
            // 
            this.labelFGP.AutoSize = true;
            this.labelFGP.Location = new System.Drawing.Point(40, 460);
            this.labelFGP.Name = "labelFGP";
            this.labelFGP.Size = new System.Drawing.Size(37, 16);
            this.labelFGP.TabIndex = 7;
            this.labelFGP.Text = "FGP:";
            // 
            // labelRPG
            // 
            this.labelRPG.AutoSize = true;
            this.labelRPG.Location = new System.Drawing.Point(40, 440);
            this.labelRPG.Name = "labelRPG";
            this.labelRPG.Size = new System.Drawing.Size(39, 16);
            this.labelRPG.TabIndex = 6;
            this.labelRPG.Text = "RPG:";
            // 
            // labelAPG
            // 
            this.labelAPG.AutoSize = true;
            this.labelAPG.Location = new System.Drawing.Point(40, 420);
            this.labelAPG.Name = "labelAPG";
            this.labelAPG.Size = new System.Drawing.Size(38, 16);
            this.labelAPG.TabIndex = 5;
            this.labelAPG.Text = "APG:";
            // 
            // labelPPG
            // 
            this.labelPPG.AutoSize = true;
            this.labelPPG.Location = new System.Drawing.Point(40, 400);
            this.labelPPG.Name = "labelPPG";
            this.labelPPG.Size = new System.Drawing.Size(38, 16);
            this.labelPPG.TabIndex = 4;
            this.labelPPG.Text = "PPG:";
            // 
            // labelPosition
            // 
            this.labelPosition.AutoSize = true;
            this.labelPosition.Location = new System.Drawing.Point(40, 380);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.Size = new System.Drawing.Size(58, 16);
            this.labelPosition.TabIndex = 3;
            this.labelPosition.Text = "Position:";
            // 
            // labelTeam
            // 
            this.labelTeam.AutoSize = true;
            this.labelTeam.Location = new System.Drawing.Point(40, 360);
            this.labelTeam.Name = "labelTeam";
            this.labelTeam.Size = new System.Drawing.Size(46, 16);
            this.labelTeam.TabIndex = 2;
            this.labelTeam.Text = "Team:";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(40, 38);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(47, 16);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Name:";
            // 
            // pictureBoxPlayer
            // 
            this.pictureBoxPlayer.Location = new System.Drawing.Point(43, 57);
            this.pictureBoxPlayer.Name = "pictureBoxPlayer";
            this.pictureBoxPlayer.Size = new System.Drawing.Size(280, 300);
            this.pictureBoxPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPlayer.TabIndex = 0;
            this.pictureBoxPlayer.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 511);
            this.Controls.Add(this.panelCard);
            this.Controls.Add(this.listViewPlayers);
            this.Name = "Form1";
            this.Text = "NBA Trading Cards";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelCard.ResumeLayout(false);
            this.panelCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlayer)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
