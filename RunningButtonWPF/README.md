# Running button
###The project demonstrates the usage of Event Handler

Some code is below:
```C#
private void button_MouseEnter(object sender, MouseEventArgs e)
{
    button.MouseEnter += button_rndMove;
}
        
private void button_rndMove(object sender, MouseEventArgs e)
{
    Random rnd = new Random();

    var width = rnd.Next(0, (int)Grid.Width - (int)button.Width);

    var height = rnd.Next(0, (int)Grid.Height - (int)button.Height);

    button.Margin = new Thickness(width, height, 0, 0);
}
```

The result is below: <br\>
![Running Button](https://github.com/harutyunyanhayk/PublicProjects/blob/master/RunningButtonWPF/buttonGif.gif)



> This project written by C#6.0 for .NET Framework 4.6.2 version on Visual Studio 2015 Comunity Edition
