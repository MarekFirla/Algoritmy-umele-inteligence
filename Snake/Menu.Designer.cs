
namespace Snake
{
    partial class Menu_form
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
            this.Start_button = new System.Windows.Forms.Button();
            this.Konec_button = new System.Windows.Forms.Button();
            this.HrajeHracRadioButton = new System.Windows.Forms.RadioButton();
            this.HrajeAIRadioButton = new System.Windows.Forms.RadioButton();
            this.ObtiznostTrackBar = new System.Windows.Forms.TrackBar();
            this.Obtiznostlabel = new System.Windows.Forms.Label();
            this.AIExpertRadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.ObtiznostTrackBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Start_button
            // 
            this.Start_button.Location = new System.Drawing.Point(12, 12);
            this.Start_button.Name = "Start_button";
            this.Start_button.Size = new System.Drawing.Size(233, 38);
            this.Start_button.TabIndex = 0;
            this.Start_button.Text = "Start";
            this.Start_button.UseVisualStyleBackColor = true;
            this.Start_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // Konec_button
            // 
            this.Konec_button.Location = new System.Drawing.Point(12, 299);
            this.Konec_button.Name = "Konec_button";
            this.Konec_button.Size = new System.Drawing.Size(233, 23);
            this.Konec_button.TabIndex = 2;
            this.Konec_button.Text = "Konec";
            this.Konec_button.UseVisualStyleBackColor = true;
            this.Konec_button.Click += new System.EventHandler(this.Konec_button_Click);
            // 
            // HrajeHracRadioButton
            // 
            this.HrajeHracRadioButton.AutoSize = true;
            this.HrajeHracRadioButton.Checked = true;
            this.HrajeHracRadioButton.Location = new System.Drawing.Point(6, 21);
            this.HrajeHracRadioButton.Name = "HrajeHracRadioButton";
            this.HrajeHracRadioButton.Size = new System.Drawing.Size(69, 21);
            this.HrajeHracRadioButton.TabIndex = 3;
            this.HrajeHracRadioButton.TabStop = true;
            this.HrajeHracRadioButton.Text = "Player";
            this.HrajeHracRadioButton.UseVisualStyleBackColor = true;
            this.HrajeHracRadioButton.CheckedChanged += new System.EventHandler(this.HrajeHrac_CheckedChanged);
            // 
            // HrajeAIRadioButton
            // 
            this.HrajeAIRadioButton.AutoSize = true;
            this.HrajeAIRadioButton.Location = new System.Drawing.Point(6, 48);
            this.HrajeAIRadioButton.Name = "HrajeAIRadioButton";
            this.HrajeAIRadioButton.Size = new System.Drawing.Size(41, 21);
            this.HrajeAIRadioButton.TabIndex = 4;
            this.HrajeAIRadioButton.Text = "AI";
            this.HrajeAIRadioButton.UseVisualStyleBackColor = true;
            this.HrajeAIRadioButton.CheckedChanged += new System.EventHandler(this.HrajeAI_CheckedChanged);
            // 
            // ObtiznostTrackBar
            // 
            this.ObtiznostTrackBar.Location = new System.Drawing.Point(6, 42);
            this.ObtiznostTrackBar.Maximum = 100;
            this.ObtiznostTrackBar.Minimum = 10;
            this.ObtiznostTrackBar.Name = "ObtiznostTrackBar";
            this.ObtiznostTrackBar.Size = new System.Drawing.Size(221, 56);
            this.ObtiznostTrackBar.TabIndex = 5;
            this.ObtiznostTrackBar.TickFrequency = 5;
            this.ObtiznostTrackBar.Value = 20;
            this.ObtiznostTrackBar.Scroll += new System.EventHandler(this.ObtiznostTrackBar_Scroll);
            // 
            // Obtiznostlabel
            // 
            this.Obtiznostlabel.AutoSize = true;
            this.Obtiznostlabel.Location = new System.Drawing.Point(104, 18);
            this.Obtiznostlabel.Name = "Obtiznostlabel";
            this.Obtiznostlabel.Size = new System.Drawing.Size(24, 17);
            this.Obtiznostlabel.TabIndex = 6;
            this.Obtiznostlabel.Text = "20";
            // 
            // AIExpertRadioButton
            // 
            this.AIExpertRadioButton.AutoSize = true;
            this.AIExpertRadioButton.Location = new System.Drawing.Point(6, 75);
            this.AIExpertRadioButton.Name = "AIExpertRadioButton";
            this.AIExpertRadioButton.Size = new System.Drawing.Size(85, 21);
            this.AIExpertRadioButton.TabIndex = 7;
            this.AIExpertRadioButton.TabStop = true;
            this.AIExpertRadioButton.Text = "AI Expert";
            this.AIExpertRadioButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Rychlost Hry:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 265);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Ovládání: WASD nebo šipky";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.HrajeHracRadioButton);
            this.groupBox1.Controls.Add(this.HrajeAIRadioButton);
            this.groupBox1.Controls.Add(this.AIExpertRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 100);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nastavení hry";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ObtiznostTrackBar);
            this.groupBox2.Controls.Add(this.Obtiznostlabel);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 158);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(233, 104);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            // 
            // Menu_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 331);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Konec_button);
            this.Controls.Add(this.Start_button);
            this.MaximizeBox = false;
            this.Name = "Menu_form";
            this.Text = "SNAKE";
            ((System.ComponentModel.ISupportInitialize)(this.ObtiznostTrackBar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Start_button;
        private System.Windows.Forms.Button Konec_button;
        private System.Windows.Forms.RadioButton HrajeHracRadioButton;
        private System.Windows.Forms.RadioButton HrajeAIRadioButton;
        private System.Windows.Forms.TrackBar ObtiznostTrackBar;
        private System.Windows.Forms.Label Obtiznostlabel;
        private System.Windows.Forms.RadioButton AIExpertRadioButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}