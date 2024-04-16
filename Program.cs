namespace KMZI
{
    public class Program
    {
        // Главна програма за изпълнение на кода
        public static void Main(string[] args)
        {
            // Полиномът за новата инстанция на GaloisLFSR
            string newPolynomial = "101011011";

            // Създаване на инстанция на GaloisLFSR с новия полином
            GaloisLFSR newLfsr = new GaloisLFSR(newPolynomial);

            // Принтиране на началното състояние на LFSR с новия полином
            newLfsr.PrintResults();
        }
    }

}


