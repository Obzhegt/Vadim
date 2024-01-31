namespace rtrtrt;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        //Основные настройки формы
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Text = "Калькулятор";
        this.BackColor = Color.White;
        this.DoubleBuffered = true;
        this.ClientSize = new System.Drawing.Size(325, 420);
        this.Icon = new Icon("icon.ico");
        this.MaximizeBox = false;
        this.StartPosition = FormStartPosition.CenterScreen;
        this.MaximumSize = new Size(680, 480);
        this.MinimumSize = new Size(340, 480);
        this.TopMost = true;

        //Необходимые данные и массив с названиями кнопок
        string primer = "", index_dop = "";
        byte value_symber = 2;
        bool comma_dop = false, enumeration_primer = false, single_action = false;
        string[] button_name = new string[24]
        {
            "1","2","3","C",
            "4","5","6","←",
            "7","8","9","+",
            ",","0","=","-",
            "√","^","/","*",
            "e","π","!","log"
        };

        //Определение цвета кнопок
        List<Color> button_color = new List<Color>()
        {
            Color.White,Color.White,Color.White,Color.DarkRed,
            Color.White,Color.White,Color.White,Color.Red,
            Color.White,Color.White,Color.White,Color.LightGray,
            Color.LightGray,Color.White,Color.Green,Color.LightGray,
            Color.LightGray,Color.LightGray,Color.LightGray,Color.LightGray,
            Color.LightGray,Color.LightGray,Color.LightGray,Color.LightGray
        };
        List<string> primer_chet_list = new List<string>();
        short X = 5,Y = 60;

        //Строка для ввывода данных
        Label label_ = new Label
        {
            Text = "",
            ForeColor = Color.Black,
            Font = new Font(FontFamily.GenericMonospace,16),
            AutoSize = true,
            Location = new Point(0, 0),
        };
        this.Controls.Add(label_);

        //Строка для вывода ошибок или предупреждений
        Label label_error = new Label
        {
            Text = "",
            ForeColor = Color.Red,
            Font = new Font(FontFamily.GenericMonospace,12),
            AutoSize = true,
            Location = new Point(5, 35),
        };
        this.Controls.Add(label_error);

        //Версия программы
        Label label_version = new Label
        {
            Text = "v1.2.0",
            Font = new Font(FontFamily.GenericMonospace,12),
            AutoSize = true,
            Location = new Point(580, 400),
        };
        this.Controls.Add(label_version);
        
        //Тёмная или светлая тема
        Button button_bg_click = new Button
        {
            Text = "֍",
            BackColor = Color.Black,
            ForeColor = Color.White,
            AutoSize = true,
            FlatStyle = FlatStyle.Standard,
            Location = new Point(500, 380),
        };
        button_bg_click.Font = new Font(FontFamily.GenericMonospace,16);
        button_bg_click.Size = new Size(75,56);

        button_bg_click.Click += (a,e) =>
        {
            if(button_bg_click.BackColor == Color.Black)
            {
                button_bg_click.BackColor = Color.White;
                button_bg_click.ForeColor = Color.Black;
                label_version.ForeColor = Color.White;
                label_.ForeColor = Color.White;
                this.BackColor = Color.Black;
            }
            else
            {
                button_bg_click.BackColor = Color.Black;
                button_bg_click.ForeColor = Color.White;
                label_version.ForeColor = Color.Black;
                label_.ForeColor = Color.Black;
                this.BackColor = Color.White;
            }  
        };

        this.Controls.Add(button_bg_click);
        //Цикл создающий кнопки и события
        for(byte i = 0;i < button_name.Length;i++)
        {
            //Визуальные настройки кнопки
            Button button_click = new Button
            {
                Text = button_name[i],
                BackColor = button_color[i],
                ForeColor = Color.Black,
                AutoSize = true,
                FlatStyle = FlatStyle.Standard,
                Location = new Point(X, Y),
            };
            button_click.Font = new Font(FontFamily.GenericMonospace,16);
            button_click.Size = new Size(75,56);

            //Добавления события кнопку
            button_click.Click += (a,e) => 
            {
                label_error.Text = "";
                if(enumeration_primer == true)
                {
                    enumeration_primer = false;
                    label_.Text = "";
                }
                
                //Метка необходимая для работы -
                METKA_return:

                //Удаляет 1 символ с конца
                if(button_click.Text == "←" && primer_chet_list.Count > 0)
                {
                    if(!int.TryParse(primer_chet_list[primer_chet_list.Count - 1], out _) && value_symber == 1 && primer_chet_list[primer_chet_list.Count - 1] != ",") value_symber = 2;
                    else if(!int.TryParse(primer_chet_list[primer_chet_list.Count - 1], out _) && value_symber == 0 && primer_chet_list[primer_chet_list.Count - 1] != ",") value_symber = 1;
                    primer = "";
                    for(short k = 0;k < primer_chet_list.Count - 1;k++) {primer += Convert.ToString(primer_chet_list[k]);}

                    primer_chet_list.Clear();
                    label_.Text = primer;
                    for(short k = 0;k < primer.Length;k++) {primer_chet_list.Add(Convert.ToString(primer[k]));}
                    primer = "";
                }

                //Очистка данных показаных на экране
                else if(button_click.Text == "C") 
                {
                    primer_chet_list.Clear();
                    label_.Text = "";
                    primer = "";
                    comma_dop = false;
                    value_symber = 2;
                }

                //Добавление данных на строку, если не нажато = и счётчик логических символов больше 0
                else if(button_click.Text != "=" && value_symber > 0 && button_click.Text != "π" && button_click.Text != "e"
                 && button_click.Text != "√" && button_click.Text != "!" && button_click.Text != "log") 
                {
                    primer = button_click.Text;
                    //Если первое число 0 и следующее число, то за место этого числа поставиться "," + число и будет обозначаться как дробь
                    if(primer_chet_list.Count == 1)
                    {
                        if(primer_chet_list[0] == "0" && int.TryParse(primer, out _)) 
                        {
                            primer_chet_list.Add(",");
                            label_.Text += "," + primer;
                        }
                        else label_.Text += primer;
                    }
                    //Если первое число -0 и следующее число, то за место этого числа поставиться "," + число и будет обозначаться как дробь
                    else if(primer_chet_list.Count == 2)
                    {
                        if(primer_chet_list[0] == "-" && primer_chet_list[1] == "0" && int.TryParse(primer, out _)) 
                        {
                            primer_chet_list.Add(",");
                            label_.Text += "," + primer;
                        }
                        else label_.Text += primer;
                    }
                    //Если при начале нажать на любой логический символ кроме -, то поставится 0
                    else if(!int.TryParse(primer, out _) && primer != "-" && primer_chet_list.Count == 0)
                    {
                        primer = "0";
                        label_.Text = "0";
                        primer_chet_list.Add(primer);
                        goto METKA_return;
                    }
                    else label_.Text += primer;
                }

                //Счётчик логических символов
                if(value_symber > 0 && (button_click.Text == "*" || button_click.Text == "+" || button_click.Text == "/" || button_click.Text == "^"))
                {
                    value_symber--;
                    if(value_symber == 0) index_dop = primer;
                }

                //Главная логика калькулятора
                if(button_click.Text != "C" && button_click.Text != "←")
                {
                    if(comma_dop == false || button_click.Text == "-") primer_chet_list.Add(primer);
                    if(primer_chet_list.Count > 1 || button_click.Text == "e" || button_click.Text == "π")
                    {
                        if(value_symber == 1 && button_click.Text == "0") 
                        {
                            if(!int.TryParse(primer_chet_list[primer_chet_list.Count - 2], out _) && primer_chet_list[primer_chet_list.Count - 2] != ",")
                            {
                                primer_chet_list.Add(",");
                                label_.Text += ",";
                            } 
                        }
                        //Проверка, если стоит логический символ, то ещё один логический символ добавлен не будет
                        if(comma_dop == false && value_symber > 0 && button_click.Text != "e" && button_click.Text != "π" && button_click.Text != "√" && button_click.Text != "log" && button_click.Text != "!" && button_click.Text != "="
                        && button_click.Text != "," && button_click.Text != "-")
                        {
                            if(int.TryParse(primer, out _) == false && int.TryParse(primer_chet_list[primer_chet_list.Count - 2], out _) == false)
                            {
                                primer_chet_list.RemoveAt(Convert.ToInt32(primer_chet_list.Count - 1));
                                label_.Text = label_.Text.Remove(label_.Text.Length - 1);
                                index_dop = "";
                                value_symber++;
                            }
                        }

                        //Проверка, чтобы была только 1 "," у двух частей чисел
                        if(button_click.Text == ",")
                        {
                            int o2 = 0, m = 0;
                            for(int k = primer_chet_list.Count - 1;k > 0;k--)
                            {
                                if(primer_chet_list[k] == "," && value_symber > 0) o2++;
                                if(primer_chet_list[k] == "-" && value_symber > 0) m++;
                            }
                            if((o2 > 1 && value_symber == 2) || (o2 > 2 && value_symber == 1) || !int.TryParse(primer_chet_list[primer_chet_list.Count - 2], out _))
                            {
                                primer_chet_list.RemoveAt(Convert.ToInt32(primer_chet_list.Count - 1));
                                label_.Text = label_.Text.Remove(label_.Text.Length - 1);
                            }
                            else if(o2 > 1 && value_symber == 1 && o2 != 2 && m != 1)
                            {
                                for(int k = 0;k < primer_chet_list.Count - 1;k++)
                                {
                                    if(primer_chet_list[k] == ",") break;
                                    if(!int.TryParse(primer_chet_list[k], out _))
                                    {
                                        primer_chet_list.RemoveAt(Convert.ToInt32(primer_chet_list.Count - 1));
                                        label_.Text = label_.Text.Remove(label_.Text.Length - 1);
                                        break;
                                    }
                                }
                            }
                        }

                        //Проверка, чтобы была только 1 "-" у двух частей чисел
                        else if(button_click.Text == "-" && value_symber != 0)
                        {
                            if(primer_chet_list[0] == "-" && primer_chet_list[1] == "-")
                            {
                                primer_chet_list.RemoveAt(Convert.ToInt32(primer_chet_list.Count - 1));
                                label_.Text = label_.Text.Remove(label_.Text.Length - 1);
                            }
                            else if(primer_chet_list[primer_chet_list.Count - 1] == "-" && primer_chet_list[primer_chet_list.Count - 2] == "-")
                            {
                                primer = "+";
                                primer_chet_list.RemoveAt(Convert.ToInt32(primer_chet_list.Count - 1));
                                primer_chet_list.RemoveAt(Convert.ToInt32(primer_chet_list.Count - 1));
                                label_.Text = label_.Text.Remove(label_.Text.Length - 2) + primer;
                                value_symber = 1;
                                primer_chet_list.Add(primer);
                                index_dop = primer;
                            }
                            else if(primer_chet_list[primer_chet_list.Count - 1] == "-" && !int.TryParse(primer_chet_list[primer_chet_list.Count - 2], out _) && primer_chet_list[primer_chet_list.Count - 2] != ",")
                            {
                                primer = "-";
                                primer_chet_list.RemoveAt(Convert.ToInt32(primer_chet_list.Count - 1));
                                primer_chet_list.RemoveAt(Convert.ToInt32(primer_chet_list.Count - 1));
                                label_.Text = label_.Text.Remove(label_.Text.Length - 2) + primer;
                                index_dop = "-";
                                primer_chet_list.Add(primer);
                            }
                            else if(primer_chet_list[primer_chet_list.Count - 1] == "-" && value_symber != 2)
                            {
                                if(value_symber == 1) 
                                {
                                    value_symber = 0;
                                    index_dop = "-";
                                }
                                primer_chet_list.RemoveAt(Convert.ToInt32(primer_chet_list.Count - 1));
                                label_.Text = label_.Text.Remove(label_.Text.Length - 1);

                                goto METKA_return;
                            }
                            else
                            {
                                byte o = 0;
                                for(int k = primer_chet_list.Count - 1;k >= 0;k--)
                                {
                                    if(primer_chet_list[k] == "-") o++;
                                    
                                }
                                if(primer_chet_list[0] != "-" && o != 1)
                                {
                                    o = 0;
                                }
                                if(o == 1 || o == 2) value_symber = 1;
                            }
                        }

                        else
                        {
                            try
                            {
                                string index_symbol = " ";
                                //Проверка некотрых знаков
                                if((button_click.Text == "√" || button_click.Text == "log" || button_click.Text == "!") && value_symber == 2 && primer_chet_list[0] != "-"
                                 && primer_chet_list[0] != "0") 
                                {
                                    single_action = true;
                                    if(button_click.Text == "√") index_symbol = "√";
                                    else if(button_click.Text == "log") index_symbol = "log";
                                    else if(button_click.Text == "!") index_symbol = "!";
                                }
                                else if(button_click.Text == "!" && value_symber == 2 && primer_chet_list[0] != "-")
                                {
                                    single_action = true;
                                    index_symbol = "!";
                                }
                                else if(button_click.Text == "√" || button_click.Text == "log" || button_click.Text == "!")
                                {
                                    label_error.Text = "ОШИБКА, пример числа: 4";
                                    single_action = false;
                                    primer_chet_list.RemoveAt(Convert.ToInt32(primer_chet_list.Count - 1));
                                }
                                else single_action = false;

                                //Проверка некотрых знаков
                                if((button_click.Text == "e" || button_click.Text == "π") && (primer_chet_list.Count == 1))
                                {
                                    single_action = true;
                                    if(button_click.Text == "e") index_symbol = "e";
                                    else if(button_click.Text == "π") index_symbol = "π";
                                }
                                else if(button_click.Text == "e" || button_click.Text == "π")
                                {
                                    label_error.Text = "ОШИБКА, поле должно быть пустым!";
                                    single_action = false;
                                    primer_chet_list.RemoveAt(Convert.ToInt32(primer_chet_list.Count - 1));
                                }

                                bool primer_bool = false;
                                //Счёт примера срабатывет при нажатии на =, если имеется 1 логический символ и 2 числа
                                if((button_click.Text == "=" && value_symber != 2) || (value_symber == 0 || single_action == true))
                                {
                                    string num1 = "", num2 = "";
                                    byte value_minus = 0;
                                    //Счёт примера
                                    if(single_action == false)
                                    {
                                        for(short j = 0;j < primer_chet_list.Count - 1; j++)
                                        {
                                            if(int.TryParse(primer_chet_list[j], out _) || primer_chet_list[j] == "," || primer_chet_list[j] == "-")
                                            {
                                                if(primer_chet_list[j] == "-" && j != 0)
                                                {
                                                    if(!int.TryParse(primer_chet_list[j - 1], out _) && !int.TryParse(primer_chet_list[j], out _)) index_symbol = primer_chet_list[j - 1];
                                                    else index_symbol = primer_chet_list[j];
                                                    if(primer_bool == false && value_minus == 0) primer_bool = true;
                                                    value_minus++;
                                                }

                                                if(primer_bool == false) num1 += primer_chet_list[j];
                                                else num2 += primer_chet_list[j];
                                            }
                                            else if(primer_chet_list[j] != "," && value_minus == 0)
                                            {
                                                index_symbol = primer_chet_list[j];
                                                if(primer_bool == false) primer_bool = true;
                                            }
                                        }
                                    }
                                    else if(index_symbol != "π" && index_symbol != "e")
                                    {
                                        for(short j = 0;j < primer_chet_list.Count - 1; j++)
                                        {
                                            num1 += primer_chet_list[j];
                                        }
                                        if(index_symbol == "!" && num1 != "-0" && Convert.ToDecimal(num1) <= 25) 
                                        {
                                            num1 = Convert.ToString(Math.Round(Convert.ToDecimal(num1)));
                                            label_error.Text = $"Число округленно до: {num1}";
                                        }
                                        else if(index_symbol == "!" && Convert.ToDecimal(num1) > 25) label_error.Text = "Слишком большое число!";
                                    }
                                    //Конечный счёт примера
                                    if(index_symbol == "*") primer = Convert.ToString(Convert.ToDecimal(num1) * Convert.ToDecimal(num2));
                                    else if(index_symbol == "/") primer = Convert.ToString(Convert.ToDecimal(num1) / Convert.ToDecimal(num2));
                                    else if(index_symbol == "^") primer = Convert.ToString(Math.Pow(Convert.ToDouble(num1),Convert.ToDouble(num2)));
                                    else if(index_symbol == "√") primer = Convert.ToString(Math.Sqrt(Convert.ToDouble(num1)));
                                    else if(index_symbol == "log") 
                                    {
                                        if(Convert.ToDouble(num1) % 10 == 0) primer = Convert.ToString(Math.Log10(Convert.ToDouble(num1)));
                                        else primer = Convert.ToString(Math.Log2(Convert.ToDouble(num1)));
                                    }
                                    else if(index_symbol == "π") primer = Convert.ToString(Math.PI);
                                    else if(index_symbol == "e") primer = Convert.ToString(Math.E);
                                    else if(index_symbol == "!" && Convert.ToDecimal(num1) <= 25) primer = Convert.ToString(Factorial(Convert.ToInt64(num1)));
                                    else if(index_symbol == "!" && Convert.ToDecimal(num1) > 25) primer = num1;
                                    else if(index_symbol == "+" || (num1[0] == '-' && num2[0] == '-')) primer = Convert.ToString(Convert.ToDecimal(num1) + Convert.ToDecimal(num2));
                                    else if(index_symbol == "-") primer = Convert.ToString(Convert.ToDecimal(num1) + Convert.ToDecimal(num2));
                                    if(index_symbol != "π" && index_symbol != "e" && index_symbol != "log" && index_symbol != "√") if(num1[0] == '-' && num2[0] == '-' && index_symbol == "*") primer = primer.Substring(0);
                                    //Удаление/Сброс данных, а так же конечный вывод ответа
                                    if(primer == "∞") label_error.Text = "Конечный ответ";
                                    label_.Text = primer;
                                    primer_chet_list.Clear();
                                    for(short k = 0;k < primer.Length;k++) {primer_chet_list.Add(Convert.ToString(primer[k]));}

                                    int o = 0;
                                    for(int k = primer.Length - 1;k > 0;k--)
                                    {
                                        if(primer[k] == ',') o++;
                                    }
                                    if(o > 0)
                                    {
                                        for(int k = primer.Length - 1;k > 0 && (primer_chet_list[k] == "0" || primer_chet_list[k] == ",");k--)
                                        {
                                            primer_chet_list.RemoveAt(k);
                                            if(primer[k] == ',') break;
                                        }
                                    }
                                    primer = "";
                                    for(short k = 0;k < primer_chet_list.Count;k++) {primer += Convert.ToString(primer_chet_list[k]);}
                                    label_.Text = primer;
                                    
                                    if(value_symber == 0)
                                    {
                                        value_symber = 1;
                                        primer = index_dop;
                                        label_.Text += primer;
                                        primer_chet_list.Add(primer);
                                    }
                                    else value_symber = 2;
                                    index_dop = "";
                                    comma_dop = false;
                                    primer = "";

                                    for(int k = primer_chet_list.Count - 1;k > 0;k--)
                                    {
                                        if(primer_chet_list[k] == "E")
                                        {
                                            label_error.Text = "Конечный ответ";
                                            if(!int.TryParse(primer_chet_list[primer_chet_list.Count - 1], out _)) label_.Text = label_.Text.Remove(primer_chet_list.Count - 1);
                                            primer_chet_list.Clear();
                                            enumeration_primer = true;
                                            break;
                                        }
                                    }
                                }
                                else if(button_click.Text == "=" && value_symber == 2) primer_chet_list.RemoveAt(Convert.ToInt32(primer_chet_list.Count - 1));
                            }
                            //Срабатывает если есть только 1 число и 1 логический символ
                            catch (FormatException)
                            {
                                primer = "";
                                for(short k = 0;k < primer_chet_list.Count && (int.TryParse(primer_chet_list[k], out _) || primer_chet_list[k] == "," || primer_chet_list[k] == "-");k++) 
                                {
                                    if((k == 0 && primer_chet_list[0] == "-") || primer_chet_list[k] != "-") primer += Convert.ToString(primer_chet_list[k]);
                                }
                                primer_chet_list.Clear();
                                label_.Text = primer;
                                for(short k = 0;k < primer.Length;k++) {primer_chet_list.Add(Convert.ToString(primer[k]));}
                                    
                                index_dop = "";
                                comma_dop = false;
                                value_symber = 2;
                            }
                            //Срабатывает если слишком большое число
                            catch (OverflowException)
                            {
                                label_error.Text = "Слишком большое число!";
                            }
                            //Срабатывает если делить на 0
                            catch (DivideByZeroException)
                            {
                                label_error.Text = "На 0 делить нельзя!";
                                primer_chet_list.Clear();
                                label_.Text = "";
                                primer = "";
                                value_symber = 2;
                            }
                        }
                    }
                }
            };
            
            //Позиция кнопок
            X += 80;
            if(X == 325)
            {
                X = 5;
                Y += 60;
            }
            this.Controls.Add(button_click);
        }
    }

    #endregion

    //Факториал
    public static long Factorial(long i)
    {
        long n = 1;
        for(short j = 1;j < i; j++)
        {
            n += n * j;
        }
        return n;
    }