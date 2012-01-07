# wgnuplot for C Sharp

*Last Update: 2009/01/19*

## What is it?

This assembly is to control gnuplot on Windows.

## Usage

1. Download "gp***win32.zip" from http://gnuplot.info/
2. Build wgnuplot4cs (Wgnuplot.sln)
3. On your project, refer Wgnuplot.dll

Sample:

    const string deployPath = @"C:\Tools\gnuplot\binary\";
    using (Wgnuplot plot = new Wgnuplot(deployPath + "pgnuplot.exe"))
    {
        plot.Send("splot x**2 + y**2");
    }

## License

MIT License
Copyright (C) 2009 KrdLab All Rights Reserved.
