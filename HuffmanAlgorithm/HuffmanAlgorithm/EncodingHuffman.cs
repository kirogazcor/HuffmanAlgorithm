using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanAlgorithm
{
    public class EncodingHuffman
    {
        // Класс кодировщика по алгоритву Хаффмана
        private class Node
        // Класс узла дерева Хаффмана
        {
            public char Symbol { get; set; }        // Симфол узла
            public ushort Frequency { get; set; }   // Частота повторения символа
            public Node Right { get; set; }         // Правая ветвь
            public Node Left { get; set; }          // Левая ветвь
            public List<bool> Traverse(char symbol, List<bool> data)
            // Метод обхода дерева в заданному символу
            {
                if (Right == null && Left == null)
                {
                    if (symbol.Equals(this.Symbol))
                    // Поднялись к символу
                    {
                        return data;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    List<bool> left = null;
                    List<bool> right = null;
                    if (Left != null)
                    // Обход левой ветви
                    {
                        List<bool> leftPath = new List<bool>();
                        leftPath.AddRange(data);
                        leftPath.Add(false);
                        left = Left.Traverse(symbol, leftPath);
                    }
                    if (Right != null)
                    // Обход правой ветви
                    {
                        List<bool> rightPath = new List<bool>();
                        rightPath.AddRange(data);
                        rightPath.Add(true);
                        right = Right.Traverse(symbol, rightPath);
                    }
                    if (left != null)
                    {
                        return left;
                    }
                    else
                    {
                        return right;
                    }
                }
            }
        }
        private Node Root;          // Корень дерева Хаффмана
        private byte[] CodeBytes;    // Код Хаффмана для декодирования
        private Dictionary<char, ushort> Frequencies;
        // Таблица частот символов в виде словаря
        private int RemoveBits = 0;
        // Количество бит отсекаемых при декодировании
        public EncodingHuffman(string source)
        // Конструктор кодировщика для кодирования строки
        {
            Frequencies = new Dictionary<char, ushort>();
            // Составление таблицы частот символов
            for (int i = 0; i < source.Length; i++)
            {
                if (!Frequencies.ContainsKey(source[i]))
                {
                    Frequencies.Add(source[i], 0);
                }
                Frequencies[source[i]]++;
            }
        }
        public EncodingHuffman(byte[] bytes)
        // Конструктор кодировщика для декодирования массива байтов
        {
            Frequencies = new Dictionary<char, ushort>();
            char[] FreqChars = new char [bytes.Length / 2];
            Buffer.BlockCopy(bytes, 0, FreqChars, 0, FreqChars.Length*2);
            // Преобразование массива байтов в массив символов
            string FreqStr = new string(FreqChars);
            // Далее в строку символов
            List<int> indexArr = new List<int>();
            // Поиск разделительного символа
            for (char separator = 'ȸ'; separator <= 'ȿ';separator++)
            {
                int index = FreqStr.IndexOf(separator);
                if (index != -1) indexArr.Add(index);
            }
            // Если разделительный символ не найден - ошибка
            if (indexArr.Count == 0) throw new Exception("Файл поврежден");
            else
            {   // Если найден, 
                RemoveBits = FreqStr[indexArr.Min()] - 'ȸ';
                // Определение количества бит отсекаемых при декодировании
                FreqStr = FreqStr.Substring(0, indexArr.Min());
                // Выделение из строки символов элементов таблицы частот
                for (int i = 0; i < FreqStr.Length; i += 2)
                    Frequencies.Add(FreqChars[i], (ushort)FreqChars[i + 1]);
                // Составление таблицы частот символов
                CodeBytes = new byte[bytes.Length - FreqStr.Length * 2 - 2];
                // Выделение кода Хаффмана для декодирования
                Buffer.BlockCopy(bytes, FreqStr.Length * 2 + 2, CodeBytes, 0, CodeBytes.Length);
            }
        }
        private void BuildTree()
        // Метод построения дерева Хаффмана
        {
            List<Node> nodes = new List<Node>();            
            foreach (KeyValuePair<char, ushort> symbol in Frequencies)
            {
                nodes.Add(new Node()
                {
                    Symbol = symbol.Key,
                    Frequency = symbol.Value
                });
            }
            while (nodes.Count > 1)
            // Пока дерево не построено
            {
                List<Node> orderedNodes = nodes.OrderBy(node =>
                node.Frequency).ToList<Node>();
                // Сортировка узiesлов по возрастанию частоты
                if (orderedNodes.Count >= 2)
                {
                    // Замена двух узлов с наименьшими частотами 
                    // На родительский узел с частотой равной сумме частот дочерних
                    List<Node> taken =
                    orderedNodes.Take(2).ToList<Node>();
                    Node parent = new Node()
                    {
                        Symbol = '¿',
                        Frequency = (ushort)(taken[0].Frequency + taken[1].Frequency),
                        Left = taken[0],
                        Right = taken[1]
                    };
                    nodes.Remove(taken[0]);
                    nodes.Remove(taken[1]);
                    nodes.Add(parent);
                }
            }
            Root = nodes.FirstOrDefault(); // Получение корня дерева хаффмана

        }
        
        public byte [] Encode(string source)
        // Метод кодирования строки кодом Хаффмана
        {
            BuildTree();
            Dictionary<char, List<bool>> Alphabet = new Dictionary<char, List<bool>>();
            // Алфавит кода Хаффмана
            List<bool> encodeddata = new List<bool>();
            // Код Хаффмана в виде списка логических величин
            int LenCharTab = Frequencies.Count * 2;
            // Количество символов для хранения таблицы частот
            int TabLen = LenCharTab * 2 + 2;
            // Количество байт для хранения таблицы частот и разделительного символа
            char[] FreqChar = new char[(int)(LenCharTab + 1)];
            // Массив символов для хранения таблицы частот и разделительного символа
            int i = 0;
            foreach (KeyValuePair<char, ushort> symbol in Frequencies)
            {
                // Формирование алфавита
                Alphabet.Add(symbol.Key, this.Root.Traverse(symbol.Key, new List<bool>()));
                // Таблица частот в файл
                FreqChar[i] = symbol.Key;
                FreqChar[i+1] = (char)symbol.Value;
                i+=2;
            }
            FreqChar[LenCharTab] = 'ȸ'; // Разделительный символ
            for (i = 0; i < source.Length; i++)
            {
                // Кодирование строки по алфавиту
                List<bool> encodedSymbol = new List<bool>();
                if(Alphabet.TryGetValue(source[i],out encodedSymbol))
                    encodeddata.AddRange(encodedSymbol);
            }
            int AddBits = 8 - encodeddata.Count % 8;
            // Добавление битов кода до целого количества байт
            // и изменение разделительного символа
            if (AddBits != 8)
            {
                for (i = 0; i < AddBits; i++)
                {
                    FreqChar[LenCharTab]++;
                    encodeddata.Add(false);
                }
            }
            BitArray bits = new BitArray(encodeddata.ToArray());
            // Битовая таблица кода Хаффмана
            int CountBytes = (int)(bits.Count / 8) + TabLen;
            // Количество байт в кодированном сообщении
            byte[] EncodeByte = new byte[CountBytes];
            // Кодированное сообщение
            Buffer.BlockCopy(FreqChar, 0, EncodeByte, 0, TabLen);
            // Добавление в сообщение таблицы частот
            bits.CopyTo(EncodeByte, TabLen);
            // Добавление в сообщение кода Хаффмана
            return EncodeByte;
        }
        public string Decode()
        // Метод декодирования кода Хаффмана
        {
            BitArray bits = new BitArray(CodeBytes);
            bits.Length = bits.Count - RemoveBits;
            // Перевод байтов в биты и отсечение лишних бит
            BuildTree();
            Node current = Root;
            string decoded = "";
            foreach (bool bit in bits)
            {
                // Перемещение по дереву Хаффмана
                if (bit)
                {   // Вправо при "1"
                    if (current.Right != null)
                    {
                        current = current.Right;
                    }
                }
                else
                {   // Влево при "0"
                    if (current.Left != null)
                    {
                        current = current.Left;
                    }
                }
                if ((current.Left == null && current.Right == null))
                {
                    // При достижении листа дерева
                    decoded += current.Symbol;
                    // Получить символ
                    current = Root;
                    // Вернуться в корень
                }
            }
            return decoded;
        }
    }
}
