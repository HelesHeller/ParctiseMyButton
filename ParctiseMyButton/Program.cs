using System;

class MyButton
{
    private string color;
    private int width;
    private int height;
    private string buttonText;

    public MyButton(string color, int width, int height, string buttonText)
    {
        this.color = color;
        this.width = width;
        this.height = height;
        this.buttonText = buttonText;
    }

    public delegate void ClickEventHandler(object sender, EventArgs e);
    public event ClickEventHandler OnClickButton;

    public void Click()
    {
        Console.WriteLine($"Кнопка була натиснута. Час: {DateTime.Now}");
        OnClickButton?.Invoke(this, EventArgs.Empty);
    }
}

class Program
{
    static void Main(string[] args)
    {
        MyButton button = new MyButton("Червона", 100, 50, "Натисни мене");

        // Підписка на подію
        button.OnClickButton += (sender, e) => Console.WriteLine("Подія оброблена першим підписником");
        button.OnClickButton += (sender, e) => Console.WriteLine("Подія оброблена другим підписником");

        // Натискання кнопки
        button.Click();
    }
}
