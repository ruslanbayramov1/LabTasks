namespace _07_Class_Inheritance
{

    class Grade
    {
        public byte Point;
        public string Subject;
        public byte CreditCount;

        public Grade(byte point, string subject, byte creditCount)
        {
            Point = point;
            Subject = subject;
            CreditCount = creditCount;
        }
    }
}