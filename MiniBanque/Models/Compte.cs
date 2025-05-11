using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniBanque.Models
{
    public abstract class Compte
    {
        public string NumCompte { get; set; }
        public string Libelle { get; set; }
        public DateTime DateOuverture { get; set; }
        public decimal Solde { get; set; }
        public string Type { get; set; }

        public bool? AutorisationDecouvert { get; set; }
        public decimal? MontantDecouvert { get; set; }

        public decimal? TauxInteret { get; set; }
        public int? AncienneteMin { get; set; }

        public int NumClient { get; set; }
        public Client Client { get; set; }

        public virtual void Credit(decimal montant) => Solde += montant;

        public virtual bool Debit(decimal montant)
        {
            var decouvertMax = (AutorisationDecouvert == true && MontantDecouvert.HasValue)
                ? -MontantDecouvert.Value
                : 0;

            if (Solde - montant >= decouvertMax)
            {
                Solde -= montant;
                return true;
            }
            return false;
        }
    }

}
