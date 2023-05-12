using ArenaGestor.BusinessHelpers;
using ArenaGestor.BusinessInterface;
using ArenaGestor.DataAccessInterface;
using ArenaGestor.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArenaGestor.Business
{
    public class SnacksService : ISnacksService
    {
        private readonly ISnacksManagement SnacksManagement;

        public SnacksService(ISnacksManagement SnacksManagement)
        {
            this.SnacksManagement = SnacksManagement;
        }
        public Snack AddSnack(Snack snack)
        {

            ValidSnack(snack);
            SnacksManagement.AddSnack(snack);
            SnacksManagement.Save();


            return snack;
        }

        public void DeleteSnack(int snackId)
        {
            CommonValidations.ValidId(snackId);
            Snack snackToDelete = SnacksManagement.SnackById(snackId);
            if (snackToDelete == null)
            {
                throw new NullReferenceException($"The snack with identifier: {snackId} doesn't exist.");
            }
            SnacksManagement.DeleteSnack(snackToDelete);
            SnacksManagement.Save();
        }

        public Snack SnackById(int snackId)
        {
            CommonValidations.ValidId(snackId);
            Snack snack = SnacksManagement.SnackById(snackId);
            if (snack == null)
            {
                throw new NullReferenceException("The snack doesn't exist");
            }
            return snack;
        }

        public IEnumerable<Snack> Snacks()
        {
            return SnacksManagement.Snacks().ToList();
        }

        private static void ValidSnack(Snack snack)
        {
            if (snack == null)
            {
                throw new ArgumentException("You must send the snack");
            }

            snack.ValidSnack();
        }
    }
}
