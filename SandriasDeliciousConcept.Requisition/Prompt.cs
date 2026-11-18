using System;
using System.Collections.Generic;
using System.Text;

namespace SandriasDeliciousConcept.Requisition;

internal static class Prompt
{
    public static string? Show(IWin32Window owner, string title, string label)
    {
        using var form = new Form
        {
            Text = title,
            Width = 420,
            Height = 180,
            StartPosition = FormStartPosition.CenterParent,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            MaximizeBox = false,
            MinimizeBox = false
        };
        var lbl = new Label { Text = label, Left = 12, Top = 12, Width = 380 };
        var box = new TextBox { Left = 12, Top = 40, Width = 380 };
        var ok = new Button { Text = "OK", Left = 232, Top = 80, Width = 75, DialogResult = DialogResult.OK };
        var cancel = new Button { Text = "Cancel", Left = 317, Top = 80, Width = 75, DialogResult = DialogResult.Cancel };
        form.Controls.AddRange(new Control[] { lbl, box, ok, cancel });
        form.AcceptButton = ok;
        form.CancelButton = cancel;
        return form.ShowDialog(owner) == DialogResult.OK && !string.IsNullOrWhiteSpace(box.Text)
            ? box.Text.Trim() : null;
    }
}
