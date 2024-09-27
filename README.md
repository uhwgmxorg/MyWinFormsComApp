# MyWinFormsComApp

is a small, simple Windows Forms C# .NET 8.0 application. In principle, it functions like <a href="https://uhwgmxorg.wordpress.com/2014/02/03/mywpfcomapp-kommunikation-uber-serielle-schnittstellen/" target="_blank">MyWPFComApp</a>, but adapted to .NET 8 and WinForms. Enabling the debug buttons 1 to 6 allows you to control the red and green LEDs (turning them on/off).

Furthermore, in this version, the software is designed so that the green LED turns on when the string "switch 01 pressed" is received via the COM interface, and turns off again when the string "switch 01 released" is received.

![img](https://github.com/uhwgmxorg/MyWinFormsComApp/blob/master/Doc/100_1.png)

If you want to test the whole setup on Windows alone (without a second PC or another device connected via a serial interface), you can use the null-modem driver <a href="https://com0com.sourceforge.net/" target="_blank">com0cmom</a>. You can then start MyWinFormsComApp twice or use an alternative like <a href="https://www.der-hammer.info/pages/terminal.html" target="_blank">hterm</a> as the counterpart.
