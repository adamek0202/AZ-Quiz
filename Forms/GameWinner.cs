using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ_Kviz.Forms
{
    internal static class GameWinner
    {
        public static bool GameWinAnounce(string name)
        {
            var dialog = new TaskDialog
            {
                Caption = "AZ-Kvíz – Propojení polí",
                InstructionText = $"{name} úspěšně propojil všechny tři strany!",
                Text = "Byla splněna hlavní podmínka pro výhru. Chceš hru ukončit a vyhodnotit, nebo pokračovat dál v procvičování?",
                Icon = TaskDialogStandardIcon.Information,
            };

            var btnFinish = new TaskDialogCommandLink(
                "btnFinish",
                "Ukončit hru a vyhodnotit",
                "Prohlásit hráče za vítěze a zobrazit závěrečné vyhodnocení."
            );
            btnFinish.Click += (s, e) => dialog.Close(TaskDialogResult.Ok);

            var btnContinue = new TaskDialogCommandLink(
                "btnContinue",
                "Pokračovat ve hře",
                "Ponechat herní plán otevřený a pokračovat v odpovídání na zbývající otázky."
            );
            btnContinue.Click += (s, e) => dialog.Close(TaskDialogResult.CustomButtonClicked);

            dialog.Controls.Add(btnFinish);
            dialog.Controls.Add(btnContinue);

            TaskDialogResult result = dialog.Show();

            return result == TaskDialogResult.Ok ? true : false;
        }
    }
}
