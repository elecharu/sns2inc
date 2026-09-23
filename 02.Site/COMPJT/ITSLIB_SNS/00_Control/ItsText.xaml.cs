using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Input.Test;

namespace ITSLIB
{
    /// <summary>
    /// ItsLabelText.xaml 的交互逻辑
    /// </summary>
    public partial class Text : UserControl
    {
        private bool _isKoreanMode = false;
        private string _hangulCho = "";
        private string _hangulJung = "";
        private string _hangulJong = "";

        public ItsModelPanel ModelPanel = null;
        public Text()
        {
            InitializeComponent();
            textBox.BorderBrush = Brushes.Silver;
            textBox.BorderThickness = new Thickness(1d);
        }
        public bool ReadOnly
        {
            get { return textBox.IsReadOnly; }
            set
            {
                textBox.IsReadOnly = value;
                if (value)
                {
                    textBox.Background = new BrushConverter().ConvertFrom("#ECECEC") as SolidColorBrush;
                }
                else
                {
                    textBox.Background = Brushes.White;
                }
            }
        }

        public new bool IsFocused
        {
            get
            {
                return textBox.IsFocused;
            }
        }

        public void SetFocus()
        {
            textBox.SelectAll();
            textBox.Focus();
        }

        public string Label
        {
            get { return textBlock.Text; }
            set { textBlock.Text = value; }
        }

        public string HidenLabel
        {
            set
            {
                if (value.Length > 0)
                {
                    this.Width = this.Width - textBlock.Width;
                    textBlock.Width = 0;
                    textBlock.Visibility = Visibility.Hidden;
                }
            }
        }

        public double LabelWidth
        {
            get { return textBlock.Width; }
            set { textBlock.Width = value; }
        }

        public string Unit
        {
            get { return textUnit.Text; }
            set { textUnit.Text = value; }
        }

        public string Value
        {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        public readonly static DependencyProperty ValueProperty =
            DependencyProperty.Register("Value",
                typeof(string),
                typeof(Text),
                new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, valueChangedCallback));
        private static void valueChangedCallback(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ((Text)(sender)).textBox.Text = e.NewValue.ToString();
        }

        private void textBox_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox.BorderBrush = Brushes.Black;
            textBox.BorderThickness = new Thickness(1.5d);
            if (!textBox.IsReadOnly)
            {
                textBox.Background = Brushes.MintCream;
            }

            if (_inputType == ItsEnums.InputTypes.Alphabat)
            {
                InputMethod.SetPreferredImeConversionMode(textBox, ImeConversionModeValues.Alphanumeric);
            }
            else if (_inputType == ItsEnums.InputTypes.Native)
            {
                InputMethod.SetPreferredImeConversionMode(textBox, ImeConversionModeValues.Native);
            }

            if (_ShowKeyPad)
            {
                keypop.IsOpen = true;
                UpdateKeypadDisplay();
            }
        }

        private void textBox_LostFocus(object sender, RoutedEventArgs e)
        {
            textBox.BorderBrush = Brushes.Silver;
            textBox.BorderThickness = new Thickness(1d);
            if (!textBox.IsReadOnly)
            {
                textBox.Background = Brushes.White;
            }

            keypop.IsOpen = false;
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetValue(ValueProperty, textBox.Text);
            if (this.ModelPanel != null) this.ModelPanel.AcceptChanges();
        }

