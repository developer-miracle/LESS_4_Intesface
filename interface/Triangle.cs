﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace @interface
{
    [Serializable]
    class Triangle : Shape, IShape
    {
        public Triangle() : base()
        {
        }
        public Triangle(ConsoleColor color, int Xpos, int Ypos, int height, int width) : base(color, Xpos, Ypos, height, width)
        {
        }
        public double Area()
        {
            return (config.Height * config.Width) / 2;
        }

        public void Dell()
        {
            Console.SetCursorPosition(lastPosX, lastPosY);
            Console.ForegroundColor = ConsoleColor.Black;
            for (int i = 0; i < config.Height; i++)
            {
                for (int j = 0; j < config.Width; j++)
                {
                    Console.SetCursorPosition(lastPosX + j, lastPosY + i);
                    Console.Write("@");
                }
            }
            Console.ResetColor();
        }
        public void Move(Direction direction)
        {
            lastPosX = position.Xpos;
            lastPosY = position.Ypos;
            switch (direction)
            {
                case Direction.Up:
                    if (position.Ypos == 0)
                        break;
                    position.Ypos--;
                    break;
                case Direction.Down:
                    if (position.Ypos == Console.WindowHeight - config.Height - 1)
                        break;
                    position.Ypos++;
                    break;
                case Direction.left:
                    if (position.Xpos == 0)
                        break;
                    position.Xpos--;
                    break;
                case Direction.Right:
                    if (position.Xpos == Console.WindowWidth - config.Width - 1)
                        break;
                    position.Xpos++;
                    break;
                default:
                    break;
            }
        }
        public double Perimeter()
        {
            double answer = config.Height * config.Height + config.Width * config.Width;
            answer = Math.Sqrt(answer);
            return answer = answer + config.Height + config.Width;
        }
        public void Print()
        {
            Console.SetCursorPosition(position.Xpos, position.Ypos);
            for (int i = 0; i < config.Height; i++)
            {
                for (int j = 0; j < config.Width; j++)
                {
                    Console.SetCursorPosition(position.Xpos + j, position.Ypos + i);
                    if (i + 1 > j)
                    {
                        Console.ForegroundColor = Color;
                        Console.Write("@");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("@");
                    }
                }
            }
            Console.ResetColor();
        }
        public Shape Read(string filePath = "data.dat")
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Triangle deserilizePeople;
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                deserilizePeople = (Triangle)formatter.Deserialize(fs);
            }
            return deserilizePeople;
        }
        public void SaveData(string filePath = "data.dat")
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, this);
                Console.WriteLine("Объект сериализован");
            }
        }
        public int GetAngles()
        {
            return 3;
        }
        public int CompareTo(Shape other)
        {
            Triangle temp = ((Triangle)other);
            if (!(temp is null))
            {
                if (this.Area() < temp.Area())
                    return 1;
                else if (this.Area() > temp.Area())
                    return -1;
                return 0;
                throw new NotImplementedException();
            }
            else
                throw new Exception("Что - то пошло не так.");
        }
    }
}
