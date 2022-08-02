namespace KikoGuide.UI.Settings;

using System;
using System.IO;
using Dalamud.Interface.Internal.Notifications;
using Dalamud.Interface.ImGuiFileDialog;
using CheapLoc;
using KikoGuide.Base;

class SettingsPresenter : IDisposable
{
    public SettingsPresenter() { }
    public void Dispose() { }

    public bool isVisible = false;

#if DEBUG
    public FileDialogManager dialogManager = new FileDialogManager();
    public void OnDirectoryPicked(bool success, string path)
    {
        if (!success) return;
        var directory = Directory.GetCurrentDirectory();
        Directory.SetCurrentDirectory(path);
        Loc.ExportLocalizable();
        File.Copy(Path.Combine(path, "KikoGuide_Localizable.json"), Path.Combine(path, "en.json"), true);
        Directory.SetCurrentDirectory(directory);
        Service.PluginInterface.UiBuilder.AddNotification("Localization exported successfully.", "KikoGuide", NotificationType.Success);
    }
#endif
}
