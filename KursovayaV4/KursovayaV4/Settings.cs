using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursovayaV4
{
    public class Settings
    {
        public static Settings Load()
        {
            Settings settings= new Settings();
            string filename = Globals.SettingsFile;

            if (File.Exists(filename))
            {
                using(BinaryReader reader = new BinaryReader(File.Open(filename, FileMode.Open)))
                {
                    settings.ColorOfSin = reader.ReadString();
                    settings.ColorOfCos = reader.ReadString();
                    settings.ColorOfTan = reader.ReadString();

                    settings.LineWidthSin = reader.ReadInt32();
                    settings.LineWidthCos = reader.ReadInt32();
                    settings.LineWidthTan = reader.ReadInt32();

                    settings.ChartTypeSin = reader.ReadString();
                    settings.ChartTypeCos = reader.ReadString();
                    settings.ChartTypeTan = reader.ReadString();

                    settings.a = reader.ReadDouble();
                    settings.b = reader.ReadDouble();
                    settings.h = reader.ReadDouble();
                    settings.a1= reader.ReadDouble();
                    settings.b1= reader.ReadDouble();

                    reader.Close();
                }
            }

            else
            {
                settings = new Settings();

                settings.ColorOfSin = "blue";
                settings.ColorOfCos = "red";
                settings.ColorOfTan = "green";

                settings.LineWidthSin = 3;
                settings.LineWidthCos = 3;
                settings.LineWidthTan = 3;

                settings.ChartTypeSin = "Spline";
                settings.ChartTypeCos = "Spline";
                settings.ChartTypeTan = "Spline";

                settings.a = -10;
                settings.b = 10;
                settings.h = 0.1;
                settings.a1 = -10;
                settings.b1 = 10;
            }
                

            return settings;
        }

        public void Save()
        {
            string filename = Globals.SettingsFile;

            if(File.Exists(filename)) File.Delete(filename);

            using (BinaryWriter writer = new BinaryWriter(File.Open(filename, FileMode.Create)))
            {
                writer.Write(ColorOfSin);
                writer.Write(ColorOfCos);
                writer.Write(ColorOfTan);

                writer.Write(LineWidthSin);
                writer.Write(LineWidthCos);
                writer.Write(LineWidthTan);

                writer.Write(ChartTypeSin);
                writer.Write(ChartTypeCos);
                writer.Write(ChartTypeTan);

                writer.Write(a);
                writer.Write(b);
                writer.Write(h);
                writer.Write(a1);
                writer.Write(b1);

                writer.Close();
            }
        }

        public string ColorOfSin { get; set; }
        public string ColorOfCos { get; set; }
        public string ColorOfTan { get; set; }

        public int LineWidthSin { get; set; }
        public int LineWidthCos { get; set; }
        public int LineWidthTan { get; set; }

        public string ChartTypeSin { get; set; }
        public string ChartTypeCos { get; set; }
        public string ChartTypeTan { get; set; }

        public double a { get; set; }
        public double b { get; set; }
        public double h { get; set; }

        public double a1 { get; set; }
        public double b1 { get; set; }
        
    }
}
