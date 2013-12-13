using EPSILab.Jupiter.Webservice;
using System.Collections.Generic;
using System.Linq;

namespace EPSILab.Jupiter.Classes
{
    /// <summary>
    /// Classe permettant l'affichage du bureau et des membres par ville à l'aide de Repeater
    /// </summary>
    public class MembresVille
    {
        /// <summary>
        /// Ville
        /// </summary>
        public Ville Ville { get; private set; }

        /// <summary>
        /// Bureau
        /// </summary>
        public IEnumerable<Membre> Bureau { get; private set; }

        /// <summary>
        /// Membres
        /// </summary>
        public IEnumerable<Membre> Membres { get; private set; }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="ville">Ville</param>
        /// <param name="membres">Liste des membres (bureau et membres)</param>
        public MembresVille(Ville ville, ICollection<Membre> membres)
        {
            Ville = ville;

            Bureau = (from m in membres
                      where m.Role.Code_Role > 1
                      select m);

            Membres = (from m in membres
                       where m.Role.Code_Role == 1
                       select m);
        }
    }
}