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
                    settings.ColorOfFirstfunc  = reader.ReadString();
                    settings.ColorOfSecondfunc = reader.ReadString();
                    settings.ColorOfThirdfunc  = reader.ReadString();

                    settings.LineWidthFirstfunc  = reader.ReadInt32();
                    settings.LineWidthSecondfunc = reader.ReadInt32();
                    settings.LineWidthThirdfunc  = reader.ReadInt32();

                    settings.ChartTypeFirstfunc  = reader.ReadString();
                    settings.ChartTypeSecondfunc = reader.ReadString();
                    settings.ChartTypeThirdfunc  = reader.ReadString();

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

                settings.ColorOfFirstfunc = "blue";
                settings.ColorOfSecondfunc = "red";
                settings.ColorOfThirdfunc = "green";

                settings.LineWidthFirstfunc = 3;
                settings.LineWidthSecondfunc = 3;
                settings.LineWidthThirdfunc = 3;

                settings.ChartTypeFirstfunc = "Spline";
                settings.ChartTypeSecondfunc = "Spline";
                settings.ChartTypeThirdfunc = "Spline";

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
                writer.Write(ColorOfFirstfunc);
                writer.Write(ColorOfSecondfunc);
                writer.Write(ColorOfThirdfunc);

                writer.Write(LineWidthFirstfunc);
                writer.Write(LineWidthSecondfunc);
                writer.Write(LineWidthThirdfunc);

                writer.Write(ChartTypeFirstfunc);
                writer.Write(ChartTypeSecondfunc);
                writer.Write(ChartTypeThirdfunc);

                writer.Write(a);
                writer.Write(b);
                writer.Write(h);
                writer.Write(a1);
                writer.Write(b1);
                writer.Write(eps);

                writer.Close();
            }
        }

        public string ColorOfFirstfunc { get; set; } //цвет синус графика
        public string ColorOfSecondfunc { get; set; } //цвет косинуса графика
        public string ColorOfThirdfunc { get; set; } //цвет тангенса графика

        public int LineWidthFirstfunc { get; set; } //толщина синус графика
        public int LineWidthSecondfunc { get; set; } //толщина косинуса графика
        public int LineWidthThirdfunc { get; set; } //толщина тангенса графика

        public string ChartTypeFirstfunc { get; set; } //тип синус графика
        public string ChartTypeSecondfunc { get; set; } //тип косинуса графика
        public string ChartTypeThirdfunc { get; set; } //тип тангенса графика

        public double a { get; set; } //начальная точка для графика
        public double b { get; set; } //конечная точка для графика
        public double h { get; set; } //шаг для графика

        public double a1 { get; set; } //начальная точка для вычислений
        public double b1 { get; set; } //конечная точка для вычислений
        public double eps { get; set; } //точность метода

    }
}
