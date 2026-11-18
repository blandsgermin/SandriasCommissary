using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SandriasDeliciousConcept.Requisition;

public partial class ReasonPromptForm : Form
{
    public ReasonPromptForm(string title, string label)
    {
        InitializeComponent();
        Text = title;
        lblPrompt.Text = label;
    }

    public string Reason => txtReason.Text.Trim();

    public static string? Ask(IWin32Window owner, string title, string label)
    {
        using var form = new ReasonPromptForm(title, label);
        return form.ShowDialog(owner) == DialogResult.OK && form.Reason.Length > 0 ? form.Reason : null;
    }
}