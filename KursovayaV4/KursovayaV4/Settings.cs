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
        //Метод загрузки настроек
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
                    settings.eps = reader.ReadDouble();

                    reader.Close();
                }
            }

            else //Параметры "По умолчанию"
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
                settings.eps = 0.001;
            }
                

            return settings;
        }

        //Метод сохранения настроек
        public void Save()
        {
            string filename = Globals.SettingsFile;

            if(File.Exists(filename)) File.Delete(filename); //Удаление прошлых сохранений

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
                writer.Write(eps);

                writer.Close();
            }
        }

        public string ColorOfSin { get; set; } //цвет синус графика
        public string ColorOfCos { get; set; } //цвет косинуса графика
        public string ColorOfTan { get; set; } //цвет тангенса графика

        public int LineWidthSin { get; set; } //толщина синус графика
        public int LineWidthCos { get; set; } //толщина косинуса графика
        public int LineWidthTan { get; set; } //толщина тангенса графика

        public string ChartTypeSin { get; set; } //тип синус графика
        public string ChartTypeCos { get; set; } //тип косинуса графика
        public string ChartTypeTan { get; set; } //тип тангенса графика

        public double a { get; set; } //начальная точка для графика
        public double b { get; set; } //конечная точка для графика
        public double h { get; set; } //шаг для графика

        public double a1 { get; set; } //начальная точка для вычислений
        public double b1 { get; set; } //конечная точка для вычислений
        public double eps { get; set; } //точность метода

    }
}
