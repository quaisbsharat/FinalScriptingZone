using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Provider;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using Windows.UI.Xaml.Media.Animation;

public class Library
{
    public bool myVar = true;
    private StorageFile file;

    public async Task<bool> Confirm(string content, string title, string ok, string cancel)
    {
        bool result = false;
        MessageDialog dialog = new MessageDialog(content, title);
        dialog.Commands.Add(new UICommand(ok, new UICommandInvokedHandler((cmd) => result = true)));
        dialog.Commands.Add(new UICommand(cancel, new UICommandInvokedHandler((cmd) => result = false)));

        await dialog.ShowAsync();
        return result;
    }

    public async
        Task
        New(TextBox display)
    {

        if (await Confirm("Create New Text Document?", "Text Editor", "Yes", "No"))
        {
            display.Text = string.Empty;
            file = null;
            myVar = true;
        }
        else
        {
            myVar = false;
        }
    }



    public async
          Task
     Open(TextBox display)
    {
        try
        {
            FileOpenPicker picker = new FileOpenPicker();
            picker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            picker.FileTypeFilter.Add(".txt");
            this.file = await picker.PickSingleFileAsync();
            display.Text = await FileIO.ReadTextAsync(file);
            myVar = true;
        }
        catch
        {
            myVar = false;
        }
    }
    public async
            Task
    Save(TextBox display)
    {
        try
        {

            FileSavePicker picker = new FileSavePicker();
            picker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            picker.FileTypeChoices.Add("Plain Text", new List<string>() { ".txt" });
            picker.DefaultFileExtension = ".txt";
            picker.SuggestedFileName = "Document";
            StorageFile file = await picker.PickSaveFileAsync();

            if (file != null)
            {
                CachedFileManager.DeferUpdates(file);
                await FileIO.WriteTextAsync(file, display.Text);
                FileUpdateStatus status = await CachedFileManager.CompleteUpdatesAsync(file);
                this.file = null;//Edit عشان

                var msg = new MessageDialog("Saved Successfully");
                await msg.ShowAsync();

                myVar = true;
            }
            else
            {
                myVar = false;
            }
        }
        catch
        {
            var msg = new MessageDialog("Saved Is Not Completed");
            await msg.ShowAsync();
            myVar = false;
        }
    }

    public async
        Task
        Edit(TextBox display)
    {
        if (file != null)
        {
            try
            {

                await FileIO.WriteTextAsync(file, display.Text);
                var msg = new MessageDialog("Updated Successfully");
                await msg.ShowAsync();
                myVar = true;

            }
            catch
            {
                var msg = new MessageDialog("No File Selected!");
                await msg.ShowAsync();
                myVar = false;

            }
        }
        else if (file == null)
        {
            await Open(display);
        }
    }
}