namespace POS_Terminal
{
    public class Drink : Product
    {
        public string Size
        { get; set; }

        public decimal MakeSizeMedium(string Size)
        {
            Price *= (decimal).10;
            return Price;
        }

        public decimal MakeSizeLarge(string Size)
        {
            Price *= (decimal).20;
            return Price;
        }
    }
}