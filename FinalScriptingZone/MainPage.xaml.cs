using Scripting_Zone;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FinalScriptingZone
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Library lib = new Library();

        List<string> param = new List<string>();
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            string url = "http://localhost:62516/api/Default";
            WebRequest webreq = HttpWebRequest.Create(url);
            webreq.Method = "Post";
            StreamWriter sw = new StreamWriter(await webreq.GetRequestStreamAsync());
            sw.WriteLine(txtLicence.Text);
            sw.Flush();
            WebResponse response = await webreq.GetResponseAsync();//get stream from httprequest
            Stream dataStream = response.GetResponseStream();
            StreamReader sr = new StreamReader(dataStream);
            string result = sr.ReadToEnd();
            MessageDialog MD = new MessageDialog(result);
            await MD.ShowAsync();
        }
        void HideAllLayout()
        {
            EditorPage.Visibility = Visibility.Visible;
            L00pPage.Visibility = Visibility.Collapsed;
            IfStatmentPage.Visibility = Visibility.Collapsed;
            CheckedButtonPage.Visibility = Visibility.Collapsed;
            ExtractPage.Visibility = Visibility.Collapsed;
            TextInputPage.Visibility = Visibility.Collapsed;
            TimeWaitPage.Visibility = Visibility.Collapsed;
            URLNavigationPage.Visibility = Visibility.Collapsed;
            LoadDataFromFilePage.Visibility = Visibility.Collapsed;
        }

        private void Number_Just(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key < Windows.System.VirtualKey.Number0 || e.Key > Windows.System.VirtualKey.Number9)
            {
                if (e.Key < Windows.System.VirtualKey.NumberPad0 || e.Key > Windows.System.VirtualKey.NumberPad9)
                {
                    if (e.Key != Windows.System.VirtualKey.Back)
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
        }

        private async void New_Click(object sender, RoutedEventArgs e)
        {

            bool IsChanged = Editor.Text != string.Empty;

            if (IsChanged)
            {
                await lib.New(Editor);


            }
        }

        private async void Open_Click(object sender, RoutedEventArgs e)
        {

            await lib.Open(Editor);


        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            await lib.Save(Editor);





        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
        }


        private void NumberEditor_GotFocus(object sender, RoutedEventArgs e)
        {
            Editor.Focus(FocusState.Keyboard);

        }

        private void Editor_TextChanged(object sender, TextChangedEventArgs e)
        {

            /*Know What The User Inter

            string[] ReservedWord = { "for", "if" };


            string[] Words = Editor.Text.Split(' ','\n');

            foreach(string Word in Words )
            {
                if (Word == ReservedWord[0] || Word==ReservedWord[1])
                {
                   
                    var msg = new MessageDialog("its ReservedWord");
                    await msg.ShowAsync();

                    // if the Word Was for
                }

            }

            End Of Know What The User Inter*/


            //if(Word[Editor.Text.Length]==' ')
            //{

            //}

            //foreach (char c in Editor.Text)
            //{

            //    CharCha [count] = c;
            //    if(Editor.Text.Split(' ')) { }
            //    if (c == '\n' || c== '\t' || c==Convert.ToChar(" "))
            //    {

            //    }
            //}

            //char [] c = Editor.Text.Split('')

            //IsChanged = true;
            ////How Much Enter I have
            //NumberEditor.Text += Environment.NewLine;
            //int EnterChar = Editor.Text.Split('\n').Count();
            //for (int i = 0; i < EnterChar; i++)
            //    NumberEditor.Text = EnterChar.ToString();
            ////foreach (char c in Editor.Text)
            ////{


            ////    if (c == '\n')
            ////    {

            ////        NumberEditor.Text += EnterChar + Environment.NewLine;
            ////        EnterChar = Editor.Text.Split('\n').Count();


            ////    }
            ////}



            ////foreach (char c in Editor.Text)
            ////{
            ////    if (c == '\n')
            ////    {
            ////        count++;

            ////    }
            ////}

        }

        private async void Edit_Click(object sender, RoutedEventArgs e)
        {
            await lib.Edit(Editor);

        }

        private void FullScreen_Click(object sender, RoutedEventArgs e)
        {
            EditorPage.Visibility = Visibility.Collapsed;
            GridForAllPic.Visibility = Visibility.Visible;

        }

        private void ShowL00p_Click(object sender, RoutedEventArgs e)
        {

            HideAllLayout();


            if (EditorPage.Visibility == Visibility.Visible)
            {
                L00pPage.Visibility = Visibility.Visible;
                EditorPage.Visibility = Visibility.Collapsed;

            }
            else if (L00pPage.Visibility == Visibility.Visible)
            {
                L00pPage.Visibility = Visibility.Collapsed;
                EditorPage.Visibility = Visibility.Visible;
            }

        }

        private void ShowIF_Click(object sender, RoutedEventArgs e)
        {

            HideAllLayout();

            if (EditorPage.Visibility == Visibility.Visible)
            {
                IfStatmentPage.Visibility = Visibility.Visible;
                EditorPage.Visibility = Visibility.Collapsed;

            }
            else
            {
                IfStatmentPage.Visibility = Visibility.Collapsed;
                EditorPage.Visibility = Visibility.Visible;
            }
        }

        private void ShowCheckedButton_Click(object sender, RoutedEventArgs e)
        {

            HideAllLayout();

            if (EditorPage.Visibility == Visibility.Visible)
            {
                CheckedButtonPage.Visibility = Visibility.Visible;
                EditorPage.Visibility = Visibility.Collapsed;

            }
            else
            {
                CheckedButtonPage.Visibility = Visibility.Collapsed;
                EditorPage.Visibility = Visibility.Visible;
            }


            if (App.loop_array_variables.Count != 0)
            {
                Checkedloop.IsEnabled = true;
                foreach (String l in App.loop_array_variables)
                {
                    Checkedcomboboxloop.Items.Add(l);
                }
            }
            else
            {
                Checkedloop.IsEnabled = false;
            }
        }

        private void ShowExtract_Click(object sender, RoutedEventArgs e)
        {
            App.ExtractLink_bool = false;
            App.ExtractText_bool = false;


            if (App.loop_array_variables.Count != 0)
            {
                ExrepeatedLoop.IsEnabled = true;
                foreach (String l in App.loop_array_variables)
                {
                    ExcomboBoxloop.Items.Add(l);
                }
            }
            else
            {
                ExrepeatedLoop.IsEnabled = false;
            }


            HideAllLayout();

            if (EditorPage.Visibility == Visibility.Visible)
            {
                ExtractPage.Visibility = Visibility.Visible;
                EditorPage.Visibility = Visibility.Collapsed;

            }
            else
            {
                ExtractPage.Visibility = Visibility.Collapsed;
                EditorPage.Visibility = Visibility.Visible;
            }
        }

        private void ShowTextInput_Click(object sender, RoutedEventArgs e)
        {
            HideAllLayout();


            if (EditorPage.Visibility == Visibility.Visible)
            {
                TextInputPage.Visibility = Visibility.Visible;
                EditorPage.Visibility = Visibility.Collapsed;

            }
            else
            {
                TextInputPage.Visibility = Visibility.Collapsed;
                EditorPage.Visibility = Visibility.Visible;
            }



            if (App.loop_array_variables.Count != 0)
            {
                Inputcomboboxloop.IsEnabled = true;
                foreach (String l in App.loop_array_variables)
                {
                    Inputcomboboxloop.Items.Add(l);
                }
            }
            else
            {
                Inputloop.IsEnabled = false;
            }


        }

        private void ShowTimeWait_Click(object sender, RoutedEventArgs e)
        {
            HideAllLayout();


            if (EditorPage.Visibility == Visibility.Visible)
            {
                TimeWaitPage.Visibility = Visibility.Visible;
                EditorPage.Visibility = Visibility.Collapsed;

            }
            else
            {
                TimeWaitPage.Visibility = Visibility.Collapsed;
                EditorPage.Visibility = Visibility.Visible;
            }
        }

        private void ShowURLNavigation_Click(object sender, RoutedEventArgs e)
        {
            HideAllLayout();

            if (EditorPage.Visibility == Visibility.Visible)
            {
                URLNavigationPage.Visibility = Visibility.Visible;
                EditorPage.Visibility = Visibility.Collapsed;

            }
            else
            {
                URLNavigationPage.Visibility = Visibility.Collapsed;
                EditorPage.Visibility = Visibility.Visible;
            }
            if (App.File_Coulmns.Count > 0 || App.Extracted_Data_Variables.Count > 0 || App.Prompts.Count > 0)
            {
                foreach (string datavariable in App.Extracted_Data_Variables)
                {
                    comboBoxurl.Items.Add(datavariable);
                }
                foreach (string column in App.File_Coulmns)
                {
                    comboBoxurl.Items.Add(column);
                }
                foreach (string prompt in App.Prompts)
                {
                    comboBoxurl.Items.Add(prompt);
                }
            }
            else
            {
                radioButtonvariable.IsEnabled = false;
            }
        }

        private void ShowLoadDataFromFile_Click(object sender, RoutedEventArgs e)
        {
            HideAllLayout();

            if (EditorPage.Visibility == Visibility.Visible)
            {
                LoadDataFromFilePage.Visibility = Visibility.Visible;
                EditorPage.Visibility = Visibility.Collapsed;

            }
            else
            {
                LoadDataFromFilePage.Visibility = Visibility.Collapsed;
                EditorPage.Visibility = Visibility.Visible;
            }


            if (App.loop_array_variables.Count > 0)
            {
                foreach (string loop in App.loop_array_variables)
                {
                    Loadloop.Items.Add(loop);
                }
            }
            else
            {
                Loadlineeachloop.IsChecked = false;
                Loadlineeachloop.IsEnabled = false;
            }
        }

        private void Licence_Click(object sender, RoutedEventArgs e)
        {
            HideAllLayout();
            if (LicencePage.Visibility == Visibility.Visible)
            {
                EditorPage.Visibility = Visibility.Visible;
                LicencePage.Visibility = Visibility.Collapsed;
            }
            else
            {
                EditorPage.Visibility = Visibility.Collapsed;
                LicencePage.Visibility = Visibility.Visible;
            }
        }

        #region ForLoop
        // LOOP 
        RemoveWhiteSpaces remove = new RemoveWhiteSpaces();
        private async void txtstart_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog msg;
            variableloop.Text = remove.Remove_White_Spaces((variableloop.Text).ToUpper());

            //Errors
            if (!Convert.ToBoolean(loopunlitmted.IsChecked) && string.IsNullOrWhiteSpace(txtendloop.Text))
            {
                msg = new MessageDialog("Please Enter the Loop paramters!");
                await msg.ShowAsync();
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtstartloop.Text))
            {
                msg = new MessageDialog("Please Enter the Loop paramters!");
                await msg.ShowAsync();
                return;
            }
            else if (!Convert.ToBoolean(loopunlitmted.IsChecked) && int.Parse(txtstartloop.Text) > int.Parse(txtendloop.Text))
            {
                // MessageBox.Show("The Started Number Can't be bigger Than End Number!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                msg = new MessageDialog("The Started Number Can't be bigger Than End Number!");
                await msg.ShowAsync();
                return;
            }
            else if (string.IsNullOrWhiteSpace(variableloop.Text))
            {
                // MessageBox.Show("Variable Can't be Blank!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                msg = new MessageDialog("Variable Can't be Blank!");
                await msg.ShowAsync();
                return;
            }
            else if (App.All_Variables.Contains(variableloop.Text))
            {
                // MessageBox.Show("you used this variable before please choose different one!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                msg = new MessageDialog("you used this variable before please choose different one!");
                await msg.ShowAsync();
                return;
            }

            string theloop;
            //Create the code
            if (!Convert.ToBoolean(loopunlitmted.IsChecked))
            {
                theloop = "for(var " + variableloop.Text + " = " + int.Parse(txtstartloop.Text) + "; " + variableloop.Text + " <= " + int.Parse(txtendloop.Text) + "; " + variableloop.Text + "++)" + "\n" + "{" + "\n\n" + "}";
            }
            else
            {
                theloop = "for(var " + variableloop.Text + " = " + int.Parse(txtstartloop.Text) + "; " + int.Parse(txtstartloop.Text) + " <= " + variableloop.Text + "; " + variableloop.Text + "++)" + "\n" + "{" + "\n\n" + "}";
            }
            Editor.Text = Editor.Text.Insert(Editor.SelectionStart, theloop) + Environment.NewLine;
            App.loop_array_variables.Add(variableloop.Text);
            App.All_Variables.Add(variableloop.Text);
            L00pPage.Visibility = Visibility.Collapsed;
            EditorPage.Visibility = Visibility.Visible;
        }


        private void loopunlitmted_Click(object sender, RoutedEventArgs e)
        {
            txtendloop.IsEnabled = !Convert.ToBoolean(loopunlitmted.IsChecked);
        }
        //End LOOP
        #endregion ForLoop

        #region URL Navigation
        //URL Navigation <-------------------------------------------------------------------------------------------------------------->
        private async void OkUrlNavigation_Click(object sender, RoutedEventArgs e)
        {


            urltext.Text = urltext.Text.Replace(" ", "");
            //     url_timewait = int.Parse(urltimeout.Text);
            //      choosen_variable = comboBoxurl.IsSynchronizedWithCurrentItem.Value.ToString();
            MessageDialog mesg;


            if (Convert.ToBoolean(radioButtonenterlink.IsChecked))
            {
                string urlregex = @"^(http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$";
                Regex reg = new Regex(urlregex, RegexOptions.Compiled | RegexOptions.IgnoreCase);
                if (!reg.IsMatch(urltext.Text))
                {
                    // MessageBox.Show("It Is Not Valid Url?!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mesg = new MessageDialog("It Is Not Valid Url?!");
                    await mesg.ShowAsync();
                    return;
                }
            }
            else if (Convert.ToBoolean(radioButtonvariable.IsChecked))
            {
                if (comboBoxurl.SelectedItem.ToString().Length <= 0)
                {
                    //  MessageBox.Show("You must choose an variable that it's content will contain url", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mesg = new MessageDialog("You must choose an variable that it's content will contain url");
                    await mesg.ShowAsync();
                    return;
                }
            }

            //create the code
            string URLNAVIGATE = "";
            string macrourl = "";
            string Set = "";
            string macrotimeout = "'SET !TIMEOUT_PAGE " + urltimeout.Text + "'";

            if (Convert.ToBoolean(radioButtonenterlink.IsChecked))
            {
                macrourl = "'\\nURL GOTO=" + urltext.Text + "'";
            }
            else if (Convert.ToBoolean(radioButtonvariable.IsChecked))
            {
                Set = "iimSet('" + comboBoxurl.SelectedItem.ToString().ToLower() + "', " + comboBoxurl.SelectedItem.ToString() + ")\n";
                macrourl = "'\\nURL GOTO={{" + comboBoxurl.SelectedItem.ToString().ToLower() + "}}'";
            }


            if (urlnewtab.IsChecked == true)
            {
                URLNAVIGATE = "iimPlay('CODE:'+" + macrotimeout + "+" + "'\\nTab open'+'\\nTab t=2'+" + macrourl + ");";
            }
            else
            {
                URLNAVIGATE = "iimPlay('CODE:'+" + macrotimeout + "+" + macrourl + ");";
            }


            Editor.Text = Editor.Text.Insert(Editor.SelectionStart, Set + URLNAVIGATE + Environment.NewLine);

            URLNavigationPage.Visibility = Visibility.Collapsed;
            EditorPage.Visibility = Visibility.Visible;
        }

        private void URLNavigationPage_Loading(FrameworkElement sender, object args)
        {




        }

        private void radioButtonenterlink_Click(object sender, RoutedEventArgs e)
        {
            radioButtonvariable.IsChecked = !radioButtonenterlink.IsChecked;
            comboBoxurl.IsEnabled = false;
        }

        private void radioButtonvariable_Click(object sender, RoutedEventArgs e)
        {
            radioButtonenterlink.IsChecked = !radioButtonvariable.IsChecked;
            comboBoxurl.IsEnabled = true;
        }

        private void urltimeout_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (urltimeout.Text.Length == 0)
            {
                urltimeout.Text = "0";
            }
        }
        //End URL Navigation <-------------------------------------------------------------------------------------------------------------->
        #endregion URL Navigation

        #region Extract

        private void extractText_Click(object sender, RoutedEventArgs e)
        {
            App.ExtractText_bool = true;
            App.ExtractLink_bool = false;
            extractText.Background = new SolidColorBrush(Windows.UI.Colors.Aqua);
        }

        private void extractLink_Click(object sender, RoutedEventArgs e)
        {
            App.ExtractText_bool = false;
            App.ExtractLink_bool = true;
            extractLink.Background = new SolidColorBrush(Windows.UI.Colors.Aqua);
        }

        private void extractPageTitle_Click(object sender, RoutedEventArgs e)
        {
            string pagetitle = "iimPlay('CODE:'+'TAG POS=1 TYPE=TITLE ATTR=* EXTRACT=TXT');";
            string pagetitle_var = String.Format("var PAGETITLE{0} = iimGetLastExtract(1);", App.counter_title);
            Editor.Text = Editor.Text.Insert(Editor.SelectionStart, pagetitle + "\n" + pagetitle_var) + Environment.NewLine;
            App.Extracted_Data_Variables.Add(String.Format("PAGETITLE{0}", App.counter_title));
            App.All_Variables.Add(String.Format("PAGETITLE{0}", App.counter_title));
            App.counter_title++;
            ExtractPage.Visibility = Visibility.Collapsed;
            EditorPage.Visibility = Visibility.Visible;
        }

        private void extractCurrentUrl_Click(object sender, RoutedEventArgs e)
        {
            string pagetitle = "iimPlay('CODE:'+'ADD !EXTRACT {{!URLCURRENT}}');";
            string pagetitle_var = String.Format("var CURRENTURL{0} = iimGetLastExtract(1);", App.counter_url);
            Editor.Text = Editor.Text.Insert(Editor.SelectionStart, pagetitle + "\n" + pagetitle_var) + Environment.NewLine;
            App.Extracted_Data_Variables.Add(String.Format("CURRENTURL{0}", App.counter_url));
            App.All_Variables.Add(String.Format("CURRENTURL{0}", App.counter_url));
            App.counter_url++;
            ExtractPage.Visibility = Visibility.Collapsed;
            EditorPage.Visibility = Visibility.Visible;
        }

        private async void ExOk_Click(object sender, RoutedEventArgs e)
        {
            /*------Errors------*/
            MessageDialog ErrorMSG;
            //tag
            if (ExTageType.Text.Length < 1)
            {
                // MessageBox.Show("You Can't Leave Tage Type Blank!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ErrorMSG = new MessageDialog("You Can't Leave Tage Type Blank!");
                await ErrorMSG.ShowAsync();
                return;
            }
            //Extract Nmae
            else if (ExExtractName.Text.Length < 1)
            {
                //  MessageBox.Show("You Can't Leave Extract Name Blank!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ErrorMSG = new MessageDialog("You Can't Leave Extract Name Blank!");
                await ErrorMSG.ShowAsync();
                return;
            }
            else if (App.All_Variables.Contains(ExExtractName.Text))
            {
                //MessageBox.Show("You Used This Name Before You Can't Use It Again !", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ErrorMSG = new MessageDialog("You Used This Name Before You Can't Use It Again !");
                await ErrorMSG.ShowAsync();
                return;
            }
            //attr1
            else if (ExattrName.Text.Length < 1 || ExattrValue.Text.Length < 1)
            {
                // MessageBox.Show("You Can't Leave Attribute Name Or Attribute Value Blank", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ErrorMSG = new MessageDialog("You Can't Leave Attribute Name Or Attribute Value Blank");
                await ErrorMSG.ShowAsync();
                return;
            }

            //Create the code
            string Extracting;
            string choosen_loop = "";
            string lastextraction;

            Extracting = "iimPlay('CODE:'+'SET !TIMEOUT_STEP " + ExTimeout.Text + "'" + "+'\\nTAG POS=1 TYPE=" + ExTageType.Text + " ATTR=" + ExattrName.Text + ":" + ExattrValue.Text;
            lastextraction = "var " + ExExtractName.Text + "=" + " iimGetLastExtract(1);";

            if (attr2checked.IsChecked == true)
            {
                Extracting += "&&" + Exattr2Name + ":" + Exattr2Value;
            }
            if (ExrepeatedLoop.IsChecked == true)
            {
                choosen_loop = "iimSet('" + ExcomboBoxloop.SelectedItem.ToString().ToLower() + "'," + ExcomboBoxloop.SelectedItem.ToString() + ")\n";
                Extracting = Extracting.Replace("POS=1", "POS={{" + ExcomboBoxloop.SelectedItem.ToString().ToLower() + "}}");
            }

            if (App.ExtractText_bool)
            {
                App.ExtractText_bool = false;
                Extracting += " EXTRACT=TXT'" + ");";
            }
            else if (App.ExtractLink_bool)
            {
                App.ExtractLink_bool = true;
                Extracting += " EXTRACT=href'" + ");";
            }
            else
            {
                ErrorMSG = new MessageDialog("Please choose Extracted Data Type (Text - Link)");
                await ErrorMSG.ShowAsync();
                return;
            }
            App.Extracted_Data_Variables.Add(ExExtractName.Text);
            App.All_Variables.Add(ExExtractName.Text);
            Editor.Text = Editor.Text.Insert(Editor.SelectionStart, choosen_loop + Extracting + "\n" + lastextraction) + Environment.NewLine;
            ExtractPage.Visibility = Visibility.Collapsed;
            EditorPage.Visibility = Visibility.Visible;
        }


        private void ExrepeatedLoop_Click(object sender, RoutedEventArgs e)
        {
            ExcomboBoxloop.IsEnabled = Convert.ToBoolean(ExrepeatedLoop.IsChecked);
        }


        private void attr2checked_Click(object sender, RoutedEventArgs e)
        {
            Exattr2Name.IsEnabled = Convert.ToBoolean(attr2checked.IsChecked);
            Exattr2Value.IsEnabled = Convert.ToBoolean(attr2checked.IsChecked);
        }

        private void ExTimeout_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ExTimeout.Text.Length == 0)
            {
                ExTimeout.Text = "0";
            }
        }


        #endregion Extract

        #region IF_Statment
        private void CheckText_Click(object sender, RoutedEventArgs e)
        {
            App.CheckText_bool = true;
            App.CheckLink_bool = false;
            App.CheckButton_bool = false;
        }

        private void CheckLink_Click(object sender, RoutedEventArgs e)
        {
            App.CheckLink_bool = true;
            App.CheckText_bool = false;
            App.CheckButton_bool = false;
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            App.CheckButton_bool = true;
            App.CheckText_bool = false;
            App.CheckLink_bool = false;
        }

        private async void CHok_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog msg;

            /*------Errors------*/
            //tag
            if (CHTagType.Text.Length < 1)
            {
                msg = new MessageDialog("You Can't Leave Tage Type Blank!");
                await msg.ShowAsync();
                // MessageBox.Show("You Can't Leave Tage Type Blank!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //Extract Nmae
            else if (CHTextName.Text.Length < 1)
            {
                msg = new MessageDialog("You Can't Leave Extract Name Blank!");
                await msg.ShowAsync();
                return;

                //  MessageBox.Show("You Can't Leave Extract Name Blank!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (App.All_Variables.Contains(CHTextName.Text))
            {
                msg = new MessageDialog("You Used This Name Before You Can't Use It Again !");
                await msg.ShowAsync();
                return;

                //MessageBox.Show("You Used This Name Before You Can't Use It Again !", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //attr1
            else if (CHattrName1.Text.Length < 1 || CHattrValue1.Text.Length < 1)
            {
                msg = new MessageDialog("You Can't Leave Attribute Name Or Attribute Value Blank ");
                await msg.ShowAsync();
                return;

                //MessageBox.Show("You Can't Leave Attribute Name Or Attribute Value Blank", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            //creat the code

            string text_button_pressing = "iimPlay('CODE:'+'SET !TIMEOUT_STEP " + CHtimeout.Text + "'" + "+'\\nTAG POS=1 TYPE=" + CHTagType.Text + " ATTR=" + CHattrName1.Text + ":" + CHattrValue1.Text;

            App.All_Variables.Add(CHTextName.Text);

            if (CHcomboboxattr2.IsChecked == true)
            {
                text_button_pressing += "&&" + CHattrName2.Text + ":" + CHattrValue2.Text;
            }

            if (App.CheckText_bool)
            {
                text_button_pressing += " Extract=txt'" + ");";
                string variable = String.Format("var {0} = iimGetLastExtract(1)", CHTextName.Text);
                string IF_ELSE = "if(" + CHTextName.Text + " == '#EANF#' || " + CHTextName.Text + " == null)" + "\n{\n////Here are the codes that will run if data is null////\n}" + "\nelse" + "\n{\n////Here are the codes that will run if data not null////\n}";
                Editor.Text = Editor.Text.Insert(Editor.SelectionStart, text_button_pressing + "\n" + variable + "\n" + IF_ELSE + "\n");
            }
            else if (App.CheckLink_bool)
            {

                text_button_pressing += " Extract=href'" + ");";
                string variable = String.Format("var {0} = iimGetLastExtract(1)", CHTextName.Text);
                string IF_ELSE = "if(" + CHTextName.Text + " == '#EANF#' || " + CHTextName.Text + " == null)" + "\n{\n////Here are the codes that will run if link is null////\n}" + "\nelse" + "\n{\n////Here are the codes that will run if link not null////\n}";
                Editor.Text = Editor.Text.Insert(Editor.SelectionStart, text_button_pressing + "\n" + variable + "\n" + IF_ELSE + "\n");
            }
            else if (App.CheckButton_bool)
            {
                text_button_pressing += "'" + ");";
                string variable = String.Format("var {0} = {1}", CHTextName.Text, text_button_pressing);
                string IF_ELSE = "if(" + CHTextName.Text + " > 0)" + "\n{\n////Replace this with cods will run if button exist////\n}" + "\nelse" + "\n{\n////Replace this with cods will run if button dose't exist////\n}";
                Editor.Text += (variable + "\n" + IF_ELSE + "\n\n");
            }
            //Editor.Text.Insert(Editor.SelectionStart,

            IfStatmentPage.Visibility = Visibility.Collapsed;
            EditorPage.Visibility = Visibility.Visible;
        }
        #endregion  IF_Statment

        #region TextInput
        private async void InputOK_Click(object sender, RoutedEventArgs e)
        {
            /*------Errors------*/
            //tag
            MessageDialog msg;

            if (Inputtagtype.Text.Length < 1)
            {
                // MessageBox.Show("You Can't Leave Tage Type Blank!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                msg = new MessageDialog("You Can't Leave Tage Type Blank!");
                await msg.ShowAsync();
                return;

            }
            //attr1
            else if (InputattrName1.Text.Length < 1 || InputattrValue1.Text.Length < 1)
            {
                // MessageBox.Show("You Can't Leave Attribute Name Or Attribute Value Blank", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                msg = new MessageDialog("You Can't Leave Attribute Name Or Attribute Value Blank");
                await msg.ShowAsync();
                return;
            }

            //create the code
            string Text_Input;
            string choosen_loop = "";
            Text_Input = "iimPlay('CODE:'+'SET !TIMEOUT_STEP " + Inputtimeout.Text + "'" + "+'\\nTAG POS=1 TYPE=" + Inputtagtype.Text + " ATTR=" + InputattrName1.Text + ":" + InputattrValue1.Text;

            if (Inputattr2.IsChecked == true)
            {
                Text_Input += "&&" + InputattrName2.Text + ":" + InputattrValue2.Text;
            }
            if (Inputloop.IsChecked == true)
            {
                choosen_loop = "iimSet('" + Inputcomboboxloop.SelectedItem.ToString().ToLower() + "'," + Inputcomboboxloop.SelectedItem.ToString() + ")";
                Text_Input = Text_Input.Replace("POS=1", "POS={{" + Inputcomboboxloop.SelectedItem.ToString().ToLower() + "}}");
            }
            //Form Content Show
            ContentPage.Visibility = Visibility.Visible;
            TextInputPage.Visibility = Visibility.Collapsed;

            if (App.Prompts.Count != 0)
            {
                foreach (string prompt in App.Prompts)
                {
                    Contentcomboboxprompt.Items.Add(prompt);
                }
            }
            else
            {
                Contentprompt.IsEnabled = false;
            }

            if (App.File_Coulmns.Count != 0 || App.Extracted_Data_Variables.Count != 0)
            {
                foreach (string column in App.File_Coulmns)
                {
                    Contentcoboboxfile.Items.Add(column);
                }

                foreach (string variable in App.Extracted_Data_Variables)
                {
                    Contentcoboboxfile.Items.Add(variable);
                }
            }
            else
            {
                Contentfile.IsEnabled = false;
            }

            ContentOk.Click += (object s, RoutedEventArgs ee) =>
            {
                string ContentSet = "";
                string ContentIMpliment = "";

                if (App.ContentText_bool)
                {
                    ContentSet = String.Format("var CONTENT{0} = '{1}'\niimSet('content{0}',CONTENT{0})", App.contentCounter, ContentText_input.Text);
                    ContentIMpliment = "{{" + "content" + App.contentCounter + "}}";
                    App.contentCounter++;
                }
                else if (App.Contentfile_bool)
                {
                    ContentSet = String.Format("iimSet('{0}',{1})", Contentcoboboxfile.SelectedItem.ToString().ToLower(), Contentcoboboxfile.SelectedItem.ToString());
                    ContentIMpliment = "{{" + Contentcoboboxfile.SelectedItem.ToString().ToLower() + "}}";
                }
                else if (App.Contentprompt_bool)
                {
                    ContentSet = String.Format("iimSet('{0}',{1})", Contentcomboboxprompt.SelectedItem.ToString().ToLower(), Contentcomboboxprompt.SelectedItem.ToString());
                    ContentIMpliment = "{{" + Contentcomboboxprompt.SelectedItem.ToString().ToLower() + "}}";
                }

                Text_Input += String.Format(" CONTENT={0}'" + ");", ContentIMpliment);
                Editor.Text += (ContentSet + choosen_loop + "\n" + Text_Input + "\n\n");

                ContentPage.Visibility = Visibility.Collapsed;
                EditorPage.Visibility = Visibility.Visible;
            };



        }


        private void contentText_Click(object sender, RoutedEventArgs e)
        {
            Contentfile.IsChecked = Contentprompt.IsChecked = !contentText.IsChecked;
            App.ContentText_bool = true;
            App.Contentfile_bool = App.Contentprompt_bool = !App.ContentText_bool;
            ContentText_input.IsEnabled = Convert.ToBoolean(contentText.IsChecked);
            Contentcoboboxfile.IsEnabled = false;
            Contentcomboboxprompt.IsEnabled = false;
        }

        private void Contentfile_Click(object sender, RoutedEventArgs e)
        {
            Contentprompt.IsChecked = contentText.IsChecked = !Contentfile.IsChecked;
            App.Contentfile_bool = true;
            App.Contentprompt_bool = App.ContentText_bool = !App.Contentfile_bool;
            Contentcoboboxfile.IsEnabled = Convert.ToBoolean(Contentfile.IsChecked);
            ContentText_input.IsEnabled = false;
            Contentcomboboxprompt.IsEnabled = false;
        }

        private void Contentprompt_Click(object sender, RoutedEventArgs e)
        {
            Contentfile.IsChecked = contentText.IsChecked = !Contentprompt.IsChecked;
            App.Contentprompt_bool = true;
            App.Contentfile_bool = App.ContentText_bool = !App.Contentprompt_bool;
            Contentcomboboxprompt.IsEnabled = Convert.ToBoolean(Contentprompt.IsChecked);
            ContentText_input.IsEnabled = false;
            Contentcoboboxfile.IsEnabled = false;
        }

        private void Inputattr2_Click(object sender, RoutedEventArgs e)
        {
            InputattrName2.IsEnabled = InputattrValue2.IsEnabled = Convert.ToBoolean(Inputattr2.IsChecked);
        }

        private void Inputloop_Click(object sender, RoutedEventArgs e)
        {
            Inputcomboboxloop.IsEnabled = Convert.ToBoolean(Inputloop.IsChecked);
        }

        #endregion TextInput

        #region loadFile
        private void Loadlineeachloop_Click(object sender, RoutedEventArgs e)
        {
            Loadrandomline.IsChecked = Loadoneline.IsChecked = !Loadlineeachloop.IsChecked;
            Loadloop.IsEnabled = App.Loadlineeachloop_bool = true;
            App.Loadoneline_bool = App.Loadrandomline_bool = !App.Loadlineeachloop_bool;

        }

        private void Loadrandomline_Click(object sender, RoutedEventArgs e)
        {
            Loadlineeachloop.IsChecked = Loadoneline.IsChecked = !Loadrandomline.IsChecked;
            App.Loadrandomline_bool = true;
            Loadloop.IsEnabled = App.Loadoneline_bool = App.Loadlineeachloop_bool = !App.Loadrandomline_bool;
        }

        private void Loadoneline_Click(object sender, RoutedEventArgs e)
        {
            Loadlineeachloop.IsChecked = Loadrandomline.IsChecked = !Loadoneline.IsChecked;
            App.Loadoneline_bool = true;
            Loadloop.IsEnabled = App.Loadrandomline_bool = App.Loadlineeachloop_bool = !App.Loadoneline_bool;
        }

        private async void Loadimportpath_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker openFileDialogFILE = new FileOpenPicker();

            //____________________________________________
            Loadtextpath.Text = string.Empty;
            FileOpenPicker picker = new FileOpenPicker();
            picker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            picker.FileTypeFilter.Add(".txt");
            picker.FileTypeFilter.Add(".csv");
            StorageFile file = await picker.PickSingleFileAsync();
            try
            {
                string text = await Windows.Storage.FileIO.ReadTextAsync(file);
                App.LoadNumberOfLines = text.ToString().Split('\n').Length;
                if (file != null)
                {

                    Loadtextpath.Text = file.Path.Replace(" ", "<SP>").Replace("\\", "\\\\");
                }
                else
                {
                    return;
                }
            }
            catch
            {
                MessageDialog msg = new MessageDialog("error");
                await msg.ShowAsync();
            }
        }

        private void Loadcolumns_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Loadcolumns.Text.Length == 0)
            {
                Loadcolumns.Text = "1";
            }
        }

        private async void Loadok_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog msg;
            if (Loadtextpath.Text.Length < 1)
            {
                msg = new MessageDialog("Please Choose the File");
                await msg.ShowAsync();
                return;
            }
            else if (Convert.ToBoolean(Loadlineeachloop.IsChecked) && Loadloop.SelectedItem.ToString().Length < 1)
            {
                msg = new MessageDialog("You Must To Choose An Loop");
                await msg.ShowAsync();
                return;
            }

            //create the code
            App.File_Coulmns.Clear();
            string Load = "var load;\nload = 'CODE: ';\n";
            string DataSourcePath = String.Format("load += 'SET !DATASOURCE {0}' + '\\n';", Loadtextpath.Text);
            string DataColumns = String.Format("load += 'SET !DATASOURCE_COLUMNS {0}' + '\\n';", Loadcolumns.Text);
            string DataLine = "";
            string AddDataExtracted = "load += 'ADD !EXTRACT {{!COL1}}' + '\\n';\n";
            string SetDataExtracted = "var COLUMN1 = iimGetLastExtract(1);\n";
            App.File_Coulmns.Add("COLUMN1");
            App.All_Variables.Add("COLUMN1");

            if (App.Loadlineeachloop_bool)
            {
                DataLine = String.Format("iimSet('{0}', {1});", Loadloop.SelectedItem.ToString().ToLower(), Loadloop.SelectedItem.ToString());
                DataLine += "\nload += 'SET !DATASOURCE_LINE {{" + Loadloop.SelectedItem.ToString().ToLower() + "}}' + '\\n';";
            }
            else if (App.Loadoneline_bool)
            {
                DataLine = "load += 'SET !DATASOURCE_LINE 1' + '\\n';";
            }
            else if (App.Loadrandomline_bool)
            {
                DataLine = String.Format("iimSet('R', Math.floor(Math.random()*({0}-1+1)+1));", App.LoadNumberOfLines);
                DataLine += "\nload += 'SET !DATASOURCE_LINE {{R}}' + '\\n';";
            }



            for (int data = 2; data <= int.Parse(Loadcolumns.Text); data++)
            {
                AddDataExtracted += "load += 'ADD !EXTRACT {{!COL" + data + "}}' + '\\n';\n";
                SetDataExtracted += String.Format("var COLUMN{0} = iimGetLastExtract({0});\n", data);
                App.File_Coulmns.Add(String.Format("COLUMN{0}", data));
                App.All_Variables.Add(String.Format("COLUMN{0}", data));
            }

            Load += DataSourcePath + "\n" + DataColumns + "\n" + DataLine + "\n" + AddDataExtracted + "iimPlay(load)" + "\n" + SetDataExtracted;
            Editor.Text += Load + "\n";
            LoadDataFromFilePage.Visibility = Visibility.Collapsed;
            EditorPage.Visibility = Visibility.Visible;
        }

        #endregion  loadFile

        #region Checked button
        private void Checkedselection_Click(object sender, RoutedEventArgs e)
        {
            App.CheckedSelection_bool = true;
            App.CheckedDeselection_bool = !App.CheckedSelection_bool;

        }

        private void Checkeddeselection_Click(object sender, RoutedEventArgs e)
        {
            App.CheckedDeselection_bool = true;
            App.CheckedSelection_bool = !App.CheckedDeselection_bool;

        }

        private void Checkedloop_Click(object sender, RoutedEventArgs e)
        {
            Checkedcomboboxloop.IsEnabled = Convert.ToBoolean(Checkedloop.IsChecked);
        }

        private void Checkedattr2_Click(object sender, RoutedEventArgs e)
        {
            CheckedattrName2.IsEnabled = CheckedattrValue2.IsEnabled = Convert.ToBoolean(Checkedattr2.IsChecked);
        }

        private async void Checkedok_Click(object sender, RoutedEventArgs e)
        {
            /*------Errors------*/
            //tag
            if (Checkedtagtype.Text.Length < 1)
            {
                // MessageBox.Show("You Can't Leave Tage Type Blank!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageDialog msg = new MessageDialog("You Can't Leave Tage Type Blank!");
                await msg.ShowAsync();
                return;
            }
            //attr1
            else if (CheckedattrName1.Text.Length < 1 || CheckedattrValue1.Text.Length < 1)
            {
                //  MessageBox.Show("You Can't Leave Attribute Name Or Attribute Value Blank", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageDialog msg = new MessageDialog("You Can't Leave Attribute Name Or Attribute Value Blank");
                await msg.ShowAsync();
                return;
            }
            //Create the code
            string CheckedBox_Selection;
            string choosen_loop = "";

            CheckedBox_Selection = "iimPlay('CODE:'+'SET !TIMEOUT_STEP " + Checkedtimeout.Text + "'" + "+'\\nTAG POS=1 TYPE=" + Checkedtagtype.Text + " ATTR=" + CheckedattrName1.Text + ":" + CheckedattrValue1.Text;

            if (Checkedattr2.IsChecked == true)
            {
                CheckedBox_Selection += "&&" + CheckedattrName2.Text + ":" + CheckedattrValue2.Text;
            }
            if (Checkedloop.IsChecked == true)
            {
                choosen_loop = "iimSet('" + Checkedcomboboxloop.SelectedItem.ToString().ToLower() + "'," + Checkedcomboboxloop.SelectedItem.ToString() + ")\n";
                CheckedBox_Selection = CheckedBox_Selection.Replace("POS=1", "POS={{" + Checkedcomboboxloop.SelectedItem.ToString().ToLower() + "}}");
            }

            if (App.CheckedSelection_bool)
            {
                //Selection
                CheckedBox_Selection += " CONTENT=YES');";
            }
            else if (App.CheckedDeselection_bool)
            {
                //Deselection
                CheckedBox_Selection += " CONTENT=NO');";
            }
            Editor.Text += (choosen_loop + CheckedBox_Selection + "\n\n");
            CheckedButtonPage.Visibility = Visibility.Collapsed;
            EditorPage.Visibility = Visibility.Visible;
        }
        #endregion Checked button

        #region TimeWait
        private void TimeStatic_Click(object sender, RoutedEventArgs e)
        {
            App.TimeStatic_bool = true;
            App.TimeRandom_bool = !App.TimeStatic_bool;
            TimeRandom.IsChecked = !TimeStatic.IsChecked;
            TimeStatic_value.IsEnabled = Convert.ToBoolean(TimeStatic.IsChecked);
            TimeRandomE.IsEnabled = TimeRandomS.IsEnabled = !Convert.ToBoolean(TimeStatic.IsChecked);
        }

        private void TimeRandom_Click(object sender, RoutedEventArgs e)
        {
            App.TimeRandom_bool = true;
            App.TimeStatic_bool = !App.TimeRandom_bool;
            TimeStatic.IsChecked = !TimeRandom.IsChecked;
            TimeStatic_value.IsEnabled = !Convert.ToBoolean(TimeRandom.IsChecked);

            TimeRandomE.IsEnabled = TimeRandomS.IsEnabled = Convert.ToBoolean(TimeRandom.IsChecked);
        }

        private async void Timeok_Click(object sender, RoutedEventArgs e)
        {
            string SetTime = "";

            if (App.TimeStatic_bool)
            {
                SetTime = String.Format("iimPlay('CODE:'+'wait seconds={0}');", TimeStatic_value.Text);
            }
            else if (App.TimeRandom_bool)
            {
                if (int.Parse(TimeRandomS.Text) >= int.Parse(TimeRandomE.Text))
                {
                    //MessageBox.Show("The Minimum number cannot be greater than or equal to Maximum number", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageDialog msg = new MessageDialog("The Minimum number cannot be greater than or equal to Maximum number");
                    await msg.ShowAsync();
                    return;
                }
                SetTime += String.Format("iimSet('R', Math.floor(Math.random()*({0}-{1}+1)+{1}));\n", TimeRandomS.Text, TimeRandomE.Text);
                SetTime += "iimPlay('CODE:'+'wait seconds={{R}}');";
            }

            Editor.Text += (SetTime + "\n\n");
            TimeWaitPage.Visibility = Visibility.Collapsed;
            EditorPage.Visibility = Visibility.Visible;
        }

        private void TimeStatic_value_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TimeStatic_value.Text.Length == 0)
            {
                TimeStatic_value.Text = "1";
            }
        }

        private void TimeRandomS_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TimeRandomS.Text.Length == 0)
            {
                TimeRandomS.Text = "1";
            }
        }

        private void TimeRandomE_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TimeRandomE.Text.Length == 0)
            {
                TimeRandomE.Text = "1";
            }
        }
        #endregion TimeWait

        private void Comands_Click(object sender, RoutedEventArgs e)
        {
            if (LoopGrid.Visibility == Visibility.Collapsed)
            {
                LoopGrid.Visibility = Visibility.Visible;
                ExtractGrid.Visibility = Visibility.Visible;
                ConditionGrid.Visibility = Visibility.Visible;
                CheckedBGrid.Visibility = Visibility.Visible;
                LoadDataGrid.Visibility = Visibility.Visible;
                TextInputGrid.Visibility = Visibility.Visible;
                TimeWaitGrid.Visibility = Visibility.Visible;
                URLNavigationGrid.Visibility = Visibility.Visible;
            }
            else if (LoopGrid.Visibility == Visibility.Visible)
            {
                LoopGrid.Visibility = Visibility.Collapsed;
                ExtractGrid.Visibility = Visibility.Collapsed;
                ConditionGrid.Visibility = Visibility.Collapsed;
                CheckedBGrid.Visibility = Visibility.Collapsed;
                LoadDataGrid.Visibility = Visibility.Collapsed;
                TextInputGrid.Visibility = Visibility.Collapsed;
                TimeWaitGrid.Visibility = Visibility.Collapsed;
                URLNavigationGrid.Visibility = Visibility.Collapsed;
            }
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            if (GridForAllPic.Visibility == Visibility.Visible)
            {
                GridForAllPic.Visibility = Visibility.Collapsed;
                EditorPage.Visibility = Visibility.Visible;
            }
            else if (GridForAllPic.Visibility == Visibility.Collapsed)
            {
                GridForAllPic.Visibility = Visibility.Visible;
                EditorPage.Visibility = Visibility.Collapsed;
            }
        }
    }
}

