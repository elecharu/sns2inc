using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Grid;
using ItsKeyPad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WindowsInput.Native;

namespace ITSLIB
{
    /// <summary>
    /// ItsLabelText.xaml 的交互逻辑
    /// </summary>
    public partial class StyleGrid
    {
        public static TextEdit _BaseEdit = null;

        private void BUTTON_COLUMN_LOADED(object sender, EventArgs e)
        {
            System.Windows.Controls.Button CELL_BUTTON = sender as System.Windows.Controls.Button;
            CELL_BUTTON.Content = ((CELL_BUTTON.TemplatedParent as DevExpress.Xpf.Grid.LightweightCellEditor).Column as ITSLIB.Column).ButtonText;
            CELL_BUTTON.Click -= CELL_BUTTON_Click;
            CELL_BUTTON.Click += CELL_BUTTON_Click;
        }

        private void CELL_IMAGE_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e != null && e.ChangedButton == MouseButton.Left) e.Handled = true;
            if (e != null && e.ChangedButton != MouseButton.Left) return;

            // 이미지 확인창 띄우기
        }

        private void CELL_BUTTON_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button btn = sender as System.Windows.Controls.Button;
            ITSLIB.Column column = (btn.TemplatedParent as DevExpress.Xpf.Grid.LightweightCellEditor).Column as ITSLIB.Column;

            DependencyObject dpo = column.Parent;
            DependencyObject dpoTemp = null;
            if (column.CommandName.Trim().Length > 0)
            {
                do
                {
                    dpoTemp = dpo;
                    dpo = VisualTreeHelper.GetParent(dpoTemp);
                    if (dpo == null) {
                        dpo = LogicalTreeHelper.GetParent(dpoTemp);
                        if (dpo is Popup)
                        {
                            dpo = (dpo as Popup).Parent;
                        }
                    }

                    if (dpo is ItsPageBase)
                    {
                        try
                        {
                            (dpo as ItsPageBase).EventCommand(column.CommandName);
                        }
                        catch { }
                    }
                    if (dpo is ItsWinBase)
                    {
                        try
                        {
                            (dpo as ItsWinBase).EventCommand(column.CommandName);
                        }
                        catch { }
                    }
                } while (!(dpo is ItsPageBase) && !(dpo is ItsWinBase));
            }
        }

        private void TIME_KEYPAD_MouseUp(object sender, MouseButtonEventArgs e)
        {
            DockPanel dockPanel = ItsElement.FindParent<DockPanel>(sender) as DockPanel;
            Popup popup = ItsElement.FindChild<Popup>(dockPanel)[0] as Popup;
            TextEdit textEdit = ItsElement.FindChild<TextEdit>(dockPanel)[0] as TextEdit;

            popup.IsOpen = true;
            textEdit.Focus();
            textEdit.SelectAll();
        }

        private void KEY_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;

            Popup popup = ItsElement.FindParent<Popup>(sender) as Popup;

            DockPanel dockPanel = ItsElement.FindParent<DockPanel>(ItsElement.FindParent<DockPanel>(sender)) as DockPanel;
            DevExpress.Xpf.Editors.SpinEdit spinEdit = ItsElement.FindByName(dockPanel, "PART_Editor") as DevExpress.Xpf.Editors.SpinEdit;
            DevExpress.Xpf.Editors.TextEdit textEdit = ItsElement.FindByName(dockPanel, "PART_Editor") as DevExpress.Xpf.Editors.TextEdit;

            if (spinEdit != null)
            {
                spinEdit.Focus();
                // spinEdit.SelectionLength = 0;
            }
            if (textEdit != null)
            {
                textEdit.Focus();
                // textEdit.SelectionLength = 0;
            }

            string keyCode = (e.Source as Label).Content.ToString();

            if (keyCode == "1") InputSimulatorStatic.Keyboard.KeyPress(VirtualKeyCode.NUMPAD1);
            else if (keyCode == "2") InputSimulatorStatic.Keyboard.KeyPress(VirtualKeyCode.NUMPAD2);
            else if (keyCode == "3") InputSimulatorStatic.Keyboard.KeyPress(VirtualKeyCode.NUMPAD3);
            else if (keyCode == "4") InputSimulatorStatic.Keyboard.KeyPress(VirtualKeyCode.NUMPAD4);
            else if (keyCode == "5") InputSimulatorStatic.Keyboard.KeyPress(VirtualKeyCode.NUMPAD5);
            else if (keyCode == "6") InputSimulatorStatic.Keyboard.KeyPress(VirtualKeyCode.NUMPAD6);
            else if (keyCode == "7") InputSimulatorStatic.Keyboard.KeyPress(VirtualKeyCode.NUMPAD7);
            else if (keyCode == "8") InputSimulatorStatic.Keyboard.KeyPress(VirtualKeyCode.NUMPAD8);
            else if (keyCode == "9") InputSimulatorStatic.Keyboard.KeyPress(VirtualKeyCode.NUMPAD9);
            else if (keyCode == "0") InputSimulatorStatic.Keyboard.KeyPress(VirtualKeyCode.NUMPAD0);
            else if (keyCode == ".") InputSimulatorStatic.Keyboard.KeyPress(VirtualKeyCode.DECIMAL);
            else if (keyCode == "Y")
            {
                if (Keyboard.IsKeyToggled(Key.CapsLock))
                    InputSimulatorStatic.Keyboard.KeyPress(VirtualKeyCode.VK_Y);
                else
                    InputSimulatorStatic.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LSHIFT, VirtualKeyCode.VK_Y);
            }
            else if (keyCode == "N")
            {
                if (Keyboard.IsKeyToggled(Key.CapsLock))
                    InputSimulatorStatic.Keyboard.KeyPress(VirtualKeyCode.VK_N);
                else
                    InputSimulatorStatic.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LSHIFT, VirtualKeyCode.VK_N);
            }
            else if (keyCode == "-") InputSimulatorStatic.Keyboard.KeyPress(VirtualKeyCode.OEM_MINUS);
            else if (keyCode == "(") InputSimulatorStatic.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LSHIFT, VirtualKeyCode.VK_9);
            else if (keyCode == ")") InputSimulatorStatic.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LSHIFT, VirtualKeyCode.VK_0);
            else if (keyCode == "Delete") InputSimulatorStatic.Keyboard.KeyPress(VirtualKeyCode.DELETE);
            else if (keyCode == "Backspace") InputSimulatorStatic.Keyboard.KeyPress(VirtualKeyCode.BACK);
            else if (keyCode == "◀") InputSimulatorStatic.Keyboard.KeyPress(VirtualKeyCode.LEFT);
            else if (keyCode == "▶") InputSimulatorStatic.Keyboard.KeyPress(VirtualKeyCode.RIGHT);
            else if (keyCode == "Clear")
            {
                if (spinEdit != null)
                {
                    if (spinEdit.MinValue < 0m)
                    {
                        spinEdit.Value = 0;
                    }
                    else
                    {
                        spinEdit.Value = (decimal)spinEdit.MinValue;
                    }

                    spinEdit.SelectionStart = 0;
                    spinEdit.SelectionLength = 100;
                }
            }
            else if (keyCode == "✖")
            {
                popup.IsOpen = false;
            }
            else
            {
                ItsMsgBox.Show("키코드가 정의되지 않았습니다. ");
            }
        }

        private void NUM_KEYPAD_MouseUp(object sender, MouseButtonEventArgs e)
        {
            DockPanel dockPanel = ItsElement.FindParent<DockPanel>(sender) as DockPanel;
            Popup popup = ItsElement.FindChild<Popup>(dockPanel)[0] as Popup;
            TextEdit textEdit = ItsElement.FindChild<TextEdit>(dockPanel)[0] as TextEdit;

            popup.IsOpen = true;
            textEdit.Focus();
            textEdit.SelectAll();
        }

        private void POP_COLUMN_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;

            ITSLIB.ItsPageBase basePage = ItsElement.FindParent<ITSLIB.ItsPageBase>(sender);

            TextEdit edit = sender as TextEdit;
            DockPanel dock = ItsElement.FindParent<DockPanel>(edit);
            List<TextBlock> textList = ItsElement.FindChild<TextBlock>(dock);

            basePage.ShowPopColumn(edit, textList[0].Text, textList[1].Text, textList[2].Text, textList[3].Text, textList[4].Text, textList[5].Text);
        }

        private void POP_COLUMN_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // e.Handled = true;

                ITSLIB.ItsPageBase basePage = ItsElement.FindParent<ITSLIB.ItsPageBase>(sender);

                TextEdit edit = sender as TextEdit;
                DockPanel dock = ItsElement.FindParent<DockPanel>(edit);
                List<TextBlock> textList = ItsElement.FindChild<TextBlock>(dock);
                basePage.ShowPopColumn(edit, textList[0].Text, textList[1].Text, textList[2].Text, textList[3].Text, textList[4].Text, textList[5].Text);
            }
        }

        private void STD_KEYPAD_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DockPanel dockPanel = ItsElement.FindParent<DockPanel>(sender) as DockPanel;
                Popup popup = ItsElement.FindChild<Popup>(dockPanel)[0] as Popup;
                TextEdit textEdit = ItsElement.FindChild<TextEdit>(dockPanel)[0] as TextEdit;

                popup.IsOpen = true;
                textEdit.Focus();
                textEdit.SelectAll();
            }
            catch { }
        }
    }
}