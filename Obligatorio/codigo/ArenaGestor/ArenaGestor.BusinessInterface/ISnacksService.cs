using ArenaGestor.Domain;
using System.Collections.Generic;

namespace ArenaGestor.BusinessInterface
{
    public interface ISnacksService
    {
        Snack SnackById(int snackId);
        IEnumerable<Snack> Snacks();
        Snack AddSnack(Snack snack);
        void DeleteSnack(int snackId);
    }
}
