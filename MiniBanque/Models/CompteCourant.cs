using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniBanque.Models
{
    public class CompteCourant : Compte
    {
        public override bool Debit(decimal montant)
        {
            if (montant <= 0)
            {
                throw new ArgumentException("Le montant doit être positif.");
            }

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
