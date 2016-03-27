namespace Enterprise_Development_CW1.View
{
    partial class ScoreHistory
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
            this.label1 = new System.Windows.Forms.Label();
            this.lstUsernames = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.lstGames = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.lstGameData = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usernames";
            // 
            // lstUsernames
            // 
            this.lstUsernames.Location = new System.Drawing.Point(13, 30);
            this.lstUsernames.Name = "lstUsernames";
            this.lstUsernames.Size = new System.Drawing.Size(121, 286);
            this.lstUsernames.TabIndex = 1;
            this.lstUsernames.UseCompatibleStateImageBehavior = false;
            this.lstUsernames.View = System.Windows.Forms.View.List;
            this.lstUsernames.SelectedIndexChanged += new System.EventHandler(this.lstUsernames_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Games";
            // 
            // lstGames
            // 
            this.lstGames.Location = new System.Drawing.Point(196, 30);
            this.lstGames.Name = "lstGames";
            this.lstGames.Size = new System.Drawing.Size(121, 286);
            this.lstGames.TabIndex = 3;
            this.lstGames.UseCompatibleStateImageBehavior = false;
            this.lstGames.View = System.Windows.Forms.View.List;
            this.lstGames.SelectedIndexChanged += new System.EventHandler(this.lstGames_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(388, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Game Data";
            // 
            // lstGameData
            // 
            this.lstGameData.Location = new System.Drawing.Point(391, 30);
            this.lstGameData.Name = "lstGameData";
            this.lstGameData.Size = new System.Drawing.Size(249, 286);
            this.lstGameData.TabIndex = 5;
            this.lstGameData.UseCompatibleStateImageBehavior = false;
            this.lstGameData.View = System.Windows.Forms.View.List;
            // 
            // ScoreHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 328);
            this.Controls.Add(this.lstGameData);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstGames);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstUsernames);
            this.Controls.Add(this.label1);
            this.Name = "ScoreHistory";
            this.Text = "Score History";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lstUsernames;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lstGames;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lstGameData;
    }
}