        private void textBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            textBox.SelectAll();
        }

        private bool _ShowKeyPad = false;
        public string ShowKeyPad
        {
            set
            {
                if (value.Length > 0)
                {
                    _ShowKeyPad = true;
                }
                else
                {
                    _ShowKeyPad = false;
                }
            }
        }

        private ItsEnums.InputTypes _inputType = ItsEnums.InputTypes.Alphabat;
        public ItsEnums.InputTypes InputType
        {
            get
            {
                return _inputType;
            }
            set
            {
                _inputType = value;
            }
        }

        private void KEY_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            textBox.Focus();

            e.Handled = true;

            string keyCode = (e.Source as Label).Content.ToString();

            if (keyCode == "공백") { ResetHangulState(); SendKeys.Send(textBox, " "); }
            else if (keyCode == "삭제") { ResetHangulState(); SendKeys.Send(textBox, "{BACKSPACE}"); }
            else if (keyCode == "◀") { ResetHangulState(); SendKeys.Send(textBox, "{LEFT}"); }
            else if (keyCode == "▶") { ResetHangulState(); SendKeys.Send(textBox, "{RIGHT}"); }
            else if (keyCode == "전부삭제")
            {
                ResetHangulState();
                textBox.Text = "";
            }
            else if (keyCode == "✖")
            {
                ResetHangulState();
                keypop.IsOpen = false;
            }
            else if (keyCode == "한/영" || keyCode == "영/한")
            {
                _isKoreanMode = !_isKoreanMode;
                keyHanEng.Content = _isKoreanMode ? "영/한" : "한/영";
                UpdateKeypadDisplay();
            }
            else if (keyCode == "대")
            {
                DockPanel dockPanel = ItsElement.FindParent<DockPanel>(sender as Label);
                List<Label> labelList = ItsElement.FindChild<Label>(dockPanel);
                foreach(Label label in labelList)
                {
                    if (label.Content.ToString().Length == 1)
                    {
                        label.Content = label.Content.ToString().ToUpper();
                    }
                }
            }
            else if (keyCode == "소")
            {
                DockPanel dockPanel = ItsElement.FindParent<DockPanel>(sender as Label);
                List<Label> labelList = ItsElement.FindChild<Label>(dockPanel);
                foreach (Label label in labelList)
                {
                    if (label.Content.ToString().Length == 1)
                    {
                        label.Content = label.Content.ToString().ToLower();
                    }
                }
            }
            else if (keyCode == "특")
            {
                DockPanel dockPanel = ItsElement.FindParent<DockPanel>(sender as Label);
                List<Label> labelList = ItsElement.FindChild<Label>(dockPanel);
                foreach (Label label in labelList)
                {
                    if (label.Content.ToString().Length == 1 && "ABCDEFGHIJKLMNOPQRSTUVWXYZ◀▶대소특삭제전부삭제공백✖ㅂㅈㄷㄱㅅㅛㅕㅑㅐㅔㅁㄴㅇㄹㅎㅗㅓㅏㅣㅋㅌㅊㅍㅠㅜㅡ".IndexOf(label.Content.ToString().ToUpper()) == -1)
                    {
                        // 특수문자
                        if (label.Content.ToString() == "[") label.Content = "{";
                        else if (label.Content.ToString() == "]") label.Content = "}";
                        else if (label.Content.ToString() == ";") label.Content = ":";
                        else if (label.Content.ToString() == "'") label.Content = "\"";
                        else if (label.Content.ToString() == ",") label.Content = "<";
                        else if (label.Content.ToString() == ".") label.Content = ">";
                        else if (label.Content.ToString() == "/") label.Content = "?";
                        else if (label.Content.ToString() == "-") label.Content = "_";
                        else if (label.Content.ToString() == "=") label.Content = "+";

                        // 숫자 -> 특수문자
                        else if (label.Content.ToString() == "`") label.Content = "~";
                        else if (label.Content.ToString() == "1") label.Content = "!";
                        else if (label.Content.ToString() == "2") label.Content = "@";
                        else if (label.Content.ToString() == "3") label.Content = "#";
                        else if (label.Content.ToString() == "4") label.Content = "$";
                        else if (label.Content.ToString() == "5") label.Content = "%";
                        else if (label.Content.ToString() == "6") label.Content = "^";
                        else if (label.Content.ToString() == "7") label.Content = "&";
                        else if (label.Content.ToString() == "8") label.Content = "*";
                        else if (label.Content.ToString() == "9") label.Content = "(";
                        else if (label.Content.ToString() == "0") label.Content = ")";

                        // 역으로 교체
                        else if (label.Content.ToString() == "{") label.Content = "[";
                        else if (label.Content.ToString() == "}") label.Content = "]";
                        else if (label.Content.ToString() == ":") label.Content = ";";
                        else if (label.Content.ToString() == "\"") label.Content = "'";
                        else if (label.Content.ToString() == "<") label.Content = ",";
                        else if (label.Content.ToString() == ">") label.Content = ".";
                        else if (label.Content.ToString() == "?") label.Content = "/";
                        else if (label.Content.ToString() == "_") label.Content = "-";
                        else if (label.Content.ToString() == "+") label.Content = "=";

                        else if (label.Content.ToString() == "~") label.Content = "`";
                        else if (label.Content.ToString() == "!") label.Content = "1";
                        else if (label.Content.ToString() == "@") label.Content = "2";
                        else if (label.Content.ToString() == "#") label.Content = "3";
                        else if (label.Content.ToString() == "$") label.Content = "4";
                        else if (label.Content.ToString() == "%") label.Content = "5";
                        else if (label.Content.ToString() == "^") label.Content = "6";
                        else if (label.Content.ToString() == "&") label.Content = "7";
                        else if (label.Content.ToString() == "*") label.Content = "8";
                        else if (label.Content.ToString() == "(") label.Content = "9";
                        else if (label.Content.ToString() == ")") label.Content = "0";

                        else label.Content = "";
                    }
                }
            }
            else
            {
                string insertChar = keyCode;
                int deleteLen = 0;
                if (_isKoreanMode && keyCode.Length == 1)
                {
                    char engKey = _hangulToEng.TryGetValue(keyCode, out string engStr) ? engStr[0] : char.ToUpper(keyCode[0]);
                    if (_engToHangul.ContainsKey(engKey))
                        ProcessHangulInput(engKey, out insertChar, out deleteLen);
                }
                int curSel = textBox.SelectionStart;
                int selLen = textBox.SelectionLength;
                string before = textBox.Text.Substring(0, curSel - deleteLen);
                string after = textBox.Text.Substring(curSel + selLen);
                textBox.Text = before + insertChar + after;
                textBox.SelectionStart = before.Length + insertChar.Length;
                textBox.SelectionLength = 0;
            }

            textBox.Focus();
        }

        // 두벌식 키보드 영문→한글 자모 매핑
        private static readonly Dictionary<char, string> _engToHangul = new Dictionary<char, string>
        {
            {'Q', "ㅂ"}, {'W', "ㅈ"}, {'E', "ㄷ"}, {'R', "ㄱ"}, {'T', "ㅅ"}, {'Y', "ㅛ"}, {'U', "ㅕ"}, {'I', "ㅑ"}, {'O', "ㅐ"}, {'P', "ㅔ"},
            {'A', "ㅁ"}, {'S', "ㄴ"}, {'D', "ㅇ"}, {'F', "ㄹ"}, {'G', "ㅎ"}, {'H', "ㅗ"}, {'J', "ㅓ"}, {'K', "ㅏ"}, {'L', "ㅣ"},
            {'Z', "ㅋ"}, {'X', "ㅌ"}, {'C', "ㅊ"}, {'V', "ㅍ"}, {'B', "ㅠ"}, {'N', "ㅜ"}, {'M', "ㅡ"}
        };

        private static readonly Dictionary<string, string> _hangulToEng = new Dictionary<string, string>
        {
            {"ㅂ", "Q"}, {"ㅈ", "W"}, {"ㄷ", "E"}, {"ㄱ", "R"}, {"ㅅ", "T"}, {"ㅛ", "Y"}, {"ㅕ", "U"}, {"ㅑ", "I"}, {"ㅐ", "O"}, {"ㅔ", "P"},
            {"ㅁ", "A"}, {"ㄴ", "S"}, {"ㅇ", "D"}, {"ㄹ", "F"}, {"ㅎ", "G"}, {"ㅗ", "H"}, {"ㅓ", "J"}, {"ㅏ", "K"}, {"ㅣ", "L"},
            {"ㅋ", "Z"}, {"ㅌ", "X"}, {"ㅊ", "C"}, {"ㅍ", "V"}, {"ㅠ", "B"}, {"ㅜ", "N"}, {"ㅡ", "M"}
        };

        private static readonly string _cho = "ㄱㄲㄴㄷㄸㄹㅁㅂㅃㅅㅆㅇㅈㅉㅊㅋㅌㅍㅎ";
        private static readonly string _jung = "ㅏㅐㅑㅒㅓㅔㅕㅖㅗㅘㅙㅚㅛㅜㅝㅞㅟㅠㅡㅢㅣ";
        private static readonly string _jong = " ㄱㄲㄳㄴㄵㄶㄷㄹㄺㄻㄼㄽㄾㄿㅀㅁㅂㅄㅅㅆㅇㅈㅊㅋㅌㅍㅎ";

        private void ProcessHangulInput(char engKey, out string toInsert, out int toDelete)
        {
            toDelete = 0;
            if (!_engToHangul.TryGetValue(engKey, out string jamo))
            {
                toInsert = engKey.ToString();
                return;
            }
            int choIdx = _cho.IndexOf(jamo);
            int jungIdx = _jung.IndexOf(jamo);
            bool isCho = choIdx >= 0;
            bool isJung = jungIdx >= 0;

            if (isCho && !isJung)
            {
                if (!string.IsNullOrEmpty(_hangulJung))
                {
                    if (string.IsNullOrEmpty(_hangulJong))
                    {
                        int jongIdx = _jong.IndexOf(jamo);
                        if (jongIdx >= 0)
                        {
                            _hangulJong = jamo;
                            toInsert = ComposeHangul(_hangulCho, _hangulJung, _hangulJong);
                            toDelete = 1;
                            return;
                        }
                    }
                    toInsert = ComposeHangul(_hangulCho, _hangulJung, _hangulJong) + jamo;
                    toDelete = 1;
                    _hangulCho = jamo;
                    _hangulJung = "";
                    _hangulJong = "";
                    return;
                }
                if (!string.IsNullOrEmpty(_hangulCho))
                {
                    int doubleIdx = GetDoubleConsonantIndex(_hangulCho, jamo);
                    if (doubleIdx >= 0)
                    {
                        _hangulCho = _cho[doubleIdx].ToString();
                        toInsert = _hangulCho;
                        toDelete = 1;
                        return;
                    }
                    toInsert = _hangulCho + jamo;
                    toDelete = 1;
                    _hangulCho = jamo;
                    _hangulJung = "";
                    _hangulJong = "";
                    return;
                }
                toInsert = jamo;
                toDelete = 0;
                _hangulCho = jamo;
                _hangulJung = "";
                _hangulJong = "";
                return;
            }
            else if (isJung && !isCho)
            {
                if (!string.IsNullOrEmpty(_hangulCho))
                {
                    if (!string.IsNullOrEmpty(_hangulJung))
                    {
                        int compositeIdx = GetCompositeVowelIndex(_hangulJung, jamo);
                        if (compositeIdx >= 0)
                        {
                            _hangulJung = _jung[compositeIdx].ToString();
                            toInsert = ComposeHangul(_hangulCho, _hangulJung, _hangulJong);
                            toDelete = 1;
                            return;
                        }
                        toInsert = ComposeHangul(_hangulCho, _hangulJung, _hangulJong);
                        toDelete = 1;
                        _hangulCho = "ㅇ";
                        _hangulJung = jamo;
                        _hangulJong = "";
                        return;
                    }
                    _hangulJung = jamo;
                    toInsert = ComposeHangul(_hangulCho, _hangulJung, _hangulJong);
                    toDelete = 1;
                    return;
                }
                toInsert = jamo;
                toDelete = 0;
                _hangulCho = "ㅇ";
                _hangulJung = jamo;
                _hangulJong = "";
                return;
            }
            toInsert = jamo;
            toDelete = 0;
        }

        private static int GetDoubleConsonantIndex(string c1, string c2)
        {
            if (c1 == c2 && "ㄱㄷㅂㅅㅈ".Contains(c1))
            {
                string dbl = c1 == "ㄱ" ? "ㄲ" : c1 == "ㄷ" ? "ㄸ" : c1 == "ㅂ" ? "ㅃ" : c1 == "ㅅ" ? "ㅆ" : "ㅉ";
                return _cho.IndexOf(dbl);
            }
            return -1;
        }

        private static int GetCompositeVowelIndex(string j1, string j2)
        {
            var map = new Dictionary<string, string>
            {
                {"ㅗㅏ", "ㅘ"}, {"ㅗㅐ", "ㅙ"}, {"ㅗㅣ", "ㅚ"},
                {"ㅜㅓ", "ㅝ"}, {"ㅜㅔ", "ㅞ"}, {"ㅜㅣ", "ㅟ"},
                {"ㅡㅣ", "ㅢ"}
            };
            if (map.TryGetValue(j1 + j2, out string composed))
                return _jung.IndexOf(composed);
            return -1;
        }

        private static string ComposeHangul(string cho, string jung, string jong)
        {
            int ci = _cho.IndexOf(cho);
            int ji = _jung.IndexOf(jung);
            int oi = string.IsNullOrEmpty(jong) ? 0 : _jong.IndexOf(jong);
            if (ci < 0 || ji < 0) return "";
            int code = 0xAC00 + (ci * 588) + (ji * 28) + oi;
            return char.ConvertFromUtf32(code);
        }

        private void ResetHangulState()
        {
            _hangulCho = "";
            _hangulJung = "";
            _hangulJong = "";
        }

        private void UpdateKeypadDisplay()
        {
            DockPanel keypadRoot = keypop.Child as DockPanel;
            if (keypadRoot == null) return;
            List<Label> labelList = ItsElement.FindChild<Label>(keypadRoot);
            foreach (Label label in labelList)
            {
                if (label == keyHanEng) continue;
                string content = label.Content?.ToString() ?? "";
                if (content.Length != 1) continue;
                if (_isKoreanMode)
                {
                    char c = content[0];
                    char upper = char.ToUpper(c);
                    if ((c >= 'A' && c <= 'Z' || c >= 'a' && c <= 'z') && _engToHangul.TryGetValue(upper, out string jamo))
                        label.Content = jamo;
                }
                else
                {
                    if (_hangulToEng.TryGetValue(content, out string eng))
                        label.Content = eng;
                }
            }
        }

        private void textBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (_ShowKeyPad) keypop.IsOpen = true;
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (_ShowKeyPad) keypop.IsOpen = !keypop.IsOpen;
            }
        }
    }
}
