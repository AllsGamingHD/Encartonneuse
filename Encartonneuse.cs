using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encartonneuse
{
    class Encartonneuse
    {
        public CarteES ES = new CarteES();
        public BDD BaseDD = new BDD();
        const int nb_Ranger = 3;

        int nb_RangerAct = 1;
        int nb_BouteilleAct = 0;

        public void Connexion()
        {
            ES.Init();
            BaseDD.Connect();
        }

        private async Task<int> nb_BouteilleTime(int x)
        {
            switch (x)
            {
                case 1:
                    return 500;
                case 2:
                    return 2000;
                case 3:
                    return 3200;
                default:
                    return 0;
            }
        }
        private async void avancer_Bouteille()
        {
            // Faire avancer bouteille
            ES.Relay(8, true);

            while (ES.input1 == false)  // Attendre bouteille au capteur
            {
                await Task.Delay(1);
            }

            // Bouteille au capteur, arreter le tapis
            ES.Relay(8, false);
        }

        private bool verificationBouteille()
        {
            bool cameraresult = false;

            // Acquisition des données de la caméra (bouteille valide ou non)

            return cameraresult;
        }

        private async void deplacerPosmo_EmplacementBouteille()
        {
            // Déplacer POSMO vers les bouteilles
            ES.Relay(2, true);
            await Task.Delay(1500);
            ES.Relay(4, true);
            ES.Relay(3, true);

            while (!ES.input6) // Attendre le POSMO au capteur bouteille
            {
                await Task.Delay(1);
            }
            ES.Relay(3, false);
            ES.Relay(4, false);
        }

        private async void deplacerPosmo_DeposerBouteilleCarton()
        {
            // Lancement posmo vers capteur bouteilles
            ES.Relay(2, true);
            await Task.Delay(1000);
            ES.Relay(3, true);

            while (!ES.input7) // Attendre le POSMO au capteur bouteille
            {
                await Task.Delay(1);
            }

            await Task.Delay(await nb_BouteilleTime(nb_BouteilleAct));


            ES.Relay(3, false);

            await Task.Delay(500);
        }

        private async void deplacerCarton()
        {
            // Déplacer le carton 2 fois pour atteindre la ranger 2
            for (int i = 1; i <= 2; i++)
            {
                // Lever du pas de pelerin 
                ES.Relay(7, true);
                await Task.Delay(100);
                // Avancement du pas de pelerin
                ES.Relay(6, true);

                // Capteur non fonctionnel (donc attente de 1 seconde)
                await Task.Delay(1000);

                // Descendre pas de pelerin 
                ES.Relay(7, false);
                await Task.Delay(100);
                // Déplacement pas de pélerin à la position initiale
                ES.Relay(6, true);

                while (!ES.input5) // Attendre le pas de pélerin à la position initiale
                {
                    await Task.Delay(1);
                }
            }
        }

        public void ajouter_Bouteilles()
        {
            while (nb_RangerAct != nb_Ranger)
            {
                if (nb_RangerAct > 1)
                {
                    // 3 bouteille sur la ranger actuel (ranger 2 ou 3), avancer le carton à la ranger suivante
                    deplacerCarton();
                }

                for (nb_BouteilleAct = 0; nb_BouteilleAct < 3; nb_BouteilleAct++)
                {
                    // Active le tapis et attend une bouteille au capteur
                    avancer_Bouteille();
                    if (verificationBouteille())
                    {
                        // Camera repond true, bouteille valide continuer

                        // Déplace le posmo vers le tapis pour prendre la bouteille
                        deplacerPosmo_EmplacementBouteille();

                        ///////////////////////
                        ///////PROFIBUS////////

                        // Prendre bouteille //

                        /// BOUTEILLE PRISE ///

                        ///////////////////////
                        ///////////////////////

                        deplacerPosmo_DeposerBouteilleCarton();
                        BaseDD.send_data(true, nb_BouteilleAct, nb_RangerAct);
                    }
                    else
                    {
                        // Camera repond false, bouteille non valide ejecter bouteille  et ajouter à la base de données
                        BaseDD.send_data(false, nb_BouteilleAct, nb_RangerAct);

                        // décremente la position de la bouteille de 1, car la boucle va la re-incrementer donc l'emplacement sera vide ou la bouteille n'a pas était placer, si pas de décrement
                        nb_BouteilleAct--;
                    }
                }

                nb_RangerAct++;
            }
        }

        public async Task<string> Demarrage_Init()
        {
            // Vérifié qu'aucun capteur est actif avant le démarrage de la machine.
            if (ES.input1 == false && ES.input2 == false && ES.input4 == false && ES.input5 == false)
            {
                ES.Relay(1, true);
                if (ES.input8 == false) // Deplacer POSMO à butée d'origine
                {
                    ES.Relay(2, true);
                    await Task.Delay(3000);
                    ES.Relay(3, true);
                    while (!ES.input8) // Attente arriver POSMO au capteur butée origine
                    {
                        await Task.Delay(1);
                    }
                    ES.Relay(3, false);
                }

                // Machine prête

                ES.Relay(5, true);
                MessageBox.Show("Machine prête," + Environment.NewLine + "Veuillez mettre un carton en buté puis cliquez sur OK.");

                while (ES.input3 == false)  // Attendre un placement de carton  
                {
                    await Task.Delay(1);
                    if (ES.input3 == true && ES.input4 == false)
                    {
                        break;
                    }
                }
                return "Stop";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Capteur bouteille 1 (camera) : " + ES.input1.ToString());
                sb.AppendLine("Capteur bouteille 2 (sortie de bouteille) : " + ES.input2.ToString());
                sb.AppendLine("Capteur carton 1 (avant butée) : " + ES.input3.ToString());
                sb.AppendLine("Capteur carton 2 (après butée) : " + ES.input4.ToString());
                sb.AppendLine("Pas de pèlerin rentrer : " + ES.input5.ToString());
                sb.AppendLine("Origine posmo X (bouteille) : " + ES.input6.ToString());
                sb.AppendLine("Origine posmo X (entre bouteille et carton) : " + ES.input7.ToString());
                sb.AppendLine("Origine posmo X (Origine départ): " + ES.input8.ToString());
                sb.Replace("True", "Actif");
                sb.Replace("False", "Non actif");

                if (MessageBox.Show("Veuillez vérifié les capteurs de la machine, puis cliquez sur OK" + Environment.NewLine + Environment.NewLine + sb, "Avertissement !", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation) == DialogResult.Retry)
                {
                    return await Demarrage_Init();
                }
                else
                {
                    return "Start";
                }
            }
        }
    }
}
