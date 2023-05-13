using ArenaGestor.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGestor.DataAccessInterface
{
    public interface ISnacksManagement
    {
        IEnumerable<Snack> Snacks();
        void AddSnack(Snack snack);
        Snack SnackById(int snackId);
        void DeleteSnack(Snack snack);
        void Save();
    }
}
