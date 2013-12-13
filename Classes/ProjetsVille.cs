using EPSILab.Jupiter.Webservice;
using System.Collections.Generic;

namespace EPSILab.Jupiter.Classes
{
    /// <summary>
    /// Classe permettant l'affichage des projets par ville à l'aide de Repeater
    /// </summary>
    public class ProjetsVille
    {
        /// <summary>
        /// Ville
        /// </summary>
        public Ville Ville { get; private set; }

        /// <summary>
        /// Liste des projets
        /// </summary>
        public IEnumerable<Projet> Projets { get; private set; }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="ville">Ville</param>
        /// <param name="projets">Liste des projets</param>
        public ProjetsVille(Ville ville, IEnumerable<Projet> projets)
        {
            Ville = ville;
            Projets = projets;
        }
    }
}