using System;
using System.Drawing;
using System.Windows.Forms;

namespace Encartonneuse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Encartonneuse ECT = new Encartonneuse();
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ECT.ES.input1) { rB_BouteilleCamera.ForeColor = Color.Green; } else { rB_BouteilleCamera.ForeColor = Color.Red; };
            if (ECT.ES.input2) { rB_BouteilleSortie.ForeColor = Color.Green; } else { rB_BouteilleSortie.ForeColor = Color.Red; };
            if (ECT.ES.input3) { rB_CapteurCarton1.ForeColor = Color.Green; } else { rB_CapteurCarton1.ForeColor = Color.Red; };
            if (ECT.ES.input4) { rB_CapteurCarton2.ForeColor = Color.Green; } else { rB_CapteurCarton2.ForeColor = Color.Red; };
            if (ECT.ES.input5) { rB_PasPelerin.ForeColor = Color.Green; } else { rB_PasPelerin.ForeColor = Color.Red; };
            if (ECT.ES.input6) { rB_OrigineBouteille.ForeColor = Color.Green; } else { rB_OrigineBouteille.ForeColor = Color.Red; };
            if (ECT.ES.input7) { rB_PointEntreBouteilleEtCarton.ForeColor = Color.Green; } else { rB_PointEntreBouteilleEtCarton.ForeColor = Color.Red; };
            if (ECT.ES.input8) { rB_PointOrigineX.ForeColor = Color.Green; } else { rB_PointOrigineX.ForeColor = Color.Red; };
        }

        private void ArretUrgence(object sender, EventArgs e)
        {
            ECT.ES.all_OFF();
            ECT.BaseDD.Disconnect();
        }
        private void ArretUrgence_FormClose(object sender, FormClosedEventArgs e)
        {
            ECT.ES.all_OFF();
            ECT.BaseDD.Disconnect();
        }

        private async void btn_StartProg_Click(object sender, EventArgs e)
        {
            // Vérification des capteurs & Attendre le placement du carton si tout est OK
            btn_StartProg.Text = await ECT.Demarrage_Init();

            ECT.ajouter_Bouteilles();
        }
    }
}
