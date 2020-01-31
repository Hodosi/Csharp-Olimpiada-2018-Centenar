namespace CentenarMareaUnire
{
    partial class Logare
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
            this.textBox_email = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_parola = new System.Windows.Forms.TextBox();
            this.button_logare = new System.Windows.Forms.Button();
            this.button_uitat = new System.Windows.Forms.Button();
            this.button_Anulare = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_email
            // 
            this.textBox_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_email.Location = new System.Drawing.Point(151, 90);
            this.textBox_email.Name = "textBox_email";
            this.textBox_email.Size = new System.Drawing.Size(363, 34);
            this.textBox_email.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(65, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Email:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(56, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Parola:";
            // 
            // textBox_parola
            // 
            this.textBox_parola.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_parola.Location = new System.Drawing.Point(151, 158);
            this.textBox_parola.Name = "textBox_parola";
            this.textBox_parola.Size = new System.Drawing.Size(363, 34);
            this.textBox_parola.TabIndex = 2;
            // 
            // button_logare
            // 
            this.button_logare.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_logare.Location = new System.Drawing.Point(249, 230);
            this.button_logare.Name = "button_logare";
            this.button_logare.Size = new System.Drawing.Size(137, 47);
            this.button_logare.TabIndex = 4;
            this.button_logare.Text = "Logare";
            this.button_logare.UseVisualStyleBackColor = true;
            this.button_logare.Click += new System.EventHandler(this.button_logare_Click);
            // 
            // button_uitat
            // 
            this.button_uitat.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_uitat.Location = new System.Drawing.Point(209, 304);
            this.button_uitat.Name = "button_uitat";
            this.button_uitat.Size = new System.Drawing.Size(218, 47);
            this.button_uitat.TabIndex = 5;
            this.button_uitat.Text = "Am uitat parola";
            this.button_uitat.UseVisualStyleBackColor = true;
            this.button_uitat.Click += new System.EventHandler(this.button_uitat_Click);
            // 
            // button_Anulare
            // 
            this.button_Anulare.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Anulare.Location = new System.Drawing.Point(249, 12);
            this.button_Anulare.Name = "button_Anulare";
            this.button_Anulare.Size = new System.Drawing.Size(137, 47);
            this.button_Anulare.TabIndex = 6;
            this.button_Anulare.Text = "Anulare";
            this.button_Anulare.UseVisualStyleBackColor = true;
            this.button_Anulare.Click += new System.EventHandler(this.button_Anulare_Click);
            // 
            // Logare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 400);
            this.Controls.Add(this.button_Anulare);
            this.Controls.Add(this.button_uitat);
            this.Controls.Add(this.button_logare);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_parola);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_email);
            this.Name = "Logare";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Logare";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_email;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_parola;
        private System.Windows.Forms.Button button_logare;
        private System.Windows.Forms.Button button_uitat;
        private System.Windows.Forms.Button button_Anulare;
    }
}