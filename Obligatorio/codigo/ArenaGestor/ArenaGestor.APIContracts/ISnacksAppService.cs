using ArenaGestor.APIContracts.Snacks;
using Microsoft.AspNetCore.Mvc;


namespace ArenaGestor.APIContracts
{
    public interface ISnacksAppService
    {
        IActionResult SnacksById(int snackId);
        IActionResult Snacks();
        IActionResult AddSnack(SnackInsertDto insertSnack);
        IActionResult RemoveSnack(int snackId);
    }
}
