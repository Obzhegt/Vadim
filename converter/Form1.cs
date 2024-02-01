namespace converter;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }
    public static ComboBox comboBox_begin = new ComboBox()
    {
        Location = new Point(10,30),
        AutoSize = true,
        DropDownStyle = ComboBoxStyle.DropDownList
    };
    public static ComboBox comboBox_1 = new ComboBox()
    {
        Location = new Point(10,120),
        AutoSize = true,
        DropDownStyle = ComboBoxStyle.DropDownList
    };
    public static ComboBox comboBox_2 = new ComboBox()
    {
        Location = new Point(250,120),
        AutoSize = true,
        DropDownStyle = ComboBoxStyle.DropDownList
    };
    public static TextBox textBox = new TextBox()
    {
        Location = new Point(140,120),
        AutoSize = true,
    };
    public static Button button_result = new Button()
    {
        Location = new Point(120,150),
        AutoSize = true,
        Font = new Font(FontFamily.GenericMonospace,11),
        Text = "Конвертировать"
    };
    public static Label Text_result = new Label()
    {
        Text = "",
        Font = new Font(FontFamily.GenericMonospace,14),
        AutoSize = true,
        Location = new Point(10, 200),
    };
    public static string provercka = "";

    public static void Begin_script()
    {
        comboBox_1.Visible = true;
        comboBox_2.Visible = true;
        if(button_result.Visible == false)
        {
            button_result.Click += (a,e) =>
            {
                try
                {
                    if(provercka == "Время")
                    {
                        if(comboBox_1.Text == "Секунда" && comboBox_2.Text == "Минута" && textBox.Text.Length != 0) Text_result.Text = Convert.ToString(Convert.ToDouble(textBox.Text) / 60);
                        else if(comboBox_1.Text == "Секунда" && comboBox_2.Text == "Час" && textBox.Text.Length != 0) Text_result.Text = Convert.ToString(Convert.ToDouble(textBox.Text) / (60 * 60));
                        else if(comboBox_1.Text == "Секунда" && comboBox_2.Text == "Сутки" && textBox.Text.Length != 0) Text_result.Text = Convert.ToString(Convert.ToDouble(textBox.Text) / (60 * 60 * 24));
                        else if(comboBox_1.Text == "Секунда" && comboBox_2.Text == "Неделя" && textBox.Text.Length != 0) Text_result.Text = Convert.ToString(Convert.ToDouble(textBox.Text) / (60 * 60 * 24 * 7));

                        else if(comboBox_1.Text == "Минута" && comboBox_2.Text == "Секунда" && textBox.Text.Length != 0) Text_result.Text = Convert.ToString(Convert.ToDouble(textBox.Text) * 60);
                        else if(comboBox_1.Text == "Минута" && comboBox_2.Text == "Час" && textBox.Text.Length != 0) Text_result.Text = Convert.ToString(Convert.ToDouble(textBox.Text) / 60);
                        else if(comboBox_1.Text == "Минута" && comboBox_2.Text == "Сутки" && textBox.Text.Length != 0) Text_result.Text = Convert.ToString(Convert.ToDouble(textBox.Text) / (60 * 24));
                        else if(comboBox_1.Text == "Минута" && comboBox_2.Text == "Неделя" && textBox.Text.Length != 0) Text_result.Text = Convert.ToString(Convert.ToDouble(textBox.Text) / (60 * 24 * 7));

                        else if(comboBox_1.Text == "Час" && comboBox_2.Text == "Секунда" && textBox.Text.Length != 0) Text_result.Text = Convert.ToString(Convert.ToDouble(textBox.Text) * 60 * 60);
                        else if(comboBox_1.Text == "Час" && comboBox_2.Text == "Минута" && textBox.Text.Length != 0) Text_result.Text = Convert.ToString(Convert.ToDouble(textBox.Text) * 60);
                        else if(comboBox_1.Text == "Час" && comboBox_2.Text == "Сутки" && textBox.Text.Length != 0) Text_result.Text = Convert.ToString(Convert.ToDouble(textBox.Text) / 24);
                        else if(comboBox_1.Text == "Час" && comboBox_2.Text == "Неделя" && textBox.Text.Length != 0) Text_result.Text = Convert.ToString(Convert.ToDouble(textBox.Text) / (24 * 7));

                        else if(comboBox_1.Text == "Сутки" && comboBox_2.Text == "Секунда" && textBox.Text.Length != 0) Text_result.Text = Convert.ToString(Convert.ToDouble(textBox.Text) * 24 * 60 * 60);
                        else if(comboBox_1.Text == "Сутки" && comboBox_2.Text == "Минута" && textBox.Text.Length != 0) Text_result.Text = Convert.ToString(Convert.ToDouble(textBox.Text) * 24 * 60);
                        else if(comboBox_1.Text == "Сутки" && comboBox_2.Text == "Час" && textBox.Text.Length != 0) Text_result.Text = Convert.ToString(Convert.ToDouble(textBox.Text) * 24);
                        else if(comboBox_1.Text == "Сутки" && comboBox_2.Text == "Неделя" && textBox.Text.Length != 0) Text_result.Text = Convert.ToString(Convert.ToDouble(textBox.Text) / 7);

                        else if(comboBox_1.Text == "Неделя" && comboBox_2.Text == "Секунда" && textBox.Text.Length != 0) Text_result.Text = Convert.ToString(Convert.ToDouble(textBox.Text) * 7 * 24 * 60 * 60);
                        else if(comboBox_1.Text == "Неделя" && comboBox_2.Text == "Минута" && textBox.Text.Length != 0) Text_result.Text = Convert.ToString(Convert.ToDouble(textBox.Text) * 7 * 24 * 60);
                        else if(comboBox_1.Text == "Неделя" && comboBox_2.Text == "Час" && textBox.Text.Length != 0) Text_result.Text = Convert.ToString(Convert.ToDouble(textBox.Text) * 7 * 24);
                        else if(comboBox_1.Text == "Неделя" && comboBox_2.Text == "Сутки" && textBox.Text.Length != 0) Text_result.Text = Convert.ToString(Convert.ToDouble(textBox.Text) * 7);
                    
                        else if(textBox.Text.Length == 0) MessageBox.Show("Поле ввода не должно быть пустым!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else MessageBox.Show("Поля выбора не должны быть пустыми или одинаковыми!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if(provercka == "Температура")
                    {
                        if(comboBox_1.Text == "C" && comboBox_2.Text == "F" && textBox.Text.Length != 0) Text_result.Text = Convert.ToString(Convert.ToDouble(textBox.Text) * 1.8 + 32);
                        else if(comboBox_1.Text == "F" && comboBox_2.Text == "C" && textBox.Text.Length != 0) Text_result.Text = Convert.ToString((Convert.ToDouble(textBox.Text) - 32) * 5 / 9);

                        else if(textBox.Text.Length == 0) MessageBox.Show("Поле ввода не должно быть пустым!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else MessageBox.Show("Поля выбора не должны быть пустыми или одинаковыми!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if(provercka == "Длина")
                    {
                        if(comboBox_1.Text == "Миллиметр" && comboBox_2.Text == "Сантиметр" && textBox.Text.Length != 0) Text_result.Text = Convert.ToString(Convert.ToDouble(textBox.Text) / 10);
                        else if(comboBox_1.Text == "Миллиметр" && comboBox_2.Text == "Метр" && textBox.Text.Length != 0) Text_result.Text = Convert.ToString(Convert.ToDouble(textBox.Text) / (10 * 100));
                        else if(comboBox_1.Text == "Миллиметр" && comboBox_2.Text == "Километр" && textBox.Text.Length != 0) Text_result.Text = Convert.ToString(Convert.ToDouble(textBox.Text) / (10 * 100 * 10));
                        else if(comboBox_1.Text == "Миллиметр" && comboBox_2.Text == "Миля" && textBox.Text.Length != 0) Text_result.Text = Convert.ToString(Convert.ToDouble(textBox.Text) / (100 * 100 * 100 * 1.6093));

                        else if(comboBox_1.Text == "Сантиметр" && comboBox_2.Text == "Миллиметр" && textBox.Text.Length != 0) Text_result.Text = Convert.ToString(Convert.ToDouble(textBox.Text) * 10);
                        else if(comboBox_1.Text == "Сантиметр" && comboBox_2.Text == "Метр" && textBox.Text.Length != 0) Text_result.Text = Convert.ToString(Convert.ToDouble(textBox.Text) / 100);
                        else if(comboBox_1.Text == "Сантиметр" && comboBox_2.Text == "Километр" && textBox.Text.Length != 0) Text_result.Text = Convert.ToString(Convert.ToDouble(textBox.Text) / (100 * 10));
                        else if(comboBox_1.Text == "Сантиметр" && comboBox_2.Text == "Миля" && textBox.Text.Length != 0) Text_result.Text = Convert.ToString(Convert.ToDouble(textBox.Text) / (100 * 10 * 1.6093));

                        else if(comboBox_1.Text == "Метр" && comboBox_2.Text == "Миллиметр" && textBox.Text.Length != 0) Text_result.Text = Convert.ToString(Convert.ToDouble(textBox.Text) * 100 * 10);
                        else if(comboBox_1.Text == "Метр" && comboBox_2.Text == "Сантиметр" && textBox.Text.Length != 0) Text_result.Text = Convert.ToString(Convert.ToDouble(textBox.Text) * 100);
                        else if(comboBox_1.Text == "Метр" && comboBox_2.Text == "Километр" && textBox.Text.Length != 0) Text_result.Text = Convert.ToString(Convert.ToDouble(textBox.Text) / 1000);
                        else if(comboBox_1.Text == "Метр" && comboBox_2.Text == "Миля" && textBox.Text.Length != 0) Text_result.Text = Convert.ToString(Convert.ToDouble(textBox.Text) / (1000 * 1.6093));

                        else if(comboBox_1.Text == "Километр" && comboBox_2.Text == "Миллиметр" && textBox.Text.Length != 0) Text_result.Text = Convert.ToString(Convert.ToDouble(textBox.Text) * 1000 * 100 * 10);
                        else if(comboBox_1.Text == "Километр" && comboBox_2.Text == "Сантиметр" && textBox.Text.Length != 0) Text_result.Text = Convert.ToString(Convert.ToDouble(textBox.Text) * 1000 * 100);
                        else if(comboBox_1.Text == "Километр" && comboBox_2.Text == "Метр" && textBox.Text.Length != 0) Text_result.Text = Convert.ToString(Convert.ToDouble(textBox.Text) * 1000);
                        else if(comboBox_1.Text == "Километр" && comboBox_2.Text == "Миля" && textBox.Text.Length != 0) Text_result.Text = Convert.ToString(Convert.ToDouble(textBox.Text) / 1.6093);

                        else if(comboBox_1.Text == "Миля" && comboBox_2.Text == "Миллиметр" && textBox.Text.Length != 0) Text_result.Text = Convert.ToString(Convert.ToDouble(textBox.Text) * 1.6093 * 100 * 100 * 100);
                        else if(comboBox_1.Text == "Миля" && comboBox_2.Text == "Сантиметр" && textBox.Text.Length != 0) Text_result.Text = Convert.ToString(Convert.ToDouble(textBox.Text) * 1.6093 * 1000 * 100);
                        else if(comboBox_1.Text == "Миля" && comboBox_2.Text == "Метр" && textBox.Text.Length != 0) Text_result.Text = Convert.ToString(Convert.ToDouble(textBox.Text) * 1.6093 * 1000);
                        else if(comboBox_1.Text == "Миля" && comboBox_2.Text == "Километр" && textBox.Text.Length != 0) Text_result.Text = Convert.ToString(Convert.ToDouble(textBox.Text) * 1.6093);

                        else if(textBox.Text.Length == 0) MessageBox.Show("Поле ввода не должно быть пустым!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else MessageBox.Show("Поля выбора не должны быть пустыми или одинаковыми!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Поле ввода должно быть корректным!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
        }
        button_result.Visible = true;
        provercka = comboBox_begin.Text;
        comboBox_1.Items.Clear();
        comboBox_2.Items.Clear();
        Text_result.Text = "";
        textBox.Text = "";
        if(provercka == "Время")
        {
            comboBox_1.Items.AddRange(new string[] {"Секунда", "Минута", "Час", "Сутки", "Неделя"});
            comboBox_2.Items.AddRange(new string[] {"Секунда", "Минута", "Час", "Сутки", "Неделя"});
        }
        else if(provercka == "Температура")
        {
            comboBox_1.Items.AddRange(new string[] {"C", "F"});
            comboBox_2.Items.AddRange(new string[] {"C", "F"});
        }
        else if(provercka == "Длина")
        {
            comboBox_1.Items.AddRange(new string[] {"Миллиметр", "Сантиметр", "Метр", "Километр", "Миля"});
            comboBox_2.Items.AddRange(new string[] {"Миллиметр", "Сантиметр", "Метр", "Километр", "Миля"});
        }
    }
}
