using ArenaGestor.DataAccessInterface;
using ArenaGestor.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGestor.DataAccess.Managements
{
    public class SnacksManagement : ISnacksManagement
    {
        private readonly DbSet<Snack> snacks;
        private readonly DbContext context;

        public SnacksManagement(DbContext context)
        {
            this.snacks = context.Set<Snack>();
            this.context = context;
        }

        public void AddSnack(Snack snack)
        {
            snacks.Add(snack);
        }

        public void DeleteSnack(Snack snack)
        {
            snacks.Remove(snack);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        public Snack SnackById(int snackId)
        {
            return snacks.AsNoTracking().FirstOrDefault(x => x.SnackId == snackId);

        }

        public IEnumerable<Snack> Snacks()
        {
            return snacks.AsNoTracking();
        }
    }
}
