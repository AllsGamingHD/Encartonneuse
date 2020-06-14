namespace Encartonneuse
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_ArretUrgence = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.rB_BouteilleCamera = new System.Windows.Forms.RadioButton();
            this.rB_BouteilleSortie = new System.Windows.Forms.RadioButton();
            this.rB_CapteurCarton1 = new System.Windows.Forms.RadioButton();
            this.rB_CapteurCarton2 = new System.Windows.Forms.RadioButton();
            this.rB_PasPelerin = new System.Windows.Forms.RadioButton();
            this.rB_OrigineBouteille = new System.Windows.Forms.RadioButton();
            this.rB_PointEntreBouteilleEtCarton = new System.Windows.Forms.RadioButton();
            this.rB_PointOrigineX = new System.Windows.Forms.RadioButton();
            this.btn_StartProg = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_ArretUrgence
            // 
            this.btn_ArretUrgence.Location = new System.Drawing.Point(530, 12);
            this.btn_ArretUrgence.Name = "btn_ArretUrgence";
            this.btn_ArretUrgence.Size = new System.Drawing.Size(130, 63);
            this.btn_ArretUrgence.TabIndex = 0;
            this.btn_ArretUrgence.Text = "Arret d\'urgence";
            this.btn_ArretUrgence.UseVisualStyleBackColor = true;
            this.btn_ArretUrgence.Click += new System.EventHandler(this.ArretUrgence);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // rB_BouteilleCamera
            // 
            this.rB_BouteilleCamera.AutoSize = true;
            this.rB_BouteilleCamera.Location = new System.Drawing.Point(12, 12);
            this.rB_BouteilleCamera.Name = "rB_BouteilleCamera";
            this.rB_BouteilleCamera.Size = new System.Drawing.Size(103, 17);
            this.rB_BouteilleCamera.TabIndex = 1;
            this.rB_BouteilleCamera.TabStop = true;
            this.rB_BouteilleCamera.Text = "Bouteille caméra";
            this.rB_BouteilleCamera.UseVisualStyleBackColor = true;
            // 
            // rB_BouteilleSortie
            // 
            this.rB_BouteilleSortie.AutoSize = true;
            this.rB_BouteilleSortie.Location = new System.Drawing.Point(12, 35);
            this.rB_BouteilleSortie.Name = "rB_BouteilleSortie";
            this.rB_BouteilleSortie.Size = new System.Drawing.Size(93, 17);
            this.rB_BouteilleSortie.TabIndex = 1;
            this.rB_BouteilleSortie.TabStop = true;
            this.rB_BouteilleSortie.Text = "Bouteille sortie";
            this.rB_BouteilleSortie.UseVisualStyleBackColor = true;
            // 
            // rB_CapteurCarton1
            // 
            this.rB_CapteurCarton1.AutoSize = true;
            this.rB_CapteurCarton1.Location = new System.Drawing.Point(12, 58);
            this.rB_CapteurCarton1.Name = "rB_CapteurCarton1";
            this.rB_CapteurCarton1.Size = new System.Drawing.Size(104, 17);
            this.rB_CapteurCarton1.TabIndex = 1;
            this.rB_CapteurCarton1.TabStop = true;
            this.rB_CapteurCarton1.Text = "Capteur carton 1";
            this.rB_CapteurCarton1.UseVisualStyleBackColor = true;
            // 
            // rB_CapteurCarton2
            // 
            this.rB_CapteurCarton2.AutoSize = true;
            this.rB_CapteurCarton2.Location = new System.Drawing.Point(12, 81);
            this.rB_CapteurCarton2.Name = "rB_CapteurCarton2";
            this.rB_CapteurCarton2.Size = new System.Drawing.Size(104, 17);
            this.rB_CapteurCarton2.TabIndex = 1;
            this.rB_CapteurCarton2.TabStop = true;
            this.rB_CapteurCarton2.Text = "Capteur carton 2";
            this.rB_CapteurCarton2.UseVisualStyleBackColor = true;
            // 
            // rB_PasPelerin
            // 
            this.rB_PasPelerin.AutoSize = true;
            this.rB_PasPelerin.Location = new System.Drawing.Point(12, 104);
            this.rB_PasPelerin.Name = "rB_PasPelerin";
            this.rB_PasPelerin.Size = new System.Drawing.Size(92, 17);
            this.rB_PasPelerin.TabIndex = 1;
            this.rB_PasPelerin.TabStop = true;
            this.rB_PasPelerin.Text = "Pas de pelerin";
            this.rB_PasPelerin.UseVisualStyleBackColor = true;
            // 
            // rB_OrigineBouteille
            // 
            this.rB_OrigineBouteille.AutoSize = true;
            this.rB_OrigineBouteille.Location = new System.Drawing.Point(12, 127);
            this.rB_OrigineBouteille.Name = "rB_OrigineBouteille";
            this.rB_OrigineBouteille.Size = new System.Drawing.Size(100, 17);
            this.rB_OrigineBouteille.TabIndex = 1;
            this.rB_OrigineBouteille.TabStop = true;
            this.rB_OrigineBouteille.Text = "Origine bouteille";
            this.rB_OrigineBouteille.UseVisualStyleBackColor = true;
            // 
            // rB_PointEntreBouteilleEtCarton
            // 
            this.rB_PointEntreBouteilleEtCarton.AutoSize = true;
            this.rB_PointEntreBouteilleEtCarton.Location = new System.Drawing.Point(12, 150);
            this.rB_PointEntreBouteilleEtCarton.Name = "rB_PointEntreBouteilleEtCarton";
            this.rB_PointEntreBouteilleEtCarton.Size = new System.Drawing.Size(163, 17);
            this.rB_PointEntreBouteilleEtCarton.TabIndex = 1;
            this.rB_PointEntreBouteilleEtCarton.TabStop = true;
            this.rB_PointEntreBouteilleEtCarton.Text = "Point entre bouteille et carton";
            this.rB_PointEntreBouteilleEtCarton.UseVisualStyleBackColor = true;
            // 
            // rB_PointOrigineX
            // 
            this.rB_PointOrigineX.AutoSize = true;
            this.rB_PointOrigineX.Location = new System.Drawing.Point(12, 173);
            this.rB_PointOrigineX.Name = "rB_PointOrigineX";
            this.rB_PointOrigineX.Size = new System.Drawing.Size(93, 17);
            this.rB_PointOrigineX.TabIndex = 1;
            this.rB_PointOrigineX.TabStop = true;
            this.rB_PointOrigineX.Text = "Point origine X";
            this.rB_PointOrigineX.UseVisualStyleBackColor = true;
            // 
            // btn_StartProg
            // 
            this.btn_StartProg.Location = new System.Drawing.Point(341, 12);
            this.btn_StartProg.Name = "btn_StartProg";
            this.btn_StartProg.Size = new System.Drawing.Size(183, 132);
            this.btn_StartProg.TabIndex = 2;
            this.btn_StartProg.Text = "Stop";
            this.btn_StartProg.UseVisualStyleBackColor = true;
            this.btn_StartProg.Click += new System.EventHandler(this.btn_StartProg_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 213);
            this.Controls.Add(this.btn_StartProg);
            this.Controls.Add(this.rB_PointOrigineX);
            this.Controls.Add(this.rB_PointEntreBouteilleEtCarton);
            this.Controls.Add(this.rB_OrigineBouteille);
            this.Controls.Add(this.rB_PasPelerin);
            this.Controls.Add(this.rB_CapteurCarton2);
            this.Controls.Add(this.rB_CapteurCarton1);
            this.Controls.Add(this.rB_BouteilleSortie);
            this.Controls.Add(this.rB_BouteilleCamera);
            this.Controls.Add(this.btn_ArretUrgence);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Encartonneuse";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ArretUrgence_FormClose);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ArretUrgence;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RadioButton rB_BouteilleCamera;
        private System.Windows.Forms.RadioButton rB_BouteilleSortie;
        private System.Windows.Forms.RadioButton rB_CapteurCarton1;
        private System.Windows.Forms.RadioButton rB_CapteurCarton2;
        private System.Windows.Forms.RadioButton rB_PasPelerin;
        private System.Windows.Forms.RadioButton rB_OrigineBouteille;
        private System.Windows.Forms.RadioButton rB_PointEntreBouteilleEtCarton;
        private System.Windows.Forms.RadioButton rB_PointOrigineX;
        private System.Windows.Forms.Button btn_StartProg;
    }
}

