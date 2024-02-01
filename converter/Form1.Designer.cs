namespace converter;

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
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Text = "Конвентёр";
        this.BackColor = Color.White;
        this.DoubleBuffered = true;
        this.ClientSize = new System.Drawing.Size(380, 250);
        this.Icon = new Icon("icon.ico");
        this.MaximizeBox = false;
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedSingle;

        Label Text_begin = new Label()
        {
            Text = "Выбирите что будете конвертировать:",
            ForeColor = Color.Black,
            Font = new Font(FontFamily.GenericMonospace,11),
            AutoSize = true,
            Location = new Point(0, 0),
        };
        this.Controls.Add(Text_begin);

        comboBox_begin.Items.AddRange(new string[] { "Время", "Длина", "Температура"});
        this.Controls.Add(comboBox_begin);

        this.Controls.Add(comboBox_1);
        comboBox_1.Visible = false;

        this.Controls.Add(comboBox_2);
        comboBox_2.Visible = false;

        this.Controls.Add(textBox);
        textBox.Visible = false;

        this.Controls.Add(button_result);
        button_result.Visible = false;

        this.Controls.Add(Text_result);

        Button b_result_begin = new Button()
        {
            Text = "Далее",
            ForeColor = Color.Black,
            Font = new Font(FontFamily.GenericMonospace,11),
            AutoSize = true,
            Location = new Point(150, 29),
        };
        b_result_begin.Click += (a,e) =>
        {
            if(comboBox_begin.Text.Length != 0 && comboBox_begin.Text != provercka)
            {
                Begin_script();
                Text_begin.Text = "Выбирите ед. измерения, затем\nвпишите данные, а потом\nвыбирите ед. в которую вы\nхотите конвертировать";
                b_result_begin.Location = new Point(150, 88);
                comboBox_begin.Location = new Point(10, 90);
                textBox.Visible = true;
            }
            else if(comboBox_begin.Text.Length == 0)
            {
                MessageBox.Show("Вы должны указать вариант конвертирования!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        };
        this.Controls.Add(b_result_begin);
    }

    #endregion
}
