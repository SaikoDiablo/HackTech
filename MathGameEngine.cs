using System;

namespace MathGame
{
    public class MathGameEngine
    {
        private Random random;
        public int Number1 { get; private set; }
        public int Number2 { get; private set; }
        public char Operator { get; private set; }

        public MathGameEngine()
        {
            random = new Random();
            GenerateNewQuestion();
        }

        public void GenerateNewQuestion()
        {
            Number1 = random.Next(1, 51);
            Number2 = random.Next(1, 51);
            Operator = random.Next(0, 2) == 0 ? '+' : '-';
        }

        public int GetAnswer()
        {
            return Operator == '+' ? Number1 + Number2 : Number1 - Number2;
        }

        public bool CheckAnswer(int userAnswer)
        {
            return userAnswer == GetAnswer();
        }
    }
}
