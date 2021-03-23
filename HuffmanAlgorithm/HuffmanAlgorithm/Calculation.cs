using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanAlgorithm
{
    public class Calculation
    {   //Класс вычислителя энтропии и коэффициента избыточности
        public Calculation(string str)
        // Конструктор вычислителя для строки
        {
            byte[] Code = Encoding.Unicode.GetBytes(str);
            bits = new BitArray(Code);
        }
        public Calculation(byte [] cod)
        // Конструктор вычислителя для массива байт
        {
            byte[] Code = cod;
            bits = new BitArray(cod);
        }
        public double H, r, Compres;    
        // Энтропия, коэффициент избыточности, коэффициент сжатия
        public BitArray bits; // Двоичный код 
        public void Calc(BitArray bitsComp)
        // Метод вычислений
        {            
            int counter = 0;    // Счетчик единиц в двоичном коде
            foreach (bool bit in bits)
                if (bit) counter++;
            double p = (double)counter / (double)(bits.Count);
            H = Math.Round(-p * Math.Log(p, 2) - (1 - p) * Math.Log((1 - p), 2),8);
            r = Math.Round(1 - H, 8);
            Compres = Math.Round((double)(bits.Length) / (double)(bitsComp.Length),8);
        }
    }
}
