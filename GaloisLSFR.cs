using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMZI
{
    public class GaloisLFSR

    {

        private bool[] register; // Масив, който съхранява състоянието на регистъра
        private bool[] outputBits; // Масив, който съхранява изходните битове на регистъра
        private bool[] stateChangeBits; // Масив, който съхранява битовете за промяна на състоянието на регистъра
        

        public GaloisLFSR(string polynomial)
        {
            // Изчисляваме дължината на регистъра въз основа на дължината на полинома
            int registerLength = polynomial.Length;

            // Инициализираме масивите за регистър, изходни битове и битове за промяна на състоянието
            register = new bool[registerLength];
            outputBits = new bool[registerLength];
            stateChangeBits = new bool[registerLength];

           

            // Инициализираме всички елементи на масивите на false
            for (int i = 0; i < registerLength; i++)
            {
                register[i] = false;
                outputBits[i] = false;
                stateChangeBits[i] = false;
            }

            // Задаваме началното състояние на регистъра (всички битове на 1 или всички на 0 в зависимост от полинома)
            // За Галоа LFSR, първият бит винаги е зададен на 1
            register[0] = true;

            // Инициализираме коефициентите на полинома
            Console.WriteLine("Polynomial coefficients:");
            int[] polynomialCoefficients = new int[polynomial.Length];
            for (int i = 0; i < polynomial.Length; i++)
            {
                polynomialCoefficients[i] = int.Parse(polynomial[i].ToString());
                Console.Write(polynomialCoefficients[i] + " ");
            }
            Console.WriteLine();

           
            // Обхождаме регистър масива
            for (int i = 0; i < registerLength; i++)
            {
                // Запазваме изходния бит (последният бит на регистъра)
                outputBits[i] = register[registerLength - 1];

                // Запазваме бита за промяна на състоянието (резултатът от обратната връзка на полинома)
                stateChangeBits[i] = register[0] ^ (register[registerLength - 1] && polynomialCoefficients[i] == 1);

                // Преместваме регистъра една позиция надясно
                bool lastBit = register[0];
                for (int j = 0; j < registerLength - 1; j++)
                {
                    register[j] = register[j + 1];
                }
                register[registerLength - 1] = lastBit;

                // Прилагаме обратната връзка на полинома, за да обновим регистъра
                if (stateChangeBits[i])
                {
                    for (int j = 0; j < registerLength; j++)
                    {
                        register[j] = register[j] ^ (polynomialCoefficients[j] == 1);
                    }
                }
            }
        }
        public void PrintResults()
        {
            // Извеждане на заглавие за изходните битове
            Console.WriteLine("Output Bits:");

            // Итериране през всеки бит в масива outputBits
            for (int i = 0; i < outputBits.Length; i++)
            {
                // Извеждане на "1", ако битът е истина, иначе извеждане на "0"
                Console.Write(outputBits[i] ? "1" : "0");
            }

            // Преминаване на нов ред след като всички битове са изведени
            Console.WriteLine();

            // Извеждане на заглавие за битовете за промяна на състоянието
            Console.WriteLine("State Change Bits:");

            // Итериране през всеки бит в масива stateChangeBits
            for (int i = 0; i < stateChangeBits.Length; i++)
            {
                // Извеждане на "1", ако битът е истина, иначе извеждане на "0"
                Console.Write(stateChangeBits[i] ? "1" : "0");
            }

            // Преминаване на нов ред след като всички битове са изведени
            Console.WriteLine();
        }

        // Метод за проверка на максималния период
        public bool HasMaximalPeriod()
        {
            // Обхождаме всички битове на регистъра
            foreach (bool bit in register)
            {
                // Ако срещнем бит различен от 0, периодът не е максимален
                if (bit)
                {
                    return false;
                }
            }

            // Ако всички битове са 0, регистърът има максимален период
            return true;
        }
    }
}
        

      
       
