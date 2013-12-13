using EPSILab.Jupiter.Webservice;
using System.Collections.Generic;

namespace EPSILab.Jupiter.Classes
{
    /// <summary>
    /// Classe permettant l'affichage des conférences par ville à l'aide de Repeater
    /// </summary>
    public class ConferencesVille
    {
        /// <summary>
        /// Ville
        /// </summary>
        public Ville Ville { get; set; }

        /// <summary>
        /// Les conférences de cette ville
        /// </summary>
        public IEnumerable<Conference> Conferences { get; set; }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="ville">Ville</param>
        /// <param name="conferences">Conférences</param>
        public ConferencesVille(Ville ville, IEnumerable<Conference> conferences)
        {
            Ville = ville;
            Conferences = conferences;
        }
    }
}